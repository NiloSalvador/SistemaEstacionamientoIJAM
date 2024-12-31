using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidades;
using CapaAplicacion;

namespace CapaPresentacion.Controllers
{
    public class IntranetController : Controller
    {
        [HttpGet]
        public ActionResult InicioSesion(String msg)
        {
            Session["Empleado"] = null;
            ViewBag.mensaje = msg;
            return View();
        }

        [HttpPost]
        public ActionResult InicioSesion(FormCollection formulario)
        {
            try
            {
                String usuario = Convert.ToString(formulario["txtusuario"]);
                String contransena = Convert.ToString(formulario["txtcontrasena"]);
                entEmpleado e = logEmpleado.Instancia.VerificarEmpleado(usuario, contransena);
                if (e != null)
                {
                    Session["Empleado"] = e;
                    return View("MenuPrincipal");
                }
                else
                {
                    return RedirectToAction("InicioSesion", "Intranet", new { msg = "Usuario y/o contraseña incorrectos" });
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("InicioSesion", "Intranet", new { msg = ex.Message });
            }
        }

        [Filtros.SesionIntranetController]
        public ActionResult MenuPrincipal()
        {
            return View();
        }
    }
}