using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CapaEntidades;
using System.Data;

namespace CapaDatos
{
    public class datEmpleado
    {
        #region Singleton
        private static readonly datEmpleado UnicaInstancia = new datEmpleado();

        public static datEmpleado Instancia
        {
            get
            {
                return datEmpleado.UnicaInstancia;
            }
        }
        #endregion Singleton

        #region Metodos CRUD
        public entEmpleado verificarEmpleado(string usuario, string contrasena)
        {
            entEmpleado e = null;
            SqlCommand cmd = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spVerificarEmpleado", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmUsuario", usuario);
                cmd.Parameters.AddWithValue("@prmContrasena", contrasena);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    e = new entEmpleado();
                    e.idEmpleado = Convert.ToInt32(dr["idEmpleado"]);
                    e.nombres = Convert.ToString(dr["nombres"]);
                    e.apellidos = Convert.ToString(dr["apellidos"]);
                    e.documentoIdentidad = Convert.ToString(dr["documentoIdentidad"]);
                    e.tipoDocumentoIdentidad = Convert.ToString(dr["tipoDocumentoIdentidad"]);
                    e.celular = Convert.ToString(dr["celular"]);
                    e.correo = Convert.ToString(dr["correo"]);
                    e.sexo = Convert.ToString(dr["sexo"]);
                    e.fechaNacimiento = Convert.ToDateTime(dr["fechaNacimiento"]);
                    e.cargo = Convert.ToString(dr["cargo"]);
                    e.estado = Convert.ToString(dr["estado"]);
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return e;
        }

        public List<entEmpleado> ListarEmpleado()
        {
            SqlCommand cmd = null;
            List<entEmpleado> lista = new List<entEmpleado>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //Conexion a la base de datos
                cmd = new SqlCommand("spListarEmpleados", cn);  //Consulta a la base de datos
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entEmpleado p = new entEmpleado();
                    p.idEmpleado = Convert.ToInt32(dr["identEmpleado"]);
                    p.nombres = Convert.ToString(dr["nombre"]);
                    p.apellidos = Convert.ToString(dr["marca"]);
                    p.documentoIdentidad = Convert.ToString(dr["cantidad"]);
                    p.tipoDocumentoIdentidad = Convert.ToString(dr["precio"]);
                    p.celular = Convert.ToString(dr["descripcion"]);
                    p.correo = Convert.ToString(dr["estado"]);
                    lista.Add(p);
                }
                cn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return lista;
        }

        public entEmpleado BuscarEmpleado(int idEmpleado)
        {
            SqlCommand cmd = null;
            entEmpleado p = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //Conexion a la base de datos
                cmd = new SqlCommand("spBuscarEmpleado", cn);  //Consulta a la base de datos
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmidEmpleado", idEmpleado);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    p = new entEmpleado();
                    
                    p.nombres = Convert.ToString(dr["nombre"]);
                    p.apellidos = Convert.ToString(dr["marca"]);
                    p.documentoIdentidad = Convert.ToString(dr["cantidad"]);
                    p.tipoDocumentoIdentidad = Convert.ToString(dr["precio"]);
                    p.celular = Convert.ToString(dr["descripcion"]);
                    p.correo = Convert.ToString(dr["estado"]);
                }
                cn.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return p;
        }



        #endregion Metodos
    }
}
