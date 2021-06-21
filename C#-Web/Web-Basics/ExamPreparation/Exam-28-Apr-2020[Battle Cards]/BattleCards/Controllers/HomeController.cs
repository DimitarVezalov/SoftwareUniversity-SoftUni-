﻿using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleCards.Controllers
{
    public class HomeController : Controller
    {
        public HttpResponse Index()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/Cards/All");
            }

            return this.View();
        }


        [HttpGet("/")]
        public HttpResponse IndexSlash()
        {
            return this.Index();
        }
    }
}
