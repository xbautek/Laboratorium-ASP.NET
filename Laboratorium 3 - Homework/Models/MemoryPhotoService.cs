using Laboratorium_3___Homework.Mappers;
using ProjectData;
using ProjectData.Entities;
using SQLitePCL;

namespace Laboratorium_3___Homework.Models
{
    public class MemoryPhotoService : IPhotoService
    {
        private readonly AppDbContext _context;

        public MemoryPhotoService(AppDbContext context)
        {
            _context = context;
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

      //  public PagingList<Photo> FindPagingAll()
      //  {
        //    return _context.Photos.Select(e => PhotoMapper.FromEntity(e)).ToList();
       // }

        public List<AuthorEntity> FindAllAuthorsForViewModel()
        {
            return _context.Authors.ToList();
        }

        public Photo? FindById(int id)
        {
            //            return _contacts.ContainsKey(id) ? _contacts[id] : null;
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
    }
}
