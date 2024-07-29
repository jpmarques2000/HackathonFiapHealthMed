﻿using Hackathon.HealthMed.Services.Input;
using Hackathon.HealthMed.Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.HealthMed.Services.Contract.User
{
    public class AddUserContract : BaseContract<UserRegisterInput>
    {
        public AddUserContract(UserRegisterInput input)
        {
            Validate(input);
        }
        protected override void Validate(UserRegisterInput input)
        {
            AddNotifications(new Flunt.Br.Contract()
                .Requires()
                .IsNotNull(input, "User", "Parameters is null")
                .IsNotNullOrWhiteSpace(input.Name, "Name", "The Name field cannot be empty")
                .IsGreaterThan(input.Name, 2, "Name", "The Name field must be greater than 2")
                .IsNotNullOrWhiteSpace(input.Email, "Email", "The Email field cannot be empty")
                .IsGreaterThan(input.Email, 10, "Email", "The Email field must be greater than 10")
                .IsNotNullOrWhiteSpace(input.Password, "Password", "The Password field cannot be empty")
                .IsGreaterThan(input.Password, 5, "Password", "The Password field must be greater than 5"));
        }
    }
}
