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
    public partial class EspecificacionesIngreso : System.Web.UI.Page
    {
        private PlanEstrategicoLN pEstrategicoLN;
        private PlanOperativoLN pOperativoLN;
        private PlanAccionLN pAccionLN;
        private PlanAnualLN pAnualLN;

        private PedidosLN pInsumoLN;
        private PedidosEN pInsumoEN;
        
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                try
                {
                    Response.AddHeader("Cache-Control", "no-cache");
                    string s = Convert.ToString(Request.QueryString["No"]);
                    string mostrarBotones = Convert.ToString(Request.QueryString["OptB"]);
                    string tipoDocumento = Convert.ToString(Request.QueryString["TipoD"]);

                    if (s != null)
                    {
                        int idEncabezado = 0;
                        int.TryParse(s, out idEncabezado);
                        lblNo.Text = idEncabezado.ToString();

                        if (tipoDocumento != null)
                            lblTipoDocumento.Text = tipoDocumento;

                        pInsumoLN = new PedidosLN();
                        DataSet dsResultado = new DataSet();
                        
                        if(lblTipoDocumento.Text.Equals("R"))
                            dsResultado = pInsumoLN.InformacionPedido(idEncabezado, 0, 0, "", 2);
                        else if (lblTipoDocumento.Text.Equals("V"))
                            dsResultado = pInsumoLN.InformacionVale(idEncabezado, 0, 2);

                        if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                            throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                        if (dsResultado.Tables.Count == 0)
                            throw new Exception("Error al consultar la información del pedido.");

                        if (dsResultado.Tables[0].Rows.Count == 0)
                            throw new Exception("No existe información del pedido");

                        lblIdPedido.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_PEDIDO"].ToString();
                        lblNo.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["NO_SOLICITUD"].ToString() + "-" + dsResultado.Tables["BUSQUEDA"].Rows[0]["ANIO_SOLICITUD"].ToString();
                        lblNoAnexo.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_ANEXO"].ToString();
                        lblFecha.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["FECHA_PEDIDO"].ToString();
                        lblUnidad.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["UNIDAD_ADMINISTRATIVA"].ToString();
                        lblidunidad.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["id_unidad"].ToString();
                        lblidanio.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["ANIO_SOLICITUD"].ToString();
                        filtrarGridDetalles(idEncabezado);

                        btnGuardar.Visible = true;
                        lblError.Text = string.Empty;
                        if(int.Parse(lblNoAnexo.Text) > 0)
                            validarEstadoAnexo();

                        if (mostrarBotones != null)
                            if (bool.Parse(mostrarBotones) == false)
                                btnGuardar.Visible = btnImprimir.Visible = btnListado.Visible = false;


                    }
                }
                catch (Exception ex)
                {
                    lblError.Text = "Page_LoadComplete(). " + ex.Message;
                }
            }
        }

        protected void validarEstadoAnexo()
        {
            try
            {
                int idPedido = 0;
                int.TryParse(lblIdPedido.Text.Split('-')[0].Trim(), out idPedido);
                int idTipoDocumento = 0;
                if (lblTipoDocumento.Text.Equals("R"))
                    idTipoDocumento = 1;
                else if (lblTipoDocumento.Text.Equals("V"))
                    idTipoDocumento = 2;

                pInsumoLN = new PedidosLN();
                DataSet dsResultado = pInsumoLN.InformacionPedido(int.Parse(lblIdPedido.Text), idTipoDocumento, 0, "ENCABEZADO", 8);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                string idEstado = dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_ESTADO"].ToString();
                string estado = dsResultado.Tables["BUSQUEDA"].Rows[0]["ESTADO"].ToString();

                btnGuardar.Visible = false;
                lblError.Text = string.Empty;

                if (idEstado.Equals("1") || idEstado.Equals("2") || idEstado.Equals("3") || idEstado.Equals("6"))
                {
                    btnGuardar.Visible = true;
                    lblError.Text = string.Empty;
                }

                else if (idEstado.Equals("4") || idEstado.Equals("5"))
                {
                    btnGuardar.Visible = false;
                    lblError.Text = "La especificación se encuentra en estado " + estado + ", y no se puede modificar";
                }

                //if (idEstado.Equals("3"))
                    generarReporte(idPedido);
            }
            catch (Exception ex)
            {
                throw new Exception("validarEstadoAnexo()" + ex.Message);
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
                DataSet dsResultado = new DataSet();

                int idTipoDocumento = 0;

                if (lblTipoDocumento.Text.Equals("R"))
                    idTipoDocumento = 1;
                else if (lblTipoDocumento.Text.Equals("V"))
                    idTipoDocumento = 2;

                dsResultado = pInsumoLN.InformacionPedido(id, idTipoDocumento, 0, "DETALLE", 8);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0 && dsResultado.Tables["BUSQUEDA"].Rows[0]["ID"].ToString() != "")
                {
                    gridDet.DataSource = dsResultado.Tables["BUSQUEDA"];
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

        protected DataTable armarDtDetalles()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID_ESPECIFICACION_DETALLE", Type.GetType("System.String"));
            dt.Columns.Add("ID_ESPECIFICACION", Type.GetType("System.String"));
            dt.Columns.Add("ID_PEDIDO_DETALLE", Type.GetType("System.String"));
            dt.Columns.Add("DESCRIPCION_ESPECIFICA", Type.GetType("System.String"));
            dt.Columns.Add("USUARIO", Type.GetType("System.String"));

            return dt;
        }

        /// <summary>
        /// Boton para almacenar las especificaciones de un vale o requisicion
        /// </summary>
        /// <remarks>
        /// Se modifico la funcion para que solo almacene los datos si el usuario que ingreso es el mismo que modifica
        /// Tablas en base de datos: 
        ///  - sipa_especificaciones_pedido
        ///  - sipa_especificaciones_pedido_detalle
        /// </remarks>
        /// 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                

                int idPedido, idEspecificacion = 0;
                int.TryParse(lblIdPedido.Text.Split('-')[0].Trim(), out idPedido);
                int.TryParse(lblNoAnexo.Text, out idEspecificacion);
                pInsumoEN = new PedidosEN();

                pInsumoEN.ID_ESPECIFICACION = idEspecificacion;
                pInsumoEN.ID_PEDIDO = idPedido;
                pInsumoEN.USUARIO = Session["usuario"].ToString();
                //Nuevo
                pInsumoLN = new PedidosLN();
                DataSet usuarioIngreso = pInsumoLN.UsuarioRequisicion(idPedido.ToString());
                //
                if (pInsumoEN.USUARIO.Equals(usuarioIngreso.Tables[0].Rows[0]["usuario_ing"].ToString()))
                {

                   

                    if (lblTipoDocumento.Text.Equals("R"))
                        pInsumoEN.VID_TIPO_DOCUMENTO = "1";
                    else if (lblTipoDocumento.Text.Equals("V"))
                        pInsumoEN.VID_TIPO_DOCUMENTO = "2";

                    DataTable dtDetalles = armarDtDetalles();
                    int filas = gridDet.Rows.Count;

                    for (int i = 0; i < gridDet.Rows.Count; i++)
                    {
                        string idEspecificacionDetalle = gridDet.DataKeys[i].Values[0].ToString();
                        string idPedidoDetalle = gridDet.DataKeys[i].Values[1].ToString();
                        TextBox txtDescripcionEspecifica = gridDet.Rows[i].FindControl("txtDescripcionE") as TextBox;
                        string usuario = Session["usuario"].ToString();

                        Label lblObservaciones = (Label)gridDet.Rows[i].FindControl("lblObservaciones");

                        DataRow dr = dtDetalles.NewRow();
                        dr["ID_ESPECIFICACION"] = idEspecificacion;
                        dr["ID_ESPECIFICACION_DETALLE"] = gridDet.DataKeys[i].Values[0].ToString();
                        dr["ID_PEDIDO_DETALLE"] = gridDet.DataKeys[i].Values[1].ToString();
                        dr["DESCRIPCION_ESPECIFICA"] = (gridDet.Rows[i].FindControl("txtDescripcionE") as TextBox).Text;
                        dr["USUARIO"] = Session["usuario"].ToString();

                        dtDetalles.Rows.Add(dr);
                    }

                    pInsumoLN = new PedidosLN();
                    DataSet dsResultado = pInsumoLN.AlmacenarEspecificacion(pInsumoEN, dtDetalles);

                    if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                        throw new Exception("No se INSERTARON/ACTUALIZARON las especificaciones: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());


                    int.TryParse(dsResultado.Tables[0].Rows[0]["VALOR"].ToString(), out idEspecificacion);
                    lblNoAnexo.Text = idEspecificacion.ToString();

                    generarReporte(idPedido);

                    lblError.Text = string.Empty;
                    lblSuccess.Text = "Especificaciones ALMACENADAS/MODIFICADAS exitosamente: ";
                }
                else
                    lblError.Text = "El usuario que ingreso la requisicion no coincide con el que tiene iniciada la sesion";
            }
            catch (Exception ex)
            {
                lblError.Text = "btnGuardar(). " + ex.Message;
            }
        }

        protected void generarReporte(int idEncabezado)
        {
            try
            {
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

                    int idTipoDocumento = 0;

                    if (lblTipoDocumento.Text.Equals("R"))
                        idTipoDocumento = 1;
                    else if (lblTipoDocumento.Text.Equals("V"))
                        idTipoDocumento = 2;


                    pInsumoLN = new PedidosLN();
                    DataSet dsResultado = pInsumoLN.InformacionPedido(idEncabezado, idTipoDocumento, 0, "ENCABEZADO", 8);

                    if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                        throw new Exception("No se CONSULTÓ el encabezado de la especificación: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                    ReportDataSource RD = new ReportDataSource();
                    RD.Value = dsResultado.Tables[1];
                    RD.Name = "DataSet1";

                    dsResultado = pInsumoLN.InformacionPedido(idEncabezado, idTipoDocumento, 0, "DETALLE", 8);

                    if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                        throw new Exception("No se CONSULTÓ el detalle de la especificación: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());


                    ReportDataSource RD2 = new ReportDataSource();
                    RD2.Value = dsResultado.Tables[1];
                    RD2.Name = "DataSet2";

                    dsResultado = pInsumoLN.InforamcionPresentacion(idEncabezado);
                    ReportDataSource RD3 = new ReportDataSource();
                    RD3.Value = dsResultado.Tables[1];
                    RD3.Name = "DataSet3";

                    rViewer.LocalReport.DataSources.Clear();
                    rViewer.LocalReport.DataSources.Add(RD);
                    rViewer.LocalReport.DataSources.Add(RD2);
                    rViewer.LocalReport.DataSources.Add(RD3);
                    rViewer.LocalReport.ReportEmbeddedResource = "\\Reportes/rptCOMFOR06.rdlc";
                    rViewer.LocalReport.ReportPath = @"Reportes\\rptCOMFOR06.rdlc";
                    rViewer.LocalReport.Refresh();


                    byte[] bytes = rViewer.LocalReport.Render(
                       "PDF", null, out mimeType, out encoding,
                        out extension,
                       out streamids, out warnings);

                    string nombreReporte = "Especificaciones";

                    string direccion = Server.MapPath("ArchivoPdf");
                    direccion = (direccion + ("\\\\" + (""
                                + (nombreReporte + ".pdf"))));

                    FileStream fs = new FileStream(direccion,
                       FileMode.Create);
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Close();

                    String reDireccion = "\\ArchivoPDF/";
                    reDireccion += "\\" + "" + nombreReporte + ".pdf";


                    string jScript = "javascript:window.open('" + reDireccion + "','Especificaciones Técnicas'," + "'directories=no, location=no, menubar=no, scrollbars=yes, statusbar=no, tittlebar=no, width=750, height=400');";
                    btnImprimir.Attributes.Add("onclick", jScript);
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "btnVerReporte(). " + ex.Message;
            }
        }

        protected void ddlPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            int idPedido = 0;
            int.TryParse(lblIdPedido.Text.Split('-')[0].Trim(), out idPedido);
            generarReporte(idPedido);
        }

        protected void btnListado_Click(object sender, EventArgs e)
        {
            if (lblTipoDocumento.Text.Equals("V"))
                if (int.Parse(lblidunidad.Text) < 36)
                    Response.Redirect("~/Pedido/ValeListado.aspx?Anio=" + lblidanio.Text + "&unidad=" + lblidunidad.Text);
                else
                    Response.Redirect("~/Pedido/ValeListado.aspx?Anio=" + lblidanio.Text + "&unidad=29" + "&dep=" + lblidunidad.Text);
            else if (lblTipoDocumento.Text.Equals("R"))
                if(int.Parse(lblidunidad.Text)<36)
                    Response.Redirect("~/Pedido/PedidoListado.aspx?Anio=" + lblidanio.Text + "&unidad=" + lblidunidad.Text);
                else
                    Response.Redirect("~/Pedido/PedidoListado.aspx?Anio=" + lblidanio.Text + "&unidad=29"  + "&dep="+lblidunidad.Text);

        }
    }
}