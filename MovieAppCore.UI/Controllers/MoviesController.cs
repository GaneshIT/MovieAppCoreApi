using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAppCore.UI.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {
            //connect api service
            return View();
        }
    }
}
