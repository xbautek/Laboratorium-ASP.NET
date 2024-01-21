using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectData.Entities
{
    [Table("comments")]
    public class CommentEntity
    {
        [Column("comment_id")]
        public int Id { get; set; }
        public string Comment { get; set; }

        public int PhotoId { get; set; }
        public PhotoEntity? Photo { get; set; }

        public string? UserId { get; set; }
    }
}
