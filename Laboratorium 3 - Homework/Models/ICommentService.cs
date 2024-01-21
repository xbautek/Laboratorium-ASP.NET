using ProjectData.Entities;


namespace Laboratorium_3___Homework.Models
{
    public interface ICommentService
    {
        void Add(Comment comment);
        void RemoveById(int id);
        Comment? FindById(int id);
        List<Comment> FindAll();
        List<Comment> FindAllWithDetails();

    }
}
