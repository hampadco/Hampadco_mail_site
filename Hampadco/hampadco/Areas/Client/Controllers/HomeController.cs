using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace hampadco.Areas.Client.Controllers
{
    [Area("Client")]
    public class HomeController : BaseController
    {

        public IActionResult Index()
        {
            return View();
        }

    }
}