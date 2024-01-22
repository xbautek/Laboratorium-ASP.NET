using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectData;
using ProjectData.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Laboratorium_3___Homework.Controllers
{
    [Route("api/photos")]
    [ApiController]
    public class PhotoApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PhotoApiController(AppDbContext context)
        {
            _context = context;
        }

        //https://localhost:7053/api/photos/ByAuthor/101
        [HttpGet("ByAuthor/{authorId}")]
        public IActionResult GetFiltered(int authorId)
        {
            var photos = _context.Photos
                .Include(p => p.Author)
                .Where(p => p.AuthorId == authorId)
                .Select(p => new
                {
                    Author = new
                    {
                        p.Author.Id,
                        p.Author.Name,
                        p.Author.Surname,
                        p.Author.Email
                    },
                    p.Description,
                    p.Format,
                    p.Camera,
                    p.Resolution,
                    Comments = p.Comments.Select(c => new
                    {
                        c.Id,
                        c.Comment,
                        c.PhotoId,
                        c.UserId
                    }).ToList()
                })
                .ToList();

            if (photos == null || photos.Count == 0)
            {
                return NotFound();
            }

            return Ok(photos);
        }

    }
}
