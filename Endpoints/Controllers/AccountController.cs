using Interfaces.Services;
using Interfaces.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Interfaces.DTO;

namespace Endpoints.Controllers
{
    [Produces("application/json")]
    public class AccountController : Controller
    {
        private readonly ILogger _logger;
        private readonly IUserService _userService;
        public AccountController(ILogger<AccountController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost]
        [Route("api/account/register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Добавление нового пользователя
                    var result = await _userService.RegisterUserAsync(model.Name, model.Midname, model.Surname, model.PhoneNumber, model.Email, model.Password);

                    if (result.Succeeded)
                    {
                        var userRole = await _userService.GetUserRole(model.Email);
                        return Ok(new { message = "Добавлен новый пользователь: ", email = model.Email, userRole });
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
            catch (Exception ex)
            {
                _logger.LogError(ex.Message,
                    DateTime.UtcNow.ToLongTimeString());
                return Problem();
            }
        }

        [HttpPost]
        [Route("api/account/login")]
        //[AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _userService.SignInUserAsync(model.Email, model.Password, model.RememberMe);
                    if (result.Succeeded)
                    {
                        var userRole = await _userService.GetUserRole(model.Email);
                        return Ok(new { message = "Выполнен вход", email = model.Email, userRole });
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
            catch (Exception ex)
            {
                _logger.LogError(ex.Message,
                    DateTime.UtcNow.ToLongTimeString());
                return Problem();
            }
        }

        [HttpPost]
        [Route("api/account/logoff")]
        public async Task<IActionResult> LogOff()
        {
            try
            {
                var result = await _userService.LogOffAsync(HttpContext.User);
                if (!result)
                {
                    return Unauthorized(new { message = "Сначала выполните вход" });
                }

                return Ok(new { message = "Выполнен выход" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message,
                    DateTime.UtcNow.ToLongTimeString());
                return Problem();
            }
        }

        [HttpGet]
        [Route("api/account/isauthenticated")]
        public async Task<IActionResult> IsAuthenticated()
        {
            try
            {
                var result = await _userService.IsAuthenticatedAsync(HttpContext.User);
                if (result == null)
                {
                    return Unauthorized(new { message = "Вы Гость. Пожалуйста, выполните вход" });
                }
                var userRole = await _userService.GetUserRole(result.email);
                return Ok(new { message = "Сессия активна", userDTO = result, userRole });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message,
                    DateTime.UtcNow.ToLongTimeString());
                return Problem();
            }

        }
    }
}
