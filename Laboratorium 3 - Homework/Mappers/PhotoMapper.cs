using Laboratorium_3___Homework.Models;
using ProjectData.Entities;

namespace Laboratorium_3___Homework.Mappers
{
    public class PhotoMapper
    {
        public static Photo FromEntity(PhotoEntity entity)
        {    
            return new Photo()
            {
                Id = entity.Id,
                DateAndTime= entity.DateAndTime,
                Description = entity.Description,
                Camera= entity.Camera,
                Format = (Format)Enum.Parse( typeof(Format),entity.Format),
                Resolution = (Resolution)Enum.Parse( typeof(Resolution),entity.Resolution),
                AuthorId = entity.AuthorId
            };
        }

        public static PhotoEntity ToEntity(Photo photo)
        {
            return new PhotoEntity()
            {
                Id = photo.Id,
                DateAndTime = photo.DateAndTime,
                Description = photo.Description,
                Camera = photo.Camera,
                Format = photo.Format.ToString(),
                Resolution = photo.Resolution.ToString(),
                AuthorId = photo.AuthorId
             
            };
        }
        
    }
}
