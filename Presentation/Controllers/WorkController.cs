﻿using Core.Models.Bugs;
using Core.Models.Bugs.Create;
using Core.Models.Comments;
using Core.Models.Users;
using Core.Services;
using Core.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Presentation.Controllers
{
    [Authorize]
    [Route("workflow")]
    public class WorkController : Controller
    {
        private readonly BackendService _backendService;
        private readonly IFilterFactory _filterFactory;

        public WorkController(BackendService backendService, IFilterFactory filterFactory)
        {
            _backendService = backendService;
            _filterFactory = filterFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _backendService.Get<PagedList<BugViewModel>>(Urls.Bug.Base);
            
            if (response.StatusCode == HttpStatusCode.Unauthorized)
                return RedirectToAction("Login", "User");

            return View(response.Resource);
        }

        [HttpPost]
        public async Task<IActionResult> Index(PagedList<BugViewModel> filteredList)
        {
            if (filteredList is not null)
            {
                return View("Index", filteredList);
            }

            var response = await _backendService.Get<PagedList<BugViewModel>>(Urls.Bug.Base);

            return View("Index", response.Resource);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            string requestUri = Urls.Bug.Base + $"/{id}";

            var response = await _backendService.Get<BugViewModel>(requestUri);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
                return RedirectToAction("Login", "User");

            return View(response.Resource);
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, BugViewModel model)
        {
            return View();
        }

        [HttpPost("workflow/search")]
        public async Task<IActionResult> Search(SearchViewModel search)
        {
            var filters = _filterFactory.Create(search);

            var filterService = new FilterService();

            string queryString = Urls.Bug.Base + "?" + filterService.JoinFiltersForQueryString(filters);

            var response = await _backendService.Get<PagedList<BugViewModel>>(queryString);

            return await Index(response.Resource);
        }

        [HttpGet("create")]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm]CreateBugViewModel? model)
        {
            if (!ModelState.IsValid)
            {
                var userResponse = await _backendService.Get<List<UserViewModel>>("/users");

                return View(new CreateBugViewModel
                {
                    Users = userResponse.Resource
                });
            }

            var mappedModel = CreateBugModel.MapFrom(model);

            var response = await _backendService.Post<BugViewModel>(Urls.Bug.Base, mappedModel);

            return RedirectToAction("Get", new { id = response.Resource.Id, response.Resource });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            string queryString = Urls.Bug.Base + $"/{id}";
            var response = await _backendService.Delete<BugViewModel>(queryString);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Get", new { id });
        }

        [HttpPost("/comment")]
        public async Task<IActionResult> AddComment([FromForm] CreateCommentViewModel newComment)
        {
            if (!ModelState.IsValid)
            {
                return View(newComment);
            }

            var mappedComment = CommentModel.MapFrom(newComment);

            string requestUri = Urls.Comment.Base.Replace("{bugId}", newComment.BugId.ToString());

            var response = await _backendService.Post<CommentViewModel>(requestUri, mappedComment);

            return RedirectToAction("Get", new { id = response.Resource.BugId });
        }
    }
}
