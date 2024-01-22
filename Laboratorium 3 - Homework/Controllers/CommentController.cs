using Laboratorium_3___Homework.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium_3___Homework.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly SignInManager<IdentityUser> _signInManager;


        public CommentController(ICommentService commentService, SignInManager<IdentityUser> signInManager)
        {
            _commentService = commentService;
            _signInManager = signInManager;

        }

        [AllowAnonymous]
        public IActionResult Index(int? id)
        {
            ViewBag.PhotoId = id;
            if (id is not null)
            {
                var commentsForPhoto = _commentService.FindAllWithDetails().Where(c => c.PhotoId == id).ToList();
                return View(commentsForPhoto);
            }

            return View(_commentService.FindAllWithDetails());
        }


        [HttpPost]
        [Authorize(Roles = "admin,user,guest")]
        public IActionResult Create(Comment comment, int? photoId)
        {
            if (!_signInManager.IsSignedIn(User))
            {
                return Unauthorized();
            }

            var currentUser = _signInManager.UserManager.GetUserId(User);
            comment.UserId = currentUser;
           
            _commentService.Add(comment);
            return RedirectToAction("Index", new { id = photoId });
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_commentService.FindById(id));
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(Comment comment, int? photoId)
        {
            _commentService.RemoveById(comment.Id);

            return RedirectToAction("Index", new { id = photoId });
        }

    }
}
