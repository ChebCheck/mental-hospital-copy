﻿using AutoMapper;
using MentalHospital.BLL.Interfaces;
using MentalHospital.BLL.Models;
using MentalHospital.DAL.Interfaces;
using MentalHospital.DAL.Entities;

namespace MentalHospital.BLL.Services
{
    public class PatientService : IService<PatientModel>
    {
        private readonly IRepository<Patient> _repository;
        private readonly IMapper _mapper;

        public PatientService(IRepository<Patient> repository, IMapper maper)
        {
            _repository = repository;
            _mapper = maper;
        }
        

        public async Task<PatientModel> Create(PatientModel model)
        {
            var entity = _repository.Create(_mapper.Map<Patient>(model));
            return _mapper.Map<PatientModel>(entity);
        }

        public async Task<PatientModel> Delete(string id)
        {
            var entity = await _repository.Delete(id);
            return _mapper.Map<PatientModel>(entity);
        }

        public async Task<PatientModel> Get(string id)
        {
            var entity = await _repository.Get(id);
            return _mapper.Map<PatientModel>(entity);
        }

        public async Task<IEnumerable<PatientModel>> GetAll()
        {
            var entities = await _repository.GetAll();
            return _mapper.Map<IEnumerable<PatientModel>>(entities);
        }

        public async Task<PatientModel> Update(PatientModel model)
        {
            var entity = await _repository.Update(_mapper.Map<Patient>(model));
            return _mapper.Map<PatientModel>(entity);
        }
    }
}
