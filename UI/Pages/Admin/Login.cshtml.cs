using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Entities.Dtos;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace UI.Pages.Admin
{
    public class LoginModel : PageModel
    {
        private IConstantService _constantService;

        public String ErrorMessage;
        public LogoDto LogoDto { get; set; }
        [BindProperty]
        public LoginDto LoginDto { get; set; }

        public LoginModel(IConstantService constantService)
        {
            _constantService = constantService;
        }

        public IActionResult OnGet()
        {
            var result = _constantService.GetLogo();

            if (!result.IsSuccess)
            {

            }

            LogoDto = result.Data;

            return this.Page();
        }

        public IActionResult OnPost()
        {
            if ("admin" == LoginDto.UserName && "rella-2021" == LoginDto.Password)
            {
                List<Claim> claims = new List<Claim>();

                claims.Add(new Claim(ClaimTypes.Name, "admin"));

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true
                };
                
                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                 HttpContext.SignInAsync(
                     CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                 return RedirectToPage("Index");
            }
            else
            {
                TempData["PasswordOrUserNameInValid"] = "Kullanýcý adý veya þifre yanlýþ";
                //ViewData["PasswordOrUserNameInValid"] = "Kullanýcý adý veya þifre yanlýþ";
            }
            return RedirectToPage("Login");
        }
    }
}
