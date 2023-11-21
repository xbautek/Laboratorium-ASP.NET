using ProjectData.Entities;

namespace Laboratorium_3___Homework.Models
{
    public interface IPhotoService
    {
        void Add(Photo photo);
        void RemoveById(int id);
        void Update(Photo photo);
        List<Photo> FindAll();
        Photo? FindById(int id);
        List<AuthorEntity> FindAllAuthorsForViewModel();
    }
}
