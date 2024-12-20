﻿using GymFeesManagement.Database;
using GymFeesManagement.DTOs.ResDTO;
using GymFeesManagement.Entities;
using GymFeesManagement.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace GymFeesManagement.Repositories
{
    public class GymProgramRepository : IGymProgramRepository
    {
        private readonly AppDbContext _appDbContext;

        public GymProgramRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

       public async Task<GymProgram>NewProgram(GymProgram program)
        {
            
           
                var data = await _appDbContext.Programs.AddAsync(program);
                await _appDbContext.SaveChangesAsync();
               
                return data.Entity;
           
        }

        public async Task<GymProgram> GetProgram(int id)
        {
            var program = await _appDbContext.Programs.FindAsync(id);

            if (program == null)
            {
                throw new Exception();
            }

            return program;
        }

        public async Task<ICollection<GymProgram>> GetPrograms()
        {
            return await _appDbContext.Programs.ToListAsync();
        }

        //public async Task<GymProgram> PutProgram(GymProgram program)
        //{
        //     _appDbContext.Entry(program).State = EntityState.Modified;
        //    await _appDbContext.SaveChangesAsync();

        //    return program;
        //}


        public async Task<GymProgram> UpdateProgram(GymProgram Program)
        {
            var data = _appDbContext.Programs.Update(Program);
            await _appDbContext.SaveChangesAsync();
            return data.Entity;
        }

        public async Task<Message> DeleteProgram(int id)
        {
            var program = await _appDbContext.Programs.FindAsync(id);
            if (program == null)
            {
                throw new ArgumentException();
            }

            _appDbContext.Programs.Remove(program);
            await _appDbContext.SaveChangesAsync();

            var message = new Message
            {
                text = "Program Successfully Deleted..."
            };

            return message;
        }

       
    }
}
