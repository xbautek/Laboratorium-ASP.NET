using Laboratorium_3___Homework.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using ProjectData;
using ProjectData.Entities;
using SQLitePCL;


namespace Laboratorium_3___Homework.Models
{
    public class MemoryCommentService : ICommentService
    {
        private readonly AppDbContext _context;

        

        public MemoryCommentService(AppDbContext context) 
        { 
            _context = context;
        }
        public void Add(Comment comment)
        {
            _context.Comments.Add(CommentMapper.ToEntity(comment));
            _context.SaveChanges();
        }

        public List<Comment> FindAll()
        {
            return _context.Comments.Select(e => CommentMapper.FromEntity(e)).ToList();
        }

        public List<Comment> FindAllWithDetails()
        {
            var commentsWithDetails = _context.Comments
                .Include(c => c.Photo) // Załaduj powiązane zdjęcie
                .ToList();

            var result = commentsWithDetails
                .Select(comment => new Comment
                {
                    Id = comment.Id,
                    Content = comment.Comment,
                    UserId = comment.UserId,
                    PhotoId = comment.PhotoId,
                    PhotoDescription = comment.Photo?.Description, // Użyj Description z powiązanego zdjęcia
                    Username = GetUsernameForComment(comment.UserId) // Pobierz nazwę użytkownika dla danego UserId
                })
                .ToList();

            return result;
        }

        private string GetUsernameForComment(string userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            return user != null ? user.UserName : string.Empty;
        }



        public Comment? FindById(int id)
        {
            return CommentMapper.FromEntity(_context.Comments.Find(id));
        }

        public void RemoveById(int id)
        {
            CommentEntity? find = _context.Comments.Find(id);

            if (find != null)
            {
                _context.Comments.Remove(find);
            }
            _context.SaveChanges();
        }
    }
}
