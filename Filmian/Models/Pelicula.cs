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
		public Int16	Duracion		{ get; set; }

		
		[DisplayName( "Director" )]
		[Required( ErrorMessage = "El campo Director no es válido" )]
		public Int16				DirectorId { get; set; }

		[DisplayName( "Director" )]
		public virtual	Director	Director		{ get; set; }

		[NotMapped]
		public IDictionary<short,string> Directores { get; } = Director.Directores;

	}
}
