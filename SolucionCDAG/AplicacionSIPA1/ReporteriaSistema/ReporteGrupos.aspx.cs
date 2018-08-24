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
    public partial class ReporteGrupos : System.Web.UI.Page
    {
        private PlanEstrategicoLN pEstrategicoLN;
        private PlanOperativoLN pOperativoLN;
        private PlanAccionLN pAccionLN;
        private PlanAnualLN pAnualLN;
        private ReportesLN pReportes;
        private PedidosLN pInsumoLN;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
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

                stringBuilder.Append(" Where a.anio = " + ddlAnios.SelectedValue);
                if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0)
                {
                    pOperativoLN.DdlUnidades(ddlUnidades);
                    pOperativoLN.DdlDependencias(ddlDependencia, ddlUnidades.SelectedValue);
                    stringBuilder.Append(" and u.id_padre = " + ddlUnidades.SelectedValue);
                }
                else
                {
                    pOperativoLN.DdlUnidades(ddlUnidades, usuario);
                    pOperativoLN.DdlDependencias(ddlDependencia, ddlUnidades.SelectedValue);
                    
                }
                if (ddlUnidades.Items.Count < 2)
                {
                    //ddlUnidades_SelectedIndexChanged(sender, e);
                }
                ReporteG(stringBuilder.ToString());

            }
        }
         public void ReporteG(string filtro)
        {
            pReportes = new ReportesLN();
            DataTable dt = pReportes.GruposRenglones(filtro);


            DataSet thisDataSet = new System.Data.DataSet();

            /* Put the stored procedure result into a dataset */

            ReportDataSource datasource = new ReportDataSource("DataSet1", dt);

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);

            ReportViewer1.LocalReport.Refresh();
        }
        protected bool validarPoa(int idUnidad, int anio)
        {
            bool poaValido = false;
            try
            {
                pOperativoLN = new PlanOperativoLN();
                DataSet dsPoa = pOperativoLN.DatosPoaUnidad(idUnidad, anio);

                if (dsPoa.Tables.Count == 0)
                    throw new Exception("Error al consultar el presupuesto.");

                if (dsPoa.Tables[0].Rows.Count == 0)
                    throw new Exception("No existe presupuesto asignado");

                int idPoa = 0;
                int.TryParse(dsPoa.Tables[0].Rows[0]["ID_POA"].ToString(), out idPoa);
                lblPoa.Text = idPoa.ToString();
            }
            catch (Exception ex)
            {
                // throw new Exception("validarPoa(). " + ex.Message);
            }
            return poaValido;
        }

        protected void ddlAnios_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            stringBuilder.Append(" Where a.anio = " + ddlAnios.SelectedValue);
            if(ddlUnidades.SelectedIndex>0)
                stringBuilder.Append(" and u.id_padre = " + ddlUnidades.SelectedValue);
            if(ddlDependencia.SelectedIndex >0)
                stringBuilder.Append(" and u.id_unidad = " + ddlDependencia.SelectedValue);
            ReporteG(stringBuilder.ToString());
        }

        protected void ddlUnidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            pOperativoLN = new PlanOperativoLN();
            pOperativoLN.DdlDependencias(ddlDependencia, ddlUnidades.SelectedValue);

            validarPoa(int.Parse(ddlUnidades.SelectedValue), int.Parse(ddlAnios.SelectedValue));

            int idPoa = 0;
            int.TryParse(lblPoa.Text, out idPoa);
            pAccionLN = new PlanAccionLN();
            pAccionLN.DdlAcciones(ddlAcciones, idPoa, 0, "", 3);
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            stringBuilder.Append(" Where a.anio = " + ddlAnios.SelectedValue);
            stringBuilder.Append(" and u.id_padre = " + ddlUnidades.SelectedValue);
            ReporteG(stringBuilder.ToString());
        }

        protected void ddlDependencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            validarPoa(int.Parse(ddlDependencia.SelectedValue), int.Parse(ddlAnios.SelectedValue));

            int idPoa = 0;
            int.TryParse(lblPoa.Text, out idPoa);
            pAccionLN = new PlanAccionLN();
            pAccionLN.DdlAcciones(ddlAcciones, idPoa, 0, "", 3);
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            stringBuilder.Append(" Where a.anio = " + ddlAnios.SelectedValue);
            stringBuilder.Append(" and u.id_unidad = " + ddlDependencia.SelectedValue);
            ReporteG(stringBuilder.ToString());
        }

        protected void ddlAcciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            stringBuilder.Append(" Where b.id_accion =  " + ddlAcciones.SelectedValue);
            
            ReporteG(stringBuilder.ToString());
        }
    }
}