using Laboratorium_3___Homework.Mappers;
using Microsoft.Extensions.Caching.Memory;
using ProjectData;
using ProjectData.Entities;
using SQLitePCL;

namespace Laboratorium_3___Homework.Models
{
    public class MemoryPhotoService : IPhotoService
    {
        private readonly AppDbContext _context;
        private readonly IMemoryCache _memoryCache;


        public MemoryPhotoService(AppDbContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }

        public List<Photo> RecentlyDeletedPhotos
        {
            get
            {
                if (!_memoryCache.TryGetValue("RecentlyDeletedPhotos", out List<Photo> photos))
                {
                    photos = new List<Photo>();
                    _memoryCache.Set("RecentlyDeletedPhotos", photos, new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(100) // Ustaw odpowiedni czas wygaśnięcia
                    });
                }

                return photos;
            }
        }

        public void AddRecent(Photo photo)
        {
            RecentlyDeletedPhotos.Add(PhotoMapper.FromEntity(_context.Photos.Find(photo.Id)));
        }

        public void DeleteRecent(Photo photo)
        {
            RecentlyDeletedPhotos.Remove(photo);
        }

        public void Add(Photo photo)
        {
            _context.Photos.Add(PhotoMapper.ToEntity(photo));
            _context.SaveChanges();
        }

        public List<Photo> FindAll()
        {
            return _context.Photos.Select(e => PhotoMapper.FromEntity(e)).ToList();
        }

        public List<AuthorEntity> FindAllAuthorsForViewModel()
        {
            return _context.Authors.ToList();
        }

        public Photo? FindById(int id)
        {
            return PhotoMapper.FromEntity(_context.Photos.Find(id));
        }

        public void RemoveById(int id)
        {
            PhotoEntity? find = _context.Photos.Find(id);

            if(find != null)
            {
                _context.Photos.Remove(find);
            }
            _context.SaveChanges();
        }

        public void Update(Photo photo)
        {
            _context.Photos.Update(PhotoMapper.ToEntity(photo));
            _context.SaveChanges();
        }



        public PagingList<Photo> FindPage(int page, int size, int? authorId)
        {
            var allPhotos = FindAll(); 


            if (authorId.HasValue)
            {
                allPhotos = allPhotos.Where(photo => photo.AuthorId == authorId).ToList();
            }
           
            var totalCount = allPhotos.Count();

            var result = PagingList<Photo>.Create(
                (p, s) =>
                    allPhotos
                    .OrderBy(c => c.Id)
                    .Skip((p - 1) * size)
                    .Take(s)
                    .ToList(),
                page,
                size,
                totalCount
            );
            return result;
        }

        public List<Photo> FindAllRecent()
        {
            return RecentlyDeletedPhotos.ToList();
        }

        public Photo? FindByIdRestore(int id)
        {
            return RecentlyDeletedPhotos.FirstOrDefault(photo => photo.Id == id);
        }
    }
}
