﻿using AnimeRecommender.Application.Interfaces;
using AnimeRecommender.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeRecommender.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<User>> GetAllUsersAsync() => _repository.GetAllAsync();

        public Task<User?> GetUserByIdAsync(Guid id) => _repository.GetByIdAsync(id);

        public Task CreateUserAsync(User user) => _repository.AddAsync(user);

        public Task UpdateUserAsync(User user) => _repository.UpdateAsync(user);


        public Task DeleteUserAsync(Guid id) => _repository.DeleteAsync(id);
    }

}
