using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomaston.Models.Siniflar;

namespace OnlineTicariOtomaston.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman

        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Departmans.Where(x=>x.Durum == true).ToList();
            return View(degerler);
        }

        [HttpGet]

        public ActionResult DepartmanEkle()

        {
            return View();
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        {
            c.Departmans.Add(d);
            d.Durum= true;
            c.SaveChanges();
            return  RedirectToAction("Index");


        }

        public ActionResult DepartmanSil(int id)
        {
            var dep = c.Departmans.Find(id);
            dep.Durum= false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGetir(int id) 
        {
            var dep = c.Departmans.Find(id);
            return View("DepartmanGetir" , dep);

        }

        public ActionResult DepartmanGuncelle(Departman d)
        {
            var dpt = c.Departmans.Find(d.DepartmanId);
            dpt.DepartmanAd = d.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");
            
        }
        public ActionResult DepartmanDetay(int id)
        {
            var degerler = c.Personels.Where(x => x.Departmanid == id).ToList();
            var dpt = c.Departmans.Where(x=>x.DepartmanId== id).Select(y=>y.DepartmanAd).FirstOrDefault();
            ViewBag.d = dpt;
           

            return View(degerler);
        }

        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.Personelid == id).ToList();
            var baslikdep = c.Departmans.Where(x => x.DepartmanId == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.dpers = baslikdep;
            return View(degerler);

        }
    }
}