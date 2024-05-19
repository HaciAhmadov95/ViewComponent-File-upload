using System.ComponentModel.DataAnnotations;

namespace Fiorella.Models
{
    public class Blog : BaseEntity
    {
        [Required(ErrorMessage = "This field can't be empty")]
        [StringLength(100, ErrorMessage = "Length must be max 20")]
        public string Title { get; set; }
        [Required(ErrorMessage = "This field can't be empty")]
        [StringLength(100, ErrorMessage = "Length must be max 20")]
        public string Description { get; set; }
        [Required(ErrorMessage = "This field can't be empty")]
        [StringLength(100, ErrorMessage = "Length must be max 20")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "This field can't be empty")]
        [StringLength(100, ErrorMessage = "Length must be max 20")]
        public string Image { get; set; }
    }
}
