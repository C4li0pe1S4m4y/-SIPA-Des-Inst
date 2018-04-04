using CapaLN;
using Microsoft.Reporting.WebForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionSIPA1.ReporteriaSistema
{
    public partial class EstadosDocumentos : System.Web.UI.Page
    {
        private PlanEstrategicoLN pEstrategicoLN;
        private PlanOperativoLN pOperativoLN;
        private PlanAccionLN pAccionLN;
        private PlanAnualLN pAnualLN;

        private PedidosLN pInsumoLN;
        public string thisConnectionString = ConfigurationManager.ConnectionStrings["dbcdagsipaConnectionString1"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pEstrategicoLN = new PlanEstrategicoLN();
                pOperativoLN = new PlanOperativoLN();
                pAccionLN = new PlanAccionLN();
                pAnualLN = new PlanAnualLN();
                string usuario = Session["Usuario"].ToString().ToLower();
                pEstrategicoLN = new PlanEstrategicoLN();
                pEstrategicoLN.DdlAniosPlan(ddlAnios, 2017, 2020);
                ddlAnios.Items.RemoveAt(0);
                ddlAnios.SelectedValue = "2018";

                string criterio = "AND c.id_tipo IN(48) AND a.usuario = ''" + usuario + "''";
                pInsumoLN = new PedidosLN();
                pAccionLN = new PlanAccionLN();
                pAccionLN.DdlAcciones(ddlAcciones, 0, 0, "", 3);
                ddlAcciones.Items[0].Text = "<< TODAS >>";
                DataSet dsResultado = pInsumoLN.InformacionPermisos(0, 0, criterio, 12);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0)
                    pOperativoLN.DdlUnidades(ddlUnidades);
                else
                    pOperativoLN.DdlUnidades(ddlUnidades, usuario);

                if (ddlUnidades.Items.Count <= 1)
                {
                    ddlUnidades_SelectedIndexChanged(sender, e);
                }
                else
                {
                    System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
                    stringBuilder.Append(consulta());
                    string tiposSalida = "";
                    for (int i = 0; i < chkTiposSalida.Items.Count; i++)
                        if (chkTiposSalida.Items[i].Selected == true)
                            tiposSalida += chkTiposSalida.Items[i].Value + ", ";


                    if (tiposSalida.Equals("") == false)
                        stringBuilder.Append(" AND t.id_tipo_documento IN(" + tiposSalida + "0)");

                    if ((ddlDependencias.Items.Count == 1) || (ddlDependencias.SelectedIndex > 0))
                    {
                        stringBuilder.Append(" AND id_unidad = " + ddlDependencias.SelectedValue);
                        stringBuilder.Append(" AND anio_solicitud = " + ddlAnios.SelectedValue);
                    }
                    stringBuilder.Append(" Order by t.no_solicitud, t.documento, t.fecha_comparacion_anterior");
                    MySqlConnection thisConnection = new MySqlConnection(thisConnectionString);
                    System.Data.DataSet thisDataSet = new System.Data.DataSet();

                    /* Put the stored procedure result into a dataset */
                    thisDataSet = MySqlHelper.ExecuteDataset(thisConnection, stringBuilder.ToString());

                    ReportDataSource datasource = new ReportDataSource("DataSet1", thisDataSet.Tables[0]);

                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(datasource);
                    if (thisDataSet.Tables[0].Rows.Count == 0)
                    {

                    }

                    ReportViewer1.LocalReport.Refresh();
                }

            }
        }

        protected void ddlUnidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            validarPoa(int.Parse(ddlUnidades.SelectedValue), int.Parse(ddlAnios.SelectedValue));

            int idPoa = 0;
            int.TryParse(lblIdPoa.Text, out idPoa);
            pAccionLN = new PlanAccionLN();
            pAccionLN.DdlAcciones(ddlAcciones, idPoa, 0, "", 3);
            ddlAcciones.Items[0].Text = "<< TODAS >>";
            pAccionLN = new PlanAccionLN();
            pAccionLN.DdlDocumentos(ddlNumeroDocumento, " AND id_unidad = " + ddlUnidades.SelectedValue + " AND anio_solicitud =" + ddlAnios.SelectedValue);
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            pOperativoLN = new PlanOperativoLN();
            pOperativoLN.DdlDependencias(ddlDependencias, ddlUnidades.SelectedValue);
            stringBuilder.Append(consulta());
            stringBuilder.Append(" AND id_padre = " + ddlUnidades.SelectedValue);
            stringBuilder.Append(" AND anio_solicitud = " + ddlAnios.SelectedValue);
            string tiposSalida = "";
            for (int i = 0; i < chkTiposSalida.Items.Count; i++)
                if (chkTiposSalida.Items[i].Selected == true)
                    tiposSalida += chkTiposSalida.Items[i].Value + ", ";

            if (tiposSalida.Equals("") == false)
                stringBuilder.Append(" AND t.id_tipo_documento IN(" + tiposSalida + "0)");
            stringBuilder.Append(" Order by t.no_solicitud, t.documento, t.fecha_comparacion_anterior");
            MySqlConnection thisConnection = new MySqlConnection(thisConnectionString);
            System.Data.DataSet thisDataSet = new System.Data.DataSet();
            
            /* Put the stored procedure result into a dataset */
            thisDataSet = MySqlHelper.ExecuteDataset(thisConnection, stringBuilder.ToString());

            ReportDataSource datasource = new ReportDataSource("DataSet1", thisDataSet.Tables[0]);

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            if (thisDataSet.Tables[0].Rows.Count == 0)
            {

            }

            ReportViewer1.LocalReport.Refresh();
        }

        protected void ddlDependencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            validarPoa(int.Parse(ddlDependencias.SelectedValue), int.Parse(ddlAnios.SelectedValue));

            int idPoa = 0;
            int.TryParse(lblIdPoa.Text, out idPoa);
            pAccionLN = new PlanAccionLN();
            pAccionLN.DdlAcciones(ddlAcciones, idPoa, 0, "", 3);
            ddlAcciones.Items[0].Text = "<< TODAS >>";
            pAccionLN = new PlanAccionLN();
            pAccionLN.DdlDocumentos(ddlNumeroDocumento, " AND id_unidad = " + ddlUnidades.SelectedValue + " AND anio_solicitud =" + ddlAnios.SelectedValue);
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            stringBuilder.Append(consulta());
            if (ddlDependencias.SelectedValue == "0")
                stringBuilder.Append(" AND id_padre = " + ddlUnidades.SelectedValue);
            else
                stringBuilder.Append(" AND id_unidad = " + ddlDependencias.SelectedValue);
            stringBuilder.Append(" AND anio_solicitud = " + ddlAnios.SelectedValue);
            string tiposSalida = "";
            for (int i = 0; i < chkTiposSalida.Items.Count; i++)
                if (chkTiposSalida.Items[i].Selected == true)
                    tiposSalida += chkTiposSalida.Items[i].Value + ", ";

            if (tiposSalida.Equals("") == false)
                stringBuilder.Append(" AND t.id_tipo_documento IN(" + tiposSalida + "0)");
            stringBuilder.Append(" Order by t.no_solicitud, t.documento, t.fecha_comparacion_anterior");
            MySqlConnection thisConnection = new MySqlConnection(thisConnectionString);
            System.Data.DataSet thisDataSet = new System.Data.DataSet();

            /* Put the stored procedure result into a dataset */
            thisDataSet = MySqlHelper.ExecuteDataset(thisConnection, stringBuilder.ToString());

            ReportDataSource datasource = new ReportDataSource("DataSet1", thisDataSet.Tables[0]);

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            if (thisDataSet.Tables[0].Rows.Count == 0)
            {

            }

            ReportViewer1.LocalReport.Refresh();
        }

        public string consulta()
        {
            string query = "";
            query = "select t.* from (select p.no_solicitud,p.anio_solicitud ,d.documento,d.id_tipo_documento,ep.nombre_estado estadoAnterior,ep2.nombre_estado EstadoNuevo,u.iniciales,u.id_unidad,d.fecha_comparacion_anterior,d.dias,d.horas,d.minutos,d.segundos,d.usuario_ing,d.observaciones,u.id_padre,CONCAT(IP,MAC_ADDRESS) IP,id_accion from sipa_documentos_wkf d " +
                    "inner join sipa_estados_pedido ep on ep.id_estado_pedido = d.id_estado_anterior inner join sipa_estados_pedido ep2 on ep2.id_estado_pedido = d.id_estado_nuevo " +
                   " inner join sipa_pedidos p on p.id_pedido = d.id_documento inner join ccl_unidades u on u.id_unidad = p.id_unidad " +
                    "where d.id_tipo_documento = 1 " +
                    "union all " +
                    "select p.no_solicitud,p.anio_solicitud,d.documento,d.id_tipo_documento,ep.nombre_estado estadoAnterior ,ep2.nombre_estado EstadoNuevo ,u.iniciales,u.id_unidad,d.fecha_comparacion_anterior,d.dias,d.horas,d.minutos,d.segundos,d.usuario_ing,d.observaciones,u.id_padre,CONCAT(IP,MAC_ADDRESS) IP,id_accion from sipa_documentos_wkf d " +
                    "inner join sipa_estados_pedido ep on ep.id_estado_pedido = d.id_estado_anterior inner join sipa_estados_pedido ep2 on ep2.id_estado_pedido = d.id_estado_nuevo " +
                    "inner join sipa_ccvale p on p.id_ccvale = d.id_documento inner join ccl_unidades u on u.id_unidad = p.id_unidad " +
                   " where d.id_tipo_documento = 2 " +
                    "union all " +
                    "select p.no_solicitud,p.anio_solicitud,d.documento,d.id_tipo_documento,ep.nombre_estado estadoAnterior,ep2.nombre_estado EstadoNuevo,u.iniciales,u.id_unidad,d.fecha_comparacion_anterior,d.dias,d.horas,d.minutos,d.segundos,d.usuario_ing,d.observaciones,u.id_padre, CONCAT(IP,MAC_ADDRESS) IP,id_accion from sipa_documentos_wkf d " +
                    "inner join sipa_estados_pedido ep on ep.id_estado_pedido = d.id_estado_anterior inner join sipa_estados_pedido ep2 on ep2.id_estado_pedido = d.id_estado_nuevo " +
                    "inner join sipa_gastos p on p.id_gasto = d.id_documento inner join ccl_unidades u on u.id_unidad = p.id_unidad " +
                    "where d.id_tipo_documento = 3 " +
                    "union all " +
                    "select p.no_solicitud,p.anio_solicitud,d.documento,d.id_tipo_documento,ep.nombre_estado estadoAnterior,ep2.nombre_estado EstadoNuevo,u.iniciales,u.id_unidad,d.fecha_comparacion_anterior,d.dias,d.horas,d.minutos,d.segundos,d.usuario_ing,d.observaciones,u.id_padre,CONCAT(IP,MAC_ADDRESS) IP,id_accion from sipa_documentos_wkf d " +
                    "inner join sipa_estados_pedido ep on ep.id_estado_pedido = d.id_estado_anterior inner join sipa_estados_pedido ep2 on ep2.id_estado_pedido = d.id_estado_nuevo " +
                    "inner join sipa_viaticos p on p.id_viatico = d.id_documento inner join ccl_unidades u on u.id_unidad = p.id_unidad " +
                    "where d.id_tipo_documento = 4) t where no_solicitud >0 ";
            return query;
        }

        protected void chkTiposSalida_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            stringBuilder.Append(consulta());
            string tiposSalida = "";
            for (int i = 0; i < chkTiposSalida.Items.Count; i++)
                if (chkTiposSalida.Items[i].Selected == true)
                    tiposSalida += chkTiposSalida.Items[i].Value + ", ";

            if (tiposSalida.Equals("") == false)
                stringBuilder.Append(" AND t.id_tipo_documento IN(" + tiposSalida + "0)");

            if (ddlDependencias.SelectedIndex>1)
            {
                stringBuilder.Append(" AND id_unidad = " + ddlDependencias.SelectedValue);
                stringBuilder.Append(" AND anio_solicitud = " + ddlAnios.SelectedValue);
            }
            else
            {
                stringBuilder.Append(" AND id_padre = " + ddlUnidades.SelectedValue);
                stringBuilder.Append(" AND anio_solicitud = " + ddlAnios.SelectedValue);
            }
            stringBuilder.Append(" Order by t.no_solicitud, t.documento, t.fecha_comparacion_anterior");
            MySqlConnection thisConnection = new MySqlConnection(thisConnectionString);
            System.Data.DataSet thisDataSet = new System.Data.DataSet();

            /* Put the stored procedure result into a dataset */
            thisDataSet = MySqlHelper.ExecuteDataset(thisConnection, stringBuilder.ToString());

            ReportDataSource datasource = new ReportDataSource("DataSet1", thisDataSet.Tables[0]);

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            if (thisDataSet.Tables[0].Rows.Count == 0)
            {

            }

            ReportViewer1.LocalReport.Refresh();
        }

        protected void ddlAnios_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            stringBuilder.Append(consulta());

            if (ddlUnidades.SelectedValue.Equals("0")== true) { 
                stringBuilder.Append(" AND id_unidad = " + "0");
                stringBuilder.Append(" AND anio_solicitud = " + ddlAnios.SelectedValue);
            }
            else
            { 
                stringBuilder.Append(" AND id_unidad = " + ddlDependencias.SelectedValue);
                stringBuilder.Append(" AND anio_solicitud = " + ddlAnios.SelectedValue);
            }

            string tiposSalida = "";
            for (int i = 0; i < chkTiposSalida.Items.Count; i++)
                if (chkTiposSalida.Items[i].Selected == true)
                    tiposSalida += chkTiposSalida.Items[i].Value + ", ";

            if (tiposSalida.Equals("") == false)
                stringBuilder.Append(" AND t.id_tipo_documento IN(" + tiposSalida + "0)");
            stringBuilder.Append(" Order by t.no_solicitud, t.documento, t.fecha_comparacion_anterior");
            MySqlConnection thisConnection = new MySqlConnection(thisConnectionString);
            System.Data.DataSet thisDataSet = new System.Data.DataSet();

            /* Put the stored procedure result into a dataset */
            thisDataSet = MySqlHelper.ExecuteDataset(thisConnection, stringBuilder.ToString());

            ReportDataSource datasource = new ReportDataSource("DataSet1", thisDataSet.Tables[0]);

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            if (thisDataSet.Tables[0].Rows.Count == 0)
            {

            }

            ReportViewer1.LocalReport.Refresh();
        }
        protected bool validarPoa(int idUnidad, int anio)
        {
            bool poaValido = false;
            try
            {
                pOperativoLN = new PlanOperativoLN();
                DataSet dsPoa = pOperativoLN.DatosPoaUnidad(idUnidad, anio);

               

                int idPoa = 0;
                int.TryParse(dsPoa.Tables[0].Rows[0]["ID_POA"].ToString(), out idPoa);
                lblIdPoa.Text = idPoa.ToString();
            }
            catch (Exception ex)
            {
            }
            return poaValido;
        }

        protected void ddlAcciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            stringBuilder.Append(consulta());

            if (ddlDependencias.SelectedIndex > 1)
            {
                stringBuilder.Append(" AND id_unidad = " + ddlDependencias.SelectedValue);
                stringBuilder.Append(" AND anio_solicitud = " + ddlAnios.SelectedValue);
            }
            else
            {
                stringBuilder.Append(" AND id_padre = " + ddlUnidades.SelectedValue);
                stringBuilder.Append(" AND anio_solicitud = " + ddlAnios.SelectedValue);
            }

            string tiposSalida = "";
            for (int i = 0; i < chkTiposSalida.Items.Count; i++)
                if (chkTiposSalida.Items[i].Selected == true)
                    tiposSalida += chkTiposSalida.Items[i].Value + ", ";

            if (tiposSalida.Equals("") == false)
                stringBuilder.Append(" AND t.id_tipo_documento IN(" + tiposSalida + "0)");
            stringBuilder.Append(" AND id_accion = " + ddlAcciones.SelectedValue);
            stringBuilder.Append(" Order by t.no_solicitud, t.documento, t.fecha_comparacion_anterior");
            MySqlConnection thisConnection = new MySqlConnection(thisConnectionString);
            System.Data.DataSet thisDataSet = new System.Data.DataSet();

            /* Put the stored procedure result into a dataset */
            thisDataSet = MySqlHelper.ExecuteDataset(thisConnection, stringBuilder.ToString());

            ReportDataSource datasource = new ReportDataSource("DataSet1", thisDataSet.Tables[0]);

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            if (thisDataSet.Tables[0].Rows.Count == 0)
            {

            }

            ReportViewer1.LocalReport.Refresh();
        }

        protected void ddlNumeroDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            stringBuilder.Append(consulta());

            stringBuilder.Append(" AND t.no_solicitud = " + ddlNumeroDocumento.SelectedValue.Split('-')[0].Trim() + " AND t.documento like '%" + ddlNumeroDocumento.SelectedValue.Split('-')[1].Trim() + "%'");
            
            stringBuilder.Append(" Order by t.no_solicitud, t.documento, t.fecha_comparacion_anterior");
            MySqlConnection thisConnection = new MySqlConnection(thisConnectionString);
            System.Data.DataSet thisDataSet = new System.Data.DataSet();

            /* Put the stored procedure result into a dataset */
            thisDataSet = MySqlHelper.ExecuteDataset(thisConnection, stringBuilder.ToString());

            ReportDataSource datasource = new ReportDataSource("DataSet1", thisDataSet.Tables[0]);

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            if (thisDataSet.Tables[0].Rows.Count == 0)
            {

            }

            ReportViewer1.LocalReport.Refresh();
        }
    }
}