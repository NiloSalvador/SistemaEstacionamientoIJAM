using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidades;
using CapaAplicacion;
using System.Net.Configuration;

namespace CapaPresentacion.Controllers
{
    public class EmpleadoController : Controller
    {
        [Filtros.SesionIntranetController]
        [HttpGet]
        public ActionResult Lista(String msg)
        {
            try
            {
                ViewBag.mensaje = msg;
                List<entEmpleado> lista = logEmpleado.Instancia.ListarEmpleado();
                return View(lista);
            }
            catch (Exception e)
            {
                return RedirectToAction("MenuPrincipal", "Intranet", new { msg = "Ocurrió un error inesperado" });
            }
        }

        [Filtros.SesionIntranetController]
        [HttpGet]
        public ActionResult Insertar(String msg)
        {
            try
            {
                ViewBag.mensaje = msg;
                return View();
            }
            catch (Exception e)
            {
                return RedirectToAction("Lista", "Empleado", new { msg = e.Message });
            }
        }

        [Filtros.SesionIntranetController]
        [HttpPost]
        public ActionResult Insertar(FormCollection formulario)
        {
            try
            {
                Boolean inserto = false;
                entEmpleado e = new entEmpleado();
                e.nombres = Convert.ToString(formulario["txtNombres"]);
                e.apellidos = Convert.ToString(formulario["txtApellidos"]);
                e.documentoIdentidad = Convert.ToString(formulario["txtDocumentoIdentidad"]);
                e.tipoDocumentoIdentidad = Convert.ToString(formulario["txtTipoDocumentoIdentidad"]);
                e.celular = Convert.ToString(formulario["txtCelular"]);
                e.correo = Convert.ToString(formulario["txtCorreo"]);
                e.sexo = Convert.ToString(formulario["txtSexo"]);
                e.fechaNacimiento = Convert.ToDateTime(formulario["txtFechaNacimiento"]);
                e.cargo = Convert.ToString(formulario["txtCargo"]);
                e.usuario = Convert.ToString(formulario["txtUsuario"]);
                e.contrasena = Convert.ToString(formulario["txtContrasena"]);

                inserto = logEmpleado.Instancia.InsertarEmpleado(e);
                if (inserto)
                {
                    return RedirectToAction("Lista", "Empleado");
                }else{
                    return View(formulario);
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("Lista", "Empleado", new { msg = e.Message });
            }
        }


        [Filtros.SesionIntranetController]
        [HttpGet]
        public ActionResult Editar(int idEmpleado)
        {
            try
            {
                entEmpleado e = new entEmpleado();
                e = logEmpleado.Instancia.BuscarEmpleado(idEmpleado);
                return View(e);
            }
            catch (Exception e)
            {
                return RedirectToAction("Lista", "Empleado", new { msg = e.Message });
            }
        }

        [Filtros.SesionIntranetController]
        [HttpPost]
        public ActionResult Editar(FormCollection formulario)
        {
            try
            {
                Boolean inserto = false;
                entEmpleado e = new entEmpleado();
                e.idEmpleado = Convert.ToInt32(formulario["txtIdEmpleado"]);
                e.nombres = Convert.ToString(formulario["txtNombres"]);
                e.apellidos = Convert.ToString(formulario["txtApellidos"]);
                e.documentoIdentidad = Convert.ToString(formulario["txtDocumentoIdentidad"]);
                e.tipoDocumentoIdentidad = Convert.ToString(formulario["txtTipoDocumentoIdentidad"]);
                e.celular = Convert.ToString(formulario["txtCelular"]);
                e.correo = Convert.ToString(formulario["txtCorreo"]);
                e.sexo = Convert.ToString(formulario["txtSexo"]);
                e.fechaNacimiento = Convert.ToDateTime(formulario["txtFechaNacimiento"]);
                e.cargo = Convert.ToString(formulario["txtCargo"]);
                e.usuario = Convert.ToString(formulario["txtUsuario"]);
                e.contrasena = Convert.ToString(formulario["txtContrasena"]);

                inserto = logEmpleado.Instancia.EditarEmpleado(e);
                if (inserto)
                {
                    return RedirectToAction("Lista", "Empleado");
                }
                else
                {
                    return View(formulario);
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("Lista", "Empleado", new { msg = e.Message });
            }
        }

        [Filtros.SesionIntranetController]
        [HttpGet]
        public ActionResult Eliminar(int idEmpleado)
        {
            try
            {
                Boolean elimino = false;
                elimino = logEmpleado.Instancia.EliminarEmpleado(idEmpleado);
                if (elimino)
                {
                    return RedirectToAction("Lista", "Empleado");
                }
                else
                {
                    return RedirectToAction("MenuPrincipal", "Intranet");
                }
            }
            catch (Exception e)
            {
                return RedirectToAction("Lista", "Empleado", new { msg = e.Message });
            }
        }
    }
}