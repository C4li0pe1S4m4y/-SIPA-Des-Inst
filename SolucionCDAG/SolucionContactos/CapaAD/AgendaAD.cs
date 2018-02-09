using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using CapaEN;

namespace CapaAD
{
    public class AgendaAD
    {
        ConexionBD conectar;

        public DataTable AlmacenarContacto(ContactosEN ObjEN)
       {
           conectar = new ConexionBD();
           DataTable dt = new DataTable();

           ObjEN.NOMBRE = "'" + ObjEN.NOMBRE + "'";
           ObjEN.CUI = "'" + ObjEN.CUI + "'";
           ObjEN.NIT = "'" + ObjEN.NIT + "'";
           ObjEN.GENERO = "'" + ObjEN.GENERO + "'";
           ObjEN.DIRECCION = "'" + ObjEN.DIRECCION + "'";
           ObjEN.TELEFONO_RESIDENCIAL = "'" + ObjEN.TELEFONO_RESIDENCIAL + "'";
           ObjEN.TELEFONO_CELULAR = "'" + ObjEN.TELEFONO_CELULAR + "'";
           ObjEN.TELEFONO_TRABAJO = "'" + ObjEN.TELEFONO_TRABAJO + "'";
           ObjEN.EMAIL_PERSONAL = "'" + ObjEN.EMAIL_PERSONAL + "'";
           ObjEN.EMAIL_TRABAJO = "'" + ObjEN.EMAIL_TRABAJO + "'";
           ObjEN.OBSERVACIONES = "'" + ObjEN.OBSERVACIONES + "'";
           ObjEN.ESTADO = "'" + ObjEN.ESTADO + "'";
           ObjEN.USUARIO = "'" + ObjEN.USUARIO + "'";

           ObjEN.NOMBRE = ObjEN.NOMBRE.Replace("''", "null");
           ObjEN.CUI = ObjEN.CUI.Replace("''", "null");
           ObjEN.NIT = ObjEN.NIT.Replace("''", "null");
           ObjEN.DIRECCION = ObjEN.DIRECCION.Replace("''", "null");
           ObjEN.TELEFONO_RESIDENCIAL = ObjEN.TELEFONO_RESIDENCIAL.Replace("''", "null");
           ObjEN.TELEFONO_CELULAR = ObjEN.TELEFONO_CELULAR.Replace("''", "null");
           ObjEN.TELEFONO_TRABAJO = ObjEN.TELEFONO_TRABAJO.Replace("''", "null");
           ObjEN.EMAIL_PERSONAL = ObjEN.EMAIL_PERSONAL.Replace("''", "null");
           ObjEN.EMAIL_TRABAJO = ObjEN.EMAIL_TRABAJO.Replace("''", "null");
           ObjEN.OBSERVACIONES = ObjEN.OBSERVACIONES.Replace("''", "null");
           ObjEN.ESTADO = ObjEN.ESTADO.Replace("''", "null");
           ObjEN.USUARIO = ObjEN.USUARIO.Replace("''", "null");

           string query = "CALL sp_iue_contactos(" + ObjEN.ID_CONTACTO + ", " + ObjEN.NOMBRE + ", " + ObjEN.CUI + ", " + ObjEN.NIT + ", " + ObjEN.GENERO + ", " + ObjEN.DIRECCION + ", " + ObjEN.TELEFONO_RESIDENCIAL + ", " + ObjEN.TELEFONO_CELULAR + ", " + ObjEN.TELEFONO_TRABAJO + ", " + ObjEN.OBSERVACIONES + ", " + ObjEN.EMAIL_PERSONAL + ", " + ObjEN.EMAIL_TRABAJO + ", " + ObjEN.ESTADO + ", " + ObjEN.USUARIO + ", 1);";
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(dt);
           conectar.CerrarConexion();
           return dt;
       }

       public DataTable AlmacenarCaso(CasosEN ObjEN)
       {
           conectar = new ConexionBD();
           DataTable dt = new DataTable();

           ObjEN.NOMBRE = "'" + ObjEN.NOMBRE + "'";
           ObjEN.DESCRIPCION = "'" + ObjEN.DESCRIPCION + "'";
           ObjEN.FECHA_APERTURA = "'" + ObjEN.FECHA_APERTURA + "'";
           ObjEN.FECHA_FINALIZACION = "'" + ObjEN.FECHA_FINALIZACION + "'";
           ObjEN.OBSERVACIONES = "'" + ObjEN.OBSERVACIONES + "'";
           ObjEN.ESTADO = "'" + ObjEN.ESTADO + "'";
           ObjEN.USUARIO = "'" + ObjEN.USUARIO + "'";

           ObjEN.NOMBRE = ObjEN.NOMBRE.Replace("''", "null");
           ObjEN.DESCRIPCION = ObjEN.DESCRIPCION.Replace("''", "null");
           ObjEN.FECHA_APERTURA = ObjEN.FECHA_APERTURA.Replace("''", "null");
           ObjEN.FECHA_FINALIZACION = ObjEN.FECHA_FINALIZACION.Replace("''", "null");
           ObjEN.OBSERVACIONES = ObjEN.OBSERVACIONES.Replace("''", "null");
           ObjEN.ESTADO = ObjEN.ESTADO.Replace("''", "null");
           ObjEN.USUARIO = ObjEN.USUARIO.Replace("''", "null");

           string query = "CALL sp_iue_casos(" + ObjEN.ID_CASO + ", " + ObjEN.NOMBRE + ", " + ObjEN.DESCRIPCION + ", " + ObjEN.ID_TIPO_CASO + ", " + ObjEN.FECHA_APERTURA + ", " + ObjEN.FECHA_FINALIZACION + ", " + ObjEN.OBSERVACIONES + ", " + ObjEN.ESTADO + ", " + ObjEN.USUARIO + ", 1);";
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(dt);
           conectar.CerrarConexion();
           return dt;
       }

