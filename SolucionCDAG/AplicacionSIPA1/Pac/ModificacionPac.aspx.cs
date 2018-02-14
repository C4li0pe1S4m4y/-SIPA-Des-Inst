using CapaLN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionSIPA1.Pac
{
    public partial class ModificacionPac : System.Web.UI.Page
    {
        PedidosLN pedidoLN = new PedidosLN();
        PacLN pacLn = new PacLN();
        PlanOperativoLN planOperativoLN = new PlanOperativoLN();
        protected void Page_Load(object sender, EventArgs e)
        {
            PlanEstrategicoLN planEstrategicoLN = new PlanEstrategicoLN();
            
            PedidosLN pedidoLN = new PedidosLN();
            PacLN pacLn = new PacLN();
            string usuario = Session["Usuario"].ToString().ToLower();
            if (!IsPostBack)
            {
                try
                {
                    int anioActual = (DateTime.Now.Year);

                    planEstrategicoLN.DdlAniosPlan(ddlAnio, 2016, 2020);
                    ListItem item = ddlAnio.Items.FindByValue(anioActual.ToString());
                    if (item != null)
                        ddlAnio.SelectedValue = anioActual.ToString();

                    planOperativoLN = new PlanOperativoLN();
                    planOperativoLN.DdlUnidades(ddlUnidad, usuario);
                    pedidoLN = new PedidosLN();
                    pacLn = new PacLN();
                    int unidad = int.Parse(ddlUnidad.SelectedValue);
                    if (unidad > 0)
                    {
                        dvPedido.DataSource = pacLn.PedidoPACItem(unidad,"");
                        dvPedido.DataBind();

                        gvPedido.DataSource = pedidoLN.PedidoDetallePac( int.Parse(dvPedido.Rows[0].Cells[1].Text));
                        gvPedido.DataBind();
                        
                    }

                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }

        private DropDownList DdlRenglones(object sender, EventArgs e)
        {
            DropDownList drop = new DropDownList();
            PacLN pac = new PacLN();
            //pac.ddlPacAccion(drop, int.Parse(ddlUnidad.SelectedValue), int.Parse(dvPedido.Rows[4].Cells[1].Text));
            drop.CssClass = "form-control";
            ///drop.SelectedIndexChanged = GuardarPAC(sender,e);
            return drop;
        }

        public void GuardarPAC(object sender, EventArgs e)
        {

        }

        private ImageButton BotonEditar(string id)
        {
            ImageButton button = new ImageButton();
            button.ImageUrl = "~/img/24_bits/edit.png";
            button.PostBackUrl = "IngresarPac.aspx?id=" + Session["Usuario"].ToString() + "&accion=" + dvPedido.Rows[5].Cells[1].Text;
            return button;
        }

        private ImageButton BotonGuardar(string id)
        {
            ImageButton button = new ImageButton();
            button.ImageUrl = "~/img/24_bits/save.png";
            button.PostBackUrl = "GuardarMoPac.aspx?id=" + Session["Usuario"].ToString() + "&accion=" + dvPedido.Rows[5].Cells[1].Text;
            return button;
        }

        private TableHeaderCell NewCellHeader()
        {
            TableHeaderCell cell = new TableHeaderCell();

            return cell;
        }

        private TableCell NewCell()
        {
            TableCell cell = new TableCell();

            return cell;
        }
        private TableRow NewRow()
        {
            TableRow tr = new TableRow();

            return tr;
        }

        protected void btnEditar_Click(object sender, ImageClickEventArgs e)
        {
            
        }

        protected void gvPedido_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
           
        }

        protected void gvPedido_SelectedIndexChanged(object sender, EventArgs e)
        {
            pacLn = new PacLN();
            int idDetalle = 0;
            int.TryParse(gvPedido.SelectedValue.ToString(), out idDetalle);
            lblIdDetalle.Text = gvPedido.SelectedDataKey[0].ToString();
            lblPACm.Text = gvPedido.SelectedDataKey[1].ToString();
            txtRenglonPacM.Text = gvPedido.SelectedDataKey[2].ToString();
            txtRenglonPptoM.Text = gvPedido.SelectedDataKey[3].ToString();
            pacLn.DdlRenglon(ddlNPac, ddlUnidad.SelectedValue, txtRenglonPptoM.Text, ddlAnio.Text, dvPedido.Rows[1].Cells[1].Text);
            //ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "verPanelModalReglon();", true);
            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.Page), "verPanelModalReglon", "verPanelModalReglon();", true);

        }

        protected void ddlUnidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                pedidoLN = new PedidosLN();
                pacLn = new PacLN();
                int unidad = int.Parse(ddlUnidad.SelectedValue);
                if (unidad > 0)
                {
                    dvPedido.DataSource = pacLn.PedidoPACItem(unidad, "");
                    dvPedido.DataBind();
                    gvPedido.DataSource = pedidoLN.PedidoDetallePac(int.Parse(dvPedido.Rows[0].Cells[1].Text));
                    gvPedido.DataBind();
                    planOperativoLN = new PlanOperativoLN();
                    planOperativoLN.DdlDependencias(ddlDependencia, unidad.ToString());
                   

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                pedidoLN = new PedidosLN();
                pacLn = new PacLN();
                int unidad = int.Parse(ddlUnidad.SelectedValue);
                if (unidad > 0)
                {
                    string pedido = txtNo.Text;
                    if (!string.IsNullOrEmpty(pedido))
                    {
                        dvPedido.DataSource = pacLn.PedidoPACItem(unidad, " and no_solicitud = " + pedido);
                        dvPedido.DataBind();
                        gvPedido.DataSource = pedidoLN.PedidoDetallePac(int.Parse(dvPedido.Rows[0].Cells[1].Text));
                        gvPedido.DataBind();
                        planOperativoLN = new PlanOperativoLN();
                        planOperativoLN.DdlDependencias(ddlDependencia, unidad.ToString());
                        ddlUnidad.SelectedValue = unidad.ToString();
                    }
                    

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void dvPedido_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
        {
            try
            {
                pedidoLN = new PedidosLN();
                pacLn = new PacLN();
                int unidad = int.Parse(ddlUnidad.SelectedValue);
                dvPedido.PageIndex = e.NewPageIndex;
                dvPedido.DataSource = pacLn.PedidoPACItem(unidad, "");
                dvPedido.DataBind();
                gvPedido.DataSource = pedidoLN.PedidoDetallePac(int.Parse(dvPedido.Rows[0].Cells[1].Text));
                gvPedido.DataBind();
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnGuardarM_Click(object sender, EventArgs e)
        {
            try
            {
                pacLn = new PacLN();
                if (pacLn.ActualizarPAC(ddlNPac.SelectedValue,lblIdDetalle.Text))
                {
                    //ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.Page), "cerrarModal", "cerrarModal();", true);
                    //ScriptManager.RegisterStartupScript(this, GetType(), "Pop", "cerrarModal();", true);
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('Actualizado Correctamente');", true);
                    gvPedido.DataSource = pedidoLN.PedidoDetallePac(int.Parse(dvPedido.Rows[0].Cells[1].Text));
                    gvPedido.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "alert('No se Actualizo el PAC');", true);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}