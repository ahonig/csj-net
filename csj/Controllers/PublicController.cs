using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using csj.Models;

namespace csj.Controllers
{
    public class PublicController : Controller
    {
        public ActionResult Index(string id)
        {
            csj.csjEntityPersona pe = new csj.csjEntityPersona();
            csj.csjEntityCarnet ca = new csj.csjEntityCarnet();
            csj.csjEntityProfesional pr = new csj.csjEntityProfesional();
            csj.csjEntityProfesionalTipo pt = new csj.csjEntityProfesionalTipo();

            ViewData["carnet"] = null;
            ViewData["persona"] = null;
            ViewData["profesional"] = null;
            ViewData["profesionalTipo"] = null;

            var carnet = ca.carnet.FirstOrDefault(c => c.carnet_qr == id);
            if (carnet != null)
            {
                var persona = pe.persona.FirstOrDefault(a => a.persona_id == carnet.persona_id);
                var profesional = pr.profesional.FirstOrDefault(p => p.persona_id == carnet.persona_id && p.profesional_tipo_id == carnet.profesional_tipo_id);
                var profesionalTipo = pt.profesional_tipo.FirstOrDefault(t => t.id == carnet.profesional_tipo_id);
                ViewData["persona"] = persona;
                ViewData["carnet"] = carnet;
                ViewData["profesional"] = profesional;
                ViewData["profesionalTipo"] = profesionalTipo;
            }

            return View();
        }


    }
}
