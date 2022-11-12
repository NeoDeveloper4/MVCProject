using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCProject.Models
{
    public class UserModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }


        [Required(ErrorMessage = "required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "required")]
        public int EducationId { get; set; }

        [Required(ErrorMessage = "required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "required")]
        public string Password { get; set; }
    }
}