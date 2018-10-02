using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAspCoreDapper.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Display(Name = "Last name :")]
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }

        [Display(Name = "First name :")]
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int PhoneNumber { get; set; }
    }
}
