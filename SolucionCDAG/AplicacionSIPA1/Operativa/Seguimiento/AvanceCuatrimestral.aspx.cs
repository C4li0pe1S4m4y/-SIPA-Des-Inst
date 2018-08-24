using CapaEN;
using CapaLN;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionSIPA1.Operativa.Seguimiento
{
    public partial class AvanceCuatrimestral : System.Web.UI.Page
    {
        private PlanEstrategicoLN pEstrategicoLN;
        private PlanOperativoLN pOperativoLN;
        private PlanAccionLN pAccionLN;
        private PlanAnualLN pAnualLN;

        private SeguimientoLN sSeguimientoLN;
        private SEGUIMIENTOS_CMI sSeguimientoEN;
        private SEGUIMIENTOS_CMI_DET sSeguimientoEN_DET;
       
        private FuncionesVarias funciones;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pEstrategicoLN = new PlanEstrategicoLN();
                pOperativoLN = new PlanOperativoLN();
                pAccionLN = new PlanAccionLN();
                pAnualLN = new PlanAnualLN();

              

                pEstrategicoLN.DdlAniosPlan(ddlAnios, 2016, 2020);
                ddlAnios.Items.RemoveAt(0);
                ddlCuatrimestre.Items.Add("<< Elija un valor >>");
                ddlCuatrimestre.Items[0].Value = "0";
                ddlCuatrimestre.Items.Add("Primero");
                ddlCuatrimestre.Items[1].Value = "1";
                ddlCuatrimestre.Items.Add("Segundo");
                ddlCuatrimestre.Items[2].Value = "2";
                ddlCuatrimestre.Items.Add("Tercero");
                ddlCuatrimestre.Items[3].Value = "3";
                int anioActual = DateTime.Now.Year;

                ListItem item = ddlAnios.Items.FindByValue(anioActual.ToString());
                if (item != null)
                    ddlAnios.SelectedValue = anioActual.ToString();

                string usuario = Session["Usuario"].ToString().ToLower();
                //pOperativoLN.DdlUnidadesxAnalista(ddlUnidades, usuario, int.Parse(ddlAnios.SelectedValue));
                pOperativoLN.DdlUnidades(ddlUnidades, usuario);

                if (ddlUnidades.Items.Count == 1)
                {
                    if (!ddlAnios.SelectedValue.Equals("0"))
                    {
                        validarPoaIngresoSeguimiento(int.Parse(ddlUnidades.SelectedValue), int.Parse(ddlAnios.SelectedValue));
                    }
                }
            }
        }

        protected bool validarPoaIngresoSeguimiento(int idUnidad, int anio)
        {
            bool poaValido = false;
            try
            {
                
                lblIdPoa.Text = "0";

                pOperativoLN = new PlanOperativoLN();
                DataSet dsPoa = pOperativoLN.DatosPoaUnidad(idUnidad, anio);

                if (dsPoa.Tables.Count == 0)
                    throw new Exception("Error al consultar el presupuesto.");

                if (dsPoa.Tables[0].Rows.Count == 0)
                    throw new Exception("No existe presupuesto asignado");

                int idPoa = 0;
                int.TryParse(dsPoa.Tables[0].Rows[0]["ID_POA"].ToString(), out idPoa);
                lblIdPoa.Text = idPoa.ToString();

                string estadoPoa = dsPoa.Tables[0].Rows[0]["ID_ESTADO"].ToString() + " - " + dsPoa.Tables[0].Rows[0]["ESTADO"].ToString();

                if (!estadoPoa.Split('-')[0].Trim().Equals("9"))
                {
                    
                    lblError.Text = "El CUADRO DE MANDO INTEGRAL seleccionado se encuenta en estado: " + estadoPoa;
                }
                else
                {
                    
                    poaValido = true;
                    lblError.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error: " + ex.Message;
            }
            return poaValido;
        }

        protected void ddlUnidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCuatrimestre.SelectedIndex>0)
            {
                validarPoa(int.Parse(ddlUnidades.SelectedValue), int.Parse(ddlAnios.SelectedValue));
                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);
                pOperativoLN = new PlanOperativoLN();
                DataSet data = pOperativoLN.AvanceCuatrimestral(ddlUnidades.SelectedValue, ddlAnios.SelectedValue, int.Parse(ddlCuatrimestre.SelectedValue));
                gvAvance.DataSource = data;
                gvAvance.DataBind();
                pAccionLN = new PlanAccionLN();
                pAccionLN.DdlAcciones(ddlAccion, idPoa, 0, "", 3);
                ddlAccion.Items[0].Text = "<< TODAS >>";
               
                pOperativoLN.DdlDependencias(ddlDependencias, ddlUnidades.SelectedValue);
            }
           
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
                lblIdPoa.Text = idPoa.ToString();
            }
            catch (Exception ex)
            {
                //lblErrorPoa.Text = lblError.Text = "Escoger la Dependencia para Visualizar los Datos " + ex.Message;
            }
            return poaValido;
        }

        /// <summary>
        /// Almacenar Avance
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvAvance_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                pOperativoLN = new PlanOperativoLN();
                int ID_seguimiento = 0;
                decimal dPorcentaje = 0;
                int.TryParse(gvAvance.SelectedDataKey["ID"].ToString(), out ID_seguimiento);
                string txtObservacionesM1 = (gvAvance.Rows[gvAvance.SelectedIndex].FindControl("txtObservacionesM1") as TextBox).Text;
                string txtObservacionesM2 = (gvAvance.Rows[gvAvance.SelectedIndex].FindControl("txtObservacionesM2") as TextBox).Text;
                string txtObservacionesM3 = (gvAvance.Rows[gvAvance.SelectedIndex].FindControl("txtObservacionesM3") as TextBox).Text;
                string txtObservacionesM4 = (gvAvance.Rows[gvAvance.SelectedIndex].FindControl("txtObservacionesM4") as TextBox).Text;
                string txtResumenAvance = (gvAvance.Rows[gvAvance.SelectedIndex].FindControl("txtResumenAvance") as TextBox).Text;
                string txtPorcentajeAvance = (gvAvance.Rows[gvAvance.SelectedIndex].FindControl("txtPorcentaje") as TextBox).Text;
                if(!string.IsNullOrEmpty(txtPorcentajeAvance))
                    dPorcentaje = decimal.Parse(txtPorcentajeAvance);

                pOperativoLN.ActulizarAvanceCuatrimestral(txtObservacionesM1, txtObservacionesM2, txtObservacionesM3, txtObservacionesM4, txtResumenAvance, ID_seguimiento.ToString(), int.Parse(ddlCuatrimestre.Text), txtPorcentajeAvance);
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('ALMACENADO/MODIFICADO exitosamente!');", true);
                if (dPorcentaje < 69)
                    gvAvance.Rows[gvAvance.SelectedIndex].BackColor = Color.Red;
                else if(dPorcentaje < 89)
                    gvAvance.Rows[gvAvance.SelectedIndex].BackColor = Color.LightYellow;
                else if(dPorcentaje <=100)
                    gvAvance.Rows[gvAvance.SelectedIndex].BackColor = Color.LightGreen;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('No se pudo almacenar el campo!');", true);
                throw;
            }
        
        }

        protected void ddlAnios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCuatrimestre.SelectedIndex > 0 && ddlUnidades.SelectedIndex>0)
            {
                pOperativoLN = new PlanOperativoLN();
                DataSet data = pOperativoLN.AvanceCuatrimestral(ddlUnidades.SelectedValue, ddlAnios.SelectedValue, int.Parse(ddlCuatrimestre.SelectedValue));
                gvAvance.DataSource = data;
                gvAvance.DataBind();
            }
        }

        protected void ddlCuatrimestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUnidades.SelectedIndex > 0)
            {
                pOperativoLN = new PlanOperativoLN();
                DataSet data = pOperativoLN.AvanceCuatrimestral(ddlUnidades.SelectedValue, ddlAnios.SelectedValue, int.Parse(ddlCuatrimestre.SelectedValue));
                gvAvance.DataSource = data;
                gvAvance.DataBind();
            }
        }

        protected void btnReporte_Click(object sender, EventArgs e)
        {
            try
            {
                int idEncabezado = 0;
                pOperativoLN = new PlanOperativoLN();

                
                if (!string.IsNullOrEmpty(ID))
                {

                    Warning[] warnings;
                    string[] streamids;
                    string mimeType;
                    string encoding;
                    string extension;

                    ReportViewer rViewer = new ReportViewer();

                    DataTable dt = new DataTable();
                    GridView gridPlan = new GridView();

                    ReportesLN reportes = new ReportesLN();
                    
                    DataSet dResultado =  pOperativoLN.AvanceCuatrimestral(ddlUnidades.SelectedValue, ddlAnios.SelectedValue, int.Parse(ddlCuatrimestre.SelectedValue));
                    ReportDataSource RD = new ReportDataSource();
                    RD.Value = dResultado.Tables[0];
                    RD.Name = "DataSet1";
                    rViewer.LocalReport.DataSources.Clear();
                    rViewer.LocalReport.DataSources.Add(RD);
                    rViewer.LocalReport.ReportEmbeddedResource = "\\Reportes\\rptAvanceCuatrimestral.rdlc";
                    rViewer.LocalReport.ReportPath = @"Reportes\\rptAvanceCuatrimestral.rdlc";

                    rViewer.LocalReport.Refresh();


                    byte[] bytes = rViewer.LocalReport.Render(
                        "EXCELOPENXML", null, out mimeType, out encoding,
                         out extension,
                        out streamids, out warnings);

                    string nombreReporte = "Avance Cuatrimestral - " + ddlCuatrimestre.SelectedValue;

                    Response.Buffer = true;
                    Response.Clear();
                    Response.ContentType = mimeType;
                    Response.AddHeader("content-disposition", "attachment; filename=" + nombreReporte + ".xlsx");
                    Response.BinaryWrite(bytes); // create the file
                    Response.Flush(); // send it to the client to download



                }


            }
            catch (Exception ex)
            {
                lblError.Text = "btnImprimir(). " + ex.Message;
            }
        }
    }
}