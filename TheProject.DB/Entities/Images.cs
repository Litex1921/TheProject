
namespace TheProject.DB.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Image : BaseEntity
    {
        [Required, StringLength(120)]
        public string ImageName { get; set; }

        [Required, StringLength(120)]
        public string ImagePath { get; set; }

        [Required]
        public virtual int CarsPartsName { get; set; }

        [Required, ForeignKey("CarsPartsName")]
        public virtual CarsParts CarsParts { get; set; }
    }
}