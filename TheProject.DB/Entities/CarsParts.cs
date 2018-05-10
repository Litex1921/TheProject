using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheProject.DB.Entities
{
    public class CarsParts : BaseEntity
    {
        [Required,Index(IsUnique= true)]
        public string Name {get; set;}
        [Required]

        public string About{ get; set; }
        [Required]

        public int Price { get; set; }
        [Required]

        public string inStoke { get; set; }
        [Required,DataType(DataType.Currency)]

        public decimal Order { get; set; }
        [Required]

        public int LocationId { get; set;  }
        [Required,ForeignKey("LocationId")]
        public virtual Location Location { get; set; }

        
    }
}
