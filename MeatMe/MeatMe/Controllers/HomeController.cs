﻿using MeatMe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeatMe.CustomAttributes;

namespace MeatMe.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {

        private FinalProjectDBEntities1 db = new FinalProjectDBEntities1();

        public ActionResult Index()
        {
            var onlyCow = from c in db.CutNames
                          where c.PrimalCut.Animal.AnimalName== "Cow"
                          select c;
            var onlyPig = from p in db.CutNames
                          where p.PrimalCut.Animal.AnimalName == "Pig"
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
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Search(string searchTerm)
        {
            if (String.IsNullOrEmpty(searchTerm))
            {
                return RedirectToAction("Index","CutName");
            }
            else
            {
                // if the search contains only one result return details
                // otherwise a list
                var cutName = from a in db.CutNames
                              where a.CutName1.Contains(searchTerm)
                              orderby a.CutName1
                              select a;
                var alCutName = from b in db.AltNames
                                where b.AltName1.Contains(searchTerm)
                                orderby b.AltName1
                                select b;
                var primeCutName = from p in db.PrimalCuts
                                   where p.PrimalCutName.Contains(searchTerm)
                                   select p;

                if (cutName.Count() == 0 && alCutName.Count()==0 && primeCutName.Count()==0)
                {
                    
                    return View("NotFound");
                }
           
                else if (cutName.Count() == 1 && alCutName.Count()==0)
                {
                    return RedirectToAction("Details", "CutName",
                        new { id = cutName.First().CutId });
                }
                else if(cutName.Count()==0 && alCutName.Count()==1)
                {
                    return RedirectToAction("Details", "CutName", new { id = alCutName.First().CutId });
                }

                else 
                {
                    return RedirectToAction("Index", "CutName",
                        new { id=searchTerm });
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