﻿using GymFeesManagement.Database;
using GymFeesManagement.DTOs.ReqDTO;
using GymFeesManagement.DTOs.ResDTO;
using GymFeesManagement.Entities;
using GymFeesManagement.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace GymFeesManagement.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        public UserRepository(AppDbContext appDbContext) 
        { 
        _appDbContext = appDbContext;
        }

        public async Task<ICollection<User>> GetUsers(UserRoles?role)
        {
            return await _appDbContext.Users.Where(u => u.Role == role).Include(u => u.Entrollments).ThenInclude(e => e.Program).ToListAsync();
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _appDbContext.Users.Include(u => u.Entrollments).ThenInclude(u => u.Program).SingleOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                throw new Exception();
            }

            return user;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _appDbContext.Users.SingleOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                throw new Exception();
            }

            return user;
        }

        public async Task<User> UpdateUser(User user)
        {
            var data =  _appDbContext.Users.Update(user);
            await _appDbContext.SaveChangesAsync();

            return data.Entity;
        }

        public async Task<User> Register(User user)
        {
            var data = await _appDbContext.Users.AddAsync(user);
            await _appDbContext.SaveChangesAsync();

            return data.Entity;
        }

        public async Task<Message> DeleteUser(int id)
        {
            var user = await _appDbContext.Users.FindAsync(id);
            if (user == null)
            {
                throw new ArgumentException();
            }

            _appDbContext.Users.Remove(user);
            await _appDbContext.SaveChangesAsync();

            var message = new Message
            {
                text = "User Successfully Deleted..."
            };

            return message;
        }

        public async Task<List<User>> GetRoles(UserRoles? role)
        {
            return await _appDbContext.Users.Where(u => u.Role == role).ToListAsync();
        }
    }
}
