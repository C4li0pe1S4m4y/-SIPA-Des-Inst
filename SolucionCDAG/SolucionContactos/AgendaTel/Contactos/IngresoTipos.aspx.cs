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
    public partial class IngresoTipos : System.Web.UI.Page
    {
        private AgendaLN cContactosLN;
        private TiposCasosEN tTiposCasosEN;
        
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                try
                {
                    btnNuevo_Click(sender, e);

                    string s = Convert.ToString(Request.QueryString["No"]);

                    if (s != null)
                    {
                        int idTipo = 0;
                        int.TryParse(s, out idTipo);
                        lblIdTipo.Text = idTipo.ToString();


                    }
                }
                catch (Exception ex)
                {
                    lblError.Text = "Page_LoadComplete(). " + ex.Message;
                }
            }
        }

        protected void ddlTipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idTipo = 0;
                int.TryParse(ddlTipos.SelectedValue, out idTipo);

                limpiarControlesError();
                NuevoIngresoRegistro();

                if (idTipo > 0)
                {
                    cContactosLN = new AgendaLN();
                    DataSet dsResultado = cContactosLN.InformacionTiposCasos(0, 0, " WHERE a.id_tipo_caso = " + idTipo, 1);

                    if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                        throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                    if (dsResultado.Tables.Count == 0)
                        throw new Exception("Error al consultar la información del tipo de caso.");

                    if (dsResultado.Tables[0].Rows.Count == 0)
                        throw new Exception("No existe información del tipo de caso");

                    lblIdTipo.Text = idTipo.ToString();
                    txtNombre.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["NOMBRE"].ToString();
                    txtDescripcion.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["DESCRIPCION"].ToString();

                    ddlTipos.SelectedValue = idTipo.ToString();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlTipos(). " + ex.Message;
            }
        }

        public void NuevoIngresoRegistro()
        {
            try
            {
                lblIdTipo.Text = "0";

                cContactosLN = new AgendaLN();
                cContactosLN.DdlTiposCasos(ddlTipos, 0, 0, "", 1);
                txtNombre.Text = string.Empty;
                txtDescripcion.Text = string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception("NuevoIngresoRegistro(). " + ex.Message);
            }
        }

        protected void limpiarControlesError()
        {
            lblErrorNombre.Text = string.Empty;
            lblError.Text = string.Empty;
        }

        private bool validarControlesABC()
        {
            bool controlesValidos = false;
            limpiarControlesError();

            try
            {
                txtNombre.Text = txtNombre.Text.Replace('\'', ' ');
                txtNombre.Text = txtNombre.Text.Trim();

                txtDescripcion.Text = txtDescripcion.Text.Replace('\'', ' ');
                txtDescripcion.Text = txtDescripcion.Text.Trim();

                if (txtNombre.Text.Equals(string.Empty))
                {
                    lblErrorNombre.Text = "Ingrese un valor. ";
                    lblError.Text += "Ingrese nombre del tipo de caso. ";
                }

                if (lblError.Text.Equals(string.Empty))
                    controlesValidos = true;

                if (controlesValidos && Page.IsValid)
                    controlesValidos = true;
                else
                    controlesValidos = false;
            }
            catch (Exception ex)
            {
                throw new Exception("validarControlesABC(). " + ex.Message);
            }
            return controlesValidos;
        }

        protected void ddlPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarControlesError();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                if (validarControlesABC())
                {
                    int idTipo = 0;
                    int.TryParse(lblIdTipo.Text, out idTipo);

                    tTiposCasosEN = new TiposCasosEN();
                    tTiposCasosEN.ID_TIPO_CASO = idTipo.ToString();
                    tTiposCasosEN.NOMBRE = txtNombre.Text;
                    tTiposCasosEN.DESCRIPCION = txtDescripcion.Text;
                    tTiposCasosEN.USUARIO = Session["USUARIO"].ToString();

                    cContactosLN = new AgendaLN();
                    DataSet dsResultado = cContactosLN.AlmacenarTipoCaso(tTiposCasosEN);

                    if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                        throw new Exception("No se INSERTÓ/ACTUALIZÓ el caso: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                    int.TryParse(dsResultado.Tables[0].Rows[0]["VALOR"].ToString(), out idTipo);
                    lblIdTipo.Text = idTipo.ToString();

                    btnNuevo_Click(sender, e);
                    lblSuccess.Text = "Tipo de caso ALMACENADO exitosamente: ";                  
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "btnGuardar(). " + ex.Message;
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                NuevoIngresoRegistro();
            }
            catch (Exception ex)
            {
                lblError.Text = "btnNuevo(). " + ex.Message;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
        }

    }
}