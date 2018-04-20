using CapaLN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionSIPA1.ReporteriaSistema
{
    public partial class SaldosRenglonesCuatrimestres : System.Web.UI.Page
    {
        private PlanAccionLN pAccion;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlCuatrimestre.Items.Clear();
                ddlCuatrimestre.Items.Add("<< Eliga un valor >>");
                ddlCuatrimestre.Items[0].Value = "0";
                ddlCuatrimestre.Items.Add("Primero");
                ddlCuatrimestre.Items[1].Value = "1,2,3,4";
                ddlCuatrimestre.Items.Add("Segundo");
                ddlCuatrimestre.Items[2].Value = "5,6,7,8";
                ddlCuatrimestre.Items.Add("Tercero");
                ddlCuatrimestre.Items[3].Value = "9,10,11,12";
                txtAnio.Text = "2018";
            }
          
        }

        protected void ddlCuatrimestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            pAccion = new PlanAccionLN();
            DataSet dsResultado = pAccion.InformacionPorCuatrimestre(txtAnio.Text, ddlCuatrimestre.SelectedValue);
            gridReportes.DataSource = dsResultado.Tables["BUSQUEDA"];
            gridReportes.DataBind();
        }

        protected void gridReportes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Right;
                    e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                    e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Right;

                    decimal valor = decimal.Parse(e.Row.Cells[1].Text);
                    e.Row.Cells[1].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", valor);

                    valor = decimal.Parse(e.Row.Cells[2].Text);
                    e.Row.Cells[2].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", valor);

                    valor = decimal.Parse(e.Row.Cells[3].Text);
                    e.Row.Cells[3].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", valor);
                }
            }
            catch (Exception ex)
            {
                // lblError.Text = "gridReportes_RowDataBound(). " + ex.Message;
            }
        }

        protected void txtAnio_TextChanged(object sender, EventArgs e)
        {
            pAccion = new PlanAccionLN();
            DataSet dsResultado = pAccion.InformacionPorCuatrimestre(txtAnio.Text, ddlCuatrimestre.SelectedValue);
            gridReportes.DataSource = dsResultado.Tables["BUSQUEDA"];
            gridReportes.DataBind();
        }
    }
}