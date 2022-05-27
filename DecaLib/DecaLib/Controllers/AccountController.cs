using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DecaLib.Models;
using DecaLib.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DecaLib.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private string registrationToken;

        public AccountController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // return modelstate error if email already exists
            var user = await _userManager.FindByEmailAsync(model.Email);
            if(user != null)
            {
                ModelState.AddModelError("Invalid entry", "Email already exists!");
                return View(model);
            }

            // model view model to user model
            var userToAdd = new User { Email = model.Email };
            userToAdd.UserName = model.Email;

            var result = await _userManager.CreateAsync(userToAdd, model.Password);
            if (result.Succeeded)
            {
                // return modelstate if role fail to be added for user
                //var roleResult = await _userManager.AddToRoleAsync(userToAdd, "Member");
                //if (!roleResult.Succeeded)
                //{
                //    SetModelStateErrors(roleResult);
                //    return View(model);
                //}

                // generate email confirmation link
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(userToAdd);
                var link = Url.Action("ConfirmEmail", "Account", new { email = model.Email, token }, Request.Scheme);

                // event to send message on creating user
                // TODO here

                registrationToken = Guid.NewGuid().ToString();
                return View("RegConfirmationPage");
            }

            // return modelstate error if it fails to create user
            SetModelStateErrors(result);
            return View(model);
        }

        #region help set identity errors
            private void SetModelStateErrors(IdentityResult res)
            {
                foreach(var err in res.Errors)
                {
                    ModelState.AddModelError(err.Code, err.Description);
                }
            }
        #endregion



        //[HttpPost]
        //public async Task<IActionResult> AddRole(AddRoleViewModel model )
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    // return modelstate error if email already exists
        //    var user = await _userManager.FindByEmailAsync(model.Email);
        //    if (user == null)
        //    {
        //        ModelState.AddModelError("Invalid!", "Email not recognised!");
        //        return View(model);
        //    }

        //    // check if model is already added to user
        //    // Todo

        //    var roleResult = await _userManager.AddToRolesAsync(user, model.Roles);
        //    if (!roleResult.Succeeded)
        //    {
        //        SetModelStateErrors(roleResult);
        //        return View(model);
        //    }
        //    return View();
        //}


        [HttpGet]
        public IActionResult RegConfirmationPage()
        {
            if (registrationToken == null)
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            return View();
        }
    }
}
