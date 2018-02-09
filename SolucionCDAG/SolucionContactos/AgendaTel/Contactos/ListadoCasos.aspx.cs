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
    public partial class ListadoCasos : System.Web.UI.Page
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
                rblCriterio.Items.Add(new ListItem("Descripción", "descripcion"));
                rblCriterio.Items.Add(new ListItem("Fecha apertura", "fecha_apertura_grid"));
                rblCriterio.Items.Add(new ListItem("Fecha finalización", "fecha_finalizacion_grid"));
                rblCriterio.Items.Add(new ListItem("Observaciones", "observaciones"));
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
                DataSet dsResultado = cContactosLN.InformacionCasos(0, 0, "", 1);

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

                    txtBValor.Text = txtBValor.Text.Replace('\'', ' ');
                    txtBValor.Text = txtBValor.Text.Trim();

                    filtro = "0 = 0";

                    if (rblCriterio.SelectedValue.Equals("fecha_apertura_grid") == false && rblCriterio.SelectedValue.Equals("fecha_finalizacion_grid") == false)
                    {
                        if (!txtBValor.Text.Equals(string.Empty))
                            filtro += " AND " + rblCriterio.SelectedValue + " LIKE '%" + txtBValor.Text + "%'";
                    }
                    else
                    {
                        string[] fechas = txtBValor.Text.Split('y');
                        if (fechas.Length == 2)
                        {
                            int fechaInicial = 0;
                            int fechaFinal = 0;

                            try
                            {
                                fechas[0] = fechas[0].Trim();
                                fechas[1] = fechas[1].Trim();

                                string s1 = fechas[0].Split('/')[2] + fechas[0].Split('/')[1] + fechas[0].Split('/')[0];

                                int.TryParse(fechas[0].Split('/')[2] + fechas[0].Split('/')[1] + fechas[0].Split('/')[0], out fechaInicial);
                                int.TryParse(fechas[1].Split('/')[2] + fechas[1].Split('/')[1] + fechas[1].Split('/')[0], out fechaFinal);
                            }
                            catch
                            {
                                lblError.Text = "Fecha no válida";
                            }

                            if (rblCriterio.SelectedValue.Equals("fecha_apertura_grid"))
                                filtro += " AND fecha_apertura_int >= " + fechaInicial + " AND fecha_apertura_int <= " + fechaFinal;
                            else if(rblCriterio.SelectedValue.Equals("fecha_finalizacion_grid"))
                                filtro += " AND fecha_finalizacion_int >= " + fechaInicial + " AND fecha_finalizacion_int <= " + fechaFinal;

                        }
                        else
                            filtro += " AND " + rblCriterio.SelectedValue + " LIKE '%" + txtBValor.Text + "%'";
                    }

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

                int idCaso = 0;
                int.TryParse(gridEmpleados.SelectedValue.ToString(), out idCaso);

                Response.Redirect("IngresoCasos.aspx?No=" + idCaso.ToString());
            }
            catch (Exception ex)
            {
                lblError.Text = "gridEmpleados(). " + ex.Message;
            }
        }

    }
}