using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeworkRAI.Models
{
    public class File
    {
        public int Id { get; set; }

        [DisplayName("Owner ID")]
        [Required(ErrorMessage = "Pole jest wymagane")]
        public int UserId { get; set; }

        [DisplayName("Access Privilages")]
        public List<int> AccesssPrivilages { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [RegularExpression("[0-9a-zA-Z.]*", ErrorMessage = "Nazwa moze zawierac tylko litery, cyfry oraz kropki")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Pole jest wymagane")]
        [RegularExpression(@"[A-Za-z0-9-]+[/][A-Za-z0-9-]+", ErrorMessage = "Mime musi byc podany w formie typ/podtyp")]
        public string MimeType { get; set; }
    }
}