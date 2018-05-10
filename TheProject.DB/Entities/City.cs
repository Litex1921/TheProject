﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheProject.DB.Entities
{
    public class City : BaseEntity
    {
        [Required,StringLength(20)] 
        [Index(IsUnique =true)]

        public string Name { get; set; }

        public virtual ICollection<Location> Locations { get; set; }
    }
    
    }

