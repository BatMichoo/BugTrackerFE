using Core.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models.Bugs;
using System.Net;
using System.Text.Json;

namespace Presentation.Controllers
{
    [Authorize]
    [Route("workflow")]
    public class WorkController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _jsonOptions;

        public WorkController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var bugs = new PagedList<BugViewModel>();

            var client = _httpClientFactory.CreateClient("Backend");

            var response = await client.GetAsync("/bugs");

            if (response.IsSuccessStatusCode)
            {
                bugs = await response.Content.ReadFromJsonAsync<PagedList<BugViewModel>>(_jsonOptions);
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return RedirectToAction("Login", "User");
            }

            return View(bugs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var client = _httpClientFactory.CreateClient("Backend");

            var response = await client.GetAsync($"/bugs/{id}");

            var bug = await response.Content.ReadFromJsonAsync<BugViewModel>();

            return View(bug);
        }
    }
}