       public DataTable AlmacenarTipoCaso(TiposCasosEN ObjEN)
       {
           conectar = new ConexionBD();
           DataTable dt = new DataTable();

           ObjEN.NOMBRE = "'" + ObjEN.NOMBRE + "'";
           ObjEN.DESCRIPCION = "'" + ObjEN.DESCRIPCION + "'";
           ObjEN.ESTADO = "'" + ObjEN.ESTADO + "'";
           ObjEN.USUARIO = "'" + ObjEN.USUARIO + "'";

           ObjEN.NOMBRE = ObjEN.NOMBRE.Replace("''", "null");
           ObjEN.DESCRIPCION = ObjEN.DESCRIPCION.Replace("''", "null");
           ObjEN.ESTADO = ObjEN.ESTADO.Replace("''", "null");
           ObjEN.USUARIO = ObjEN.USUARIO.Replace("''", "null");

           string query = "CALL sp_iue_tipos_casos(" + ObjEN.ID_TIPO_CASO + ", " + ObjEN.NOMBRE + ", " + ObjEN.DESCRIPCION + ", " + ObjEN.ESTADO + ", " + ObjEN.USUARIO + ", 1);";
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(dt);
           conectar.CerrarConexion();
           return dt;
       }

       public DataTable AlmacenarAsignacionCaso(AsignacionCasosEN ObjEN)
       {
           conectar = new ConexionBD();
           DataTable dt = new DataTable();

           ObjEN.OBSERVACIONES = "'" + ObjEN.OBSERVACIONES + "'";
           ObjEN.ESTADO = "'" + ObjEN.ESTADO + "'";
           ObjEN.USUARIO = "'" + ObjEN.USUARIO + "'";

           ObjEN.OBSERVACIONES = ObjEN.OBSERVACIONES.Replace("''", "null");
           ObjEN.ESTADO = ObjEN.ESTADO.Replace("''", "null");
           ObjEN.USUARIO = ObjEN.USUARIO.Replace("''", "null");

           string query = "CALL sp_iue_asignaciones(" + ObjEN.ID_ASIGNACION + ", " + ObjEN.ID_CONTACTO + ", " + ObjEN.ID_CASO + ", " + ObjEN.OBSERVACIONES + ", " + ObjEN.ESTADO + ", " + ObjEN.USUARIO + ", 1);";
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(dt);
           conectar.CerrarConexion();
           return dt;
       }
       public DataTable EliminarAsignacion(int id, string usuario)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = "CALL sp_iue_asignaciones(" + id + ", 0, 0, null, null, '" + usuario + "', 2);";
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable InformacionContactos(int id, int id2, string criterio, int opcion)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = String.Format("CALL sp_slctContactos({0}, {1}, '{2}', {3});", id, id2, criterio, opcion);
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable InformacionCasos(int id, int id2, string criterio, int opcion)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = String.Format("CALL sp_slctCasos({0}, {1}, '{2}', {3});", id, id2, criterio, opcion);
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable InformacionTiposCasos(int id, int id2, string criterio, int opcion)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = String.Format("CALL sp_slctTiposCasos({0}, {1}, '{2}', {3});", id, id2, criterio, opcion);
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable InformacionAsignaciones(int id, int id2, string criterio, int opcion)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           string query = String.Format("CALL sp_slctAsignaciones({0}, {1}, '{2}', {3});", id, id2, criterio, opcion);
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }
       
       private DataSet armarDsResultado()
       {
           DataSet ds = new DataSet();
           DataTable dt = new DataTable("RESULTADO");

           dt.Columns.Add("ERRORES", typeof(String));
           dt.Columns.Add("MSG_ERROR", typeof(String));
           dt.Columns.Add("VALOR", typeof(String));
           dt.Columns.Add("CODIGO", typeof(String));
           ds.Tables.Add(dt);

           DataRow dr = ds.Tables[0].NewRow();
           ds.Tables[0].Rows.Add(dr);
           ds.Tables[0].Rows[0]["ERRORES"] = true;
           ds.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
           return ds;
       }
    }
}
