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
    public class PacAD
    {
        ConexionBD conectar;
        public DataTable datosPoa(PacEN pacEN)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsDatosPoa ({0},{1})", pacEN.idUnidad, pacEN.anio);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable dropAccionPoa(PacEN pacEN)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsUsuarioDependencia ('{0}');", pacEN.usuario);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable dropNoPac(PacEN pacEN)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsNoPac ({0});", pacEN.idDetalleAccion);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable datosDetalleAccion(PacEN pacEN)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsSaldoPac ({0},{1});", pacEN.idAccion, 1);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable datosIdDetalleAccion(PacEN pacEN)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsSaldoPac ({0},{1});", pacEN.idDetalleAccion, 3);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable PacListado(PacEN pacEN)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsPacListado ('{0}');", pacEN.usuario);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public int maxidPac()
        {
            int idPac = 0;
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsMaxidPac");
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            if (tabla.Rows.Count > 0)
            {
                idPac = Convert.ToInt32(tabla.Rows[0]["idPac"]);
            }
            else
            {
                idPac = 0;
            }
            return idPac;
        }

        public double saldoPac(PacEN pacEN)
        {
            double saldo;
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsSaldoPac ({0},{1});", pacEN.idDetalleAccion, 2);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            if (tabla.Rows.Count > 0)
            {
                saldo = Convert.ToDouble(tabla.Rows[0]["saldoPac"]);
            }
            else
            {
                saldo = 0;
            }
            return saldo;

        }
        public double montoActualPac(PacEN pacEN)
        {
            double saldo;
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsPacMontoActual ({0});", pacEN.idPac);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            if (tabla.Rows.Count > 0)
            {
                saldo = Convert.ToDouble(tabla.Rows[0]["monto"]);
            }
            else
            {
                saldo = 0;
            }
            return saldo;
        }


        public double codificadoPacPac(PacEN pacEN)
        {
            double saldo;
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsSaldoPac ({0},{1});", pacEN.idPac, 4);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            if (tabla.Rows.Count > 0)
            {
                saldo = Convert.ToDouble(tabla.Rows[0]["CodificadoPac"]);
            }
            else
            {
                saldo = 0;
            }
            return saldo;
        }

        public double saldoPacPac(PacEN pacEN)
        {
            double saldo;
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsSaldoPac ({0},{1});", pacEN.idPac, 4);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            if (tabla.Rows.Count > 0)
            {
                saldo = Convert.ToDouble(tabla.Rows[0]["saldoPac"]);
            }
            else
            {
                saldo = 0;
            }
            return saldo;
        }

        public DataTable dropUnidadesUsuario(PacEN pacEN)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsUnidadesUsuario ('{0}')", pacEN.usuario);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable dropExcepcion()
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = "call clsPacExcepcion";
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable dropModalidad()
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = "call clsPacModalidad";
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable datosPac(PacEN pacEN)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsPacDatos ({0})", pacEN.idPac);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable datosPacDetalle(PacEN pacEN)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call ClsPacDetalleDatos ({0})", pacEN.idPac);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public int InsertarPac(PacEN pacEN)
        {
            int NoIngreso;
            conectar = new ConexionBD();
            MySqlCommand procedimiento = new MySqlCommand("Insertar_Pac");
            procedimiento.CommandType = CommandType.StoredProcedure;
            procedimiento.Parameters.AddWithValue("idDa", pacEN.idDetalleAccion);
            procedimiento.Parameters.AddWithValue("idm", pacEN.idModalidad);
            procedimiento.Parameters.AddWithValue("ide", pacEN.idExcepcion);
            procedimiento.Parameters.AddWithValue("des", pacEN.descripcion);
            procedimiento.Parameters.AddWithValue("usr", pacEN.usuario);
            conectar.AbrirConexion();
            procedimiento.Connection = conectar.conectar;
            NoIngreso = procedimiento.ExecuteNonQuery();
            conectar.CerrarConexion();
            return NoIngreso;
        }
        public int ModificarPac(PacEN pacEN)
        {
            int NoIngreso;
            conectar = new ConexionBD();
            MySqlCommand procedimiento = new MySqlCommand("Modifcar_Pac");
            procedimiento.CommandType = CommandType.StoredProcedure;
            procedimiento.Parameters.AddWithValue("idp", pacEN.idPac);
            procedimiento.Parameters.AddWithValue("idm", pacEN.idModalidad);
            procedimiento.Parameters.AddWithValue("ide", pacEN.idExcepcion);
            procedimiento.Parameters.AddWithValue("des", pacEN.descripcion);
            procedimiento.Parameters.AddWithValue("usr", pacEN.usuario);
            conectar.AbrirConexion();
            procedimiento.Connection = conectar.conectar;
            NoIngreso = procedimiento.ExecuteNonQuery();
            conectar.CerrarConexion();
            return NoIngreso;
        }
        public int InsertarPacDetalle(PacEN pacEN)
        {
            int NoIngreso;
            conectar = new ConexionBD();
            MySqlCommand procedimiento = new MySqlCommand("Insertar_PacDetalle");
            procedimiento.CommandType = CommandType.StoredProcedure;
            procedimiento.Parameters.AddWithValue("idP", pacEN.idPac);
            procedimiento.Parameters.AddWithValue("me", pacEN.mes);
            procedimiento.Parameters.AddWithValue("ca", pacEN.cantidad);
            procedimiento.Parameters.AddWithValue("mon", pacEN.montomes);
            procedimiento.Parameters.AddWithValue("usr", pacEN.usuario);
            conectar.AbrirConexion();
            procedimiento.Connection = conectar.conectar;
            NoIngreso = procedimiento.ExecuteNonQuery();
            conectar.CerrarConexion();
            return NoIngreso;
        }
        /// <summary>
        /// Almacena las modificaciones al detalle de un PAC. 
        /// Tablas de update: sipa_pac_detalles.
        /// </summary>
        /// <param name="pacEN"></param>
        /// <returns>Numero de PAC modificado.</returns>
        public int ModificarPacDetalle(PacEN pacEN)
        {
            int NoIngreso;
            conectar = new ConexionBD();
            MySqlCommand procedimiento = new MySqlCommand("Modificar_PacDetalle");
            procedimiento.CommandType = CommandType.StoredProcedure;
            procedimiento.Parameters.AddWithValue("idPD", pacEN.idPacDetalle);
            procedimiento.Parameters.AddWithValue("ca", pacEN.cantidad);
            procedimiento.Parameters.AddWithValue("mon", pacEN.montomes);
            procedimiento.Parameters.AddWithValue("usr", pacEN.usuario);
            conectar.AbrirConexion();
            procedimiento.Connection = conectar.conectar;
            NoIngreso = procedimiento.ExecuteNonQuery();
            conectar.CerrarConexion();
            return NoIngreso;
        }
        public int EliminarPac(PacEN pacEN)
        {
            int NoIngreso;
            conectar = new ConexionBD();
            MySqlCommand procedimiento = new MySqlCommand("Eliminar_Pac");
            procedimiento.CommandType = CommandType.StoredProcedure;
            procedimiento.Parameters.AddWithValue("idP", pacEN.idPac);
            conectar.AbrirConexion();
            procedimiento.Connection = conectar.conectar;
            NoIngreso = procedimiento.ExecuteNonQuery();
            conectar.CerrarConexion();
            return NoIngreso;
        }

        public DataSet PedidoPACItem(int unidad, string condicion)
        {
            conectar = new ConexionBD();
            DataSet tabla = new DataSet();
            conectar.AbrirConexion();
            string query = string.Format("select (p.no_solicitud) Solicitud, fn_codigo_accion(ac.id_accion, 0, '', 2) accion, p.fecha_pedido Fecha, u.Unidad, " +
                        "CONCAT(ep.id_estado_pedido, ' - ', ep.nombre_estado)  Estado from sipa_pedidos p inner join sipa_acciones ac on ac.id_accion = p.id_accion " +
                        "inner join ccl_unidades u on u.id_unidad = p.id_unidad inner join sipa_estados_pedido ep on ep.id_estado_pedido = p.id_estado_pedido " +
                        "inner join sipa_pedido_detalle pd on pd.id_pedido = p.id_pedido inner join sipa_pac pac on pac.id_pac = pd.id_pac where pac.id_detalle <> pd.id_detalle_accion and u.id_unidad ={0} {1} group by p.id_pedido; "
                        , unidad, condicion);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable DdlRenglon(string unida, string renglon, string anio, string accion)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("select pa.id_pac,da.no_renglon from sipa_pac pa inner join sipa_detalles_accion da on pa.id_detalle = da.id_detalle inner join sipa_poa poa on pa.id_poa = poa.id_poa " +
                            "inner join ccl_unidades u on u.id_unidad = poa.id_unidad inner join sipa_acciones ac on  ac.id_accion = da.id_accion where u.id_unidad = {0} and da.no_renglon = {1} and poa.anio ={2} and fn_codigo_accion(ac.id_accion, 0, '', 2) ='{3}'; "
                            , unida, renglon, anio, accion);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public bool ActualizarPAC(string PAC, string detalle)
        {
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            MySqlTransaction transaccion = conectar.conectar.BeginTransaction();
            MySqlCommand command = conectar.conectar.CreateCommand();
            command.Transaction = transaccion;
            try
            {
                
                command.CommandText = string.Format("Update sipa_pedido_detalle set id_pac = {0} where id_pedido_detalle = {1};",PAC,detalle);
                command.ExecuteNonQuery();
                transaccion.Commit();
                conectar.CerrarConexion();
                return true;
            }
            catch (Exception ex)
            {
                try
                {
                    transaccion.Rollback();
                }
                catch
                { };
                conectar.CerrarConexion();
                return false;
            };
        }
    }
}
