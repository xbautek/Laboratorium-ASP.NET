using ProjectData.Entities;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Laboratorium_3___Homework.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Display(Name = "Komentarz")]
        public string Content { get; set; }

        public int PhotoId { get; set; }
        //public PhotoEntity? Photo { get; set; }
        [Display(Name = "Opis zdjęcia")]
        public string? PhotoDescription { get; set; }
        [Display(Name = "Uzytkownik")]
        public string? UserId { get; set; }
        [Display(Name = "Uzytkownik")]
        public string? Username { get; set; }

    }
}
