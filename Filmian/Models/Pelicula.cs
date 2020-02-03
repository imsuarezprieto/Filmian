using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Filmian.Models
{
	[Table("Peliculas")]
	public class Pelicula
	{
		[Key]
		public Int16	PeliculaId		{ get; set; }

		[DisplayName( "Título" )]
		[Required( ErrorMessage = "El campo Título no es válido" )]
		public String	Titulo			{ get; set; }

		[DisplayName( "Duración" )]
		[Required( ErrorMessage = "El campo Duración no es válido" )]
		[DisplayFormat( DataFormatString = "{0:# min.}" )]
		[Range( 0, 1000, ErrorMessage = "La duración no está en rango")]
		public Int16	Duracion		{ get; set; }

		[DisplayName( "Año" )]
		[Required( ErrorMessage = "El campo Año es necesario" )]
		[Range( 1850, 2020, ErrorMessage = "El Año no está en rango" )]
		public Int16	Año				{ get; set; }

		[DisplayName( "Valoración" )]
		[Range( 0, 10 )]
		public decimal	Valoracion		{ get; set; }
		
		[DisplayName( "Director" )]
		[Required( ErrorMessage = "El campo Director no es válido" )]
		public Int16				DirectorId { get; set; }

		[DisplayName( "Director" )]
		public virtual	Director	Director		{ get; set; }

		[NotMapped]
		public static IDictionary<short , string> Directores { get; } = Director.Directores;

	}
}
