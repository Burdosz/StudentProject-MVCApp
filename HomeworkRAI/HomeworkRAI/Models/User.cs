using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeworkRAI.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [RegularExpression("^[a-zA-Z].*",ErrorMessage = "Login musi zaczynać się od litery alfabetu")]
        [StringLength(255,MinimumLength = 3,ErrorMessage = "Login musi zawierać minimum 3 znaki")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [RegularExpression(@"(.*[!@#$%^&*()+=\[\]{};:-]+.*[0-9]+.*)|(.*[0-9]+.*[!@#$%^&*()+=\[\]{};:-]+.*)", ErrorMessage = "Haslo musi zawierać znak specjalny i cyfre")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [EmailAddress(ErrorMessage = "Bledny adres email")]
        public string Email { get; set; }
    }
}