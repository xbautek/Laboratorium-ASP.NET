using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Laboratorium_3___Homework.Models
{
    public enum Resolution
    {
        [Display(Name = "1920x1080")]
        _1920x1080,

        [Display(Name = "1366x768")]
        _1366x768,

        [Display(Name = "1280x720")]
        _1280x720,

        [Display(Name = "2560x1440")]
        _2560x1440,

        [Display(Name = "3840x2160")]
        _3840x2160
    }

    public enum Format
    {
        [Display(Name = "4:3 (Standardowa Rozdzielczość)")]
        _4x3,

        [Display(Name = "16:9 (Wysoka Rozdzielczość)")]
        _16x9,

        [Display(Name = "21:9 (Ultra-Szeroki)")]
        _21x9,

        [Display(Name = "1:1 (Kwadratowy)")]
        _1x1,

        [Display(Name = "9:16 (Pionowy)")]
        _9x16
    }

    static public class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()
                            .GetName();
        }
    }

    public class Photo
    {

        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Data musi zostać wybrana!")]
        [DataType(DataType.Date)]
        [Display(Name = "Data i czas")]
        public DateTime DateAndTime { get; set; }

        [StringLength(70, ErrorMessage = "Opis jest za długi")]
        [Display(Name = "Opis")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Musi być podana kamera!")]
        [Display(Name = "Aparat")]
        public string Camera { get; set; }

        [Display(Name = "Rozdzielczość")]
        public Resolution Resolution { get; set; }

        [Required(ErrorMessage = "Musi być podany format!")]
        public Format Format { get; set; }
        [Display(Name = "Autor")]
        public int? AuthorId { get; set; }
        [ValidateNever]
        public List<SelectListItem> AuthorsList { get; set; }
    }
}
