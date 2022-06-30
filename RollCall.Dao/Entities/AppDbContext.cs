using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RollCall.Core.Entities;
using System;

namespace RollCall.Persistence.Entities
{
    public class AppDbContext : DbContext
    {
        private IConfiguration _configuration;

        public DbSet<AreaEntity> Area { get; set; }
        public DbSet<AssistanceEntity> Assistance { get; set; }
        public DbSet<AssistanceLogEntity> AssistanceLog { get; set; }
        public DbSet<Config> Config { get; set; }
        public DbSet<EmployeeEntity> Employee { get; set; }
        public DbSet<HolidayDay> HolidayDay { get; set; }
        public DbSet<RolEntity> Rol { get; set; }
        public DbSet<ScheduleEntity> Schedule { get; set; }
        public DbSet<SecurityQuestionEntity> SecurityQuestions { get; set; }
        public DbSet<UserEntity> User { get; set; }

        public AppDbContext()
        {

        }

        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
				string connectionString;

				//connectionString = _configuration.GetConnectionString("ConnectionStringSqlserver");
                connectionString = "Server=192.168.1.66; Database=RollCall; user id=sa; pwd=macross#7";
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Config>().HasData(
                new Config { Id = 1, Name = "Users", Value = "2", DateRegistration = DateTime.Now },
                new Config { Id = 2, Name = "Employees", Value = "50", DateRegistration = DateTime.Now }
            );

            modelBuilder.Entity<AreaEntity>().HasData(
                new AreaEntity { Id = 1, Name = "Operación", IsActive = true }
            );

            modelBuilder.Entity<ScheduleEntity>().HasData(
                new ScheduleEntity
                {
                    Id = 01,
                    IsActive = true,
                    DateRegistration = DateTime.Now,
                    StartTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 08, 00, 00),
                    StopTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 16, 00, 00)
                }
            );

            modelBuilder.Entity<HolidayDay>().HasData(
                new HolidayDay { Id = 1, Name = "Día de la revolución", Date = new DateTime(2021, 11, 15) },
                new HolidayDay { Id = 2, Name = "Navida", Date = new DateTime(2021, 12, 24) }
            );

            modelBuilder.Entity<AssistenceStatus>().HasData(
                new AssistenceStatus { Id = 1, Name = "Entrada" },
                new AssistenceStatus { Id = 2, Name = "Salida" },
                new AssistenceStatus { Id = 3, Name = "Salida al lonche" },
                new AssistenceStatus { Id = 4, Name = "Regreso del lonche" }
            );

            modelBuilder.Entity<RolEntity>().HasData(
                new RolEntity { Id = 1, Name = "Administrador", IsActive = true },
                new RolEntity { Id = 2, Name = "Supervisor", IsActive = true }
            );

            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    Id = 1,
                    Name = "Admin",
                    LastName = "Admin",
                    DischargeDate = null,
                    Email = "administrador@administrador.com",
                    Password = "123456",
                    IsActive = true,
                    DateRegistration = DateTime.Now,
                    RolId = 1
                }
            );
        }
    }
}
