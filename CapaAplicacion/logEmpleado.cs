using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;

namespace CapaAplicacion
{
    public class logEmpleado
    {
        #region singleton
        private static readonly logEmpleado UnicaInstancia = new logEmpleado();

        public static logEmpleado Instancia
        {
            get
            {
                return logEmpleado.UnicaInstancia;
            }
        }
        #endregion singleton

        #region metodos
        public entEmpleado VerificarEmpleado(string usuario, string contrasena)
        {
            try
            {
                return datEmpleado.Instancia.VerificarEmpleado(usuario, contrasena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<entEmpleado> ListarEmpleado()
        {
            try
            {
                return datEmpleado.Instancia.ListarEmpleado();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public entEmpleado BuscarEmpleado(int idEmpleado)
        {
            try
            {
                return datEmpleado.Instancia.BuscarEmpleado(idEmpleado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean InsertarEmpleado(entEmpleado p)
        {
            try
            {
                return datEmpleado.Instancia.InsertarEmpleado(p);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Boolean EditarEmpleado(entEmpleado e)
        {
            try
            {
                return datEmpleado.Instancia.EditarEmpleado(e);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean EliminarEmpleado(int idEmpleado)
        {
            try
            {
                return datEmpleado.Instancia.EliminarEmpleado(idEmpleado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion metodos

    }
}
