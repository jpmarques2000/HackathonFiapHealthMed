using AutoMapper;
using Hackathon.HealthMed.Domain.Entities;
using Hackathon.HealthMed.Domain.Interfaces.Repositories;
using Hackathon.HealthMed.Services.Contract.Patient;
using Hackathon.HealthMed.Services.Input;
using Hackathon.HealthMed.Services.Interfaces.Services;
using Hackathon.HealthMed.Services.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Services.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;
        private readonly IBaseNotification _baseNotification;

        public PatientService(IPatientRepository patientRepository, IMapper mapper,
            IBaseNotification baseNotification)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
            _baseNotification = baseNotification;
        }

        public async Task<IList<PatientResult>> ListAsync()
        {
            var result = await _patientRepository.ListAsync();

            return _mapper.Map<IList<PatientResult>>(result);
        }

        public async Task<PatientResult> FindByIdAsync(int id)
        {
            var result = await _patientRepository.FindByIdAsync(id);

            return _mapper.Map<PatientResult>(result);
        }

        public async Task<PatientResult> AddAsync(PatientInsertInput input)
        {
            var contract = new AddPatientContract(input);

            if (!contract.IsValid)
            {
                _baseNotification.AddNotifications(contract.Notifications);
                return default;
            }

            var map = _mapper.Map<Patient>(input);

            var result = new PatientResult();

            var inserted = await _patientRepository.AddAsync(map);

            if (inserted > 0)
            {
                result = _mapper.Map<PatientResult>(map);
            }

            return result;
        }

        public async Task<PatientResult> UpdateAsync(PatientUpdateInput input)
        {
            var contract = new UpdatePatientContract(input);

            if (!contract.IsValid)
            {
                _baseNotification.AddNotifications(contract.Notifications);
                return default;
            }

            var map = _mapper.Map<Patient>(input);

            var founded = await _patientRepository.GetByIdAsync(map.Id);

            var contractPatient = new FindPatientContract(founded);

            if (!contractPatient.IsValid)
            {
                _baseNotification.AddNotifications(contractPatient.Notifications);
                return default;
            }

            founded.Name = input.Name;
            founded.CPF = input.CPF;
            founded.LastModifiedDate = DateTime.Now;
            founded.Enabled = true;

            var result = new PatientResult();

            var updated = await _patientRepository.UpdateAsync(founded);

            if (updated > 0)
            {
                result = _mapper.Map<PatientResult>(founded);
            }

            return result;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var input = new DeleteInput { Id = id };
            var contract = new DeletePatientContract(input);

            if (!contract.IsValid)
            {
                _baseNotification.AddNotifications(contract.Notifications);
                return default;
            }

            var founded = await _patientRepository.GetByIdAsync(id);

            var contractPatient = new FindPatientContract(founded);

            if (!contractPatient.IsValid)
            {
                _baseNotification.AddNotifications(contractPatient.Notifications);
                return default;
            }

            founded.LastModifiedDate = DateTime.Now;
            founded.Enabled = false;

            return await _patientRepository.UpdateAsync(founded) > 0;
        }
    }
}
