using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Filmian.Models
{
	[Table("Directores")]
	public class Director
	{
		public Int16		DirectorID		{ get; set; }
		public String		Nombre			{ get; set; }

		public virtual		ICollection<Pelicula>	Peliculas		{ get; set; }
	}
}
