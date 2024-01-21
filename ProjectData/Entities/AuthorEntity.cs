using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectData.Entities
{
    [Table("authors")]
    public class AuthorEntity
    {
        [Column("author_id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Podaj imię!")]
        [StringLength(40)]
        [Display(Name = "Imię")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Podaj nazwisko!")]
        [StringLength(40)]
        [Display(Name = "Nazwisko")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Podaj Email!")]
        [StringLength(60)]
        public string Email { get; set; }
        public ICollection<PhotoEntity>? Photos { get; set; }
    }
}
