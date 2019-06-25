using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WisdomPrototype.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        [Display( Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Full Name")]
        public string FullName => $"{FirstName} {LastName}";
        [Display(Name = "Wisdom Count")]
        public int WisdomCount { get; set; }
    }
}