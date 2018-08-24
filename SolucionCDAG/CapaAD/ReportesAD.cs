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
    public class ReportesAD
    {

        ConexionBD conectar;



        public DataTable ReportesSipa(int id, int id2, string criterio, int opcion)
        {

            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("CALL sp_reportes({0}, {1}, '{2}', {3});", id, id2, criterio, opcion);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            tabla.TableName = "Datos";
            return tabla;
        }




        /// <summary>
        /// ///////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="idUnidad"></param>
        /// <param name="idPoa"></param>
        /// <returns></returns>
        public DataTable ConsultaProcedimiento(Int32 idUnidad, int idPoa)
        {

            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call sp_slctPlanAccionGB ({0}, {1})", idUnidad, idPoa);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            tabla.TableName = "DataReporte";
            return tabla;
        }

        public DataTable unidadUsuario(string usuario)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsUnidadesUsuario ('{0}')", usuario);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable poaUsuario(int anio, int idUnidad)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsDatosPoa ({0},{1})", idUnidad, anio);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }


        public DataTable fadnsSaldoRetencion(int anio)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsFADNSaldo ({0});", anio);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable fadnsSaldosGeneral(int anio)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsFADNGastos ({0});", anio);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable SaldoReglones(int opcion, int par)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsSaldosReglones ({0},{1});", opcion, par);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable SaldoReglonesUnidad(string letra, int anio)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsSaldoPVReglones ('{0}',{1});", letra, anio);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable SaldoResumenes(int opcion, int par)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsSaldosResumen ({0},{1});", opcion, par);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable SaldoProveedores(int opcion, int par)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsSaldoProveedores ({0},{1});", opcion, par);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable HistorialMovimiento(int opcion, int parametro, int anio)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("call clsHistorialMovimientos ({0},{1},{2});", opcion, parametro, anio);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataSet SaldosxUnidad(int anio)
        {
            conectar = new ConexionBD();
            DataSet tabla = new DataSet();
            conectar.AbrirConexion();
            string strConsulta = string.Format("select t.id as Unidad, t.MontoPoa, t.Codificado,  ((t.MontoPoa - t.Codificado)) Saldo from " +
                "(select u.unidad id, COALESCE(SUM(da.monto), 0) MontoPoa, COALESCE((SELECT SUM(gasto)  as Gasto FROM unionpedido up, sipa_detalles_accion da, sipa_acciones aa " +
                " WHERE up.estado_financiero = 1 AND up.id_detalle_accion = da.id_detalle AND da.id_accion = aa.id_accion AND da.no_renglon = da.no_renglon AND aa.id_poa = p.id_poa" +
                " ), 0) Codificado from sipa_acciones d inner join sipa_poa p on p.id_poa = d.id_poa inner join sipa_detalles_accion da on da.id_accion = d.id_accion " +
                " inner join ccl_unidades u on u.id_unidad = p.id_unidad and p.anio = {0} Group by p.id_unidad )t;", anio);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public string[] DashboardConsulta(string idUnidad, string anio)
        {
            string[] query = new string[7];
            query[0] = string.Format("SELECT p.no_solicitud, ep.nombre_estado, u.Unidad FROM sipa_pedidos p INNER JOIN sipa_estados_pedido ep ON ep.id_estado_pedido = p.id_estado_pedido INNER JOIN ccl_unidades u ON u.id_unidad = p.id_unidad where u.id_unidad ={0} and p.anio_solicitud = {1}", idUnidad, anio);
            query[1] = string.Format("SELECT v.no_solicitud, ev.nombre_estado, u.id_unidad, u.Unidad FROM sipa_viaticos v INNER JOIN sipa_estados_viaticos ev ON ev.id_estado_viatico = v.id_estado_viatico INNER JOIN ccl_unidades u ON u.id_unidad = v.id_unidad  where u.id_unidad ={0} and v.anio_solicitud = {1}", idUnidad, anio);
            query[2] = string.Format("SELECT SUM(d.monto) AS monto FROM     sipa_detalles_accion d INNER JOIN sipa_acciones aa ON aa.id_accion = d.id_accion INNER JOIN sipa_renglones r ON d.no_renglon = r.No_Renglon " +
                                     "INNER JOIN sipa_tipos_financiamiento f ON d.id_tipo_financiamiento = f.id_tipo inner join sipa_poa poa on poa.id_poa = aa.id_poa WHERE  poa.id_unidad = {0} and poa.anio = {1} ", idUnidad, anio);
            query[3] = string.Format("SELECT SUM(up.gasto) AS Gasto FROM unionpedido up INNER JOIN sipa_detalles_accion d ON up.id_detalle_accion = d.id_detalle INNER JOIN sipa_acciones aa" +
                                    " ON aa.id_accion = d.id_accion  inner join sipa_poa poa on poa.id_poa = aa.id_poa " +
                                     "WHERE(up.estado_financiero = 1) and up.id_estado_pedido in (8,10) AND poa.id_unidad = {0} and poa.anio = {1} ", idUnidad, anio);
            query[4] = string.Format("SELECT p.no_solicitud, ep.nombre_estado, u.Unidad FROM sipa_ccvale p INNER JOIN sipa_estados_pedido ep ON ep.id_estado_pedido = p.id_estado_vale INNER JOIN ccl_unidades u ON u.id_unidad = p.id_unidad  where u.id_unidad ={0} and p.anio_solicitud = {1}", idUnidad, anio);
            query[5] = string.Format("SELECT g.no_solicitud, p.nombre_estado, u.Unidad FROM     sipa_gastos g INNER JOIN sipa_estados_pedido p ON p.id_estado_pedido = g.id_estado_gasto INNER JOIN ccl_unidades u ON u.id_unidad = g.id_unidad  where u.id_unidad ={0} and g.anio_solicitud = {1}", idUnidad, anio);
            query[6] = string.Format("SELECT SUM(up.gasto) AS Gasto FROM unionpedido up INNER JOIN sipa_detalles_accion d ON up.id_detalle_accion = d.id_detalle INNER JOIN sipa_acciones aa" +
                                   " ON aa.id_accion = d.id_accion  inner join sipa_poa poa on poa.id_poa = aa.id_poa " +
                                    "WHERE(up.estado_financiero = 1) and up.id_estado_pedido in (12) AND poa.id_unidad = {0} and poa.anio = {1} ", idUnidad, anio);
            return query;
        }
        public string[] DashboardConsulta_Padre(string idUnidad, string anio)
        {
            string[] query = new string[7];
            query[0] = string.Format("SELECT p.no_solicitud, ep.nombre_estado, u.Unidad FROM sipa_pedidos p INNER JOIN sipa_estados_pedido ep ON ep.id_estado_pedido = p.id_estado_pedido INNER JOIN ccl_unidades u ON u.id_unidad = p.id_unidad where u.id_padre ={0} and p.anio_solicitud = {1}", idUnidad, anio);
            query[1] = string.Format("SELECT v.no_solicitud, ev.nombre_estado, u.id_unidad, u.Unidad FROM sipa_viaticos v INNER JOIN sipa_estados_viaticos ev ON ev.id_estado_viatico = v.id_estado_viatico INNER JOIN ccl_unidades u ON u.id_unidad = v.id_unidad  where u.id_padre ={0} and v.anio_solicitud = {1}", idUnidad, anio);
            query[2] = string.Format("SELECT SUM(d.monto) AS monto FROM     sipa_detalles_accion d INNER JOIN sipa_acciones aa ON aa.id_accion = d.id_accion INNER JOIN sipa_renglones r ON d.no_renglon = r.No_Renglon " +
                                     "INNER JOIN sipa_tipos_financiamiento f ON d.id_tipo_financiamiento = f.id_tipo inner join sipa_poa poa on poa.id_poa = aa.id_poa inner join ccl_unidades u on u.id_unidad = poa.id_unidad WHERE  u.id_padre = {0} and poa.anio = {1} ", idUnidad, anio);
            query[3] = string.Format("SELECT SUM(up.gasto) AS Gasto FROM unionpedido up INNER JOIN sipa_detalles_accion d ON up.id_detalle_accion = d.id_detalle INNER JOIN sipa_acciones aa" +
                                    " ON aa.id_accion = d.id_accion  inner join sipa_poa poa on poa.id_poa = aa.id_poa  inner join ccl_unidades u on u.id_unidad = poa.id_unidad " +
                                     "WHERE(up.estado_financiero = 1) and up.id_estado_pedido in (8,10) AND u.id_padre = {0} and poa.anio = {1} ", idUnidad, anio);
            query[4] = string.Format("SELECT p.no_solicitud, ep.nombre_estado, u.Unidad FROM sipa_ccvale p INNER JOIN sipa_estados_pedido ep ON ep.id_estado_pedido = p.id_estado_vale INNER JOIN ccl_unidades u ON u.id_unidad = p.id_unidad  where u.id_padre ={0} and p.anio_solicitud = {1}", idUnidad, anio);
            query[5] = string.Format("SELECT g.no_solicitud, p.nombre_estado, u.Unidad FROM     sipa_gastos g INNER JOIN sipa_estados_pedido p ON p.id_estado_pedido = g.id_estado_gasto INNER JOIN ccl_unidades u ON u.id_unidad = g.id_unidad  where u.id_padre ={0} and g.anio_solicitud = {1}", idUnidad, anio);
            query[6] = string.Format("SELECT SUM(up.gasto) AS Gasto FROM unionpedido up INNER JOIN sipa_detalles_accion d ON up.id_detalle_accion = d.id_detalle INNER JOIN sipa_acciones aa" +
                                  " ON aa.id_accion = d.id_accion  inner join sipa_poa poa on poa.id_poa = aa.id_poa  inner join ccl_unidades u on u.id_unidad = poa.id_unidad " +
                                   "WHERE(up.estado_financiero = 1) and up.id_estado_pedido in (12) AND u.id_padre = {0} and poa.anio = {1} ", idUnidad, anio);
            return query;
        }
        public string[] DashboardConsulta_anio(string anio)
        {
            string[] query = new string[7];
            query[0] = string.Format("SELECT p.no_solicitud, ep.nombre_estado, u.Unidad FROM sipa_pedidos p INNER JOIN sipa_estados_pedido ep ON ep.id_estado_pedido = p.id_estado_pedido INNER JOIN ccl_unidades u ON u.id_unidad = p.id_unidad where p.anio_solicitud ={0} ", anio);
            query[1] = string.Format("SELECT v.no_solicitud, ev.nombre_estado, u.id_unidad, u.Unidad FROM sipa_viaticos v INNER JOIN sipa_estados_viaticos ev ON ev.id_estado_viatico = v.id_estado_viatico INNER JOIN ccl_unidades u ON u.id_unidad = v.id_unidad where v.anio_solicitud ={0} ", anio);
            query[2] = string.Format("SELECT SUM(d.monto) AS monto FROM     sipa_detalles_accion d INNER JOIN sipa_acciones aa ON aa.id_accion = d.id_accion INNER JOIN sipa_renglones r ON d.no_renglon = r.No_Renglon " +
                                     "INNER JOIN sipa_tipos_financiamiento f ON d.id_tipo_financiamiento = f.id_tipo inner join sipa_poa poa on poa.id_poa = aa.id_poa WHERE  poa.id_poa in(33,37,40,43,49,56,57,58,59,61,62,63,64,86,87,88,89) ");
            query[3] = string.Format("SELECT SUM(up.gasto) AS Gasto FROM unionpedido up INNER JOIN sipa_detalles_accion d ON up.id_detalle_accion = d.id_detalle INNER JOIN sipa_acciones aa" +
                                    " ON aa.id_accion = d.id_accion  inner join sipa_poa poa on poa.id_poa = aa.id_poa " +
                                     "WHERE(up.estado_financiero = 1) and up.id_estado_pedido in (8,10) AND poa.id_poa in(33,37,40,43,49,56,57,58,59,61,62,63,64,86,87,88,89)");
            query[4] = string.Format("SELECT p.no_solicitud, ep.nombre_estado, u.Unidad FROM sipa_ccvale p INNER JOIN sipa_estados_pedido ep ON ep.id_estado_pedido = p.id_estado_vale INNER JOIN ccl_unidades u ON u.id_unidad = p.id_unidad where anio_solicitud = {0} ", anio);
            query[5] = string.Format("SELECT g.no_solicitud, p.nombre_estado, u.Unidad FROM     sipa_gastos g INNER JOIN sipa_estados_pedido p ON p.id_estado_pedido = g.id_estado_gasto INNER JOIN ccl_unidades u ON u.id_unidad = g.id_unidad where anio_solicitud = {0} ", anio);
            query[6] = string.Format("SELECT SUM(up.gasto) AS Gasto FROM unionpedido up INNER JOIN sipa_detalles_accion d ON up.id_detalle_accion = d.id_detalle INNER JOIN sipa_acciones aa" +
                                    " ON aa.id_accion = d.id_accion  inner join sipa_poa poa on poa.id_poa = aa.id_poa " +
                                     "WHERE(up.estado_financiero = 1) and up.id_estado_pedido in (12)  AND poa.id_poa in(33,37,40,43,49,56,57,58,59,61,62,63,64,86,87,88,89)");
            return query;
        }

        //Query que muestra toda la info.
        public string[] DashboardConsulta_All(string anio)
        {
            string[] query = new string[7];
            query[0] = string.Format("SELECT p.no_solicitud, ep.nombre_estado, u.Unidad FROM sipa_pedidos p INNER JOIN sipa_estados_pedido ep ON ep.id_estado_pedido = p.id_estado_pedido INNER JOIN ccl_unidades u ON u.id_unidad = p.id_unidad where u.id_padre in (21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 38) and p.anio_solicitud = {0}", anio);
            query[1] = string.Format("SELECT v.no_solicitud, ev.nombre_estado, u.id_unidad, u.Unidad FROM sipa_viaticos v INNER JOIN sipa_estados_viaticos ev ON ev.id_estado_viatico = v.id_estado_viatico INNER JOIN ccl_unidades u ON u.id_unidad = v.id_unidad  where u.id_padre in (21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 38) and v.anio_solicitud = {0}", anio);
            query[2] = string.Format("SELECT SUM(d.monto) AS monto FROM     sipa_detalles_accion d INNER JOIN sipa_acciones aa ON aa.id_accion = d.id_accion INNER JOIN sipa_renglones r ON d.no_renglon = r.No_Renglon " +
                                     "INNER JOIN sipa_tipos_financiamiento f ON d.id_tipo_financiamiento = f.id_tipo inner join sipa_poa poa on poa.id_poa = aa.id_poa inner join ccl_unidades u on u.id_unidad = poa.id_unidad where u.id_padre in (21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 38) and poa.anio = {0}", anio);
            query[3] = string.Format("SELECT SUM(up.gasto) AS Gasto FROM unionpedido up INNER JOIN sipa_detalles_accion d ON up.id_detalle_accion = d.id_detalle INNER JOIN sipa_acciones aa" +
                                    " ON aa.id_accion = d.id_accion  inner join sipa_poa poa on poa.id_poa = aa.id_poa  inner join ccl_unidades u on u.id_unidad = poa.id_unidad " +
                                     "WHERE(up.estado_financiero = 1 )  and up.id_estado_pedido in (8,10) AND u.id_padre in (21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 38) and  poa.anio = {0}", anio);
            query[4] = string.Format("SELECT p.no_solicitud, ep.nombre_estado, u.Unidad FROM sipa_ccvale p INNER JOIN sipa_estados_pedido ep ON ep.id_estado_pedido = p.id_estado_vale INNER JOIN ccl_unidades u ON u.id_unidad = p.id_unidad  where u.id_padre in (21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 38) and p.anio_solicitud = {0}", anio);
            query[5] = string.Format("SELECT g.no_solicitud, p.nombre_estado, u.Unidad FROM     sipa_gastos g INNER JOIN sipa_estados_pedido p ON p.id_estado_pedido = g.id_estado_gasto INNER JOIN ccl_unidades u ON u.id_unidad = g.id_unidad  where u.id_padre in (21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 38) and g.anio_solicitud = {0}", anio);
            query[3] = string.Format("SELECT SUM(up.gasto) AS Gasto FROM unionpedido up INNER JOIN sipa_detalles_accion d ON up.id_detalle_accion = d.id_detalle INNER JOIN sipa_acciones aa" +
                                   " ON aa.id_accion = d.id_accion  inner join sipa_poa poa on poa.id_poa = aa.id_poa  inner join ccl_unidades u on u.id_unidad = poa.id_unidad " +
                                    "WHERE(up.estado_financiero = 1 )  and up.id_estado_pedido in (12) AND u.id_padre in (21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 38) and  poa.anio = {0}", anio);
            return query;
        }
        /// <summary>
        /// Reporte de Ejecuciones y Modificaciones. 
        /// </summary>
        /// <returns></returns>
        public DataTable EjecucionyModificaciones(string filtros)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("SELECT " +
                "u.unidad,u.id_unidad, " +
                "ppto_aprobado techo_aprobado, " +
                "monto techo_actual, " +
                "COALESCE((  " +
                    "SELECT SUM(gasto)  " +
                    "FROM unionpedido up, sipa_detalles_accion da  " +
                    "WHERE up.id_detalle_accion = da.id_detalle  " +
                    "AND up.estado_financiero = 1 " +
                    "AND da.id_accion IN(SELECT ap.id_accion FROM sipa_acciones ap WHERE ap.id_poa = a.id_poa) " +
                "), 0) ppto_codificado, " +
                "0 ppto_pendiente_codificar, " +
                "t.techo_actual techo_actual_m,(t.nuevo_techo-t.techo_actual) modificacion, t.nuevo_techo " +
             "FROM sipa_poa a " +
            "inner join ccl_unidades u on u.id_unidad = a.id_unidad " +
            "left join sipa_poa_modificaciones_techos t on t.id_poa = a.id_poa " +
            "WHERE a.id_poa > 0  {0} order by u.id_unidad; ",filtros);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable ReportePptoCantidad(string filtro)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("select count(id_documento) ingresados, " +
                 " (select count(id_documento) " +
                 "   from sipa_documentos_wkf " +
                 "   where id_estado_nuevo = 8 and id_tipo_documento = 1 {0} ) finalizados " +
                 " from sipa_documentos_wkf " +
                 " where id_estado_nuevo = 6 and id_tipo_documento = 1 {0} ; ",filtro);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable ReportePpto(string filtro)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("select nombres usuario,count(id_documento) cantidad from sipa_documentos_wkf d " +
                " inner join ccl_usuarios u on u.usuario = d.usuario_ing " +
                " inner join ccl_empleados e on e.id_empleado = u.id_empleado " +
                " inner join sipa_pedidos p on p.id_pedido = d.id_documento " +
                " where id_estado_nuevo = 8 and id_tipo_documento = 1 {0} " +
                " group by d.usuario_ing; ", filtro);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataSet TrasladoCUR(string no, string anio,string det)
        {
            conectar = new ConexionBD();
            DataSet tabla = new DataSet();
            conectar.AbrirConexion();
            string strConsulta = string.Format("select e.nombres tecnico, no_solicitud NoRequisicion, d.fecha_traslado_orden fecha, d.Descripcion, pr.razon_social proveedor, pr.nit,(d.costo_pedido *1.12) Monto, "+
            " d.costo_pedido MontoSIVA, u.unidad,d.Factura no_factura, p.Justificacion, d.no_orden_compra no_orden,rt.nombre regimen,d.fecha_traslado_fondo_rotativo FCheque_FR " +
            " from sipa_pedidos p " +
            " inner  join sipa_pedido_detalle d on d.id_pedido = p.id_pedido " +
            " inner join sipa_proveedores pr on d.id_proveedor = pr.id_proveedor " +
            " inner join ccl_unidades u on u.id_unidad = p.id_unidad " +
            " inner join ccl_empleados e on e.id_empleado = p.id_tecnico " +
             "inner join sipa_regimen_tributario rt on pr.id_regimen_impuesto = rt.id_regimen  " +
            " WHERE p.no_solicitud = {0} and p.anio_solicitud = {1} and d.id_pedido_detalle in({2}) ;",no,anio,det);
                        MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataSet TrasladoAlmacen(string no, string anio, string det)
        {
            conectar = new ConexionBD();
            DataSet tabla = new DataSet();
            conectar.AbrirConexion();
            string strConsulta = string.Format("select e.nombres tecnico, no_solicitud NoRequisicion, d.fecha_traslado_orden fecha, d.Descripcion, pr.razon_social proveedor, pr.nit,(d.costo_pedido *1.12) Monto, " +
            " d.costo_pedido MontoSIVA, u.unidad, d.Fecha_factura F_factura, d.Factura no_factura" +
            " from sipa_pedidos p " +
            " inner  join sipa_pedido_detalle d on d.id_pedido = p.id_pedido " +
            " inner join sipa_proveedores pr on d.id_proveedor = pr.id_proveedor " +
            " inner join ccl_unidades u on u.id_unidad = p.id_unidad " +
            " inner join ccl_empleados e on e.id_empleado = p.id_tecnico " +
            " WHERE p.no_solicitud = {0} and p.anio_solicitud = {1} and d.id_pedido_detalle in({2}) ;", no, anio, det);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable GruposPresupuestarios(string no)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("SELECT t.NoRenglon,t.unidad,t.MontoPoa,t.Codificado,(t.MontoPoa - t.Codificado) Saldo,t.grupo "+
            "FROM  " +
            "( " +
                "SELECT  " +
                    " CONCAT(d.no_renglon, ' - ', r.Descripcion) NoRenglon,(d.no_renglon div 100) as grupo,a.id_Unidad, u.unidad,a.anio,COALESCE(SUM(d.monto), 0) MontoPoa,  " +
                     " COALESCE((  " +
                      "  select distinct Sum(gasto) as Gasto  " +
                      "  from unionpedido up  " +
                      "  inner join sipa_detalles_accion da on up.id_detalle_accion = da.id_detalle " +
                      "  inner join sipa_acciones aa on aa.id_accion = up.id_accion  " +
                      "  where up.estado_financiero = 1 " +
                      "  AND da.no_renglon = d.no_renglon  " +
                      "  and aa.id_accion = d.id_accion " +
                      " GROUP BY da.no_renglon " +
                   " ), 0) Codificado " +
                " FROM sipa_poa a " +
                " inner join ccl_unidades u on u.id_unidad = a.id_Unidad " +
                " inner join sipa_acciones b on b.id_poa = a.id_poa " +
                " inner join sipa_detalles_accion d on d.id_accion = b.id_accion " +
                " inner join sipa_renglones r on r.no_renglon = d.no_renglon " +
                " inner join  sipa_tipos_financiamiento f on d.id_tipo_financiamiento = f.id_tipo " +
                " {0} " +
                "GROUP BY(grupo),u.id_padre " +
            " ) t  " +
            " ORDER BY t.id_unidad, t.grupo; ", no );
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable Cuatrimestre1(string filtro)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("select t.* from( "+
             "select  sum(pd.costo_estimado)MontoC1,u.unidad, " +
             "case " +
              "  when sum(pd.costo_estimado) <= 2500  then 'Baja Cuantia' " +
              "  when sum(pd.costo_estimado) > 2500 and sum(pd.costo_estimado) <= 9000 then 'Compra Directa' " +
              "  when sum(pd.costo_estimado) > 9000 and sum(pd.costo_estimado) <= 900000 then 'Cotizacion' " +
               " when sum(pd.costo_estimado) > 900000  then 'Licitacion' " +
             "end Modalidad " +
             "from sipa_pedidos p " +
            "inner join sipa_pedido_detalle pd on pd.id_pedido = p.id_pedido " +
            "inner join ccl_unidades u on u.id_unidad = p.id_unidad " +
            "where date_format(p.fecha_pedido, '%m') in (1, 2, 3, 4) and p.id_estado_pedido in(8,10,12)  {0} " +
            "group by p.id_pedido) t " +
             "   group by t.Modalidad; ", filtro);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable Cuatrimestre2(string filtro)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("select t.* from( " +
             "select  sum(pd.costo_estimado)MontoC2, " +
             "case " +
               "  when sum(pd.costo_estimado) <= 2500  then 'Baja Cuantia' " +
              "  when sum(pd.costo_estimado) > 2500 and sum(pd.costo_estimado) <= 9000 then 'Compra Directa' " +
              "  when sum(pd.costo_estimado) > 9000 and sum(pd.costo_estimado) <= 900000 then 'Cotizacion' " +
               " when sum(pd.costo_estimado) > 900000  then 'Licitacion' " +
             "end Modalidad " +
             "from sipa_pedidos p " +
            "inner join sipa_pedido_detalle pd on pd.id_pedido = p.id_pedido " +
            "inner join ccl_unidades u on u.id_unidad = p.id_unidad " +
            "where date_format(p.fecha_pedido, '%m') in (5,6,7,8) and p.id_estado_pedido in(8,10,12)  {0} " +
            "group by p.id_pedido) t " +
             "   group by t.Modalidad; ", filtro);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable Cuatrimestre3(string filtro)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string strConsulta = string.Format("select t.* from( " +
             "select  sum(pd.costo_estimado)MontoC3, " +
             "case " +
            "  when sum(pd.costo_estimado) <= 2500  then 'Baja Cuantia' " +
              "  when sum(pd.costo_estimado) > 2500 and sum(pd.costo_estimado) <= 9000 then 'Compra Directa' " +
              "  when sum(pd.costo_estimado) > 9000 and sum(pd.costo_estimado) <= 900000 then 'Cotizacion' " +
               " when sum(pd.costo_estimado) > 900000  then 'Licitacion' " +
             "end Modalidad " +
             "from sipa_pedidos p " +
            "inner join sipa_pedido_detalle pd on pd.id_pedido = p.id_pedido " +
            "inner join ccl_unidades u on u.id_unidad = p.id_unidad " +
            "where date_format(p.fecha_pedido, '%m') in (9,10,11,12) and p.id_estado_pedido in(8,10,12)  {0} " +
            "group by p.id_pedido) t " +
             "   group by t.Modalidad; ", filtro);
            MySqlDataAdapter consulta = new MySqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
    }
}
