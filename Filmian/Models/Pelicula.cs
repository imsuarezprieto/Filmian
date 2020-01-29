using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Filmian.Models
{
	[Table("Peliculas")]
	public class Pelicula
	{
		//[Key]
		public Int16	PeliculaId		{ get; set; }
		[Required]
		public String	Titulo			{ get; set; }
		public Int16	Duracion		{ get; set; }

		// REFERENCES
		public Int16	DirectorId		{ get; set; }
		public Director	Director		{ get; set; }

	}
}
