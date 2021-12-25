using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PersonalBlog.Interface;
using PersonalBlog.Models;
using PersonalBlog.Strategies;

namespace PersonalBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataService _dataService;
        private readonly ILogger _logger;

        public HomeController(IDataService dataService, ILogger<HomeController> logger)
        {
            _dataService = dataService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            _logger.Log(LogLevel.Error, "Something went wrong...");

            var allRows = await _dataService.GetAll();
            return View(allRows);
        }

        [Route("Post")]
        [HttpGet]
        [ServiceFilter(typeof(ProtectorAttribute))]
        public async Task<IActionResult> CreatePost(Post model)
        {
            return View(model);
        }

        [HttpPost]
        [ServiceFilter(typeof(ProtectorAttribute))]
        public async Task<IActionResult> Post(Post model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Validation", "Please provide all values");
                return View(model);
            }
            await _dataService.Create(model);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
