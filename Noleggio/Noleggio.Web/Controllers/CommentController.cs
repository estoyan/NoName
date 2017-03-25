using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Noleggio.Services.Contracts;
using Noleggio.Web.Infrastructure;
using Bytes2you.Validation;
using Noleggio.DtoModels.CommentsDto;
using Microsoft.AspNet.Identity;


namespace Noleggio.Web.Controllers
{
    public class CommentController : BaseController
    {
        private ICommentService commentService;

        public CommentController(ICategoryService categoryService, ICommentService commentService) : base(categoryService)
        {
            Guard.WhenArgument(commentService, nameof(commentService)).IsNull().Throw();
            this.commentService = commentService;
        }

        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult AddComment(string addComment, Guid itemId)
        {
            var comment = new CommentDtoModel() { ItemId = itemId, Description = addComment, UserId = new Guid(User.Identity.GetUserId()) };
            this.commentService.AddCommnet(comment);

            return this.PartialView("_CommentsPartial", this.commentService.GetAll(itemId));
        }
    }
}