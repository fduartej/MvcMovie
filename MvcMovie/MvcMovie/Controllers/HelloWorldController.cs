﻿using Microsoft.AspNetCore.Mvc;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcMovie.Controllers
{
	public class HelloWorldController : Controller
	{
		// 
		// GET: /HelloWorld/

		/*public string Index()
		{
			return "This is my default action...";
		}*/

		public IActionResult Index()
		{
			return View();
		}


		// 
		// GET: /HelloWorld/Welcome/ 
		/*public string Welcome()
		{
			return "This is the Welcome action method...";
		}*/

		public IActionResult Welcome(string name, int numTimes = 1)
		{
			ViewData["Message"] = "Hello " + name;
			ViewData["NumTimes"] = numTimes;

			return View();

		}
	}
}