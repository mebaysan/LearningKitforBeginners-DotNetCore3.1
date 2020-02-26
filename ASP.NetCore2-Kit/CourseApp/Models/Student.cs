using System.ComponentModel.DataAnnotations;

namespace CourseApp.Models
{
    public class Student
    {
        [Required(ErrorMessage="İsminizi giriniz")] // validator
        public string Name { get; set; }
        [Required(ErrorMessage="Email giriniz")]
        [EmailAddress(ErrorMessage="Email adresinizi düzgün giriniz")]
        public string Email { get; set; }
        [Required(ErrorMessage="Telefon giriniz")]
        public string Phone { get; set; }
        [Required(ErrorMessage="Katılma durumunuzu giriniz")]
        public bool? Confirm { get; set; } // true false null
    }
}