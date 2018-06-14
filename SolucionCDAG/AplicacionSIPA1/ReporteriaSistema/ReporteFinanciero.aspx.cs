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
    public partial class ReporteFinanciero : System.Web.UI.Page
    {
        private PlanEstrategicoLN pEstrategicoLN;
        private PlanOperativoLN pOperativoLN;
        private PlanAccionLN pAccionLN;
        private PlanAnualLN pAnualLN;
        private ReportesLN reportLN;
        public string thisConnectionString = ConfigurationManager.ConnectionStrings["dbcdagsipaConnectionString1"].ConnectionString;
        private PedidosLN pInsumoLN;
        /// <summary>
        /// Reporte para visualizar las requisiciones y ver su valor real menos el pronosticado.
        /// Se puede filtrar por año, unidad, dependencia y accion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pEstrategicoLN = new PlanEstrategicoLN();
                pOperativoLN = new PlanOperativoLN();
                pAccionLN = new PlanAccionLN();
                pAnualLN = new PlanAnualLN();
                reportLN = new ReportesLN();
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
                    stringBuilder.Append(reportLN.queryReporteFinanciero());

                    if ((ddlDependencia.Items.Count == 1) || (ddlDependencia.SelectedIndex > 0))
                    {
                        stringBuilder.Append(" AND id_unidad = " + ddlDependencia.SelectedValue);
                        stringBuilder.Append(" AND anio_solicitud = " + ddlAnios.SelectedValue);
                    }
                    stringBuilder.Append(" Order by p.no_solicitud");
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
        protected void ddlUnidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiar();
            validarPoa(int.Parse(ddlUnidades.SelectedValue), int.Parse(ddlAnios.SelectedValue));

            int idPoa = 0;
            int.TryParse(lblIdPoa.Text, out idPoa);
            pAccionLN = new PlanAccionLN();
            pAccionLN.DdlAcciones(ddlAcciones, idPoa, 0, "", 3);
            ddlAcciones.Items[0].Text = "<< TODAS >>";
            pAccionLN = new PlanAccionLN();
            reportLN = new ReportesLN();
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            pOperativoLN = new PlanOperativoLN();
            pOperativoLN.DdlDependencias(ddlDependencia, ddlUnidades.SelectedValue);
            stringBuilder.Append(reportLN.queryReporteFinanciero());
            stringBuilder.Append(" AND id_padre = " + ddlUnidades.SelectedValue);
            stringBuilder.Append(" AND anio_solicitud = " + ddlAnios.SelectedValue);
            stringBuilder.Append(" Order by p.no_solicitud");
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

        protected void ddlDependencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiar();
            validarPoa(int.Parse(ddlDependencia.SelectedValue), int.Parse(ddlAnios.SelectedValue));

            int idPoa = 0;
            int.TryParse(lblIdPoa.Text, out idPoa);
            pAccionLN = new PlanAccionLN();
            pAccionLN.DdlAcciones(ddlAcciones, idPoa, 0, "", 3);
            ddlAcciones.Items[0].Text = "<< TODAS >>";
            pAccionLN = new PlanAccionLN();
            reportLN = new ReportesLN();
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            
            stringBuilder.Append(reportLN.queryReporteFinanciero());
            if (ddlDependencia.SelectedValue == "0")
                stringBuilder.Append(" AND id_padre = " + ddlUnidades.SelectedValue);
            else
                stringBuilder.Append(" AND p.id_unidad = " + ddlDependencia.SelectedValue);
            stringBuilder.Append(" AND anio_solicitud = " + ddlAnios.SelectedValue);
            stringBuilder.Append(" Order by p.no_solicitud");
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

        protected void ddlAcciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiar();
            reportLN = new ReportesLN();
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            stringBuilder.Append(reportLN.queryReporteFinanciero());

            if (ddlDependencia.SelectedIndex > 1)
            {
                stringBuilder.Append(" AND p.id_unidad = " + ddlDependencia.SelectedValue);
                stringBuilder.Append(" AND anio_solicitud = " + ddlAnios.SelectedValue);
            }
            else
            {
                stringBuilder.Append(" AND id_padre = " + ddlUnidades.SelectedValue);
                stringBuilder.Append(" AND anio_solicitud = " + ddlAnios.SelectedValue);
            }
            if(int.Parse(ddlAcciones.SelectedValue)>0)
                stringBuilder.Append(" AND ac.id_accion = " + ddlAcciones.SelectedValue);

            stringBuilder.Append(" Order by p.no_solicitud");
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

        protected void btnBusqueda_Click(object sender, ImageClickEventArgs e)
        {
            reportLN = new ReportesLN();
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            stringBuilder.Append(reportLN.queryReporteFinanciero());

            if (ddlDependencia.SelectedIndex > 1)
            {
                stringBuilder.Append(" AND p.id_unidad = " + ddlDependencia.SelectedValue);
                stringBuilder.Append(" AND anio_solicitud = " + ddlAnios.SelectedValue);
            }
            else
            {
                stringBuilder.Append(" AND id_padre = " + ddlUnidades.SelectedValue);
                stringBuilder.Append(" AND anio_solicitud = " + ddlAnios.SelectedValue);
            }
            if (int.Parse(ddlAcciones.SelectedValue) > 0)
                stringBuilder.Append(" AND ac.id_accion = " + ddlAcciones.SelectedValue);
            if (!string.IsNullOrEmpty(txtJustificacion.Text))
                stringBuilder.Append(" AND p.justificacion like '%" + txtJustificacion.Text + "%'");
            if (!string.IsNullOrEmpty(txtNoReq.Text))
                stringBuilder.Append(" AND p.no_solicitud =" + txtNoReq.Text);
            if (!string.IsNullOrEmpty(txtDescripcion.Text))
                stringBuilder.Append(" AND pd.descripcion like '%" + txtDescripcion.Text + "%'");
            stringBuilder.Append(" Order by p.no_solicitud");
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

        public void limpiar()
        {
            txtNoReq.Text = "";
            txtDescripcion.Text = "";
            txtJustificacion.Text = "";
        }
    }
}