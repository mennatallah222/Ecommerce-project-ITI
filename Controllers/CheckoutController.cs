using Microsoft.AspNetCore.Mvc;
using project01.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project01.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ApplicationDbContext db;

        public CheckoutController(ApplicationDbContext db)
        {
            this.db = db;
        }
        [Route("Check out")]
        public IActionResult Index()
        {
            return View();
        }

    }
}
