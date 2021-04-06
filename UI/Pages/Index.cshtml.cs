using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using UI.Models;

namespace UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IServiceService _serviceService;

        public List<Service> Services { get; set; }

        public HomeModel HomeModel;

        [BindProperty]
        public ServiceDto ServiceDto { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IServiceService serviceService)
        {
            _logger = logger;
            _serviceService = serviceService;
        }

        public void OnGet()
        {
            var serviceList = _serviceService.GetAll();

            if (!serviceList.IsSuccess)
            {

            }else if (serviceList.IsSuccess)
            {
                HomeModel = new HomeModel
                {
                    Services = serviceList.Data
                };
            }
        }

        public IActionResult OnPost()
        {
            var result = _serviceService.Add(ServiceDto);

            if (!result.IsSuccess)
            {
                foreach (var error in result.Messages)
                {
                    ModelState.AddModelError("", error);
                }
            }

            if (!ModelState.IsValid)
            {
               
                return Page();
            }

            return RedirectToAction("Index");
        }

      
    }
}
