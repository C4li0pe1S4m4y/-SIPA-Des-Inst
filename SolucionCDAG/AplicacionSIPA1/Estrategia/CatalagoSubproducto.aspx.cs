using CapaLN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionSIPA1.Estrategia
{
    public partial class CatalagoSubproducto : System.Web.UI.Page
    {
        private PlanEstrategicoLN planEstrategicoLN;
        private UsuariosLN uUsuariosLN;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet dsResultado = new DataSet();
                planEstrategicoLN = new PlanEstrategicoLN();
                dsResultado = planEstrategicoLN.ListadoSubProductos();
                gvListado.DataSource = dsResultado.Tables["BUSQUEDA"];
                gvListado.DataBind();

                planEstrategicoLN.ddlProducto(ddlProducto);
                uUsuariosLN = new UsuariosLN();
                uUsuariosLN.dropUnidad(ddlUnidades);
            }
        }

        protected void gvListado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            planEstrategicoLN = new PlanEstrategicoLN();
            gvListado.PageIndex = e.NewPageIndex;
            DataSet dsResultado = new DataSet();

            dsResultado = planEstrategicoLN.ListadoSubProductos();
            gvListado.DataSource = dsResultado.Tables["BUSQUEDA"];
            gvListado.DataBind();
        }

        protected void btnBusqueda_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                lblResultado.Text = "";
                lblResultadoSub.Text = "";
                planEstrategicoLN = new PlanEstrategicoLN();
                DataSet dsResultado = new DataSet();
                dsResultado = planEstrategicoLN.BusquedaProducto(txtCodigo.Text);
                if (!bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                {
                    txtNombre.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["producto"].ToString();
                    lblIdProducto.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["id_producto"].ToString();
                    txtResultado.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["resultado"].ToString();
                    txtCodigo.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["codigo"].ToString();
                }
                else
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Error", "alert('No se encontro el codigo');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Error", "alert('Debe de ingresar un Codigo');", true);
                txtCodigo.Focus();
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            planEstrategicoLN = new PlanEstrategicoLN();
            DataSet dsResultado = new DataSet();
            if (!string.IsNullOrEmpty(txtCodigo.Text) && !string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtResultado.Text))
            {
                if (!string.IsNullOrEmpty(lblIdProducto.Text))
                {
                    dsResultado = planEstrategicoLN.IngresarProducto(txtNombre.Text, txtResultado.Text, txtCodigo.Text, int.Parse(lblIdProducto.Text));
                    if (!bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                    {
                        lblResultado.BackColor = System.Drawing.Color.Green;
                        lblResultado.Text = " Ingresado/Actualizado con Exito.";
                        LimpiarCamposProducto();
                    }
                    else
                    {
                        lblResultado.BackColor = System.Drawing.Color.Red;
                        lblResultado.Text = " No se Ingreso/Actualizo el Producto.";
                    }
                }
                else
                {
                    dsResultado = planEstrategicoLN.IngresarProducto(txtNombre.Text, txtResultado.Text, txtCodigo.Text, 0);
                    if (!bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                    {
                        lblResultado.BackColor = System.Drawing.Color.Green;
                        lblResultado.Text = " Ingresado/Actualizado con Exito.";
                        LimpiarCamposProducto();
                    }
                    else
                    {
                        lblResultado.BackColor = System.Drawing.Color.Red;
                        lblResultado.Text = " No se Ingreso/Actualizo el Producto.";
                    }
                }
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            planEstrategicoLN = new PlanEstrategicoLN();
            DataSet dsResultado = new DataSet();
            if (!string.IsNullOrEmpty(lblIdProducto.Text))
            {
                dsResultado = planEstrategicoLN.EliminarProducto(lblIdProducto.Text);
                if (!bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                {
                    lblResultado.BackColor = System.Drawing.Color.Green;
                    lblResultado.Text = "Eliminado con Exito.";
                    txtNombre.Text = "";
                    txtCodigo.Text = "";
                }
                else
                {
                    lblResultado.BackColor = System.Drawing.Color.Red;
                    lblResultado.Text = " No se Elimino el Producto.";
                }
            }
            else
            {
                lblResultado.BackColor = System.Drawing.Color.Red;
                lblResultado.Text = "Se debe de buscar primer un producto.";
            }
        }

        protected void btnGuardarSub_Click(object sender, EventArgs e)
        {
            planEstrategicoLN = new PlanEstrategicoLN();
            DataSet dsResultado = new DataSet();
            if (!string.IsNullOrEmpty(txtSubproducto.Text) && !string.IsNullOrEmpty(txtCodigoSub.Text) && int.Parse(ddlProducto.SelectedValue) > 0 && int.Parse(ddlUnidades.SelectedValue) > 0)
            {
                if (!string.IsNullOrEmpty(lblSubproducto.Text))
                {
                    dsResultado = planEstrategicoLN.IngresarSubProducto(ddlProducto.SelectedValue,ddlUnidades.SelectedValue,txtSubproducto.Text,txtCodigoSub.Text,txtMonto.Text,int.Parse(lblSubproducto.Text), Session["usuario"].ToString());
                    if (!bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                    {
                        lblResultadoSub.BackColor = System.Drawing.Color.Green;
                        lblResultadoSub.Text = " Ingresado/Actualizado con Exito.";
                        dsResultado = new DataSet();
                        planEstrategicoLN = new PlanEstrategicoLN();
                        dsResultado = planEstrategicoLN.ListadoSubProductos();
                        gvListado.DataSource = dsResultado.Tables["BUSQUEDA"];
                        gvListado.DataBind();
                        LimpiarCamposSubproducto();
                    }
                    else
                    {
                        lblResultadoSub.BackColor = System.Drawing.Color.Red;
                        lblResultadoSub.Text = " No se Ingreso/Actualizo el Producto.";
                    }
                }
                else
                {
                    dsResultado = planEstrategicoLN.IngresarSubProducto(ddlProducto.SelectedValue, ddlUnidades.SelectedValue, txtSubproducto.Text, txtCodigoSub.Text, txtMonto.Text, 0, Session["usuario"].ToString());
                    if (!bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                    {
                        lblResultadoSub.BackColor = System.Drawing.Color.Green;
                        lblResultadoSub.Text = " Ingresado/Actualizado con Exito.";
                        dsResultado = new DataSet();
                        planEstrategicoLN = new PlanEstrategicoLN();
                        dsResultado = planEstrategicoLN.ListadoSubProductos();
                        gvListado.DataSource = dsResultado.Tables["BUSQUEDA"];
                        gvListado.DataBind();
                        LimpiarCamposSubproducto();
                    }
                    else
                    {
                        lblResultadoSub.BackColor = System.Drawing.Color.Red;
                        lblResultadoSub.Text = " No se Ingreso/Actualizo el Producto.";
                    }
                }
            }


        }

        protected void gvListado_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblResultado.Text = "";
            lblResultadoSub.Text = "";
            planEstrategicoLN = new PlanEstrategicoLN();
            DataSet dsResultado = new DataSet();
            dsResultado = planEstrategicoLN.BusquedaSubProducto(gvListado.SelectedValue.ToString());
            if (!bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
            {
                ListItem item = ddlProducto.Items.FindByValue(dsResultado.Tables["BUSQUEDA"].Rows[0]["id_producto"].ToString());
                if (item != null)
                    ddlProducto.SelectedValue = dsResultado.Tables["BUSQUEDA"].Rows[0]["id_producto"].ToString();
                item = ddlUnidades.Items.FindByValue(dsResultado.Tables["BUSQUEDA"].Rows[0]["id_unidad"].ToString());
                if (item != null)
                    ddlUnidades.SelectedValue = dsResultado.Tables["BUSQUEDA"].Rows[0]["id_unidad"].ToString();
                txtSubproducto.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["Subproducto"].ToString();
                lblSubproducto.Text = gvListado.SelectedValue.ToString();
                txtMonto.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["monto"].ToString();
                txtCodigoSub.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["codigo"].ToString();
            }
            else
                ScriptManager.RegisterStartupScript(this, typeof(string), "Error", "alert('No se encontro el codigo');", true);
        }

        protected void gvListado_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int idDetalle = Convert.ToInt32(e.Keys["ID"].ToString());
                planEstrategicoLN = new PlanEstrategicoLN();
                DataSet dsResultado = planEstrategicoLN.EliminarSubProducto(idDetalle);
                if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                    throw new Exception("No se ELIMINÓ el Renglón: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());
                dsResultado = new DataSet();
                planEstrategicoLN = new PlanEstrategicoLN();
                dsResultado = planEstrategicoLN.ListadoSubProductos();
                gvListado.DataSource = dsResultado.Tables["BUSQUEDA"];
                gvListado.DataBind();
                LimpiarCamposSubproducto();
                lblResultadoSub.BackColor = System.Drawing.Color.Green;
                lblResultadoSub.Text = " Eliminado con Exito.";
            }
            catch (Exception ex)
            {
                lblResultadoSub.BackColor = System.Drawing.Color.Red;
                lblResultadoSub.Text = " No se Elimino." + ex.Message;
                
            }
        }
        private void LimpiarCamposSubproducto()
        {
            ddlProducto.SelectedValue = "0";
            ddlUnidades.SelectedValue = "0";
            txtCodigoSub.Text = "";
            txtSubproducto.Text = "";
            txtMonto.Text = "";
            lblSubproducto.Text = "";
        }

        private void LimpiarCamposProducto()
        {
            txtNombre.Text = "";
            txtCodigo.Text = "";
            lblIdProducto.Text = "";
        }
    }
}