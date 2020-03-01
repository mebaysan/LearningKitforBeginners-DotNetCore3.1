using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Identity.Models
{
    public class RegisterAccountViewModel
    {
        [Required]
        public string Username { get; set; }


        [Required]
        public string Email { get; set; }


        [Required]
        public string Password { get; set; }

    }
}