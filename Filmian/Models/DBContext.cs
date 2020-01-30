using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Filmian.Models
{

	public interface IDBContext
	{
		public DbSet<Pelicula>		Peliculas		{ get; set; }
		public DbSet<Director>		Directors		{ get; set; }
	}


	public class DBContext : DbContext, IDBContext
	{
		public DBContext() { }

		protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
		{
			optionsBuilder.UseSqlServer( @"Server=localhost\SQLEXPRESS02;Database=PROYECTO;Trusted_Connection=True;" );
		}

		public DbSet<Pelicula> Peliculas { get; set; }
		public DbSet<Director> Directors { get; set; }
	}

}
