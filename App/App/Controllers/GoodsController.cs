using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class GoodsController : Controller
    {
        public IActionResult InstrumentList()
        {
            return View();
        }

        public IActionResult PartList()
        {
            return View();
        }

        public IActionResult EctList()
        {
            return View();
        }

    }
}
