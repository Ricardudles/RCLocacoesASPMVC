﻿using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using RCLocacoes.Infra.Data.Repository;
using RCLocacoes.Web.Mvc.Models;
using RCLocacoes.Application.Interface;
using RCLocacoes.Domain.Entities;

namespace RCLocacoes.Web.Mvc.Controllers
{
    public class AccessController : Controller
    {
        private readonly ILoginUseCase loginUseCase;

        public AccessController(ILoginUseCase loginUseCase)
        {
            this.loginUseCase = loginUseCase;
        }

        public IActionResult Login()
        {
            ClaimsPrincipal claimsUser = HttpContext.User;

            if (claimsUser.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel modelLogin)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("CustomError", "An error ocurred on submit");
                return View(modelLogin);
            }

            var login = new Login
            {
                Email = modelLogin.Email,
                Password = modelLogin.Password,
                KeepLoggedIn = modelLogin.KeepLoggedIn
            };

            loginUseCase.AddAccount(login);

            if (modelLogin.Email == "teste@hotmail.com" && modelLogin.Password == "oi")
            {
                List<Claim> claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier, modelLogin.Email),
                    new Claim("Ola", "Roles"),
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent = modelLogin.KeepLoggedIn
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), properties);
                return RedirectToAction("Index", "Home");
            }


            ViewData["ValidateMessage"] = "User not found";
            return View();

        }
    }
}