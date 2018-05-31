using System;
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
    public partial class PedidoListado : System.Web.UI.Page
    {
        private PlanEstrategicoLN pEstrategicoLN;
        private PlanOperativoLN pOperativoLN;
        private PlanAccionLN pAccionLN;
        private PlanAnualLN pAnualLN;
        private PlanOperativoLN planOperativoLN;
        private PedidosLN pInsumoLN;
        private bool bDepencia = false;

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                try
                {
                    nuevaBusqueda();
                    InformacionPublica_TribunalHonor();
                    planOperativoLN = new PlanOperativoLN();
                    if (!bDepencia)
                        planOperativoLN.DdlDependencias(ddlDependencia, ddlUnidades.SelectedValue);
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
                //if (ddlUnidades.Items.Count == 1)
                //{
                //    if (!ddlAnios.SelectedValue.Equals("0"))
                //    {
                //        validarPoaListadoPedido(int.Parse(ddlUnidades.SelectedValue), int.Parse(ddlAnios.SelectedValue));
                //    }
                //}
                if (!ddlAnios.SelectedValue.Equals("0"))
                {
                    validarPoaListadoPedido(int.Parse(ddlUnidades.SelectedValue), int.Parse(ddlAnios.SelectedValue));
                }
                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);

                pAccionLN = new PlanAccionLN();
                //pAccionLN.DdlAccionesPoa(ddlAcciones, idPoa);
                pAccionLN.DdlAcciones(ddlAcciones, idPoa, 0, "", 3);
                ddlAcciones.Items[0].Text = "<< Elija un valor >>";
                ddlTipo.ClearSelection();
                ddlTipo.Items.Add("<< >>");
                ddlTipo.Items[0].Value = "0";
                ddlTipo.Items.Add("Bien");
                ddlTipo.Items[1].Value = "B";
                ddlTipo.Items.Add("Servicio");
                ddlTipo.Items[2].Value = "S";
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
                DataSet dsResultado = pInsumoLN.InformacionPedido(id, 0, 0, "", 1);

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
                    filtro += " id > 0 ";
                    if (!ddlAcciones.SelectedValue.Equals("0"))
                        filtro += " AND id_accion = " + ddlAcciones.SelectedValue;
                    if (!string.IsNullOrEmpty(txtNoReq.Text))
                        filtro += " AND no_solicitud =  " + txtNoReq.Text ;
                    if (!ddlTipo.SelectedValue.Equals("0"))
                        filtro += " AND tipo_pedido = '" + ddlTipo.SelectedValue + "'" ;
                    if (!string.IsNullOrEmpty(txtJustificacion.Text))
                        filtro += " AND justificacion like '%" + txtJustificacion.Text + "%'";
                    dv.RowFilter = filtro;
                    gridDet.DataSource = dv;
                    gridDet.DataBind();
                    decimal tMonto = 0;
                    DataRow[] drArray = tbl.Select(filtro);

                    foreach (DataRow drDatos in drArray)
                    {
                        tMonto += decimal.Parse(stringToDecimalString(drDatos["total"].ToString()));
                      
                    }
                    gridDet.FooterRow.Cells[7].Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", tMonto);
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
        protected string stringToDecimalString(string s)
        {
            s = s.Replace("Q. ", "");
            s = s.Replace("Q.", "");
            s = s.Replace("Q", "");
            s = s.Replace(" ", "");
            s = s.Replace(",", "");

            if (s.Equals(""))
                return "00.00";

            return s;
        }
        protected void InformacionPublica_TribunalHonor()
        {
            try
            {
                pInsumoLN = new PedidosLN();
                DataSet dsResultado = pInsumoLN.InformacionPermisos(0, 0, Session["usuario"].ToString(), 10);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                //ELABORADOR O ENVIA REQUISICIONES DE UNIDAD DE ACCESO LA INFORMACIÓN PÚBLICA
                DataRow[] drPermisos = dsResultado.Tables["BUSQUEDA"].Select(" ID_TIPO = 42 OR ID_TIPO = 43");
                ListItem item = new ListItem();

                if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0)
                {
                    if (drPermisos != null)
                        item = ddlAcciones.Items.FindByValue("366");

                    if (item != null)
                    {
                        ddlAcciones.SelectedValue = item.Value;
                        ddlAcciones.Enabled = false;
                        ddlAcciones_SelectedIndexChanged(new Object(), new EventArgs());
                    }
                }
                else
                {
                    dsResultado = pInsumoLN.InformacionPermisos(0, 0, Session["usuario"].ToString(), 11);
                    drPermisos = dsResultado.Tables["BUSQUEDA"].Select(" ID_TIPO = 45 OR ID_TIPO = 46");

                    if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0)
                    {
                        if (drPermisos != null)
                            item = ddlAcciones.Items.FindByValue("366");

                        if (item != null)
                        {
                            ddlAcciones.SelectedValue = item.Value;
                            ddlAcciones.Enabled = false;
                            ddlAcciones_SelectedIndexChanged(new Object(), new EventArgs());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("InformacionPublica_TribunalHonor(). " + ex.Message);
            }
        }

        protected void ddlAnios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                LimpiarFiltro();

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
                //pAccionLN.DdlAccionesPoa(ddlAcciones, idPoa);
                pAccionLN.DdlAcciones(ddlAcciones, idPoa, 0, "", 3);
                ddlAcciones.Items[0].Text = "<< Elija un valor >>";

                InformacionPublica_TribunalHonor();

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
                LimpiarFiltro();

                int anio = 0;
                int idUnidad = 0;
                string id_unidad = ddlUnidades.SelectedItem.Value;
                int.TryParse(ddlAnios.SelectedValue, out anio);
                int.TryParse(ddlUnidades.SelectedValue, out idUnidad);


                if (anio > 0 && idUnidad > 0)
                {
                    planOperativoLN = new PlanOperativoLN();
                    planOperativoLN.DdlDependencias(ddlDependencia, id_unidad);
                    validarPoaListadoPedido(idUnidad, anio);
                }

                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);

                pAccionLN = new PlanAccionLN();
                //pAccionLN.DdlAccionesPoa(ddlAcciones, idPoa);
                pAccionLN.DdlAcciones(ddlAcciones, idPoa, 0, "", 3);
                ddlAcciones.Items[0].Text = "<< Elija un valor >>";


                InformacionPublica_TribunalHonor();

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
                LimpiarFiltro();
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
            lblErrorPoa.Text = string.Empty;
            lblErrorPlan.Text = string.Empty;
            lblErrorAnio.Text = lblErrorUnidad.Text = string.Empty;
            lblError.Text = lblSuccess.Text = string.Empty;
            
           

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

                int multianual = 0;
                int.TryParse(gridDet.SelectedDataKey["multianual"].ToString(), out multianual);
                if (multianual == 0)
                {
                    if (ddlDependencia.SelectedIndex > 0)
                    {
                        Response.Redirect("PedidoIngreso.aspx?No=" + Convert.ToString(idEncabezado) + "&dep=" + ddlDependencia.SelectedValue);
                    }
                    Response.Redirect("PedidoIngreso.aspx?No=" + Convert.ToString(idEncabezado));
                }
                else
                {
                    Response.Redirect("Multianuales/PedidoMultianual.aspx?No=" + Convert.ToString(idEncabezado));
                }
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

                limpiarControlesError();

                int idEncabezado = 0;
                int.TryParse(gridDet.SelectedValue.ToString(), out idEncabezado);

                pInsumoLN = new PedidosLN();

                DataSet dsResultado = pInsumoLN.InformacionPedido(idEncabezado, 0, 0, "", 2);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                int idEstado = 0;
                int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_ESTADO_PEDIDO"].ToString(), out idEstado);

                if (idEstado == 8)
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
                        DataSet dResultado = reportes.ReportesSipa(idEncabezado, 0, "PEDIDOS", 1);

                        if (bool.Parse(dResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                            throw new Exception("No se CONSULTÓ la información de la requisición (encabezado): " + dResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());


                        ReportDataSource RD = new ReportDataSource();
                        RD.Value = dResultado.Tables[1];
                        RD.Name = "DataSet1";

                        dResultado = reportes.ReportesSipa(idEncabezado, 0, "PEDIDOS", 2);

                        if (bool.Parse(dResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                            throw new Exception("No se CONSULTÓ la información de la requisición (detalles): " + dResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                        ReportDataSource RD2 = new ReportDataSource();
                        RD2.Value = dResultado.Tables[1];
                        RD2.Name = "DataSet2";

                        dsResultado = pInsumoLN.InformacionProductoSub(idEncabezado);
                        ReportDataSource RD3 = new ReportDataSource();
                        RD3.Value = dsResultado.Tables[1];
                        RD3.Name = "DataSet3";

                        rViewer.LocalReport.DataSources.Clear();
                        rViewer.LocalReport.DataSources.Add(RD);
                        rViewer.LocalReport.DataSources.Add(RD2);
                        rViewer.LocalReport.DataSources.Add(RD3);
                        rViewer.LocalReport.ReportEmbeddedResource = "\\Reportes/rptRequisicion.rdlc";
                        rViewer.LocalReport.ReportPath = @"Reportes\\rptRequisicion.rdlc";
                        rViewer.LocalReport.Refresh();


                        byte[] bytes = rViewer.LocalReport.Render(
                           "PDF", null, out mimeType, out encoding,
                            out extension,
                           out streamids, out warnings);

                        string nombreReporte = "Requisicion";

                        string direccion = Server.MapPath("ArchivoPdf");
                        direccion = (direccion + ("\\\\" + (""
                                    + (nombreReporte + ".pdf"))));

                        FileStream fs = new FileStream(direccion,
                           FileMode.Create);
                        fs.Write(bytes, 0, bytes.Length);
                        fs.Close();

                        String reDireccion = "\\ArchivoPDF/";
                        reDireccion += "\\" + "" + nombreReporte + ".pdf";


                        string jScript = "javascript:window.open('" + reDireccion + "','REQUISICIONES'," + "'directories=no, location=no, menubar=no, scrollbars=yes, statusbar=no, tittlebar=no, width=750, height=400');";
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
                Response.Redirect("EspecificacionesIngreso.aspx?No=" + gridDet.SelectedValue.ToString() + "&TipoD=R");

        }

        protected void ddlDependencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                LimpiarFiltro();

                int anio = 0;
                int idUnidad = 0;
                string id_unidad = ddlDependencia.SelectedItem.Value;
                int.TryParse(ddlAnios.SelectedValue, out anio);
                int.TryParse(ddlDependencia.SelectedValue, out idUnidad);


                if (anio > 0 && idUnidad > 0)
                {
                    planOperativoLN = new PlanOperativoLN();
                    planOperativoLN.DdlDependencias(ddlJefaturaUnidad, id_unidad);
                    validarPoaListadoPedido(idUnidad, anio);
                }

                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);

                pAccionLN = new PlanAccionLN();
                pAccionLN.DdlAcciones(ddlAcciones, idPoa, 0, "", 3);
                ddlAcciones.Items[0].Text = "<< Elija un valor >>";
                bDepencia = true;
                InformacionPublica_TribunalHonor();

                filtrarGridDetalles(idPoa);

            }
            catch (Exception ex)
            {
                lblError.Text = "ddlUnidades_SelectedIndexChanged(). " + ex.Message;
            }
        }

        protected void ddlJefaturaUnidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                LimpiarFiltro();

                int anio = 0;
                int idUnidad = 0;
                string id_unidad = ddlJefaturaUnidad.SelectedItem.Value;
                int.TryParse(ddlAnios.SelectedValue, out anio);
                int.TryParse(ddlJefaturaUnidad.SelectedValue, out idUnidad);


                if (anio > 0 && idUnidad > 0)
                {

                    validarPoaListadoPedido(idUnidad, anio);
                }

                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);

                pAccionLN = new PlanAccionLN();
                pAccionLN.DdlAcciones(ddlAcciones, idPoa, 0, "", 3);
                ddlAcciones.Items[0].Text = "<< Elija un valor >>";

                InformacionPublica_TribunalHonor();

                filtrarGridDetalles(idPoa);

            }
            catch (Exception ex)
            {
                lblError.Text = "ddlUnidades_SelectedIndexChanged(). " + ex.Message;
            }
        }

        protected void btnRenglon_Click(object sender, ImageClickEventArgs e)
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
        protected void LimpiarFiltro()
        {
            txtNoReq.Text = string.Empty;
            txtJustificacion.Text = string.Empty;
            ddlTipo.ClearSelection();
        }


    }
}