using Laboratorium_3___Homework.Models;
using ProjectData.Entities;

namespace Laboratorium_3___Homework.Mappers
{
    public class CommentMapper
    {
        public static Comment FromEntity(CommentEntity entity)
        {
            return new Comment()
            {
                Id = entity.Id,
                PhotoId = entity.PhotoId,
                Content = entity.Comment,
                UserId = entity.UserId,
            };
        }

        public static CommentEntity ToEntity(Comment com)
        {
            return new CommentEntity()
            {
                Id = com.Id,
                PhotoId = com.PhotoId,
                Comment = com.Content,
                UserId = com.UserId
            };
        }

    }
}
