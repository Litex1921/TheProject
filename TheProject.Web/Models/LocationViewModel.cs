using TheProject.DB.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheProject.Web.Models
{
    public class LocationsViewModel : BaseViewModel
    {
        [Required, DataType(DataType.PostalCode)]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "Пощенския код трябва да съдържа между 4 и 8 символа!")]
        [Display(Name = "Пощенски код")]
        public string ZipCode { get; set; }

        [Required]
        [Display(Name = "Улица")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Името на улицата трябва да съдържа между 3 и 20 символа!")]
        public string StreetName { get; set; }

        [Required]
        [Display(Name = "Номер")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Номера на улицата трябва да съдържа между 1 и 20 символа!")]
        public string StreetNum { get; set; }

        [Required]
        [Display(Name = "Доп. инфо")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Името трябва да съдържа между 3 и 50 символа!")]
        public string Extra { get; set; }

        [Required]
        public int CityId { get; set; }

        public string CityName { get; set; }

        public virtual ICollection<CarsParts> CarsParts { get; set; }
    }
}