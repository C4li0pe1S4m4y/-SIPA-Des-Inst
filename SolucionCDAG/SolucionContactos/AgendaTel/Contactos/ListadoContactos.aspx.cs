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

namespace AgendaTel.Contactos
{
    public partial class ListadoContactos : System.Web.UI.Page
    {
        private AgendaLN cContactosLN;
        
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                try
                {
                    nuevaBusqueda();
                }
                catch (Exception ex)
                {
                    lblError.Text = "Page_LoadComplete(). " + ex.Message;
                }
            }
        }

        public void nuevaBusqueda()
        {
            try
            {
                rblCriterio.Items.Add(new ListItem("Nombre", "nombre"));
                rblCriterio.Items.Add(new ListItem("CUI", "cui"));
                rblCriterio.Items.Add(new ListItem("NIT", "nit"));
                rblCriterio.Items.Add(new ListItem("Género", "genero_contacto"));
                rblCriterio.Items.Add(new ListItem("Direccion", "direccion"));
                rblCriterio.Items.Add(new ListItem("Telefono residencial", "telefono_residencial"));
                rblCriterio.Items.Add(new ListItem("Telefono celular", "telefono_celular"));
                rblCriterio.Items.Add(new ListItem("Telefono trabajo", "telefono_trabajo"));
                rblCriterio.Items.Add(new ListItem("Email personal", "email_personal"));
                rblCriterio.Items.Add(new ListItem("Email trabajo", "email_trabajo"));
                rblCriterio.SelectedValue = "nombre";
                rblCriterio.DataBind();

                txtBValor.Text = string.Empty;

                filtrarGrid();
            }
            catch (Exception ex)
            {
                throw new Exception("nuevaBusqueda(). " + ex.Message);
            }
        }

        protected void filtrarGrid()
        {
            try
            {
                gridEmpleados.DataSource = null;
                gridEmpleados.DataBind();
                gridEmpleados.SelectedIndex = -1;

                cContactosLN = new AgendaLN();
                DataSet dsResultado = cContactosLN.InformacionContactos(0, 0, "", 1);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0 && dsResultado.Tables["BUSQUEDA"].Rows[0]["ID"].ToString() != "")
                {
                    gridEmpleados.DataSource = dsResultado.Tables["BUSQUEDA"];
                    gridEmpleados.DataBind();

                    string filtro = string.Empty;

                    object obj = gridEmpleados.DataSource;
                    System.Data.DataTable tbl = gridEmpleados.DataSource as System.Data.DataTable;
                    System.Data.DataView dv = tbl.DefaultView;

                    filtro = "0 = 0";
                    if(!txtBValor.Text.Equals(string.Empty))
                        filtro += " AND " + rblCriterio.SelectedValue + " LIKE '%" + txtBValor.Text + "%'";

                    dv.RowFilter = filtro;
                    gridEmpleados.DataSource = dv;
                    gridEmpleados.DataBind();
                }
                else
                {
                    gridEmpleados.DataSource = null;
                    gridEmpleados.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("filtrarGridDetalles(). " + ex.Message);
            }
        }

        protected void limpiarControlesError()
        {
            lblError.Text = lblSuccess.Text = string.Empty;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                filtrarGrid();
            }
            catch (Exception ex)
            {
                lblError.Text = "btnBuscar(). " + ex.Message;
            }
        }

        protected void gridEmpleados_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                limpiarControlesError();
                gridEmpleados.PageIndex = e.NewPageIndex;
                filtrarGrid();
            }
            catch (Exception ex)
            {
                lblError.Text = "gridEmpleados(). " + ex.Message;
            }
        }

        protected void gridEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();

                int idContacto = 0;
                int.TryParse(gridEmpleados.SelectedValue.ToString(), out idContacto);

                Response.Redirect("IngresoContactos.aspx?No=" + idContacto.ToString());
            }
            catch (Exception ex)
            {
                lblError.Text = "gridEmpleados(). " + ex.Message;
            }
        }

        protected void rblCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}