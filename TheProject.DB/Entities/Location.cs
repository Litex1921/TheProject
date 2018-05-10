using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheProject.DB.Entities
{
    public class Location : BaseEntity
    {
       
        [Required, StringLength(8),DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }

        [Required, StringLength(20)]
        public string StreetName { get; set; }

        [Required, StringLength(20)]
        public string StreetNum { get; set; }

        [Required, StringLength(50)]
        public string Extra { get; set; }

        [Required]
        public int CityId { get; set;  }

        [Required,ForeignKey("CityId")]
      public virtual City City { get; set; }

        public virtual ICollection<CarsParts> CarsParts { get; set; }
    }
}
