using CapaLN;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionSIPA1.ReporteriaSistema
{
    public partial class CuatrimestresModalidades : System.Web.UI.Page
    {
        private PlanEstrategicoLN pEstrategicoLN;
        private PlanOperativoLN pOperativoLN;
        private ReportesLN pReportesLN;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pEstrategicoLN = new PlanEstrategicoLN();
                pOperativoLN = new PlanOperativoLN();
                pEstrategicoLN.DdlAniosPlan(ddlanio, 2016, 2020);
                ddlanio.Items.RemoveAt(0);
                int anioActual = DateTime.Now.Year;

                ListItem item = ddlanio.Items.FindByValue(anioActual.ToString());
                if (item != null)
                    ddlanio.SelectedValue = anioActual.ToString();

                string usuario = Session["Usuario"].ToString().ToLower();
                pOperativoLN.DdlUnidades(ddlUnidad, usuario);
                System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
                stringBuilder.Append(" and p.anio_solicitud = " + ddlanio.SelectedValue);
                ReporteG(stringBuilder.ToString());
            }
        }

        protected void ddlUnidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            pOperativoLN = new PlanOperativoLN();
            pOperativoLN.DdlDependencias(ddlDependencia, ddlUnidad.SelectedValue);
            pReportesLN = new ReportesLN();
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            stringBuilder.Append(" and p.anio_solicitud = " + ddlanio.SelectedValue);
            stringBuilder.Append(" and  p.id_unidad = " + ddlUnidad.SelectedValue);
            ReporteG(stringBuilder.ToString());
        }


        public void ReporteG(string filtro)
        {
            pReportesLN = new ReportesLN();
            DataTable dt = pReportesLN.ReporteCuatrimestre(filtro);


            DataSet thisDataSet = new System.Data.DataSet();

            /* Put the stored procedure result into a dataset */

            ReportDataSource datasource = new ReportDataSource("DataSet1", dt);

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);

            ReportViewer1.LocalReport.Refresh();
        }
    }
}