using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace YourHelper.Controllers
{
    [Authorize]
    public class TicketController : Controller
    
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Receipt()
        {
            return View();
        }
    }
}