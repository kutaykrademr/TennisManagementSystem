﻿using Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TennisManagementSystem.Models;

namespace TennisManagementSystem.Controllers
{
    public class HomeController : Controller
    {

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("Anasayfa")]
        public IActionResult MainPage()
        {
            List<CompanySettingsDto> model = new List<CompanySettingsDto>();

            model = Helpers.Serializers.DeserializeJson<List<CompanySettingsDto>>(Helpers.Request.Get(Mutuals.ApiUrl + "Web/GetCompanySettings"));

            return View(model);
        }

        [HttpGet]
        public JsonResult LoginUser(string user,string pass)
        {

            AdminDto model = new AdminDto();

            model = Helpers.Serializers.DeserializeJson<AdminDto>(Helpers.Request.Get(Mutuals.ApiUrl + "Web/Getuser?user=" + user + "&pass=" + pass ));

            if (model == null)
                return Json("false");
            else
                return Json("true");
        }
    }
}
