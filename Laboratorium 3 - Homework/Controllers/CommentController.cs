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
        public IActionResult Index()
        {
            return View(_commentService.FindAllWithDetails());
        }


        [HttpPost]
        [Authorize]
        public IActionResult Create(Comment comment)
        {
            if (!_signInManager.IsSignedIn(User))
            {
                return Unauthorized();
            }

            var currentUser = _signInManager.UserManager.GetUserId(User);
            comment.UserId = currentUser;
           
            _commentService.Add(comment);
            return RedirectToAction("Index");
        }

    }
}
