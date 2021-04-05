using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Helpers;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UI.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private IConstantService _constantService;
        public Constant ConstantShow { get; set; }
        [BindProperty]
        public Constant Constant { get; set; }
        public IndexModel(IConstantService constantService)
        {
            _constantService = constantService;
        }

        public void OnGet()
        {
            var constantList = _constantService.Get();

            if (!constantList.IsSuccess)
            {

            }
            else if (constantList.IsSuccess)
            {
                ConstantShow = constantList.Data;
            }
        }

        public IActionResult OnPostLogo()
        {
            var constant = Constant;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            return RedirectToPage("Index");
        }

        public IActionResult OnPostSocialMedia()
        {
            var constant = Constant;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            return RedirectToPage("Index");
        }
    }
}
