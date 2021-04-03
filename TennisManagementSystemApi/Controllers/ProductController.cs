using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisManagementSystemApi.Models;

namespace TennisManagementSystemApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        [HttpGet("GetMySettings", Name = "GetMySettings")]
        public CompanySetting GetMySettings(string MyIp)
        {
            CompanySetting model = new CompanySetting();
            try
            {
                using (TennisManagerDBContext db = new TennisManagerDBContext())
                {
                    model = db.CompanySettings.SingleOrDefault(x => x.SunucuIp.Trim() == MyIp.Trim());
                }
                if (model == null)
                    model = new CompanySetting();
            }
            catch (Exception e)
            {
                model = new CompanySetting();
                Mutuals.monitizer.AddException(e);
            }

            return model;
        }
    }
}
