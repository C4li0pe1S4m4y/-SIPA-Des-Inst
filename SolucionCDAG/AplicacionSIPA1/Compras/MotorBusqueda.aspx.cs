using CapaLN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionSIPA1.Compras
{
    public partial class MotorBusqueda : System.Web.UI.Page
    {
        private PlanEstrategicoLN pEstrategicoLN;
        private PlanOperativoLN pOperativoLN;
        private PlanAccionLN pAccionLN;
        private PlanAnualLN pAnualLN;
        private UsuariosLN uUsuariosLN;
        private PedidosLN pInsumoLN;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    pEstrategicoLN = new PlanEstrategicoLN();
                    pOperativoLN = new PlanOperativoLN();
                    pAccionLN = new PlanAccionLN();
                    pAnualLN = new PlanAnualLN();
                    uUsuariosLN = new UsuariosLN();
                    pInsumoLN = new PedidosLN();
                    pEstrategicoLN.DdlAniosPlan(ddlAnio, 2016, 2020);
                    ddlAnio.Items.RemoveAt(0);

                    int anioActual = DateTime.Now.Year;

                    ListItem item = ddlAnio.Items.FindByValue(anioActual.ToString());
                    if (item != null)
                        ddlAnio.SelectedValue = anioActual.ToString();

                    uUsuariosLN.dropUnidad(ddlUnidad);
                    pAnualLN.DdlCentroCosto(ddlCentroCosto);
                    pInsumoLN.DdlTecnicosCompras(ddlTecnico);
                    dvPedido.DataSource = pInsumoLN.EncabezadoMotorBusqueda(" ");
                    dvPedido.DataBind();
                    ddlMes.AppendDataBoundItems = true;
                    ddlMes.Items.Add("<< Elija un valor >>");
                    ddlMes.Items[0].Value = "0";
                    ddlMes.Items.Add("Enero");
                    ddlMes.Items[1].Value = "01";
                    ddlMes.Items.Add("Febrero");
                    ddlMes.Items[2].Value = "02";
                    ddlMes.Items.Add("Marzo");
                    ddlMes.Items[3].Value = "03";
                    ddlMes.Items.Add("Abril");
                    ddlMes.Items[4].Value = "04";
                    ddlMes.Items.Add("Mayo");
                    ddlMes.Items[5].Value = "05";
                    ddlMes.Items.Add("Junio");
                    ddlMes.Items[6].Value = "06";
                    ddlMes.Items.Add("Julio");
                    ddlMes.Items[7].Value = "07";
                    ddlMes.Items.Add("Agosto");
                    ddlMes.Items[8].Value = "08";
                    ddlMes.Items.Add("Septiembre");
                    ddlMes.Items[9].Value = "09";
                    ddlMes.Items.Add("Octubre");
                    ddlMes.Items[10].Value = "10";
                    ddlMes.Items.Add("Noviembre");
                    ddlMes.Items[11].Value = "11";
                    ddlMes.Items.Add("Diciembre");
                    ddlMes.Items[12].Value = "12";
                    //DataSet dsResultado = new DataSet();
                    //dsResultado = pInsumoLN.InformacionPedidoComprasDetalle(43, int.Parse(ddlAnio.SelectedValue));
                    //gvDetalle.DataSource = dsResultado.Tables["BUSQUEDA"];
                    //gvDetalle.DataBind();
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }

        protected void dvPedido_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {
            dvPedido.PageIndex = e.NewPageIndex;
            pInsumoLN = new PedidosLN();
            dvPedido.DataSource = pInsumoLN.EncabezadoMotorBusqueda(" ");
            dvPedido.DataBind();
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

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            pInsumoLN = new PedidosLN();
            dvPedido.DataSource = pInsumoLN.EncabezadoMotorBusqueda(filtro());
            dvPedido.DataBind();

            int idSalida;
            idSalida = 0;

            if (dvPedido.Rows.Count > 0)
                int.TryParse(dvPedido.DataKey[0].ToString(), out idSalida);
            DataSet dsResultado = new DataSet();
            dsResultado = pInsumoLN.InformacionPedidoComprasDetalle(idSalida, int.Parse(ddlAnio.SelectedValue));
            gvDetalle.DataSource = dsResultado.Tables["BUSQUEDA"];
            gvDetalle.DataBind();

        }

        string filtro()
        {
            System.Text.StringBuilder filtros = new System.Text.StringBuilder();
            filtros.Append(" Where p.anio_solicitud = '" + ddlAnio.SelectedValue + "' ");
            if (!string.IsNullOrEmpty(txtRequi.Text))
                filtros.Append(" and p.no_solicitud = '" + txtRequi.Text + "' ");
            if (ddlUnidad.SelectedIndex > 0)
                filtros.Append(" and p.id_unidad = '" + ddlUnidad.SelectedValue + "' ");
            if (ddlDependencia.Items.Count > 0 && ddlDependencia.SelectedIndex > 0)
                filtros.Append(" and p.id_unidad = '" + ddlDependencia.SelectedValue + "' ");
            if (ddlCentroCosto.SelectedIndex > 0)
                filtros.Append(" and p.id_centro_costo = '" + ddlCentroCosto.SelectedValue + "' ");
            if (ddlMes.SelectedIndex > 0)
                filtros.Append(" and p.date_format(fecha_pedido,'%m') =  '" + ddlMes.SelectedValue + "' ");
            if (ddlTecnico.SelectedIndex > 0)
                filtros.Append(" and p.id_tecnico =  '" + ddlTecnico.SelectedValue + "' ");
            if (ddlTecnico.SelectedIndex > 0)
                filtros.Append(" and p.id_tecnico =  '" + ddlTecnico.SelectedValue + "' ");
            if (!string.IsNullOrEmpty(txtDescripcion.Text))
                filtros.Append(" and p.justificacion like '%" + txtDescripcion.Text + "%' ");
            if (!string.IsNullOrEmpty(txtNit.Text))
                filtros.Append(" and pro.nit = '" + txtNit.Text + "' ");
            if (!string.IsNullOrEmpty(txtInsumo.Text))
                filtros.Append(" and pd.codigo_insumo = '" + txtInsumo.Text + "' ");
            return filtros.ToString();
        }
    }
}