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
					.UseSqlServer( @"Server=localhost\SQLEXPRESS;Database=FILMIAN;Trusted_Connection=True;" );
		}

		protected override void OnModelCreating( ModelBuilder modelBuilder )
		{
			modelBuilder
				.Entity<Pais>()
					.HasIndex( entity => entity.Nombre );
			modelBuilder.Entity<Director>()
				.Property( entity => entity.FechaNacimiento)
				.HasDefaultValue( DateTime.Today);

			modelBuilder.Entity<Director>()
				.HasData(
					new Director {
						DirectorID		= 1,
						Nombre			= "Ingmar Bergman",
						FechaNacimiento = new DateTime( day: 14, month: 7, year: 1918 ),
						PaisId			= 67 // Suecia,
					},
					new Director {
						DirectorID		= 2,
						Nombre			= "Lars von Trier",
						FechaNacimiento = new DateTime( day: 30, month: 4, year: 1956 ),
						PaisId			= 22 // Dinamarca,
					},
					new Director {
						DirectorID		= 3,
						Nombre			= "Andréi Tarkovski",
						FechaNacimiento = new DateTime( day: 4, month: 4, year: 1932 ),
						PaisId			= 50 // Rusia,
					}
				);
			
			modelBuilder.Entity<Pelicula>()
				.HasData(
					new Pelicula {
						PeliculaId		= 1,
						Titulo			= "El séptimo sello",
						Duracion		= 96,
						Año				= 1957,
						Valoracion		= 8.2M,
						DirectorId		= 1 // Ingmar Bergman,
					},
					new Pelicula {
						PeliculaId		= 2,
						Titulo			= "Persona",
						Duracion		= 85,
						Año				= 1966,
						Valoracion		= 8.2M,
						DirectorId		= 1 // Ingmar Bergman,
					},
					new Pelicula {
						PeliculaId		= 3,
						Titulo			= "Gritos y susurros",
						Duracion		= 106,
						Año				= 1972,
						Valoracion		= 7.8M,
						DirectorId		= 1 // Ingmar Bergman,
					},
					new Pelicula {
						PeliculaId		= 4,
						Titulo			= "Melancolía",
						Duracion		= 136,
						Año				= 2011,
						Valoracion		= 6.8M,
						DirectorId		= 2 // Lars von Trier
					},
					new Pelicula {
						PeliculaId		= 5,
						Titulo			= "Dogville",
						Duracion		= 179,
						Año				= 2003,
						Valoracion		= 7.5M,
						DirectorId		= 2 // Lars von Trier
					},
					new Pelicula {
						PeliculaId		= 6,
						Titulo			= "Los idiotas",
						Duracion		= 117,
						Año				= 1998,
						Valoracion		= 6.6M,
						DirectorId		= 2 // Lars von Trier
					},
					new Pelicula {
						PeliculaId		= 7,
						Titulo			= "Stalker",
						Duracion		= 163,
						Año				= 1972,
						Valoracion		= 7.9M,
						DirectorId		= 3 // Andréi Tarkovski
					},
					new Pelicula {
						PeliculaId		= 8,
						Titulo			= "Solaris",
						Duracion		= 169,
						Año				= 1972,
						Valoracion		= 7.5M,
						DirectorId		= 3 // Andréi Tarkovski
					}
				);
		}

		public DbSet<Pelicula>	Peliculas	{ get; set; }
		public DbSet<Director>	Directors	{ get; set; }
		public DbSet<Pais>		Pais		{ get; set; }
	}

}
