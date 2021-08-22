using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using HotelListing.EndPoint.Data.Entities.identity;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using HotelListing.EndPoint.Models.Dtos;
using HotelListing.EndPoint.Services.IRepositories;

namespace HotelListing.EndPoint.Controllers.Api
{

    [ApiController]
    [Route("api/Account")]
    public class AccountController : Controller
    {

        private readonly SignInManager<AppUser> _signin;
        private readonly UserManager<AppUser> _usermanager;
        private readonly RoleManager<IdentityRole> _rolemanager;
        private readonly ILogger<AccountController> _logger;
        private readonly IAuthManager _authmanager;

        public AccountController(RoleManager<IdentityRole> roleManager,
        UserManager<AppUser> userManager, SignInManager<AppUser> signinManger,
        ILogger<AccountController> logger,
        IAuthManager authManager)
        {
            _rolemanager = roleManager;
            _signin = signinManger;
            _usermanager = userManager;
            _logger = logger;
            _authmanager = authManager;
        }



        [HttpPost]
        [Route("RegisterUser")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDTo model)
        {
            try
            {
                _logger.LogInformation($"Attemps for registring {model.Email}");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);


                var user = new AppUser
                {
                    Email = model.Email,
                    FirstName = model.FirstName ?? "Null",
                    LastName = model.LastName ?? "Null",
                    PhoneNumber = model.PhoneNumber,
                    UserName = model.Email,
                };


                var result = await _usermanager.CreateAsync(user, model.PassWord);

                if (result.Succeeded)
                {


                    var isroleAdded = await _usermanager.AddToRoleAsync(user, "user");


                    if (isroleAdded.Succeeded)
                        return Ok("User Succssfuly registerd....");
                    else if (isroleAdded.Errors != null)
                    {
                        foreach (var item in isroleAdded.Errors)
                            _logger.LogError($"Error while adding role to Registerd user : {user.Email} with this Error : {item.Description}");

                        return StatusCode(500, "Internal Error Error Accured please try later");
                    }

                }
                else if (result.Errors != null)
                {
                    foreach (var error in result.Errors)
                        ModelState.AddModelError(string.Empty, error.Description);

                    return StatusCode(500, ModelState);
                }


                return BadRequest();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"this Error Happend During {nameof(Register)} request for this user :  {model.Email}");
                return Problem($"Someting wentWrrong in {nameof(Register)}", statusCode: 500, title: "Error");
            }
        }

        [HttpPost]
        [Route("LoginUser")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto model)
        {
            try
            {
                _logger.LogInformation($"Attemps for registring {model.UserName}");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                if (!await _authmanager.ValidateUser(model))
                    return Unauthorized();

                else
                    return Ok(new { Token = await _authmanager.createToken() });



            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"this Error Happend During {nameof(Login)} request for this user :  {model.UserName}");
                return Problem($"Someting wentWrrong in {nameof(Login)}", statusCode: 500, title: "Error");
            }
        }

    }
}