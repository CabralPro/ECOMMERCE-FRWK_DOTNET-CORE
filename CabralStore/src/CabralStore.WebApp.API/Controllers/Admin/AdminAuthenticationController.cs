using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CabralStore.WebApp.API.Controllers.Admin._models;
using CabralStore.WebApp.API.Services;

namespace CabralStore.WebApp.API.Controllers.Admin
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AdminAuthenticationController : Controller
    {

        public AdminAuthenticationController() { }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<dynamic> SingIn(LoginModel login)
        {
            var user = new UserModel()
            {
                Id = new Guid("1eea0df4-a33d-4da2-9628-3f573293bac1"),
                Password = "admin",
                UserName = "admin",
                Role = "all"
            };

            if (login.UserName != user.UserName || login.Password != user.Password)
                return BadRequest(new { message = "Usuário ou senha incorretos" });

            var token = TokenService.GenerateToken(user);
            user.Password = "";

            return new { user = user, token = token };
        }
    }
}