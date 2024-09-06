using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StdAddCRUDWithValidation.Models
{
    public class Address
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Street is required.")]
        public string Street { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        public string Country { get; set; }
    }

}