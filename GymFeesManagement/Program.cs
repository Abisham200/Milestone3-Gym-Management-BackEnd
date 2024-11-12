
using GymFeesManagement.Database;
using GymFeesManagement.IRepositories;
using GymFeesManagement.IServices;
using GymFeesManagement.Repositories;
using GymFeesManagement.Services;
using Microsoft.EntityFrameworkCore;

namespace GymFeesManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

            builder.Services.AddScoped<IGymProgramRepository, GymProgramRepository>();
            builder.Services.AddScoped< IGymProgramService, GymProgramService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
