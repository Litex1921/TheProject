using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheProject.DB.Entities
{
    public class City : BaseEntity
    {

        [Required,StringLength(20)] 

        public string Name { get; set; }

        public virtual ICollection<Location> Locations { get; set; }
    }
    
    }


