using TheProject.DB.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace TheProject.Web.Models
{
    public class CityViewModel : BaseViewModel
    {
        #region Properties
        [Required]
        [Display(Name = "Име")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Името трябва да съдържа между 3 и 20 символа!")]
        public string Name { get; set; }
        #endregion

        #region Constructors
        public CityViewModel(City e)
        {
            Id = e.Id;
            Name = e.Name;
            CreatedTime = e.CreatedTime;
            UpdatedTime = e.UpdatedTime;
        }
        #endregion
    }
}


