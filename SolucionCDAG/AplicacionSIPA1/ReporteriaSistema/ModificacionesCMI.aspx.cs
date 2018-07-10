using CapaAD;
using CapaLN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Configuration;
using AplicacionSIPA1.Reportes.Crystal;
using Microsoft.Reporting.WebForms;
using MySql.Data.MySqlClient;

namespace AplicacionSIPA1.ReporteriaSistema
{
    public partial class ModificacionesCMI : System.Web.UI.Page
    {
        private PlanEstrategicoLN pEstrategicoLN;
        private PlanOperativoLN pOperativoLN;
        private PlanAccionLN pAccionLN;
        private PlanAnualLN pAnualLN;
        private PedidosAD pedido;
        private PedidosLN pInsumoLN;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
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

                    if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0)
                    {
                        pOperativoLN.DdlUnidades(ddlUnidades);
                        pOperativoLN.DdlDependencias(ddlDependencias, ddlUnidades.SelectedValue);
                    }
                    else
                    {
                        pOperativoLN.DdlUnidades(ddlUnidades, usuario);
                        pOperativoLN.DdlDependencias(ddlDependencias, ddlUnidades.SelectedValue);
                    }
                    if (ddlUnidades.Items.Count < 2)
                    {
                        //ddlUnidades_SelectedIndexChanged(sender, e);
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void ddlUnidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReportViewer1.Visible = true;
            ReportViewer2.Visible = false;
            pOperativoLN = new PlanOperativoLN();
            pOperativoLN.DdlDependencias(ddlDependencias, ddlUnidades.SelectedValue);
            pOperativoLN = new PlanOperativoLN();
            DataSet dsPoa = pOperativoLN.DatosPoaUnidad(int.Parse(ddlUnidades.SelectedValue), int.Parse(ddlAnios.SelectedValue));
            int idPoa = 0;
            int.TryParse(dsPoa.Tables[0].Rows[0]["ID_POA"].ToString(), out idPoa);
            pAccionLN = new PlanAccionLN();
            pAccionLN.DdlAcciones(ddlAccion, idPoa, 0, "", 3);
            ddlAccion.Items[0].Text = "<< TODAS >>";
            pedido = new PedidosAD();
            DataTable dt = pedido.CMIModificaciones(idPoa.ToString());
           
           
            DataSet thisDataSet = new System.Data.DataSet();

            /* Put the stored procedure result into a dataset */
           
            ReportDataSource datasource = new ReportDataSource("DataSet1", dt);

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
           
            ReportViewer1.LocalReport.Refresh();




        }

        /// <summary>
        /// Dependencias
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlDependencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReportViewer1.Visible = true;
            ReportViewer2.Visible = false;
            rptModificacionesCMI rpt;
            pOperativoLN = new PlanOperativoLN();
            DataSet dsPoa = pOperativoLN.DatosPoaUnidad(int.Parse(ddlDependencias.SelectedValue), int.Parse(ddlAnios.SelectedValue));
            int idPoa = 0;
            int.TryParse(dsPoa.Tables[0].Rows[0]["ID_POA"].ToString(), out idPoa);
            pAccionLN = new PlanAccionLN();
            pAccionLN.DdlAcciones(ddlAccion, idPoa, 0, "", 3);
            ddlAccion.Items[0].Text = "<< TODAS >>";
            pedido = new PedidosAD();
            DataTable dt = pedido.CMIModificaciones(idPoa.ToString());
            rpt = new rptModificacionesCMI();
            rpt.SetDataSource(dt);

            DataSet thisDataSet = new System.Data.DataSet();

            /* Put the stored procedure result into a dataset */

            ReportDataSource datasource = new ReportDataSource("DataSet1", dt);

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);

            ReportViewer1.LocalReport.Refresh();
        }
        /// <summary>
        /// Acciones de una unidad o dependencia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlAccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            rptModificacionesCMI rpt;
            pOperativoLN = new PlanOperativoLN();
            DataSet dsPoa = new DataSet();
            if (int.Parse(ddlDependencias.SelectedValue) >0)
                dsPoa = pOperativoLN.DatosPoaUnidad(int.Parse(ddlDependencias.SelectedValue), int.Parse(ddlAnios.SelectedValue));
            else
                dsPoa = pOperativoLN.DatosPoaUnidad(int.Parse(ddlUnidades.SelectedValue), int.Parse(ddlAnios.SelectedValue));
            int idPoa = 0;
            int.TryParse(dsPoa.Tables[0].Rows[0]["ID_POA"].ToString(), out idPoa);
            pedido = new PedidosAD();
            string query = idPoa.ToString() + " and ac.id_accion = " + ddlAccion.SelectedValue;
            DataTable dt = pedido.CMIModificaciones(query);
            rpt = new rptModificacionesCMI();

            rpt.SetDataSource(dt);
            DataSet thisDataSet = new System.Data.DataSet();

            /* Put the stored procedure result into a dataset */

            ReportDataSource datasource = new ReportDataSource("DataSet1", dt);

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);

            ReportViewer1.LocalReport.Refresh();

        }
        /// <summary>
        /// Reporte Para Analistas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnReport_Click(object sender, EventArgs e)
        {
            ReportViewer1.Visible = false;
            ReportViewer2.Visible = true;
            pOperativoLN = new PlanOperativoLN();
            DataSet dsPoa = new DataSet();
            if (int.Parse(ddlDependencias.SelectedValue) > 0)
                dsPoa = pOperativoLN.DatosPoaUnidad(int.Parse(ddlDependencias.SelectedValue), int.Parse(ddlAnios.SelectedValue));
            else
                dsPoa = pOperativoLN.DatosPoaUnidad(int.Parse(ddlUnidades.SelectedValue), int.Parse(ddlAnios.SelectedValue));
            int idPoa = 0;
            int.TryParse(dsPoa.Tables[0].Rows[0]["ID_POA"].ToString(), out idPoa);
           
            pedido = new PedidosAD();
            DataTable dt = pedido.CMIModificacionesAnalista(idPoa.ToString());


            DataSet thisDataSet = new System.Data.DataSet();

            /* Put the stored procedure result into a dataset */

            ReportDataSource datasource = new ReportDataSource("DataSet1", dt);

            ReportViewer2.LocalReport.DataSources.Clear();
            ReportViewer2.LocalReport.DataSources.Add(datasource);

            ReportViewer2.LocalReport.Refresh();


        }



    }
}