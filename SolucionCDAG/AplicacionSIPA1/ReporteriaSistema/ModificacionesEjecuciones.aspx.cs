using CapaAD;
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
    public partial class ModificacionesEjecuciones : System.Web.UI.Page
    {
        private ReportesAD pedido;
        private PlanEstrategicoLN pEstrategicoLN;
        private PlanOperativoLN pOperativoLN;
        private PlanAccionLN pAccionLN;
        private PlanAnualLN pAnualLN;
        private PedidosLN pInsumoLN;
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
                DataSet dsResultado = pInsumoLN.InformacionPermisos(0, 0, criterio, 12);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());
                pOperativoLN.DdlUnidades(ddlUnidades);
                pOperativoLN.DdlDependencias(ddlDependencias, ddlUnidades.SelectedValue);


                pedido = new ReportesAD();
                DataTable dt = pedido.EjecucionyModificaciones(" and a.anio= " + ddlAnios.SelectedValue);


                DataSet thisDataSet = new System.Data.DataSet();

                /* Put the stored procedure result into a dataset */

                ReportDataSource datasource = new ReportDataSource("DataSet1", dt);

                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource);

                ReportViewer1.LocalReport.Refresh();
            }

        }

        protected void ddlAnios_SelectedIndexChanged(object sender, EventArgs e)
        {
            pedido = new ReportesAD();
            DataTable dt = pedido.EjecucionyModificaciones(" and a.anio= " + ddlAnios.SelectedValue);


            DataSet thisDataSet = new System.Data.DataSet();

            /* Put the stored procedure result into a dataset */

            ReportDataSource datasource = new ReportDataSource("DataSet1", dt);

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);

            ReportViewer1.LocalReport.Refresh();
        }

        protected void ddlUnidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            pedido = new ReportesAD();
            DataTable dt = pedido.EjecucionyModificaciones(" and a.anio= " + ddlAnios.SelectedValue + " and u.id_padre =" + ddlUnidades.SelectedValue);


            DataSet thisDataSet = new System.Data.DataSet();

            /* Put the stored procedure result into a dataset */

            ReportDataSource datasource = new ReportDataSource("DataSet1", dt);

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);

            ReportViewer1.LocalReport.Refresh();
        }

        protected void ddlDependencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            pedido = new ReportesAD();
            DataTable dt = pedido.EjecucionyModificaciones(" and a.anio= " + ddlAnios.SelectedValue + " and u.id_unidad =" + ddlDependencias.SelectedValue);


            DataSet thisDataSet = new System.Data.DataSet();

            /* Put the stored procedure result into a dataset */

            ReportDataSource datasource = new ReportDataSource("DataSet1", dt);

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);

            ReportViewer1.LocalReport.Refresh();
        }
    }
}