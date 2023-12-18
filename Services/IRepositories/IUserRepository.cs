﻿using InternetStore.Models;

namespace InternetStore.Services.IRepositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(decimal id);
        Task<bool> Insert(User user);
    }
}
