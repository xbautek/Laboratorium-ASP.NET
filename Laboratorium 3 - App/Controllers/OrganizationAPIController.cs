using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium_3___App.Controllers
{
    [Route("api/organizations")]
    [ApiController]
    public class OrganizationAPIController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrganizationAPIController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetByName(string? q)
        {
            return Ok(
                q == null ?
                _context.Organizations
                .Select(o => new { o.Id, o.Name })
                .ToList()
                :
                _context.Organizations
                .Where(x => x.Name.ToUpper().StartsWith(q.ToUpper()))
                .Select(o => new { o.Id, o.Name })
                .ToList()
                );
        }


    }
}
