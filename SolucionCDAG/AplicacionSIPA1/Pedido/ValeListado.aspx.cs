﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using CapaLN;
using CapaEN;

using Microsoft.Reporting.WebForms;
using System.IO;

namespace AplicacionSIPA1.Pedido
{
    public partial class ValeListado : System.Web.UI.Page
    {
        private PlanEstrategicoLN pEstrategicoLN;
        private PlanOperativoLN pOperativoLN;
        private PlanAccionLN pAccionLN;
        private PlanAnualLN pAnualLN;
        private bool bDepencia = false;
        private PedidosLN pInsumoLN;

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                try
                {
                    nuevaBusqueda();
                    if (!bDepencia)
                        pOperativoLN.DdlDependencias(ddlDependencia, ddlUnidades.SelectedValue);
                }
                catch (Exception ex)
                {
                    lblError.Text = "Page_LoadComplete(). " + ex.Message;
                }
            }
        }

        protected void nuevaBusqueda()
        {
            try
            {
                limpiarControlesError();
                NuevoEncabezadoPoa();
            }
            catch (Exception ex)
            {
                lblError.Text = "btnNuevo(). " + ex.Message;
            }
        }

        public void NuevoEncabezadoPoa()
        {
            try
            {
                upIngreso.Visible = true;
                pEstrategicoLN = new PlanEstrategicoLN();
                pOperativoLN = new PlanOperativoLN();
                pAccionLN = new PlanAccionLN();
                pAnualLN = new PlanAnualLN();

                pEstrategicoLN.DdlPlanes(ddlPlanes);

                int idPlan = 0;
                int anioIni = 0;
                int anioFin = 0;
                if (ddlPlanes.Items.Count == 2)
                {
                    ddlPlanes.SelectedIndex = 1;
                    idPlan = int.Parse(ddlPlanes.SelectedValue);
                    anioIni = int.Parse(ddlPlanes.SelectedItem.Text.Split('-')[0].Trim());
                    anioFin = int.Parse(ddlPlanes.SelectedItem.Text.Split('-')[1].Trim());
                    lblPlanE.Visible = false;
                    ddlPlanes.Visible = false;
                }
                pEstrategicoLN.DdlAniosPlan(ddlAnios, anioIni, anioFin);
                ddlAnios.Items.RemoveAt(0);

                int anioActual = DateTime.Now.Year;

                ListItem item = ddlAnios.Items.FindByValue(anioActual.ToString());
                if (item != null)
                    ddlAnios.SelectedValue = Convert.ToString(Request.QueryString["Anio"]);

                string usuario = Session["Usuario"].ToString().ToLower();
                pOperativoLN.DdlUnidades(ddlUnidades, usuario);
                ddlUnidades.SelectedValue = Convert.ToString(Request.QueryString["unidad"]);
                pOperativoLN = new PlanOperativoLN();
                if ((Request.QueryString["unidad"]) != null)
                    pOperativoLN.DdlDependencias(ddlDependencia, Convert.ToString(Request.QueryString["unidad"]));

                if (Request.QueryString["dep"] != null)
                    ddlDependencia.SelectedValue = Convert.ToString(Request.QueryString["dep"]);
                if (!ddlAnios.SelectedValue.Equals("0"))
                {
                    if (ddlDependencia.Items.Count > 0 && int.Parse(ddlDependencia.SelectedValue) > 1)
                        validarPoaListadoPedido(int.Parse(ddlDependencia.SelectedValue), int.Parse(ddlAnios.SelectedValue));
                    else
                        validarPoaListadoPedido(int.Parse(ddlUnidades.SelectedValue), int.Parse(ddlAnios.SelectedValue));
                }

                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);

                pAccionLN = new PlanAccionLN();
                pAccionLN.DdlAcciones(ddlAcciones, idPoa, 0, "", 3);
                ddlAcciones.Items[0].Text = "<< Elija un valor >>";

                filtrarGridDetalles(idPoa);
            }
            catch (Exception ex)
            {
                throw new Exception("NuevoEncabezadoPoa(). " + ex.Message);
            }
        }

        protected void filtrarGridDetalles(int id)
        {
            try
            {
                gridDet.DataSource = null;
                gridDet.DataBind();
                gridDet.SelectedIndex = -1;

                pInsumoLN = new PedidosLN();
                DataSet dsResultado = pInsumoLN.InformacionVale(id, 0, 1);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0 && dsResultado.Tables["BUSQUEDA"].Rows[0]["ID"].ToString() != "")
                {
                    gridDet.DataSource = dsResultado.Tables["BUSQUEDA"];
                    gridDet.DataBind();

                    string filtro = string.Empty;

                    object obj = gridDet.DataSource;
                    System.Data.DataTable tbl = gridDet.DataSource as System.Data.DataTable;
                    System.Data.DataView dv = tbl.DefaultView;

                    if (!ddlAcciones.SelectedValue.Equals("0"))
                        filtro += " id_accion = " + ddlAcciones.SelectedValue;

                    dv.RowFilter = filtro;
                    gridDet.DataSource = dv;
                    gridDet.DataBind();
                }
                else
                {
                    gridDet.DataSource = null;
                    gridDet.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("filtrarGridDetalles(). " + ex.Message);
            }
        }

        protected void ddlAnios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();


                int anio = 0;
                int idUnidad = 0;

                int.TryParse(ddlAnios.SelectedValue, out anio);
                int.TryParse(ddlUnidades.SelectedValue, out idUnidad);

                if (anio > 0 && idUnidad > 0)
                    validarPoaListadoPedido(idUnidad, anio);
                else
                    lblIdPoa.Text = "0";


                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);

                pAccionLN = new PlanAccionLN();
                pAccionLN.DdlAcciones(ddlAcciones, idPoa, 0, "", 3);
                ddlAcciones.Items[0].Text = "<< Elija un valor >>";

                filtrarGridDetalles(idPoa);
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlAnios_SelectedIndexChanged(). " + ex.Message;
            }
        }

        protected void ddlUnidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();


                int anio = 0;
                int idUnidad = 0;

                int.TryParse(ddlAnios.SelectedValue, out anio);
                int.TryParse(ddlUnidades.SelectedValue, out idUnidad);
                if (idUnidad > 0)
                {
                    pOperativoLN = new PlanOperativoLN();
                    pOperativoLN.DdlDependencias(ddlDependencia, ddlUnidades.SelectedValue);
                }
                if (anio > 0 && idUnidad > 0)
                    validarPoaListadoPedido(idUnidad, anio);
                else
                    lblIdPoa.Text = "0";

                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);

                pAccionLN = new PlanAccionLN();
                pAccionLN.DdlAcciones(ddlAcciones, idPoa, 0, "", 3);
                ddlAcciones.Items[0].Text = "<< Elija un valor >>";

                filtrarGridDetalles(idPoa);

            }
            catch (Exception ex)
            {
                lblError.Text = "ddlUnidades_SelectedIndexChanged(). " + ex.Message;
            }
        }


        protected void ddlAcciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();

                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);

                filtrarGridDetalles(idPoa);
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlAcciones(). " + ex.Message;
            }
        }

        protected DataSet armarDsDet()
        {
            DataSet ds = new DataSet();
            ds.Tables.Add(new DataTable());
            ds.Tables[0].Columns.Add("id", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("Mes", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("Cantidad", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("Monto", Type.GetType("System.String"));
            ds.Tables[0].Columns.Add("Subtotal", Type.GetType("System.String"));

            return ds;
        }


        protected void limpiarControlesError()
        {
            lblErrorPlan.Text = string.Empty;
            lblErrorAnio.Text = lblErrorUnidad.Text = string.Empty;
            lblError.Text = lblSuccess.Text = string.Empty;
            lblErrorPoa.Text = string.Empty;
        }

        protected bool validarPoaListadoPedido(int idUnidad, int anio)
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
            }
            catch (Exception ex)
            {
                lblErrorPoa.Text = lblError.Text = "Error: " + ex.Message;
            }
            return poaValido;
        }

        protected void ddlPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarControlesError();
        }

        protected bool ValidarPpto(int idDetalleAccion, int idPac, decimal totalPac)
        {
            pAccionLN = new PlanAccionLN();
            pAnualLN = new PlanAnualLN();
            bool pptoValido = false;

            DataSet dsPptoRenglon = pAnualLN.InformacionRenglonAccion(idDetalleAccion, int.Parse(ddlAnios.SelectedValue));
            DataSet dsPptoPac = pAnualLN.InformacionPac(idPac, 2018);

            if (bool.Parse(dsPptoRenglon.Tables[0].Rows[0]["ERRORES"].ToString()))
                throw new Exception("No se consultó el presupuesto del Renglón: " + dsPptoRenglon.Tables[0].Rows[0]["MSG_ERROR"].ToString());

            if (bool.Parse(dsPptoPac.Tables[0].Rows[0]["ERRORES"].ToString()))
                throw new Exception("No se consultó el presupuesto del Plan: " + dsPptoRenglon.Tables[0].Rows[0]["MSG_ERROR"].ToString());

            decimal saldoRenglon = 0;
            decimal codificadoPac = 0;
            decimal montoActualPac = 0;

            decimal.TryParse(dsPptoRenglon.Tables["BUSQUEDA"].Rows[0]["SALDO_PAC"].ToString(), out saldoRenglon);
            decimal.TryParse(dsPptoPac.Tables["ENCABEZADO"].Rows[0]["MONTO"].ToString(), out montoActualPac);

            decimal diferenciaRenglonMontoN = (saldoRenglon + montoActualPac) - totalPac;
            if (diferenciaRenglonMontoN < 0)
                throw new Exception("El monto máximo debe ser igual o menor al monto disponible: " + String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", (saldoRenglon + montoActualPac)));


            decimal.TryParse(dsPptoPac.Tables["ENCABEZADO"].Rows[0]["CODIFICADO"].ToString(), out codificadoPac);
            decimal diferenciaCodificadoMontoN = totalPac - codificadoPac;
            if (diferenciaCodificadoMontoN < 0)
                throw new Exception("El monto mínimo debe ser igual o mayor al monto codificado/comprometido: " + String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", codificadoPac));

            pptoValido = true;
            return pptoValido;
        }


        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewRow grid = (GridViewRow)((Control)sender).Parent.Parent;
                int indice = grid.RowIndex;

                gridDet.SelectedIndex = grid.RowIndex;

                LinkButton linkB = new LinkButton();
                linkB = (LinkButton)gridDet.Rows[indice].FindControl("btnConsultar");

                if (linkB.Text.Equals("Consultar"))

                    limpiarControlesError();

                if (gridDet.SelectedValue == null)
                    throw new Exception("Seleccione un pedido!");

                int idEncabezado = 0;
                int.TryParse(gridDet.SelectedValue.ToString(), out idEncabezado);

                if (idEncabezado == 0)
                    throw new Exception("Seleccione un pedido!");


                if (ddlDependencia.SelectedIndex > 0)
                {
                    Response.Redirect("ValeIngreso.aspx?No=" + Convert.ToString(idEncabezado) + "&dep=" + ddlDependencia.SelectedValue);
                }
                Response.Redirect("ValeIngreso.aspx?No=" + Convert.ToString(idEncabezado));
            }
            catch (Exception ex)
            {
                lblError.Text = "btnConsultar(). " + ex.Message;
            }
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewRow grid = (GridViewRow)((Control)sender).Parent.Parent;
                int indice = grid.RowIndex;
                gridDet.SelectedIndex = grid.RowIndex;

                LinkButton linkB = new LinkButton();
                linkB = (LinkButton)gridDet.Rows[indice].FindControl("btnImprimirr");
                if (linkB.Text.Equals("Imprimir"))
                    limpiarControlesError();

                    int idEncabezado = 0;
                    int.TryParse(gridDet.SelectedValue.ToString(), out idEncabezado);

                    pInsumoLN = new PedidosLN();

                    DataSet dsResultado = pInsumoLN.InformacionVale(idEncabezado, 0, 2);

                    if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                        throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                    int idEstado = 0;
                    int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_ESTADO_VALE"].ToString(), out idEstado);

                if (idEstado == 14)                    
                    if (idEncabezado > 0)
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
                        DataSet dResultado = reportes.ReportesSipa(idEncabezado, 0, "VALES", 1);

                        if (bool.Parse(dResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                            throw new Exception("No se CONSULTÓ la información del vale (encabezado): " + dResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());


                        ReportDataSource RD = new ReportDataSource();
                        RD.Value = dResultado.Tables[1];
                        RD.Name = "DataSet1";

                        dResultado = reportes.ReportesSipa(idEncabezado, 0, "VALES", 2);

                        if (bool.Parse(dResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                            throw new Exception("No se CONSULTÓ la información del vale (detalles): " + dResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                        ReportDataSource RD2 = new ReportDataSource();
                        RD2.Value = dResultado.Tables[1];
                        RD2.Name = "DataSet2";

                        rViewer.LocalReport.DataSources.Clear();
                        rViewer.LocalReport.DataSources.Add(RD);
                        rViewer.LocalReport.DataSources.Add(RD2);
                        rViewer.LocalReport.ReportEmbeddedResource = "\\Reportes/rptVale.rdlc";
                        rViewer.LocalReport.ReportPath = @"Reportes\\rptVale.rdlc";
                        rViewer.LocalReport.Refresh();

                        byte[] bytes = rViewer.LocalReport.Render(
                           "PDF", null, out mimeType, out encoding,
                            out extension,
                           out streamids, out warnings);

                        string nombreReporte = "Vale";

                        string direccion = Server.MapPath("ArchivoPdf");
                        direccion = (direccion + ("\\\\" + (""
                                    + (nombreReporte + ".pdf"))));

                        FileStream fs = new FileStream(direccion,
                           FileMode.Create);
                        fs.Write(bytes, 0, bytes.Length);
                        fs.Close();

                        String reDireccion = "\\ArchivoPDF/";
                        reDireccion += "\\" + "" + nombreReporte + ".pdf";

                        string jScript = "javascript:window.open('" + reDireccion + "','VALES DE CAJA CHICA'," + "'directories=no, location=no, menubar=no, scrollbars=yes, statusbar=no, tittlebar=no, width=750, height=400');";
                        linkB.Attributes.Add("onclick", jScript);
                }
                else
                        linkB.Attributes.Clear();
            }
            catch (Exception ex)
            {
                lblError.Text = "btnImprimir(). " + ex.Message;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            GridViewRow grid = (GridViewRow)((Control)sender).Parent.Parent;
            int indice = grid.RowIndex;

            gridDet.SelectedIndex = grid.RowIndex;

            LinkButton linkB = new LinkButton();
            linkB = (LinkButton)gridDet.Rows[indice].FindControl("LinkButton1");

            if (linkB.Text.Equals("Especificaciones"))
                Response.Redirect("EspecificacionesIngreso.aspx?No=" + gridDet.SelectedValue.ToString() + "&TipoD=V");
        }

        protected void ddlDependencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();


                int anio = 0;
                int idUnidad = 0;

                int.TryParse(ddlAnios.SelectedValue, out anio);
                int.TryParse(ddlDependencia.SelectedValue, out idUnidad);

                if (idUnidad > 0)
                {
                    pOperativoLN = new PlanOperativoLN();
                    if (idUnidad != int.Parse(ddlUnidades.SelectedValue))
                    {
                        pOperativoLN.DdlDependencias(ddlJefatura, idUnidad.ToString());

                    }
                }
                if (anio > 0 && idUnidad > 0)
                    validarPoaListadoPedido(idUnidad, anio);
                else
                    lblIdPoa.Text = "0";

                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);

                pAccionLN = new PlanAccionLN();
                pAccionLN.DdlAcciones(ddlAcciones, idPoa, 0, "", 3);
                ddlAcciones.Items[0].Text = "<< Elija un valor >>";

                filtrarGridDetalles(idPoa);

            }
            catch (Exception ex)
            {
                lblError.Text = "ddlUnidades_SelectedIndexChanged(). " + ex.Message;
            }
        }

        protected void ddlJefatura_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();


                int anio = 0;
                int idUnidad = 0;

                int.TryParse(ddlAnios.SelectedValue, out anio);
                int.TryParse(ddlJefatura.SelectedValue, out idUnidad);
                if (anio > 0 && idUnidad > 0)
                    validarPoaListadoPedido(idUnidad, anio);
                else
                    lblIdPoa.Text = "0";

                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);

                pAccionLN = new PlanAccionLN();
                pAccionLN.DdlAcciones(ddlAcciones, idPoa, 0, "", 3);
                ddlAcciones.Items[0].Text = "<< Elija un valor >>";

                filtrarGridDetalles(idPoa);

            }
            catch (Exception ex)
            {
                lblError.Text = "ddlUnidades_SelectedIndexChanged(). " + ex.Message;
            }
        }
    }
}