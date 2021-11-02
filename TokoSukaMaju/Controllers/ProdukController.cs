using System.Web.Mvc;
using TokoSukaMaju.Models;
using TokoSukaMaju.Repository;

namespace TokoSukaMaju.Controllers
{
    public class ProdukController : Controller
    {
        readonly ProdukRepo repo = new ProdukRepo();
        // GET: Produk
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetListProduk()
        {
            var result = repo.GetListProduk();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetProduk(int id)
        {
            var result = repo.GetProduk(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddProduk(Produk produk)
        {
            var result = repo.AddProduk(produk);
            return Json(result);
        }

        [HttpPost]
        public ActionResult UpdateProduk(Produk produk)
        {
            var result = repo.UpdateProduk(produk);
            return Json(result);
        }

        [HttpPost]
        public ActionResult DeleteProduk(int id)
        {
            var result = repo.DeleteProduk(id);
            return Json(result);
        }
    }
}