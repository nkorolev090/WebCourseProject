using Interfaces.Services;
using lab.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Interfaces.DTO;

namespace lab.Controllers
{
    [Produces("application/json")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        public AccountController( IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("api/account/register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Добавление нового пользователя
                var result = await _userService.RegisterUserAsync(model.Email, model.Password);

                if (result.Succeeded)
                {
                    return Ok(new { message = "Добавлен новый пользователь: ", email = model.Email });
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    var errorMsg = new
                    {
                        message = "Пользователь не добавлен",
                        error = ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage))
                    };
                    return Created("", errorMsg);
                }
            }
            else
            {
                var errorMsg = new
                {
                    message = "Неверные входные данные",
                    error = ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage))
                };
                return Created("", errorMsg);

            
            }
        }

        [HttpPost]
        [Route("api/account/login")]
        //[AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.SignInUserAsync(model.Email, model.Password, model.RememberMe);
                if (result.Succeeded)
                {
                    return Ok(new { message = "Выполнен вход", email = model.Email });
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                    var errorMsg = new
                    {
                        message = "Вход не выполнен",
                        error = ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage))
                    };
                    return Created("", errorMsg);
                }
            }
            else
            {
                var errorMsg = new
                {
                    message = "Вход не выполнен",
                    error = ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage))
                };
                return Created("", errorMsg);
            }
        }

        [HttpPost]
        [Route("api/account/logoff")]
        public async Task<IActionResult> LogOff()
        {
            var result = await _userService.LogOffAsync(HttpContext.User);
            if (!result)
            {
                return Unauthorized(new { message = "Сначала выполните вход" });
            }

            return Ok(new { message = "Выполнен выход" });
        }

        [HttpGet]
        [Route("api/account/isauthenticated")]
        public async Task<IActionResult> IsAuthenticated()
        {
            var result =  await _userService.IsAuthenticatedAsync(HttpContext.User);
            if (result == null)
            {
                return Unauthorized(new { message = "Вы Гость. Пожалуйста, выполните вход" });
            }
            return Ok(new { message = "Сессия активна", userDTO = result});
        
        }
    }
}
