﻿using CleanArchMVC.Domain.Account;
using CleanArchMVC.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchMVC.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticate _authenticate;
        public AccountController(IAuthenticate authenticate)
        {
            _authenticate = authenticate;
        }

        [HttpGet]
        public IActionResult Login(string returnURL)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnURL,
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await _authenticate.Authenticate(model.DS_EMAIL, model.DS_PASSWORD);

            if (result)
            {
                if(string.IsNullOrEmpty(model.ReturnUrl))
                    return RedirectToAction("Index", "Home");
                
                return Redirect(model.ReturnUrl);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Tentativa de login inválida");
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var result = await _authenticate.RegisterUser(model.DS_EMAIL, model.DS_PASSWORD);

            if (result)
                return Redirect("/");
            else
            {
                ModelState.AddModelError(string.Empty, "Tentativa de registro inválida (a senha deve ser forte).");
                return View(model);
            }
        }

        public async Task<IActionResult> Logout()
        {
            await _authenticate.Logout();
            return RedirectToAction("/Account/Login");
        }
    }
}
