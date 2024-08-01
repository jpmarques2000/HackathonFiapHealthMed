﻿using Hackathon.HealthMed.Domain.Entities;
using Hackathon.HealthMed.Services.Input;
using Hackathon.HealthMed.Services.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Services.Profile
{
    public class ProfileMapping : AutoMapper.Profile
    {
        public ProfileMapping() 
        {
            CreateMap<Patient, PatientResult>().ReverseMap();
            CreateMap<PatientInsertInput, Patient>().ReverseMap();
            CreateMap<PatientUpdateInput, Patient>().ReverseMap();

            CreateMap<Doctor, DoctorResult>().ReverseMap();
            CreateMap<DoctorInsertInput, Doctor>().ReverseMap();
            CreateMap<DoctorUpdateInput, Doctor>().ReverseMap();

            CreateMap<Schedule, ScheduleResult>().ReverseMap();
            CreateMap<ScheduleInsertInput, Schedule>().ReverseMap();
            CreateMap<ScheduleUpdateInput, Schedule>().ReverseMap();

            CreateMap<User, UserResult>().ReverseMap();
            CreateMap<UserRegisterInput, User>().ReverseMap();
        }
    }
}
