using AutoMapper;
using Hackathon.HealthMed.Domain.Entities;
using Hackathon.HealthMed.Domain.Interfaces.Repositories;
using Hackathon.HealthMed.Services.Contract.Doctor;
using Hackathon.HealthMed.Services.Input;
using Hackathon.HealthMed.Services.Interfaces.Services;
using Hackathon.HealthMed.Services.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Services.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;
        private readonly IBaseNotification _baseNotification;

        public DoctorService(IDoctorRepository doctorRepository, IMapper mapper,
            IBaseNotification baseNotification)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
            _baseNotification = baseNotification;
        }

        public async Task<DoctorResult> AddAsync(DoctorInsertInput input)
        {
            var contract = new AddDoctorContract(input);

            if (!contract.IsValid)
            {
                _baseNotification.AddNotifications(contract.Notifications);
                return default;
            }

            var map = _mapper.Map<Doctor>(input);

            map.Email = "TODOIDAOJA";
            map.Password = "123456543423432423";

            var result = new DoctorResult();

            var inserted = await _doctorRepository.AddAsync(map);

            if (inserted > 0)
            {
                result = _mapper.Map<DoctorResult>(map);
            }

            return result;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var input = new DeleteInput { Id = id };
            var contract = new DeleteDoctorContract(input);

            if (!contract.IsValid)
            {
                _baseNotification.AddNotifications(contract.Notifications);
                return default;
            }

            var founded = await _doctorRepository.GetByIdAsync(id);

            var contractModel = new FindDoctorContract(founded);

            if (!contractModel.IsValid)
            {
                _baseNotification.AddNotifications(contractModel.Notifications);
                return default;
            }

            founded.LastModifiedDate = DateTime.Now;
            founded.Enabled = false;

            return await _doctorRepository.UpdateAsync(founded) > 0;
        }

        public async Task<DoctorResult> FindByIdAsync(int id)
        {
            var result = await _doctorRepository.FindByIdAsync(id);

            return _mapper.Map<DoctorResult>(result);
        }

        public async Task<IList<DoctorResult>> ListAsync()
        {
            var result = await _doctorRepository.ListAsync();

            return _mapper.Map<IList<DoctorResult>>(result);
        }

        public async Task<DoctorResult> UpdateAsync(DoctorUpdateInput input)
        {
            var contract = new UpdateDoctorContract(input);

            if (!contract.IsValid)
            {
                _baseNotification.AddNotifications(contract.Notifications);
                return default;
            }

            var map = _mapper.Map<Doctor>(input);

            var founded = await _doctorRepository.GetByIdAsync(map.Id);

            var contractModel = new FindDoctorContract(founded);

            if (!contractModel.IsValid)
            {
                _baseNotification.AddNotifications(contractModel.Notifications);
                return default;
            }

            founded.LastModifiedDate = DateTime.Now;
            founded.Name = map.Name;
            founded.CPF = map.CPF;
            founded.CRM = map.CRM;
            founded.Enabled = true;

            var result = new DoctorResult();

            var updated = await _doctorRepository.UpdateAsync(founded);

            if (updated > 0)
            {
                result = _mapper.Map<DoctorResult>(founded);
            }

            return result;
        }
    }
}
