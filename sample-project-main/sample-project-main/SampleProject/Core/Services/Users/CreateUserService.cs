﻿using System;
using System.Collections.Generic;
using BusinessEntities;
using Common;
using Core.Factories;
using Data.Repositories;

namespace Core.Services.Users
{
    [AutoRegister]
    public class CreateUserService : ICreateUserService
    {
        private readonly IUpdateUserService _updateUserService;
        private readonly IIdObjectFactory<User> _userFactory;
        private readonly IUserRepository _userRepository;

        public CreateUserService(IIdObjectFactory<User> userFactory, IUserRepository userRepository, IUpdateUserService updateUserService)
        {
            _userFactory = userFactory;
            _userRepository = userRepository;
            _updateUserService = updateUserService;
        }

        public User Create(Guid id, string name, string email, UserTypes type, decimal? annualSalary, IEnumerable<string> tags)
        {
            var user = _userFactory.Create(id);
            _updateUserService.Update(user, name, email, type, annualSalary, tags);
            _userRepository.Save(user);
            return user;
        }
    }
}