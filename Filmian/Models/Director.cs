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
		[Required( ErrorMessage = "El campo Nombre no es válido" )]
		public String						Nombre			{ get; set; }

		[DisplayName( "País" )]
		public virtual	Pais				Pais			{ get; set; }

		[DisplayName( "País" )]
		[Required( ErrorMessage = "El campo Nacionalidad no es válido" )]
		public int							PaisId			{ get; set; }

		[NotMapped]
		public IDictionary<int,string>		Paises			{ get; } = Pais.Paises;

		[DisplayName( "Fecha de nacimiento" )]
		[DataType( DataType.Date )]
		[DisplayFormat( DataFormatString = "{0:d MMMM yyyy}")]
		[Required( ErrorMessage = "El campo Fecha de nacimiento no es válido" )]
		public			DateTime			FechaNacimiento { get; set; } = DateTime.Today;


		public virtual	ICollection<Pelicula>	Peliculas	{ get; set; }

		[NotMapped]
		public static IDictionary<short , string> Directores { get; } = new DBContext().Directors.ToDictionary( director => director.DirectorID , director => director.Nombre );
	}
}
