using Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisManagementSystemApi.Mapping;
using TennisManagementSystemApi.Models;

namespace TennisManagementSystemApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WebController : Controller
    {
        [HttpGet("Getuser", Name = "Getuser")]
        public Admin Getuser(string user, string pass)
        {
            Admin model = new Admin();

            using( TennisManagerDBContext db = new TennisManagerDBContext())
            {
                model = db.Admins.SingleOrDefault(x => x.Username == user && x.Password == pass); 
            }

            return model;
        }

        [HttpGet("GetCompanySettings", Name = "GetCompanySettings")]
        public List<CompanySetting> GetCompanySettings()
        {
            List<CompanySetting> model = new List<CompanySetting>();

            using (TennisManagerDBContext db = new TennisManagerDBContext())
            {
                model = db.CompanySettings.ToList();
            }
            return model;
        }

    }
}
