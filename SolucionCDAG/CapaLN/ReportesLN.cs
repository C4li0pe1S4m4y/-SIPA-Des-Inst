using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAD;
using CapaEN;
using System.Web.UI.WebControls;
using System.Web;
using System.Data;

namespace CapaLN
{
    public class ReportesLN
    {
        ReportesAD reportesAD;

        public DataSet ReportesSipa(int id, int id2, string criterio, int opcion)
        {
            DataSet dsResultado = armarDsResultado();
            reportesAD = new ReportesAD();

            try
            {
                DataTable dt = reportesAD.ReportesSipa(id, id2, criterio, opcion);
                dt.TableName = "BUSQUEDA";
                dsResultado.Tables.Add(dt);
                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.ReportesSipa(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet armarDsResultado()
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

        /// <summary>
        /// ////////////////////////
        /// </summary>
        /// <param name="idUnidad"></param>
        /// <param name="idPoa"></param>
        /// <returns></returns>
        
        public DataTable CargarReporte(Int32 idUnidad, int idPoa){
            reportesAD = new ReportesAD();
           
            //'despues de iniciar el modelo de datos, llamamos el metodo para crear el reporte y guardarlo en el dataSet
            return reportesAD.ConsultaProcedimiento(idUnidad, idPoa);
    
        }

        public int idPoa(string usuario,int anio)
        {
            reportesAD = new ReportesAD();
            DataTable dt = new DataTable();
            int idUnidad = 0;

            idUnidad= Convert.ToInt32(reportesAD.unidadUsuario(usuario).Rows[0]["id"]);

            return Convert.ToInt32(reportesAD.poaUsuario(anio, idUnidad).Rows[0]["idPoa"]);
        }
             
        public DataTable fadnsSaldos(int opcion,int anio)
        {
            reportesAD = new ReportesAD();
            DataTable dt = new DataTable();
            if (opcion == 1)
            { dt= reportesAD.fadnsSaldosGeneral(anio); }
            if (opcion == 2)
            { dt= reportesAD.fadnsSaldoRetencion(anio); }

            return dt;
        }
        public DataTable SaldoReglones(int opcion,int par)
        {
            reportesAD = new ReportesAD();
            DataTable dt = new DataTable();

            dt = reportesAD.SaldoReglones(opcion,par); 
            return dt;
        }
        public DataTable SaldoReglonesUnidad(string letra, int anio)
        {
            reportesAD = new ReportesAD();
            DataTable dt = new DataTable();

            dt = reportesAD.SaldoReglonesUnidad(letra, anio);
            return dt;
        }
        public DataTable SaldoResumenes(int opcion, int par)
        {
            reportesAD = new ReportesAD();
            DataTable dt = new DataTable();

            dt = reportesAD.SaldoResumenes(opcion, par);
            return dt;
        }
        public DataTable SaldoProveedores(int opcion, int par)
        {
            reportesAD = new ReportesAD();
            DataTable dt = new DataTable();

            dt = reportesAD.SaldoProveedores(opcion, par);
            return dt;
        }
        public DataTable HistorialMovimiento(int opcion,string parametro,int anio)
        {
            reportesAD = new ReportesAD();
            DataTable dt = new DataTable();
            int par = 0;
            if (parametro.Length == 0)
            { par = 0; }
            else
            { par = Convert.ToInt32(parametro); }
            
            dt = reportesAD.HistorialMovimiento(opcion,par,anio);
            return dt;
        }    

        /// <summary>
        /// Funcion para ReporteFinanciero.aspx
        /// Selecciona el listado de requisiciones, por año, unidad y accion. Muestra el valor real de las requisiciones
        /// <para>0</para>
        /// </summary>
        /// <returns>Query para agregar datos.</returns>
        public string queryReporteFinanciero()
        {
            string query = "SELECT p.fecha_ing, CONCAT(p.no_solicitud, '-', p.anio_solicitud) AS No_Requisicion, fn_codigo_accion(ac.id_accion, 0, '', 2) accion,p.justificacion  ,pd.Descripcion, " +
                " da.no_renglon, pd.costo_pedido, pd.costo_real, pd.costo_pedido - pd.costo_real AS saldo, CONCAT(p.id_estado_pedido, '-', ep.nombre_estado) AS estado " +
                " FROM sipa_pedidos p " +
                " INNER JOIN sipa_acciones ac ON ac.id_accion = p.id_accion " +
                " INNER JOIN sipa_pedido_detalle pd ON pd.id_pedido = p.id_pedido " +
                " INNER JOIN sipa_detalles_accion da ON pd.id_detalle_accion = da.id_detalle " +
                " INNER JOIN sipa_estados_pedido ep ON ep.id_estado_pedido = p.id_estado_pedido " +
                " INNER JOIN ccl_unidades u on u.id_unidad = p.id_unidad "+
                " Where p.id_pedido >0";
            return query;
        }
    }
}
