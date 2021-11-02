using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TokoSukaMaju.Models;
using TokoSukaMaju.Repository;

namespace TokoSukaMaju.Controllers
{
    public class PelangganController : Controller
    {
        readonly PelangganRepo repo = new PelangganRepo();
        // GET: Pelanggan
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetListPelanggan()
        {
            var result = repo.GetListPelanggan();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetPelangganBy(int id)
        {
            var result = repo.GetPelanggan(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddPelanggan(Pelanggan pelanggan)
        {
            var result = repo.AddPelanggan(pelanggan);
            return Json(result);
        }

        [HttpPost]
        public ActionResult DeletePelanggan(int id)
        {
            var result = repo.DeletePelanggan(id);
            return Json(result);
        }

        [HttpPost]
        public ActionResult UpdatePelanggan(Pelanggan pelanggan)
        {
            var result = repo.UpdatePelanggan(pelanggan);
            return Json(result);
        }
    }
}