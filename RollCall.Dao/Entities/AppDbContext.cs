using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollCall.Persistence.Entities
{
	public class AppDbContext : DbContext
	{
		public DbSet<Area> Area { get; set; }
		public DbSet<Assistance> Assistance { get; set; }
		public DbSet<Rol> Rol { get; set; }
		public DbSet<Schedule> Schedule { get; set; }
		public DbSet<User> User { get; set; }
		//public DbSet<User_Rol> User_Rol { get; set; }

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
			modelBuilder.Entity<Rol>().HasData(
				new Rol { Id = 1, Name = "Administrador", IsActive = true },
				new Rol { Id = 2, Name = "Supervisor", IsActive = true },
				new Rol { Id = 3, Name = "Empleado", IsActive = true }
			);

			modelBuilder.Entity<User>().HasData(
				new User
				{
					Id = 1,
					Name = "Administrador",
					LastName = string.Empty,
					RegistrationDate = DateTime.Now,
					Email = "administrador@administrador.com",
					Password = "123456",
					IsActive = true,
					AreaId = null,
					PhotoInBase64 = string.Empty,
					ScheduleId = null,
					RolId = 1
				}
			);

			//modelBuilder.Entity<User_Rol>().HasData(
			//	new User_Rol { Id = 1, IsActive = true, RolId = 1, RegistrationDate = DateTime.Now, UserId = 1 }
			//);
		}
	}
}
