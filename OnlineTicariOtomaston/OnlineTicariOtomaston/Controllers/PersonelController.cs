using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomaston.Models.Siniflar;

namespace OnlineTicariOtomaston.Controllers
{
    public class PersonelController : Controller
    {
        
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Personels.ToList();
            return View(degerler);
        }

        [HttpGet]

        public ActionResult PersonelEkle() 
        {
            List<SelectListItem> list = (from x in c.Departmans.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.DepartmanAd,
                                             Value = x.DepartmanId.ToString()
                                         }).ToList();

            ViewBag.dgr1 = list;
            return View();
        }

        [HttpPost]

        public ActionResult PersonelEkle(Personel p) 
        {
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> list = (from x in c.Departmans.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.DepartmanAd,
                                             Value = x.DepartmanId.ToString()
                                         }).ToList();

            ViewBag.dgr1 = list;
            var prs = c.Personels.Find(id);
            return View("PersonelGetir" , prs);

        }
        public ActionResult PersonelGuncelle(Personel p)
        {
            var prsn = c.Personels.Find(p.PersonelId);
            prsn.PersonelAd= p.PersonelAd;
            prsn.PersonelSoyad= p.PersonelSoyad;
            prsn.PersonelGorsel= p.PersonelGorsel;
            prsn.Departmanid= p.Departmanid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}