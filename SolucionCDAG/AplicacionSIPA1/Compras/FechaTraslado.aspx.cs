using CapaLN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
                AlmacenarEncabezado();
            }
            catch (Exception ex)
            {

                throw;
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
                                txtCostoReal = (gvDetalle.Rows[i].FindControl("txtCostoReal") as TextBox);
                                ddlProveedor = ddlProveedorT;

                                txtNoOrden = txtOrdenCompraT;
                                txtFechaOrden = txtFechaOrdenCompraT;
                            }
                            else
                            {
                                txtCantidad = (gvDetalle.Rows[i].FindControl("txtCantidadReal") as TextBox);
                                //txtCosto = (gridDetalle.Rows[i].FindControl("txtCostoUReal") as TextBox);
                                txtCostoReal = (gvDetalle.Rows[i].FindControl("txtCostoReal") as TextBox);
                                ddlProveedor = (gvDetalle.Rows[i].FindControl("dropProveedor") as DropDownList);
                                ddlTipoDoctoCompra = (gvDetalle.Rows[i].FindControl("dropTipoDoctoDetalle") as DropDownList);
                                txtNoOrden = (gvDetalle.Rows[i].FindControl("txtNoOrdenDetalle") as TextBox);
                                txtFechaOrden = (gvDetalle.Rows[i].FindControl("txtFechaOrdenDetalle") as TextBox);
                                chkLiquidaciones = (gvDetalle.Rows[i].FindControl("chkLiquidacionParcial") as CheckBox);
                            }

                            //string sCantidad = funciones.StringToDecimal(txtCantidad.Text).ToString();
                            string sCantidad = funciones.StringToDecimal(txtCantidad.Text).ToString();
                            if (int.Parse(sCantidad) >= 0)
                            {
                                (gvDetalle.Rows[i].FindControl("lblErrorCantidadReal") as Label).Text = "Número no válido";
                                lblError.Text = "Se detectaron errores. ";
                            }
                            else
                            {
                                if (decimal.Parse(sCantidad) >= 0)
                                {
                                    (gvDetalle.Rows[i].FindControl("txtCantidadReal") as TextBox).Text = funciones.StringToDecimal(sCantidad).ToString();
                                    (gvDetalle.Rows[i].FindControl("lblErrorCantidadReal") as Label).Text = string.Empty;
                                    cantidad = funciones.StringToDecimal(sCantidad);
                                    sumCantidad += cantidad;
                                }
                                else
                                {
                                    (gvDetalle.Rows[i].FindControl("lblErrorCantidadReal") as Label).Text = "Número menor que cero (0)";
                                    lblError.Text = "Se detectaron errores. ";
                                }
                            }

                            //decimal costoReal = cantidad * costoUnitario;
                            string sSubTotal = funciones.StringToDecimal(txtCostoReal.Text).ToString();
                            
                                if (decimal.Parse(sSubTotal) >= 0)
                                {
                                    (gvDetalle.Rows[i].FindControl("txtCostoReal") as TextBox).Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", sSubTotal);
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
                                    (gvDetalle.Rows[i].FindControl("lblErrorCostoReal") as Label).Text = "Número menor que cero (0)";
                                    lblError.Text = "Se detectaron errores. ";
                                }
                            

                            if (subTotal > 0 && cantidad > 0)
                            {
                                //string sCostoUnitario = funciones.StringToDecimal(txtCosto.Text).ToString();
                                string sCostoUnitario = (subTotal / cantidad).ToString();
                                
                                    (gvDetalle.Rows[i].FindControl("txtCostoUReal") as TextBox).Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.0000000000}", decimal.Parse(sCostoUnitario));//funciones.StringToDecimal(sCostoUnitario));
                                    (gvDetalle.Rows[i].FindControl("lblErrorCostoUReal") as Label).Text = string.Empty;
                                    //costoUnitario = funciones.StringToDecimal(sCostoUnitario);
                                    costoUnitario = decimal.Parse(sCostoUnitario);
                                    sumCosto += costoUnitario;
                                
                            }
                            else
                            {
                                (gvDetalle.Rows[i].FindControl("txtCostoUReal") as TextBox).Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.0000000000}", decimal.Parse("0"));//funciones.StringToDecimal(sCostoUnitario));
                                (gvDetalle.Rows[i].FindControl("lblErrorCostoUReal") as Label).Text = string.Empty;
                            }

                            if (subTotal > 0 && cantidad > 0)
                            {
                                if (ddlProveedor.SelectedValue.Equals("0") || ddlProveedor.Items.Count == 0)
                                {
                                    (gvDetalle.Rows[i].FindControl("lblErrorProveedor") as Label).Text = "Seleccione un proveedor";
                                     lblError.Text = "Se detectaron errores. ";
                                }
                                else
                                {
                                    if (chkConstantes.Checked)
                                        (gvDetalle.Rows[i].FindControl("dropProveedor") as DropDownList).SelectedValue = ddlProveedor.SelectedValue;

                                    (gvDetalle.Rows[i].FindControl("lblErrorProveedor") as Label).Text = string.Empty;
                                }

                                if (ddlTipoDoctoCompra.SelectedValue.Equals("0") || ddlTipoDoctoCompra.Items.Count == 0)
                                {
                                    (gvDetalle.Rows[i].FindControl("lblErrorTipoDoctoDetalle") as Label).Text = "Seleccione un tipo de documento";
                                     lblError.Text = "Se detectaron errores. ";
                                }
                                else
                                {
                                    if (chkConstantes.Checked)
                                        (gvDetalle.Rows[i].FindControl("dropTipoDoctoDetalle") as DropDownList).SelectedValue = ddlTipoDoctoCompra.SelectedValue;

                                    (gvDetalle.Rows[i].FindControl("lblErrorTipoDoctoDetalle") as Label).Text = string.Empty;
                                }
                            }

                            //EL PROVEEDOR FUE SELECCIONADO ADECUADAMENTE
                            string eProveedor = (gvDetalle.Rows[i].FindControl("lblErrorProveedor") as Label).Text;
                            if (eProveedor.Equals("") || eProveedor.Equals(string.Empty))
                            {
                                (gvDetalle.Rows[i].FindControl("txtIva") as TextBox).Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", (subTotal * decimal.Parse("1.12") - subTotal));
                            }

                            if (subTotal > 0 && cantidad > 0)
                            {
                                if (int.Parse(txtNoOrden.Text) < 1)
                                {
                                    (gvDetalle.Rows[i].FindControl("lblErrorNoOrden") as Label).Text = "Número no válido";
                                     lblError.Text = "Se detectaron errores. ";
                                }
                                else
                                {
                                    if (chkConstantes.Checked)
                                        (gvDetalle.Rows[i].FindControl("txtNoOrdenDetalle") as TextBox).Text = txtNoOrden.Text;

                                    (gvDetalle.Rows[i].FindControl("lblErrorNoOrden") as Label).Text = string.Empty;
                                }
                            }

                            DataSet dsResultado = funciones.StringToFechaMySql(txtFechaOrden.Text);

                            if (subTotal > 0 && cantidad > 0)
                            {
                                if (dsResultado.Tables[0].Rows[0]["FECHA_VALIDA"].ToString().Equals("false"))
                                {
                                    (gvDetalle.Rows[i].FindControl("lblErrorFechaNoOrden") as Label).Text = "Fecha no válida";
                                    lblError.Text = "Se detectaron errores. ";
                                }
                                else
                                {
                                    if (chkConstantes.Checked)
                                        (gvDetalle.Rows[i].FindControl("txtFechaOrdenDetalle") as TextBox).Text = txtFechaOrden.Text;

                                    (gvDetalle.Rows[i].FindControl("lblErrorFechaNoOrden") as Label).Text = string.Empty;
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
    }
}