using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace voxpopuliAPI.Controllers
{
    public class IndicadorController : Controller
    {
        public ActionResult Index(string CampaniaId)
        {
            ViewBag.Title = "Indicadores";
            ViewData["CampaniaId"] = CampaniaId;
            return View();
        }
    }
}
