using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Web;

namespace StdAddCRUDWithValidation.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is required.")]
        [Range(5, 100, ErrorMessage = "Age must be between 5 and 100.")]
        public int Age { get; set; }

        public Address Address { get; set; }
    }

}