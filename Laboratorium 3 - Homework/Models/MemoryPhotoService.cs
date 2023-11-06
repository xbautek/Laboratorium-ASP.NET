namespace Laboratorium_3___Homework.Models
{
    public class MemoryPhotoService : IPhotoService
    {
        private readonly Dictionary<int, Photo> _photos = new Dictionary<int, Photo>();
        private int id = 1;

        public void Add(Photo photo)
        {
            photo.Id = id++;
            _photos.Add(photo.Id, photo);
        }

        public List<Photo> FindAll()
        {
            return _photos.Values.ToList();
        }

        public Photo? FindById(int id)
        {
            return _photos[id];
        }

        public void RemoveById(int id)
        {
            _photos.Remove(id); 
        }

        public void Update(Photo photo)
        {
            _photos[photo.Id] = photo;
        }
    }
}
