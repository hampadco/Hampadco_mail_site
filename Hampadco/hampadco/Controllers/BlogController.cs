using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace hampadco.Controllers
{
    public class BlogController : BaseController
    {

        public IActionResult Index()
        {
            return View();
        }

    }
}