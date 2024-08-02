using AutoMapper;
using Hackathon.HealthMed.Domain.Entities;
using Hackathon.HealthMed.Domain.Interfaces.Repositories;
using Hackathon.HealthMed.Services.Contract.Doctor;
using Hackathon.HealthMed.Services.Contract.Schedule;
using Hackathon.HealthMed.Services.Input;
using Hackathon.HealthMed.Services.Interfaces.Services;
using Hackathon.HealthMed.Services.Result;
using Hackathon.HealthMed.Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Services.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IMapper _mapper;
        private readonly IBaseNotification _baseNotification;

        public ScheduleService(IScheduleRepository scheduleRepository, IMapper mapper, IBaseNotification baseNotification)
        {
            _scheduleRepository = scheduleRepository;
            _mapper = mapper;
            _baseNotification = baseNotification;
        }

        public async Task<ScheduleResult> AddAsync(ScheduleInsertInput input)
        {
            var contract = new AddScheduleContract(input);

            if (!contract.IsValid)
            {
                _baseNotification.AddNotifications(contract.Notifications);
                return default;
            }

            var scheduleTimeExists = 
                await _scheduleRepository.SearchScheduleByTimeAndMedicId(input.Time, input.DoctorId);

            var contractScheduleTime = new FindScheduleTimeExistsContract(scheduleTimeExists);

            if (!contractScheduleTime.IsValid)
            {
                _baseNotification.AddNotifications(contractScheduleTime.Notifications);
                return default;
            }

            var map = _mapper.Map<Schedule>(input);

            var result = new ScheduleResult();

            var inserted = await _scheduleRepository.AddAsync(map);

            if (inserted > 0)
            {
                result = _mapper.Map<ScheduleResult>(map);
            }

            return result;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var input = new DeleteInput { Id = id };
            var contract = new DeleteScheduleContract(input);

            if (!contract.IsValid)
            {
                _baseNotification.AddNotifications(contract.Notifications);
                return default;
            }

            var founded = await _scheduleRepository.GetByIdAsync(id);

            var contractModel = new FindScheduleContract(founded);

            if (!contractModel.IsValid)
            {
                _baseNotification.AddNotifications(contractModel.Notifications);
                return default;
            }

            founded.LastModifiedDate = DateTime.Now;
            founded.Enabled = false;

            return await _scheduleRepository.UpdateAsync(founded) > 0;
        }

        public async Task<IList<ScheduleResult>> FindByMedicIdAsync(int id)
        {
            var result = await _scheduleRepository.FindByMedicIdAsync(id);

            return _mapper.Map<IList<ScheduleResult>>(result);
        }

        public async Task<IList<ScheduleResult>> FindByPatientIdAsync(int id)
        {
            var result = await _scheduleRepository.FindByPatientIdAsync(id);

            return _mapper.Map<IList<ScheduleResult>>(result);
        }

        public async Task<ScheduleResult> ScheduleAppointment(ScheduleAppointmentInput input)
        {
            var contract = new ScheduleAppointmentContract(input);

            if (!contract.IsValid)
            {
                _baseNotification.AddNotifications(contract.Notifications);
                return default;
            }

            var map = _mapper.Map<Schedule>(input);

            var founded = await _scheduleRepository.FindByIdAsync(map.Id);

            var contractModel = new FindScheduleContract(founded);

            if (!contractModel.IsValid)
            {
                _baseNotification.AddNotifications(contractModel.Notifications);
                return default;
            }

            founded.LastModifiedDate = DateTime.Now;
            founded.isScheduled = true;
            founded.PatientId = map.PatientId;
            founded.Enabled = true;

            var result = new ScheduleResult();

            var updated = await _scheduleRepository.UpdateAsync(founded);

            if (updated > 0)
            {
                result = _mapper.Map<ScheduleResult>(founded);
            }

            return result;
        }

        public async Task<ScheduleResult> UpdateAsync(ScheduleUpdateInput input)
        {
            var contract = new UpdateScheduleContract(input);

            if (!contract.IsValid)
            {
                _baseNotification.AddNotifications(contract.Notifications);
                return default;
            }

            var map = _mapper.Map<Schedule>(input);

            var founded = await _scheduleRepository.GetByIdAsync(map.Id);

            var contractModel = new FindScheduleContract(founded);

            if (!contractModel.IsValid)
            {
                _baseNotification.AddNotifications(contractModel.Notifications);
                return default;
            }

            founded.LastModifiedDate = DateTime.Now;
            founded.Time = map.Time;
            founded.Enabled = true;

            var result = new ScheduleResult();

            var updated = await _scheduleRepository.UpdateAsync(founded);

            if (updated > 0)
            {
                result = _mapper.Map<ScheduleResult>(founded);
            }

            return result;
        }
    }
}
