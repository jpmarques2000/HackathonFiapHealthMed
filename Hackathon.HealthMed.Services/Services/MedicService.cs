using AutoMapper;
using Hackathon.HealthMed.Domain.Entities;
using Hackathon.HealthMed.Domain.Interfaces.Repositories;
using Hackathon.HealthMed.Services.Contract.Medic;
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
    public class MedicService : IMedicService
    {
        private readonly IMedicRepository _medicRepository;
        private readonly IMapper _mapper;
        private readonly IBaseNotification _baseNotification;

        public MedicService(IMedicRepository medicRepository, IMapper mapper,
            IBaseNotification baseNotification)
        {
            _medicRepository = medicRepository;
            _mapper = mapper;
            _baseNotification = baseNotification;
        }

        public async Task<MedicResult> AddAsync(MedicInsertInput input)
        {
            var contract = new AddMedicContract(input);

            if (!contract.IsValid)
            {
                _baseNotification.AddNotifications(contract.Notifications);
                return default;
            }

            var map = _mapper.Map<Medic>(input);

            var result = new MedicResult();

            var inserted = await _medicRepository.AddAsync(map);

            if (inserted > 0)
            {
                result = _mapper.Map<MedicResult>(map);
            }

            return result;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var input = new DeleteInput { Id = id };
            var contract = new DeleteMedicContract(input);

            if (!contract.IsValid)
            {
                _baseNotification.AddNotifications(contract.Notifications);
                return default;
            }

            var founded = await _medicRepository.GetByIdAsync(id);

            var contractModel = new FindMedicContract(founded);

            if (!contractModel.IsValid)
            {
                _baseNotification.AddNotifications(contractModel.Notifications);
                return default;
            }

            founded.LastModifiedDate = DateTime.Now;
            founded.Enabled = false;

            return await _medicRepository.UpdateAsync(founded) > 0;
        }

        public async Task<MedicResult> FindByIdAsync(int id)
        {
            var result = await _medicRepository.FindByIdAsync(id);

            return _mapper.Map<MedicResult>(result);
        }

        public async Task<IList<MedicResult>> ListAsync()
        {
            var result = await _medicRepository.ListAsync();

            return _mapper.Map<IList<MedicResult>>(result);
        }

        public async Task<MedicResult> UpdateAsync(MedicUpdateInput input)
        {
            var contract = new UpdateMedicContract(input);

            if (!contract.IsValid)
            {
                _baseNotification.AddNotifications(contract.Notifications);
                return default;
            }

            var map = _mapper.Map<Medic>(input);

            var founded = await _medicRepository.GetByIdAsync(map.Id);

            var contractModel = new FindMedicContract(founded);

            if (!contractModel.IsValid)
            {
                _baseNotification.AddNotifications(contractModel.Notifications);
                return default;
            }

            founded.LastModifiedDate = DateTime.Now;
            founded.Name = map.Name;
            founded.CPF = map.CPF;
            founded.CRM = map.CRM;
            founded.Email = map.Email;
            founded.Enabled = true;

            var result = new MedicResult();

            var updated = await _medicRepository.UpdateAsync(founded);

            if (updated > 0)
            {
                result = _mapper.Map<MedicResult>(founded);
            }

            return result;
        }
    }
}
