﻿using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class AuthorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
