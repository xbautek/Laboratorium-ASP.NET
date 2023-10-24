using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Laboratorium_3___Homework.Models
{
    public class Photo
    {

        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Data musi zostać wybrana!")]
        [DataType(DataType.Date)]
        public DateTime DateAndTime { get; set; }

        [StringLength(70, ErrorMessage = "Opis jest za długi")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Musi być podana kamera!")]
        public string Camera { get; set; }

        [Required(ErrorMessage = "Musi być podany autor!")]
        [StringLength(80, ErrorMessage = "Nazwa autora jest za długa")]
        public string Author { get; set; }

        [StringLength(25)]
        public string? Resolution { get; set; }

        [Required(ErrorMessage = "Musi być podany format!")]
        [RegularExpression(@"^\d{1,3}x\d{1,3}$", ErrorMessage = "Taki format nie istnieje.")]
        public string Format { get; set; }
    }
}
