using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        public UserController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("Register")]
        // registracija - ruta: http://localhost:58532/api/User/Register
        public async Task<Object> RegisterUser(UserModel model)
        {
            var user = new User() {
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName,
                DateOfBirth = model.DateOfBirth
            };
            try
            {
                var results = await _userManager.CreateAsync(user, model.Password);
                return Ok(results);

            } 
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
