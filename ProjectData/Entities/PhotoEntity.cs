using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectData.Entities
{
    [Table("photos")]
    public class PhotoEntity
    {

        [Column("photo_id")]
        public int Id { get; set; }
        [Required]
        [StringLength(70)]
        public string Description { get; set; }
        [Required]
        [StringLength(40)]
        public string Camera { get; set; }
        [Required]
        public string Resolution { get; set; }
        [Required]
        public string Format { get; set; }
        public DateTime DateAndTime { get; set; }

        public AuthorEntity? Author { get; set; }
        public int? AuthorId { get; set; }
    }
}
