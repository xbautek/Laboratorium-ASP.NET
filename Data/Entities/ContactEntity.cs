using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("contacts")]
    public class ContactEntity
    {
        [Column("contact_id")]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        public DateTime? Birth { get; set; }
        public OrganizationEntity? Organization { get; set; }
        public int? OrganizationId { get; set; }
    }
}
//dotnet tool install --global dotnet-ef
//dotnet ef migrations add InitialCreate
//dotdotnet ef database update
// appdata/local/powinny tu byc dane
//
