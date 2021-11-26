using Demo.BL.Helper;
using Demo.BL.Models;
using FCAI.BL.Model;
using FCAI.DAL.Extend;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCAI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        #region SignUP
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var findUser = await userManager.FindByEmailAsync(model.Email);
                    if(findUser == null){
                        var user = new ApplicationUser()
                        {
                            UserName = model.UserName,
                            Email = model.Email,
                            IsAgree = model.IsAgree
                        };

                        var result = await userManager.CreateAsync(user, model.Password);

                        if (result.Succeeded)
                        {
                            return RedirectToAction("Login");
                        }
                        else
                        {
                            foreach (var item in result.Errors)
                            {
                                ModelState.AddModelError("", item.Description);
                            }
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Email Is Exits");
                    }
                    
                }
                return View(model);
            }
            catch (Exception)
            {
                return View(model);
            }
        }
        #endregion

        #region Signin
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await userManager.FindByEmailAsync(model.Email);
                    if(user != null)
                    {
                        var result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Invalid UserName Or Password");

                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Email not Exits");
                    }
                }
                return View(model);
            }
            catch (Exception)
            {
                return View(model);
            }
        }

        #endregion

        #region Signout
        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        #endregion

        #region ForgetPass
        [HttpGet]
        public IActionResult ForgetPass()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPass(ForgetPassVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //get user by email
                    var user = await userManager.FindByEmailAsync(model.Email);

                    if (user != null)
                    {
                        // generate token
                        var token = await userManager.GeneratePasswordResetTokenAsync(user);

                        // generate reset link
                        var passwordResetLink = Url.Action("ResetPass", "Account", new { Email = model.Email, Token = token }, Request.Scheme);

                        MailSender.SendMail(new MailVM() { Mail = model.Email,Title = "Reset Password",Message = passwordResetLink});

                        //logger.Log(LogLevel.Warning, passwordResetLink);

                        return RedirectToAction("ConfirmForgetPass");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Email not Exits");
                    }

                }
                return View(model);
            }
            catch (Exception)
            {
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult ConfirmForgetPass()
        {
            return View();
        }
        #endregion

        #region ResetPass
        [HttpGet]
        public IActionResult ResetPass(string Email,string Token)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPass(ResetPassVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await userManager.FindByEmailAsync(model.Email);

                    if (user != null)
                    {
                        var result = await userManager.ResetPasswordAsync(user, model.Token, model.Password);

                        if (result.Succeeded)
                        {
                            return RedirectToAction("ConfirmResetPass");
                        }

                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }

                        return View(model);
                    }

                    return RedirectToAction("ConfirmResetPass");
                }
                return View(model);
            }
            catch (Exception)
            {
                return View(model);
            }
        }
        [HttpGet]
        public IActionResult ConfirmResetPass()
        {
            return View();
        }
        #endregion

    }
}
