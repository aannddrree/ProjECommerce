﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjECommerce.Controllers
{
    public class ChatClientController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.username = User.Identity.Name;

            return View();
        }
    }
}
