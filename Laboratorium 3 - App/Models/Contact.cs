using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Laboratorium_3___App.Models
{
    public class Contact
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Imię nie może być puste!")]
        [StringLength(maximumLength: 50, ErrorMessage = "Imię zbyt długie, maksymalnie 50 znaków.")]
        public string Name { get; set; }

        [EmailAddress (ErrorMessage = "Musisz podać poprawny email(brak znaku @).")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Niepoprawny numer telefonu, nie może zawierać liter.")]
        public string Phone { get; set; }

        public DateTime? Birth { get; set;  }

    }
}
