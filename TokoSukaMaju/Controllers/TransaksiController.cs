using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TokoSukaMaju.Models;
using TokoSukaMaju.Repository;

namespace TokoSukaMaju.Controllers
{
    public class TransaksiController : Controller
    {
        readonly TransaksiRepo repo = new TransaksiRepo();
        // GET: Transaksi
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetTransaksis()
        {
            var result = repo.GetTransaksis();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddTransaksi(TransaksiHeader transaksi)
        {
            var result = repo.AddTransaksi(transaksi);
            return Json(result);
        }

        public ActionResult GetDetailTransaksi(string id)
        {
            var header = repo.TransaksiHeader(id);
            var detail = repo.TransaksiDetails(id);
            return Json(new { header, detail}, JsonRequestBehavior.AllowGet);
        }
    }
}