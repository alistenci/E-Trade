using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade.DAL.Entities
{
	public class Marka
	{
		public int ID { get; set; }

		[Column(TypeName = "varchar(50)"), StringLength(50), Display(Name = "Marka Adı")]
		public string Ad { get; set; }

		public ICollection<Urun> Urunler { get; set; }
	}
}
