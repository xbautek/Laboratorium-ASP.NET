using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectData;
using System.Data;

namespace Laboratorium_3___Homework.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/authors")]
    [ApiController]
    public class AuthorApiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthorApiController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetByName(string? q)
        {
            return Ok(
                q == null ?
                _context.Authors
                .Select(o => new { o.Id, o.Name })
                .ToList()
                :
                _context.Authors
                .Where(x => x.Name.ToUpper().StartsWith(q.ToUpper()))
                .Select(o => new { o.Id, o.Name })
                .ToList()
                );
        }
    }
}
