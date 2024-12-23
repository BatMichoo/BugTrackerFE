using Core.Models.Bugs;
using Core.Models.Bugs.Create;
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

        public WorkController(BackendService backendService)
        {
            _backendService = backendService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _backendService.Get<PagedList<BugViewModel>>(Urls.Bug.Base);
            
            if (response.StatusCode == HttpStatusCode.Unauthorized)
                return RedirectToAction("Login", "User");

            return View(response.Resource);
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

        [HttpPost]
        public async Task<IActionResult> Search(SearchViewModel search)
        {
            return View(search);
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
    }
}
