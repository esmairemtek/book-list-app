﻿using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class BookListsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
