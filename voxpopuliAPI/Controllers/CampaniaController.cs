using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace voxpopuliAPI.Controllers
{
    public class CampaniaController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Campañas";

            return View();
        }

        public ActionResult Indicador(string CampaniaId)
        {
            ViewBag.Title = "Campañas";
            //Request.QueryString["type"];
            return RedirectToAction("Index", "Indicador", new { CampaniaId = CampaniaId });
        }
    }
}
