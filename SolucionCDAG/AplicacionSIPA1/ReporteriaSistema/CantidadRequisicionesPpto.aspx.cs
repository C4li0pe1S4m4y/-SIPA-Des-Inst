using CapaLN;
using Microsoft.Reporting.WebForms;
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
    public partial class CantidadRequisicionesPpto : System.Web.UI.Page
    {
        private PlanEstrategicoLN pEstrategicoLN;
        private PlanOperativoLN pOperativoLN;
        private PlanAccionLN pAccionLN;
        private PlanAnualLN pAnualLN;
        private ReportesLN pReportesLN;
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
                pReportesLN = new ReportesLN();
                string usuario = Session["Usuario"].ToString().ToLower();
                pEstrategicoLN = new PlanEstrategicoLN();
                pEstrategicoLN.DdlAniosPlan(ddlAnios, 2017, 2020);
                ddlAnios.Items.RemoveAt(0);
                ddlAnios.SelectedValue = "2018";
                pOperativoLN.DdlUsuarioPpto(ddlAnalista);
                string criterio = "AND c.id_tipo IN(48) AND a.usuario = ''" + usuario + "''";
                pInsumoLN = new PedidosLN();
                DataSet dsResultado = pInsumoLN.InformacionPermisos(0, 0, criterio, 12);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0)
                    pOperativoLN.DdlUnidades(ddlUnidades);
                else
                    pOperativoLN.DdlUnidades(ddlUnidades, usuario);

                if (ddlUnidades.Items.Count <= 1)
                {
                   // ddlUnidades_SelectedIndexChanged(sender, e);
                }
                dsResultado = pReportesLN.ReportePpto(" ");
                ReportDataSource datasource1 = new ReportDataSource("DataSet1", dsResultado.Tables[0]);
                ReportDataSource datasource2 = new ReportDataSource("DataSet2", dsResultado.Tables[1]);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource1);
                ReportViewer1.LocalReport.DataSources.Add(datasource2);
                ReportViewer1.LocalReport.Refresh();
            }
        }

        protected void ddlUnidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            pReportesLN = new ReportesLN();
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            stringBuilder.Append(" and p.anio_solicitud = '" + ddlAnalista.SelectedValue + "'");
            if (!string.IsNullOrEmpty(txtFecha.Text))
                stringBuilder.Append(" and DATE_FORMAT(fecha,'%Y-%m-%d') ='"+txtFecha.Text+"'");
            if(ddlAnalista.SelectedIndex>0)
                stringBuilder.Append(" and e.id_empleado = '" + ddlAnalista.SelectedValue + "'");
            
            stringBuilder.Append(" and p.id_unidad = '" + ddlUnidades.SelectedValue + "'");
            DataSet dsResultado = pReportesLN.ReportePpto(stringBuilder.ToString());
            ReportDataSource datasource1 = new ReportDataSource("DataSet1", dsResultado.Tables[0]);
            ReportDataSource datasource2 = new ReportDataSource("DataSet2", dsResultado.Tables[1]);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource1);
            ReportViewer1.LocalReport.DataSources.Add(datasource2);
            ReportViewer1.LocalReport.Refresh();
        }

        protected void ddlDependencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            pReportesLN = new ReportesLN();
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            stringBuilder.Append(" and p.anio_solicitud = '" + ddlAnalista.SelectedValue + "'");
            if (!string.IsNullOrEmpty(txtFecha.Text))
                stringBuilder.Append(" and DATE_FORMAT(fecha,'%Y-%m-%d') ='" + txtFecha.Text + "'");
            if (ddlAnalista.SelectedIndex > 0)
                stringBuilder.Append(" and e.id_empleado = '" + ddlAnalista.SelectedValue + "'");

            stringBuilder.Append(" and p.id_unidad = '" + ddlDependencias.SelectedValue + "'");
            DataSet dsResultado = pReportesLN.ReportePpto(stringBuilder.ToString());
            ReportDataSource datasource1 = new ReportDataSource("DataSet1", dsResultado.Tables[0]);
            ReportDataSource datasource2 = new ReportDataSource("DataSet2", dsResultado.Tables[1]);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource1);
            ReportViewer1.LocalReport.DataSources.Add(datasource2);
            ReportViewer1.LocalReport.Refresh();
        }

        protected void ddlAnalista_SelectedIndexChanged(object sender, EventArgs e)
        {
            pReportesLN = new ReportesLN();
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            stringBuilder.Append(" and p.anio_solicitud = '" + ddlAnalista.SelectedValue + "'");
            if (!string.IsNullOrEmpty(txtFecha.Text))
                stringBuilder.Append(" and DATE_FORMAT(fecha,'%Y-%m-%d') ='" + txtFecha.Text + "'");
            if (ddlAnalista.SelectedIndex > 0)
                stringBuilder.Append(" and e.id_empleado = '" + ddlAnalista.SelectedValue + "'");
            if(ddlUnidades.SelectedIndex>0)
                stringBuilder.Append(" and p.id_unidad = '" + ddlUnidades.SelectedValue + "'");
            stringBuilder.Append(" and e.id_empleado = '" + ddlAnalista.SelectedValue + "'");
            DataSet dsResultado = pReportesLN.ReportePpto(stringBuilder.ToString());
            ReportDataSource datasource1 = new ReportDataSource("DataSet1", dsResultado.Tables[0]);
            ReportDataSource datasource2 = new ReportDataSource("DataSet2", dsResultado.Tables[1]);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource1);
            ReportViewer1.LocalReport.DataSources.Add(datasource2);
            ReportViewer1.LocalReport.Refresh();
        }

        protected void btnBusqueda_Click(object sender, EventArgs e)
        {
            pReportesLN = new ReportesLN();
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            
            if (!string.IsNullOrEmpty(txtFecha.Text))
                stringBuilder.Append(" and DATE_FORMAT(fecha,'%Y-%m-%d') ='" + txtFecha.Text + "'");
            if (ddlAnalista.SelectedIndex > 0)
                stringBuilder.Append(" and e.id_empleado = '" + ddlAnalista.SelectedValue + "'");
            if (ddlUnidades.SelectedIndex > 0)
                stringBuilder.Append(" and p.id_unidad = '" + ddlUnidades.SelectedValue + "'");
            if(ddlAnalista.SelectedIndex>0)
                stringBuilder.Append(" and e.id_empleado = '" + ddlAnalista.SelectedValue + "'");

            DataSet dsResultado = pReportesLN.ReportePpto(stringBuilder.ToString());
            ReportDataSource datasource1 = new ReportDataSource("DataSet1", dsResultado.Tables[0]);
            ReportDataSource datasource2 = new ReportDataSource("DataSet2", dsResultado.Tables[1]);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource1);
            ReportViewer1.LocalReport.DataSources.Add(datasource2);
            ReportViewer1.LocalReport.Refresh();
        }
    }
}