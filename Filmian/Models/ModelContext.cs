using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Filmian.Models
{
	public class ModelContext : DbContext
	{
		public ModelContext() { }

		protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
		{
			optionsBuilder.UseSqlServer( @"Server=localhost\SQLEXPRESS02;Database=Migrations;Trusted_Connection=True;" );
		}

		public DbSet<Models.Pelicula>		Peliculas		{ get; set; }
		public DbSet<Models.Director>		Directors		{ get; set; }
	}
}
