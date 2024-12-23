using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models.Login;
using Presentation.Models.Register;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Presentation.Controllers
{
    [Route("users")]
    public class UserController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public UserController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [Route("login")]
        public async Task<IActionResult> LogIn(LoginViewModel login)
        {
            if (login.Email == null && login.Password == null)
                return View();

            var client = _clientFactory.CreateClient("Backend");

            var userCreds = new
            {
                login.Email,
                login.Password
            };

            var content = JsonContent.Create(userCreds);

            var response = await client.PostAsync("/users/login", content);

            if (response.IsSuccessStatusCode)
            {
                ClaimsPrincipal claimsPrincipal = await ParseJwtToken(response);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                return RedirectToAction("Index", "Home");
            }

            return View(login);
        }

        [HttpGet("register")]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            return View();
        }

        [HttpGet("logout")]
        public async Task<IActionResult> LogOut()
        {
            if (User.Identity.IsAuthenticated)
            {
                var client = _clientFactory.CreateClient("Backend");

                var response = await client.GetAsync("users/logout");

                if (response.IsSuccessStatusCode)
                {
                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                }
            }

            return RedirectToAction("Index", "Home");
        }

        private static async Task<ClaimsPrincipal> ParseJwtToken(HttpResponseMessage response)
        {
            var responseContent = await response.Content.ReadFromJsonAsync<LoginResponseModel>();

            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(responseContent.Token);
            var claims = jwtToken.Claims;

            claims = claims.Append(new Claim("Token", responseContent.Token));

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            return claimsPrincipal;
        }
    }
}
