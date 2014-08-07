using MeatMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeatMe.Controllers
{
    public class HomeController : Controller
    {

        private FinalProjectDBEntities1 db = new FinalProjectDBEntities1();

        public ActionResult Index()
        {
            var onlyCow = from c in db.CutNames
                          where c.PrimalCut.AnimalId == 1
                          select c;
            var onlyPig = from p in db.CutNames
                          where p.PrimalCut.AnimalId == 2
                          select p;
            ViewBag.Cow = new SelectList(onlyCow, "CutId", "CutName1");
            ViewBag.Pig = new SelectList(onlyPig, "CutId", "CutName1");
            return View();
        }
        public ActionResult Go(string Cow)
        {
            int goHere=Convert.ToInt32(Cow);            
            return RedirectToAction("Details","CutName",new{id=goHere});
        }
        public ActionResult Go2(string Pig)
        {
            int goHere = Convert.ToInt32(Pig);
            return RedirectToAction("Details", "CutName", new { id = goHere });
        }
        //Added code for search database
        public ActionResult getAjaxResult(string q)
        {

            string searchResult = string.Empty;

            var cutName = (from a in db.CutNames
                           where a.CutName1.Contains(q)
                           orderby a.CutName1
                           select a).Take(10);

            foreach (CutName a in cutName)
            {
                searchResult += string.Format("{0}|\r\n", a.CutName1);
            }

            return Content(searchResult);
        }
        //-------------------------------------
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Search(string searchTerm)
        {
            if (searchTerm == string.Empty)
            {
                return View();
            }
            else
            {
                // if the search contains only one result return details
                // otherwise a list
                var cutName = from a in db.CutNames
                              where a.CutName1.Contains(searchTerm)
                              orderby a.CutName1
                              select a;

                if (cutName.Count() == 0)
                {
                    return View("notfound");
                }
                else
                {
                    return RedirectToAction("Details", "CutName",
                        new { id = cutName.First().CutId });
                }

                
            }

            //return View("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}