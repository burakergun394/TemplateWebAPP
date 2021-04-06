using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Helpers;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UI.Models;

namespace UI.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private IConstantService _constantService;
        private IGeneralInformationService _generalInformationService;

        private readonly IWebHostEnvironment _hostEnvironment;

        [BindProperty] public GeneralInformation GeneralInformation { get; set; }

        [BindProperty] public SocialMediaDto SocialMediaDto { get; set; }
        [BindProperty] public ContactDto ContactDto { get; set; }

        public IndexModel(IConstantService constantService, IWebHostEnvironment hostEnvironment, IGeneralInformationService generalInformationService)
        {
            _constantService = constantService;
            _hostEnvironment = hostEnvironment;
            _generalInformationService = generalInformationService;
        }

        public void OnGet()
        {
            var generalInformation = _generalInformationService.Get();
            var socialMedia = _generalInformationService.GetSocialMedia();
            if (!generalInformation.IsSuccess || !socialMedia.IsSuccess)
            {

            }

            GeneralInformation = generalInformation.Data;
            SocialMediaDto = socialMedia.Data;
        }

        public IActionResult OnPostLogo(string hiddenImageNew)
        {
            var logoPath = ImageHelper.Base64ToImage(_hostEnvironment, "/images/logo", hiddenImageNew);

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _generalInformationService.UpdateLogo(new LogoDto { LogoPath = logoPath });

            return RedirectToPage("Index");
        }


        public IActionResult OnPostSocialMedia()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _generalInformationService.UpdateSocialMedia(SocialMediaDto);

            return RedirectToPage("Index");
        }

        public IActionResult OnPostContact()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _generalInformationService.UpdateContact(SocialMediaDto);

            return RedirectToPage("Index");
        }
    }
}
