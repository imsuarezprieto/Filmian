using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;


namespace Filmian.Models
{
	[Table( "Paises" )]
	public class Pais
	{
		[Key]
		public	int		PaisId		{ get; set; }

		[Required, DisplayName( "País" )]
		public string	Nombre		{ get; set; }

		[NotMapped]
		public static IDictionary<int , string> Paises { get; } = new DBContext().Pais.ToDictionary( pais => pais.PaisId , pais => pais.Nombre );

	}
}
