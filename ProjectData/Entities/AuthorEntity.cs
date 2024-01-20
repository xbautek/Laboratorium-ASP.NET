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
        [Required]
        [StringLength(40)]
        [Display(Name = "Imię")]
        public string Name { get; set; }
        [Required]
        [StringLength(40)]
        [Display(Name = "Nazwisko")]
        public string Surname { get; set; }
        [Required]
        [StringLength(60)]
        public string Email { get; set; }
        public ICollection<PhotoEntity>? Photos { get; set; }
    }
}
