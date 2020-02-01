using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Filmian.Models
{
	[Table("Directores")]
	public class Director
	{
		[Key]
		public Int16						DirectorID		{ get; set; }

		[DisplayName( "Nombre" )]
		[Required( ErrorMessage = "El campo Nombre no puede estar vacío" )]
		public String						Nombre			{ get; set; }

		[DisplayName( "País" )]
		public virtual	Pais				Pais			{ get; set; }

		[DisplayName( "País" )]
		[Required( ErrorMessage = "El campo Nacionalidad no puede estar vacio" )]
		public int							PaisId			{ get; set; }


		[NotMapped]
		public IDictionary<int,string>		Paises			{ get; } = Pais.Paises;

		[DisplayName( "Fecha de nacimiento" )]
		[Required( ErrorMessage = "El campo Fecha de nacimiento no puede estar vacío" )]
		public			DateTime			FechaNacimiento { get; set; }


		public virtual	ICollection<Pelicula>	Peliculas	{ get; }
	}
}
