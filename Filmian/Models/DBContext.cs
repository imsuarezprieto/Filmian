using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;


namespace Filmian.Models
{

	public interface IDBContext
	{
		public DbSet<Pelicula>		Peliculas		{ get; set; }
		public DbSet<Director>		Directors		{ get; set; }
		public DbSet<Pais>			Pais			{ get; set; }
	}


	public class DBContext : DbContext, IDBContext
	{
		public DBContext() 
		{
		}

		protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
		{
			optionsBuilder
					.UseLazyLoadingProxies()
					.UseSqlServer( @"Server=localhost\SQLEXPRESS;Database=PROYECTO;Trusted_Connection=True;" );
		}

		protected override void OnModelCreating( ModelBuilder modelBuilder )
		{
			modelBuilder
				.Entity<Pais>()
					.HasIndex( entity => entity.Nombre );
			modelBuilder.Entity<Director>()
				.Property( entity => entity.FechaNacimiento)
				.HasDefaultValue( DateTime.Today);
		}

		public DbSet<Pelicula>	Peliculas	{ get; set; }
		public DbSet<Director>	Directors	{ get; set; }
		public DbSet<Pais>		Pais		{ get; set; }
	}

}
