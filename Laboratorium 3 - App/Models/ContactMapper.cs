using Data.Entities;

namespace Laboratorium_3___App.Models
{
    public class ContactMapper
    {
        public static Contact FromEntity(ContactEntity entity)
        {
            return new Contact()
            {
                Id = entity.Id,
                Name = entity.Name,
                Phone = entity.Phone,
                Email = entity.Email,
                Birth = entity.Birth,
                OrganizationId = entity.OrganizationId
            };
        }

        public static ContactEntity ToEntity(Contact contact)
        {
            return new ContactEntity()
            {
                Id = contact.Id,
                Name = contact.Name,
                Phone = contact.Phone,
                Email = contact.Email,
                Birth = contact.Birth,
                OrganizationId = contact.OrganizationId
            };
        }
    }
}
