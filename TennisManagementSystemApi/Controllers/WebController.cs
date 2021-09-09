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

        TennisManagerDBContext db = new TennisManagerDBContext();

        [HttpGet("Getuser", Name = "Getuser")]
        public Admin Getuser(string user, string pass)
        {
            Admin model = new Admin();

            using (TennisManagerDBContext db = new TennisManagerDBContext())
            {
                model = db.Admins.SingleOrDefault(x => x.Username == user && x.Password == pass);
            }

            return model;
        }

        [HttpGet("GetCompanySettings", Name = "GetCompanySettings")]
        public List<CompanySetting> GetCompanySettings()
        {
            List<CompanySetting> model = new List<CompanySetting>();
            {
                model = db.CompanySettings.ToList();
            }
            return model;
        }


        [HttpGet("GetCheckList", Name = "GetCheckList")]
        public JsonResult GetCheckList(string trueStr)
        {
          
            List<CompanySetting> model = new List<CompanySetting>();
            List<int> idList = new List<int>();
            List<string> activeAuth = new List<string>();

            List<string> trueList = new List<string>(trueStr.Split("-").ToArray());

            model = db.CompanySettings.ToList();


            foreach (var item in model)
            {
                idList.Add(item.Id);
            }

            foreach (var item in idList)
            {
                activeAuth.Clear();

                for (int x = 0; x < trueList.Count(); x++)
                {
                    if (item == Convert.ToInt32(trueList[x].Split("_")[1]))
                    {
                        activeAuth.Add(trueList[x].Split("_")[0]);
                    }
                }

                CompanySetting cs = db.CompanySettings.FirstOrDefault(x => x.Id == item);

                try
                {

                    if (cs != null)
                    {
                        for (int i = 0; i < activeAuth.Count; i++)
                        {

                            if (activeAuth.Contains("m1"))
                                cs.M1 = true;
                            else
                                cs.M1 = false;

                            if (activeAuth.Contains("m2"))
                                cs.M2 = true;
                            else
                                cs.M2 = false;

                            if (activeAuth.Contains("m3"))
                                cs.M3 = true;
                            else
                                cs.M3 = false;
                            if (activeAuth.Contains("m4"))
                                cs.M4 = true;
                            else
                                cs.M4 = false;
                            if (activeAuth.Contains("m5"))
                                cs.M5 = true;
                            else
                                cs.M5 = false;
                            if (activeAuth.Contains("m6"))
                                cs.M6 = true;
                            else
                                cs.M6 = false;

                            db.Update(cs);
                            db.SaveChanges();

                        }

                    }
                   
                }
                catch (Exception ex)
                {

                    Mutuals.monitizer.AddException(ex);
                }

            }

            return Json(model);
        }

    }
}
