using System.ComponentModel.DataAnnotations;

namespace WebAspCore2.Models
{
    public class User
    {
        [Display(Name = "Last name :")]
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        [Display(Name = "First name :")]
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
    }
}
