using CapaLN;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AplicacionSIPA1.Compras
{
    public partial class FechaTraslado : System.Web.UI.Page
    {
        private PlanEstrategicoLN pEstrategicoLN;
        private PedidosLN pInsumoLN;
        private PlanAnualLN pAnualLN;
        private FuncionesVarias funciones;
        private PlanOperativoLN pOperativoLN;
        private ReportesLN pReportLN;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pEstrategicoLN = new PlanEstrategicoLN();
                pAnualLN = new PlanAnualLN();
                pEstrategicoLN.DdlAniosPlan(ddlanio, 2016, 2020);
                ddlanio.Items.RemoveAt(0);
                int anioActual = DateTime.Now.Year;

                ListItem item = ddlanio.Items.FindByValue(anioActual.ToString());
                if (item != null)
                    ddlanio.SelectedValue = anioActual.ToString();
                pAnualLN.DdlModalidades(ddlModalidadCompra);
                pAnualLN.DdlCentroCosto(ddlCentroCosto);

            }
        }

        protected void btnBusqueda_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNo.Text))
            {
                pInsumoLN = new PedidosLN();
                DataSet dsResultado = new DataSet();
                dsResultado = pInsumoLN.InformacionPedidoCompras(int.Parse(txtNo.Text), int.Parse(ddlanio.SelectedValue));
                if (dsResultado != null)
                {
                    idpedido.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["id_pedido"].ToString();
                    txtUnidad.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["padre"].ToString();
                    txtDependecia.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["unidad"].ToString();
                    txtFechaCreacion.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["fecha_ingreso"].ToString();
                    txtFechaMesaEntrada.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["fecha_ingreso_compras"].ToString();
                    txtFechaAsignacionTecnico.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["fecha_tecnico"].ToString();
                    txtTecnico.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["nombres"].ToString();
                    txtDescripcion.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["justificacion"].ToString();
                    txtTipoCompra.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["tipo_compra"].ToString();
                    txtMontoEstimado.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["costo_pedido"].ToString();
                    ListItem item = ddlCentroCosto.Items.FindByValue(dsResultado.Tables["BUSQUEDA"].Rows[0]["id_centro_costo"].ToString());
                    if (item != null)
                        ddlCentroCosto.SelectedValue = dsResultado.Tables["BUSQUEDA"].Rows[0]["id_centro_costo"].ToString();
                    item = ddlModalidadCompra.Items.FindByValue(dsResultado.Tables["BUSQUEDA"].Rows[0]["id_modalidad"].ToString());
                    if (item != null)
                        ddlModalidadCompra.SelectedValue = dsResultado.Tables["BUSQUEDA"].Rows[0]["id_modalidad"].ToString();
                    txtModificacion.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["fecha_modificacion"].ToString();
                    cbActaNegociacion.Checked = dsResultado.Tables["BUSQUEDA"].Rows[0]["acta_negociacion"].ToString().Equals("0") ? false : true;
                    txtNotas.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["notas"].ToString();
                    txtFechaTrasladoVisa.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["fecha_traslado_visa"].ToString();
                    txtFechaAmpliacion.Text = dsResultado.Tables["Busqueda"].Rows[0]["fecha_ampliacion"].ToString();
                    string jScript = "javascript:window.open('ETVoBoN2.aspx?No=" + idpedido.Text + "&OptB=true&TipoD=R" + "', '_blank');";
                    lbAnexo.Attributes.Add("onclick", jScript);
                    lbAnexo.Text = dsResultado.Tables["Busqueda"].Rows[0]["id_tipo_anexo"].ToString();
                    txtIngresoInventarios.Text = dsResultado.Tables["Busqueda"].Rows[0]["fecha_ingreso_inventarios"].ToString();
                    txtTrasladoInventarios.Text = dsResultado.Tables["Busqueda"].Rows[0]["fecha_traslado_inventarios"].ToString();
                }



                dsResultado = pInsumoLN.InformacionPedidoComprasDetalle(int.Parse(txtNo.Text), int.Parse(ddlanio.SelectedValue));
                gvDetalle.DataSource = dsResultado.Tables["BUSQUEDA"];
                gvDetalle.DataBind();
            }
        }

        protected void gvDetalle_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DropDownList dropProveedor = (DropDownList)e.Row.FindControl("ddlProveedor");
                    pInsumoLN = new PedidosLN();
                    pInsumoLN.DdlProveedores(dropProveedor, 1);
                    DataRow row = ((DataRowView)e.Row.DataItem).Row;

                    int id = 0;
                    int.TryParse(row["ID_PROVEEDOR"].ToString(), out id);

                    if (id > 0)
                    {
                        ListItem item = dropProveedor.Items.FindByValue(id.ToString());

                        if (item != null)
                            //dropProveedor.SelectedValue = id.ToString();
                            dropProveedor.SelectedValue = id.ToString();
                    }

                    DropDownList dropEstatus = (DropDownList)e.Row.FindControl("ddlEstatus");
                    pInsumoLN = new PedidosLN();
                    pInsumoLN.DdlEstatusCompras(dropEstatus);
                    row = ((DataRowView)e.Row.DataItem).Row;

                    id = 0;
                    int.TryParse(row["ID_ESTATUS_COMPRAS"].ToString(), out id);

                    if (id > 0)
                    {
                        ListItem item = dropEstatus.Items.FindByValue(id.ToString());

                        if (item != null)
                            //dropProveedor.SelectedValue = id.ToString();
                            dropEstatus.SelectedValue = id.ToString();
                    }

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                pOperativoLN = new PlanOperativoLN();
                int idSalida, idTipoSalida;
                idSalida = idTipoSalida = 0;
                if (!string.IsNullOrEmpty(idpedido.Text))
                    int.TryParse(idpedido.Text, out idSalida);



                if (idSalida == 0)
                    throw new Exception("Seleccione un PEDIDO!");
                AlmacenarEncabezado();
                System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
                //Detalle Pedido
                if (validarControlesABC())
                {
                    decimal cantidad, costoUnitario, subTotal, sumCantidad, sumCosto, sumSubtotal;
                    sumCantidad = 0;
                    sumCosto = 0;
                    sumSubtotal = 0;
                    for (int i = 0; i < gvDetalle.Rows.Count; i++)
                    {
                        DropDownList ddlProveedor, ddlEstadoCompmras;
                        TextBox txtCantidad, txtCosto, txtCostoReal, txtNoOrden, txtFechaOrden, txtFechaTrasladoOC,
                            txtFactura, txtFechaFactura, txtFechaTrasladoAlmacen, txtFechaIngresoSB, txtFTrasladoFRotativo, txtFechaCotizacion, txtFechaRazonamiento;
                        cantidad = 0;
                        costoUnitario = 0;
                        subTotal = 0;
                        Label lblCostoReal = new Label();
                        Label lblIVA = new Label();
                        txtCantidad = new TextBox();
                        txtCosto = new TextBox();
                        txtCostoReal = new TextBox();
                        ddlProveedor = new DropDownList();
                        ddlEstadoCompmras = new DropDownList();
                        txtNoOrden = txtFechaOrden = new TextBox();

                        lblCostoReal = (gvDetalle.Rows[i].FindControl("lblSubtotalEstimado") as Label);
                        lblIVA = (gvDetalle.Rows[i].FindControl("lblIVA") as Label);
                        txtCantidad = (gvDetalle.Rows[i].FindControl("txtCantidadReal") as TextBox);
                        txtCostoReal = (gvDetalle.Rows[i].FindControl("txtCostoUReal") as TextBox);
                        ddlProveedor = (gvDetalle.Rows[i].FindControl("ddlProveedor") as DropDownList);
                        ddlEstadoCompmras = (gvDetalle.Rows[i].FindControl("ddlEstatus") as DropDownList);
                        txtNoOrden = (gvDetalle.Rows[i].FindControl("txtOrdenCompra") as TextBox);
                        txtFechaOrden = (gvDetalle.Rows[i].FindControl("txtFechaOrdenCompra") as TextBox);
                        txtFechaTrasladoOC = (gvDetalle.Rows[i].FindControl("txtFechaTrasladoOC") as TextBox);
                        txtFactura = (gvDetalle.Rows[i].FindControl("txtFactura") as TextBox);
                        txtFechaFactura = (gvDetalle.Rows[i].FindControl("txtFechaFactura") as TextBox);
                        txtFechaTrasladoAlmacen = (gvDetalle.Rows[i].FindControl("txtFechaTrasladoAlmacen") as TextBox);
                        txtFechaIngresoSB = (gvDetalle.Rows[i].FindControl("txtFechaIngresoBS") as TextBox);
                        txtFTrasladoFRotativo = (gvDetalle.Rows[i].FindControl("txtFechaFondoRotativo") as TextBox);
                        txtFechaCotizacion = (gvDetalle.Rows[i].FindControl("txtFechaCotizacion") as TextBox);
                        txtFechaRazonamiento = (gvDetalle.Rows[i].FindControl("txtFechaRazonamiento") as TextBox);
                        //Costo real e IVA

                        stringBuilder.Append(" costo_real =" + funciones.StringToDecimal(lblCostoReal.Text).ToString() + ",");
                        stringBuilder.Append(" IVA =" + funciones.StringToDecimal(lblIVA.Text).ToString() + ",");

                        if (!ddlProveedor.SelectedValue.Equals("0"))
                            stringBuilder.Append("id_proveedor = '" + ddlProveedor.SelectedValue + "', ");
                        if (!ddlEstadoCompmras.SelectedValue.Equals("0"))
                            stringBuilder.Append("id_estatus_compras = '" + ddlEstadoCompmras.SelectedValue + "', ");
                        if (!string.IsNullOrEmpty(txtNoOrden.Text))
                            stringBuilder.Append("no_orden_compra = '" + txtNoOrden.Text + "', ");
                        if (!string.IsNullOrEmpty(txtFechaOrden.Text))
                            stringBuilder.Append("fecha_orden_compra = '" + txtFechaOrden.Text + "', ");
                        if (!string.IsNullOrEmpty(txtFechaTrasladoOC.Text))
                            stringBuilder.Append("fecha_traslado_orden = '" + txtFechaTrasladoOC.Text + "', ");
                        if (!string.IsNullOrEmpty(txtFactura.Text))
                            stringBuilder.Append("factura = '" + txtFactura.Text + "', ");
                        if (!string.IsNullOrEmpty(txtFechaFactura.Text))
                            stringBuilder.Append("fecha_factura = '" + txtFechaFactura.Text + "', ");
                        if (!string.IsNullOrEmpty(txtFechaTrasladoAlmacen.Text))
                            stringBuilder.Append("fecha_traslado_almacen = '" + txtFechaTrasladoAlmacen.Text + "', ");
                        if (!string.IsNullOrEmpty(txtFechaIngresoSB.Text))
                            stringBuilder.Append("fecha_ingreso_BS = '" + txtFechaIngresoSB.Text + "', ");
                        if (!string.IsNullOrEmpty(txtFTrasladoFRotativo.Text))
                            stringBuilder.Append("fecha_traslado_fondo_rotativo = '" + txtFTrasladoFRotativo.Text + "', ");
                        if (!string.IsNullOrEmpty(txtFechaCotizacion.Text))
                            stringBuilder.Append("fecha_cotizacion = '" + txtFechaCotizacion.Text + "', ");
                        if (!string.IsNullOrEmpty(txtFechaRazonamiento.Text))
                            stringBuilder.Append("fecha_razonamiento= '" + txtFechaRazonamiento.Text + "', ");

                        if (!string.IsNullOrEmpty(stringBuilder.ToString()))
                        {
                            pInsumoLN = new PedidosLN();
                            DataSet dsResultado = new DataSet();
                            dsResultado = pInsumoLN.AlmacenarDatosTecnicoDetalle(stringBuilder.ToString(), gvDetalle.DataKeys[i].Value.ToString());
                            if (dsResultado != null)
                                ScriptManager.RegisterStartupScript(this, typeof(string), "Almacenado", "alert('Datos Almacenados Exitosamente');", true);
                            else
                                lblError.Text = dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString();
                        }
                        else
                            lblError.Text = "No se tienen ningun dato a ingresar";

                    }
                }

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public void GenerarTraslado(int op)
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            try
            {
                foreach (GridViewRow gvItem in gvDetalle.Rows)
                {
                    CheckBox chkItem = (CheckBox)gvItem.FindControl("chkItem");
                    string ID = gvDetalle.DataKeys[gvItem.DataItemIndex].Value.ToString();
                    if (chkItem.Checked)
                    {
                        stringBuilder.Append(ID + ",");
                    }
                }
                if (stringBuilder.Length > 0)
                    ImprimirTrasladoCur(stringBuilder.ToString().Remove(stringBuilder.Length - 1), op);
            }
            catch (Exception ex)
            {
                lblError.Text = "btnImprimir(). " + ex.Message;
            }
        }

        private void AlmacenarEncabezado()
        {
            if (!validarEstadoAnexo())
            {
                System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
                if (!string.IsNullOrEmpty(ddlCentroCosto.SelectedValue))
                    stringBuilder.Append("id_centro_costo = " + ddlCentroCosto.SelectedValue + ", ");
                if (cbActaNegociacion.Checked)
                    stringBuilder.Append("acta_negociacion = 1, ");
                else
                    stringBuilder.Append("acta_negociacion = 0, ");
                if (!string.IsNullOrEmpty(txtFechaTrasladoVisa.Text))
                    stringBuilder.Append("fecha_traslado_visa = '" + txtFechaTrasladoVisa.Text + "', ");
                if (!string.IsNullOrEmpty(txtFechaRetorno.Text))
                    stringBuilder.Append("id_centro_costo = '" + txtFechaRetorno.Text + "', ");
                if (!string.IsNullOrEmpty(txtNotas.Text))
                    stringBuilder.Append("notas = '" + txtNotas.Text + "', ");
                if (!string.IsNullOrEmpty(txtIngresoInventarios.Text))
                    stringBuilder.Append("fecha_ingreso_inventarios = '" + txtIngresoInventarios.Text + "', ");
                if (!string.IsNullOrEmpty(txtTrasladoInventarios.Text))
                    stringBuilder.Append("fecha_traslado_inventarios = '" + txtTrasladoInventarios.Text + "', ");
                if (!string.IsNullOrEmpty(stringBuilder.ToString()))
                {
                    pInsumoLN = new PedidosLN();
                    DataSet dsResultado = new DataSet();
                    dsResultado = pInsumoLN.AlmacenarDatosTecnico(stringBuilder.ToString(), idpedido.Text);
                }
                else
                    lblError.Text = "No se tienen ningun dato a ingresar";
            }
        }

        protected bool validarEstadoAnexo()
        {
            bool estadoValido = false;
            try
            {
                if (lbAnexo.Text.Equals("1") == false)
                    return true;

                pInsumoLN = new PedidosLN();
                DataSet dsResultado = pInsumoLN.InformacionPedido(int.Parse(idpedido.Text), 1, 0, "ENCABEZADO", 8);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                string idEstado = dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_ESTADO"].ToString();

                if (idEstado.Equals("5"))
                    estadoValido = true;
                else
                    lblError.Text = "validarEstadoAnexo(). Las especificaciones deben ser aprobadas!";//throw new Exception("Las especificaciones deben ser aprobadas!");

                return estadoValido;
            }
            catch (Exception ex)
            {
                throw new Exception("validarEstadoAnexo(). " + ex.Message);
            }
        }

        protected bool validarControlesABC()
        {
            bool controlesValidos = false;
            funciones = new FuncionesVarias();
            try
            {
                if (validarEstadoAnexo() == true)
                {
                    int filas = gvDetalle.Rows.Count;

                    if (chkConstantes.Checked)
                    {
                        if (ddlProveedorT.SelectedValue.Equals("0") || ddlProveedorT.Items.Count == 0)
                        {
                            lblError.Text += "Seleccione un proveedor. ";
                        }
                        if (int.Parse(txtOrdenCompraT.Text) < 1)
                        {
                            lblError.Text += "Número no válido";
                        }
                        if (lblError.Text.Equals(string.Empty))
                            controlesValidos = true;

                        if (controlesValidos && Page.IsValid)
                            controlesValidos = true;
                        else
                            controlesValidos = false;
                    }
                    else
                        controlesValidos = true;

                    if (controlesValidos)
                    {
                        decimal cantidad, costoUnitario, subTotal, sumCantidad, sumCosto, sumSubtotal;
                        sumCantidad = 0;
                        sumCosto = 0;
                        sumSubtotal = 0;

                        controlesValidos = false;
                        for (int i = 0; i < gvDetalle.Rows.Count; i++)
                        {
                            DropDownList ddlProveedor, ddlTipoDoctoCompra;
                            CheckBox chkLiquidaciones;
                            TextBox txtCantidad, txtCosto, txtCostoReal, txtNoOrden, txtFechaOrden;

                            cantidad = 0;
                            costoUnitario = 0;
                            subTotal = 0;

                            txtCantidad = new TextBox();
                            txtCosto = new TextBox();
                            txtCostoReal = new TextBox();
                            ddlProveedor = new DropDownList();
                            ddlTipoDoctoCompra = new DropDownList();
                            chkLiquidaciones = new CheckBox();
                            txtNoOrden = txtFechaOrden = new TextBox();

                            if (chkConstantes.Checked)
                            {
                                txtCantidad = (gvDetalle.Rows[i].FindControl("txtCantidadReal") as TextBox);
                                //txtCosto = (gridDetalle.Rows[i].FindControl("txtCostoUReal") as TextBox);
                                txtCostoReal = (gvDetalle.Rows[i].FindControl("txtCostoUReal") as TextBox);
                                ddlProveedor = ddlProveedorT;

                                txtNoOrden = txtOrdenCompraT;
                                txtFechaOrden = txtFechaOrdenCompraT;
                            }
                            else
                            {
                                txtCantidad = (gvDetalle.Rows[i].FindControl("txtCantidadReal") as TextBox);
                                //txtCosto = (gridDetalle.Rows[i].FindControl("txtCostoUReal") as TextBox);
                                txtCostoReal = (gvDetalle.Rows[i].FindControl("txtCostoUReal") as TextBox);
                                ddlProveedor = (gvDetalle.Rows[i].FindControl("ddlProveedor") as DropDownList);
                                ddlTipoDoctoCompra = (gvDetalle.Rows[i].FindControl("dropTipoDoctoDetalle") as DropDownList);
                                txtNoOrden = (gvDetalle.Rows[i].FindControl("txtOrdenCompra") as TextBox);
                                txtFechaOrden = (gvDetalle.Rows[i].FindControl("txtFechaOrdenCompra") as TextBox);

                            }

                            //string sCantidad = funciones.StringToDecimal(txtCantidad.Text).ToString();
                            string sCantidad = funciones.StringToDecimal(txtCantidad.Text).ToString();

                            if (decimal.Parse(sCantidad) >= 0)
                            {
                                (gvDetalle.Rows[i].FindControl("txtCantidadReal") as TextBox).Text = funciones.StringToDecimal(sCantidad).ToString();

                                cantidad = funciones.StringToDecimal(sCantidad);
                                sumCantidad += cantidad;
                            }
                            else
                            {

                                lblError.Text = "Se detectaron errores. ";
                            }


                            //decimal costoReal = cantidad * costoUnitario;
                            string sSubTotal = funciones.StringToDecimal(txtCostoReal.Text).ToString();

                            if (decimal.Parse(sSubTotal) >= 0)
                            {
                                (gvDetalle.Rows[i].FindControl("lblSubtotalEstimado") as Label).Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", sSubTotal);
                                string subTEstimado = (gvDetalle.Rows[i].FindControl("lblSubtotalEstimado") as Label).Text;

                                subTEstimado = funciones.StringToDecimal(subTEstimado).ToString();
                                decimal subTEstimadoDec = funciones.StringToDecimal(subTEstimado);

                                //if (decimal.Parse(sSubTotal) <= subTEstimadoDec)
                                //    (gridDetalle.Rows[i].FindControl("lblErrorCostoReal") as Label).Text = string.Empty;
                                //else
                                //    (gridDetalle.Rows[i].FindControl("lblErrorCostoReal") as Label).Text = lblErrorCalculo.Text = lblError.Text = "Supera al estimado!";

                                subTotal = funciones.StringToDecimal(sSubTotal);
                                sumSubtotal += decimal.Parse(sSubTotal);
                            }
                            else
                            {

                                lblError.Text = "Se detectaron errores. ";
                            }


                            if (subTotal > 0 && cantidad > 0)
                            {
                                //string sCostoUnitario = funciones.StringToDecimal(txtCosto.Text).ToString();
                                string sCostoUnitario = (subTotal / cantidad).ToString();

                                (gvDetalle.Rows[i].FindControl("txtCostoUReal") as TextBox).Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.0000000000}", decimal.Parse(sCostoUnitario));//funciones.StringToDecimal(sCostoUnitario));

                                //costoUnitario = funciones.StringToDecimal(sCostoUnitario);
                                costoUnitario = decimal.Parse(sCostoUnitario);
                                sumCosto += costoUnitario;

                            }
                            else
                            {
                                (gvDetalle.Rows[i].FindControl("txtCostoUReal") as TextBox).Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.0000000000}", decimal.Parse("0"));//funciones.StringToDecimal(sCostoUnitario));

                            }

                            if (subTotal > 0 && cantidad > 0)
                            {
                                if (ddlProveedor.SelectedValue.Equals("0") || ddlProveedor.Items.Count == 0)
                                {

                                    lblError.Text = "Se detectaron errores. ";
                                }
                                else
                                {
                                    if (chkConstantes.Checked)
                                        (gvDetalle.Rows[i].FindControl("ddlProveedor") as DropDownList).SelectedValue = ddlProveedor.SelectedValue;
                                }
                            }

                            (gvDetalle.Rows[i].FindControl("lblIVA") as Label).Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", (subTotal * decimal.Parse("1.12") - subTotal));



                            DataSet dsResultado = funciones.StringToFechaMySql(txtFechaOrden.Text);

                            if (subTotal > 0 && cantidad > 0)
                            {
                                if (dsResultado.Tables[0].Rows[0]["FECHA_VALIDA"].ToString().Equals("false"))
                                {

                                    lblError.Text = "Se detectaron errores. ";
                                }
                                else
                                {
                                    if (chkConstantes.Checked)
                                        (gvDetalle.Rows[i].FindControl("txtFechaOrdenDetalle") as TextBox).Text = txtFechaOrden.Text;


                                }
                            }

                            if (chkConstantes.Checked)
                            {

                                (gvDetalle.Rows[i].FindControl("chkLiquidacionParcial") as CheckBox).Checked = false;
                            }

                            //SI LA CANTIDAD Y EL SUBTOTAL SON DECIMALES E IGUALES CERO, SE PROCEDERÁ A LIMPIAR LOS CAMPOS RESTANTES
                            //ESTO SERÁ PARA PODER LIQUIDAR ARTÍCULO CON VALOR 0, SIGNIFICA QUE NO FUERON ADQUIRIDOS
                            /*if (esDecimal(sCantidad) == true && esDecimal(sSubTotal) == true)
                            {
                                if (decimal.Parse(sCantidad) == 0 && decimal.Parse(sSubTotal) == 0)
                                {
                                    ddlProveedor.ClearSelection();
                                    ddlTipoDoctoCompra.ClearSelection();

                                    //NÚMERO DE ORDEN DE COMPRA
                                    (gridDetalle.Rows[i].FindControl("txtNoOrdenDetalle") as TextBox).Text = string.Empty;
                                    (gridDetalle.Rows[i].FindControl("lblErrorNoOrden") as Label).Text = string.Empty;

                                    //FECHA ORDEN DE COMPRA
                                    (gridDetalle.Rows[i].FindControl("txtFechaOrdenDetalle") as TextBox).Text = string.Empty;
                                    (gridDetalle.Rows[i].FindControl("lblErrorFechaNoOrden") as Label).Text = string.Empty;

                                    //LIQUIDACIONES PARCIALES
                                    (gridDetalle.Rows[i].FindControl("chkLiquidacionParcial") as CheckBox).Checked = false;
                                }   
                            }*/
                            //DERIVADO DE LA CAPACITACIÓN DEL DÍA 07/08/2017 SE DETERMINÓ QUE SI ES POSIBLE LIQUIDAR REQUISICIONES CON VALOR 0.00
                        }

                        if (sumSubtotal < 0)
                        {

                            lblError.Text = "No se puede liquidar una requisición con valor menor que cero (0). ";
                        }
                        else
                        {
                            int idSalida, idTipoSalida;
                            idSalida = idTipoSalida = 0;
                            if (idpedido.Text != null)
                                int.TryParse(idpedido.Text, out idSalida);



                            pInsumoLN = new PedidosLN();
                            DataSet dsResultado = pInsumoLN.DetallesPedidoAprobacion(idSalida, 1, "", 1, ddlanio.SelectedValue);

                            if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                                throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                            if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0 && dsResultado.Tables["BUSQUEDA"].Rows[0]["ID"].ToString() != "")
                            {
                                decimal costoPedido = 0;
                                string sSubtotalPedido = dsResultado.Tables["BUSQUEDA"].Compute("(SUM(SUBTOTAL) + SUM(AJUSTE_MONTO))", "").ToString();
                                decimal.TryParse(sSubtotalPedido, out costoPedido);

                                if (sumSubtotal > costoPedido)
                                {

                                    lblError.Text = "El MONTO TOTAL ADJUDICADO (" + String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", sumSubtotal) + ")no puede superar al MONTO TOTAL ESTIMADO (" + String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", costoPedido) + "). ";
                                }
                            }
                            else
                            {

                                lblError.Text = "No se puede calcular el MONTO TOTAL ESTIMADO del pedido. ";
                            }
                        }
                        if (lblError.Text.Equals(string.Empty))
                            controlesValidos = true;
                        else
                            controlesValidos = false;
                        if (controlesValidos && Page.IsValid)
                            controlesValidos = true;
                        else
                            controlesValidos = false;

                        //if (controlesValidos == true)

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("validarControlesABC(). " + ex.Message);
            }
            return controlesValidos;
        }

        protected void lbAnexo_Click(object sender, EventArgs e)
        {
            string _open = "<script type='text/javascript'> window.open();</script>";

        }

        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                validarControlesABC();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void btnTrasladoCur_Click(object sender, ImageClickEventArgs e)
        {
            GenerarTraslado(1);
        }

        private void ImprimirTrasladoCur(string ID, int op)
        {
            try
            {
                int idEncabezado = 0;


                pInsumoLN = new PedidosLN();

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
                    DataSet dResultado = reportes.TrasladoCUR(txtNo.Text, ddlanio.SelectedValue, ID);


                    ReportDataSource RD = new ReportDataSource();
                    RD.Value = dResultado.Tables[0];
                    RD.Name = "DataSet1";

                    rViewer.LocalReport.DataSources.Clear();
                    rViewer.LocalReport.DataSources.Add(RD);

                    if (op == 1)
                    {
                        rViewer.LocalReport.ReportEmbeddedResource = "\\Reportes\\Compras/rptTrasladoCUR.rdlc";
                        rViewer.LocalReport.ReportPath = @"Reportes\\Compras\\rptTrasladoCUR.rdlc";
                    }
                    else if (op == 2)
                    {
                        rViewer.LocalReport.ReportEmbeddedResource = "\\Reportes\\Compras/rptTrasladoPartidaPresupuestaria.rdlc";
                        rViewer.LocalReport.ReportPath = @"Reportes\\Compras\\rptTrasladoPartidaPresupuestaria.rdlc";
                    }
                    else if (op == 3)
                    {
                        rViewer.LocalReport.ReportEmbeddedResource = "\\Reportes\\Compras/rptPago.rdlc";
                        rViewer.LocalReport.ReportPath = @"Reportes\\Compras\\rptPago.rdlc";
                    }
                    else if (op == 4)
                    {
                        rViewer.LocalReport.ReportEmbeddedResource = "\\Reportes\\Compras/rptRazonamientoFactura.rdlc";
                        rViewer.LocalReport.ReportPath = @"Reportes\\Compras\\rptRazonamientoFactura.rdlc";
                    }
                    else if (op == 5)
                    {
                        rViewer.LocalReport.ReportEmbeddedResource = "\\Reportes\\Compras/rptImprimirContraseña.rdlc";
                        rViewer.LocalReport.ReportPath = @"Reportes\\Compras\\rptImprimirContraseña.rdlc";
                    }
                    else if (op == 6)
                    {
                        rViewer.LocalReport.ReportEmbeddedResource = "\\Reportes\\Compras/rptSolicitudChequeFR.rdlc";
                        rViewer.LocalReport.ReportPath = @"Reportes\\Compras\\rptSolicitudChequeFR.rdlc";
                    }

                    rViewer.LocalReport.Refresh();


                    byte[] bytes = rViewer.LocalReport.Render(
                       "PDF", null, out mimeType, out encoding,
                        out extension,
                       out streamids, out warnings);

                    string nombreReporte = "Traslado";

                    Response.Buffer = true;
                    Response.Clear();
                    Response.ContentType = mimeType;
                    Response.AddHeader("content-disposition", "attachment; filename=" + nombreReporte + ".pdf");
                    Response.BinaryWrite(bytes); // create the file
                    Response.Flush(); // send it to the client to download



                }


            }
            catch (Exception ex)
            {
                lblError.Text = "btnImprimir(). " + ex.Message;
            }
        }

        protected void btnTrasladoAlmacen_Click(object sender, ImageClickEventArgs e)
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            try
            {
                foreach (GridViewRow gvItem in gvDetalle.Rows)
                {
                    CheckBox chkItem = (CheckBox)gvItem.FindControl("chkItem");
                    string ID = gvDetalle.DataKeys[gvItem.DataItemIndex].Value.ToString();
                    if (chkItem.Checked)
                    {
                        stringBuilder.Append(ID + ",");
                    }
                }
                if (stringBuilder.Length > 0)
                    ImprimirTrasladoAlmacen(stringBuilder.ToString().Remove(stringBuilder.Length - 1));
            }
            catch (Exception ex)
            {
                lblError.Text = "btnImprimir(). " + ex.Message;
            }
        }

        private void ImprimirTrasladoAlmacen(string ID)
        {
            try
            {
                int idEncabezado = 0;


                pInsumoLN = new PedidosLN();

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
                    DataSet dResultado = reportes.TrasladoAlmacen(txtNo.Text, ddlanio.SelectedValue, ID, int.Parse(ddlModalidadCompra.SelectedValue));
                    ReportDataSource RD = new ReportDataSource();
                    RD.Value = dResultado.Tables[0];
                    RD.Name = "DataSet1";
                    DataSet dExtras = new DataSet();
                    DataTable dTabla = new DataTable("RESULTADO");

                    dTabla.Columns.Add("compra_directa", typeof(String));
                    dExtras.Tables.Add(dTabla);

                    DataRow dr = dExtras.Tables[0].NewRow();
                    dExtras.Tables[0].Rows.Add(dr);
                    if (ddlModalidadCompra.SelectedValue.Equals("8"))
                        dExtras.Tables[0].Rows[0]["compra_directa"] = "No aplica fecha de vencimiento";
                    else
                        dExtras.Tables[0].Rows[0]["compra_directa"] = "    ";


                    ReportDataSource RD2 = new ReportDataSource();
                    RD2.Value = dExtras.Tables[0];
                    RD2.Name = "DataSet2";

                    rViewer.LocalReport.DataSources.Clear();
                    rViewer.LocalReport.DataSources.Add(RD);
                    rViewer.LocalReport.DataSources.Add(RD2);
                    rViewer.LocalReport.ReportEmbeddedResource = "\\Reportes\\Compras/rptTrasladoAlmacen.rdlc";
                    rViewer.LocalReport.ReportPath = @"Reportes\\Compras\\rptTrasladoAlmacen.rdlc";

                    rViewer.LocalReport.Refresh();


                    byte[] bytes = rViewer.LocalReport.Render(
                       "PDF", null, out mimeType, out encoding,
                        out extension,
                       out streamids, out warnings);

                    string nombreReporte = "rptTrasladoAlmacen";

                    Response.Buffer = true;
                    Response.Clear();
                    Response.ContentType = mimeType;
                    Response.AddHeader("content-disposition", "attachment; filename=" + nombreReporte + ".pdf");
                    Response.BinaryWrite(bytes); // create the file
                    Response.Flush(); // send it to the client to download



                }


            }
            catch (Exception ex)
            {
                lblError.Text = "btnImprimir(). " + ex.Message;
            }
        }

        protected void btnTrasladoPartidaPpto_Click(object sender, ImageClickEventArgs e)
        {
            GenerarTraslado(2);
        }


        protected void btnTrasladoPago_Click(object sender, ImageClickEventArgs e)
        {
            GenerarTraslado(3);
        }

        protected void btnRazonamientoFac_Click(object sender, ImageClickEventArgs e)
        {
            //GenerarTraslado(4);
            txtObservacionesRazonamiento.Visible = true;
            btnRazonamiento.Visible = true;
            txtObservacionesRazonamiento.Focus();
        }

        protected void btnImprimirContra_Click(object sender, ImageClickEventArgs e)
        {
            GenerarTraslado(5);
        }

        protected void btnChequeFondo_Click(object sender, ImageClickEventArgs e)
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            string result = "";
            try
            {
                int idEncabezado = 0;
                foreach (GridViewRow gvItem in gvDetalle.Rows)
                {
                    CheckBox chkItem = (CheckBox)gvItem.FindControl("chkItem");
                    string ID = gvDetalle.DataKeys[gvItem.DataItemIndex].Value.ToString();
                    if (chkItem.Checked)
                    {
                        stringBuilder.Append(ID + ",");
                    }
                }
                if (stringBuilder.Length > 0)
                    result = stringBuilder.ToString().Remove(stringBuilder.Length - 1);

                pInsumoLN = new PedidosLN();

                if (!string.IsNullOrEmpty(result))
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
                    DataSet dResultado = reportes.TrasladoCUR(txtNo.Text, ddlanio.SelectedValue, result);
                    ReportDataSource RD = new ReportDataSource();
                    RD.Value = dResultado.Tables[0];
                    RD.Name = "DataSet1";
                    DataSet dExtras = new DataSet();
                    DataTable dTabla = new DataTable("RESULTADO");

                    dTabla.Columns.Add("compra_directa", typeof(String));
                    dExtras.Tables.Add(dTabla);

                    DataRow dr = dExtras.Tables[0].NewRow();
                    dExtras.Tables[0].Rows.Add(dr);

                    dExtras.Tables[0].Rows[0]["compra_directa"] = Session["usuario"].ToString();



                    ReportDataSource RD2 = new ReportDataSource();
                    RD2.Value = dExtras.Tables[0];
                    RD2.Name = "DataSet2";

                    rViewer.LocalReport.DataSources.Clear();
                    rViewer.LocalReport.DataSources.Add(RD);
                    rViewer.LocalReport.DataSources.Add(RD2);
                    rViewer.LocalReport.ReportEmbeddedResource = "\\Reportes\\Compras/rptSolicitudChequeFR.rdlc";
                    rViewer.LocalReport.ReportPath = @"Reportes\\Compras\\rptSolicitudChequeFR.rdlc";

                    rViewer.LocalReport.Refresh();


                    byte[] bytes = rViewer.LocalReport.Render(
                       "WORDOPENXML", null, out mimeType, out encoding,
                        out extension,
                       out streamids, out warnings);

                    string nombreReporte = "ChequeFondoRotativo";

                    Response.Buffer = true;
                    Response.Clear();
                    Response.ContentType = mimeType;
                    Response.AddHeader("content-disposition", "attachment; filename=" + nombreReporte + ".doc");
                    Response.BinaryWrite(bytes); // create the file
                    Response.Flush(); // send it to the client to download



                }

            }
            catch (Exception ex)
            {
                lblError.Text = "btnImprimir(). " + ex.Message;
            }
        }

        protected void btnRazonamiento_Click(object sender, EventArgs e)
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            string result = "";
            try
            {
                int idEncabezado = 0;
                foreach (GridViewRow gvItem in gvDetalle.Rows)
                {
                    CheckBox chkItem = (CheckBox)gvItem.FindControl("chkItem");
                    string ID = gvDetalle.DataKeys[gvItem.DataItemIndex].Value.ToString();
                    if (chkItem.Checked)
                    {
                        stringBuilder.Append(ID + ",");
                    }
                }
                if (stringBuilder.Length > 0)
                    result = stringBuilder.ToString().Remove(stringBuilder.Length - 1);

                pInsumoLN = new PedidosLN();

                if (!string.IsNullOrEmpty(result))
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
                    DataSet dResultado = reportes.TrasladoCUR(txtNo.Text, ddlanio.SelectedValue, result);
                    ReportDataSource RD = new ReportDataSource();
                    RD.Value = dResultado.Tables[0];
                    RD.Name = "DataSet1";
                    DataSet dExtras = new DataSet();
                    DataTable dTabla = new DataTable("RESULTADO");

                    dTabla.Columns.Add("compra_directa", typeof(String));
                    dExtras.Tables.Add(dTabla);

                    DataRow dr = dExtras.Tables[0].NewRow();
                    dExtras.Tables[0].Rows.Add(dr);

                    dExtras.Tables[0].Rows[0]["compra_directa"] = txtObservacionesRazonamiento.Text;



                    ReportDataSource RD2 = new ReportDataSource();
                    RD2.Value = dExtras.Tables[0];
                    RD2.Name = "DataSet2";

                    rViewer.LocalReport.DataSources.Clear();
                    rViewer.LocalReport.DataSources.Add(RD);
                    rViewer.LocalReport.DataSources.Add(RD2);
                    rViewer.LocalReport.ReportEmbeddedResource = "\\Reportes\\Compras/rptRazonamientoFactura.rdlc";
                    rViewer.LocalReport.ReportPath = @"Reportes\\Compras\\rptRazonamientoFactura.rdlc";

                    rViewer.LocalReport.Refresh();


                    byte[] bytes = rViewer.LocalReport.Render(
                       "PDF", null, out mimeType, out encoding,
                        out extension,
                       out streamids, out warnings);

                    string nombreReporte = "rptTrasladoAlmacen";

                    Response.Buffer = true;
                    Response.Clear();
                    Response.ContentType = mimeType;
                    Response.AddHeader("content-disposition", "attachment; filename=" + nombreReporte + ".pdf");
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
    