using Microsoft.EntityFrameworkCore;
using System;

namespace RollCall.Persistence.Entities
{
	public class AppDbContext : DbContext
	{
		public DbSet<Area> Area { get; set; }
		public DbSet<AssistanceEntity> Assistance { get; set; }
		public DbSet<AssistanceLog> AssistanceLog { get; set; }
		public DbSet<Config> Config { get; set; }
		public DbSet<EmployeeEntity> Employee { get; set; }
		public DbSet<HolidayDay> HolidayDay { get; set; }
		public DbSet<RolEntity> Rol { get; set; }
		public DbSet<Schedule> Schedule { get; set; }
		public DbSet<SecurityQuestion> SecurityQuestions { get; set; }
		public DbSet<User> User { get; set; }

		public AppDbContext()
		{

		}

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS2016;Database=RollCall;User Id=sa;Password=root;");
				//optionsBuilder.UseSqlServer("Server=DESKTOP-9CVRRTC\\SQLEXPRESS;Database=ProyectoDeIntegracion;User Id=sa;Password=123456;");
				//optionsBuilder.UseSqlServer("workstation id=ProyectoDeIntegracion.mssql.somee.com;packet size=4096;user id=vmartinez84_SQLLogin_2;pwd=3ciwfqn2az;data source=ProyectoDeIntegracion.mssql.somee.com;persist security info=False;initial catalog=ProyectoDeIntegracion");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Config>().HasData(
				new Config { Id = 1, Name = "Users", Value ="2", DateRegistration = DateTime.Now},
				new Config { Id = 2, Name = "Employees", Value ="50", DateRegistration = DateTime.Now}
			);

			modelBuilder.Entity<Area>().HasData(
				new Area { Id = 1, Name = "Operación", IsActive = true }
			);

			modelBuilder.Entity<Schedule>().HasData(
				new Schedule
				{
					Id = 01,
					IsActive = true,
					RegistrationDate = DateTime.Now,
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

			modelBuilder.Entity<User>().HasData(
				new User
				{
					Id = 1,
					Name = "Admin",
					LastName = "Admin",
					DischargeDate = null,
					Email = "administrador@administrador.com",
					Password = "123456",
					IsActive = true,
					RegistrationDate = DateTime.Now,
					RolId = 1
				}
			);
		}
	}
}
