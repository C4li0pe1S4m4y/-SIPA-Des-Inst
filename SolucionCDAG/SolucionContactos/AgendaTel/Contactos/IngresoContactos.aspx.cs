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
    public partial class IngresoContactos : System.Web.UI.Page
    {
        private AgendaLN cContactosLN;
        private ContactosEN cContactosEN;
        
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
                        int idContacto = 0;
                        int.TryParse(s, out idContacto);
                        lblIdContacto.Text = idContacto.ToString();

                        ddlContactos.SelectedValue = idContacto.ToString();
                        ddlContactos_SelectedIndexChanged(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    lblError.Text = "Page_LoadComplete(). " + ex.Message;
                }
            }
        }

        protected void ddlContactos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idContacto = 0;
                int.TryParse(ddlContactos.SelectedValue, out idContacto);

                limpiarControlesError();
                NuevoIngresoRegistro();

                if (idContacto > 0)
                {
                    cContactosLN = new AgendaLN();
                    DataSet dsResultado = cContactosLN.InformacionContactos(idContacto, 0, "", 2);

                    if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                        throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                    if (dsResultado.Tables.Count == 0)
                        throw new Exception("Error al consultar la información del contacto.");

                    if (dsResultado.Tables[0].Rows.Count == 0)
                        throw new Exception("No existe información del contacto");

                    lblIdContacto.Text = idContacto.ToString();
                    txtNombreContacto.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["NOMBRE"].ToString();
                    txtCUI.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["CUI"].ToString();
                    txtNIT.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["NIT"].ToString();
                    txtDireccion.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["DIRECCION"].ToString();
                    txtTelefonoCelular.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["TELEFONO_CELULAR"].ToString();
                    txtTelefonoResidencial.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["TELEFONO_RESIDENCIAL"].ToString();
                    txtTelefonoTrabajo.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["TELEFONO_TRABAJO"].ToString();
                    txtEmailLaboral.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["EMAIL_TRABAJO"].ToString();
                    txtEmailPersonal.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["EMAIL_PERSONAL"].ToString();
                    txtObservacionesContacto.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["OBSERVACIONES"].ToString();

                    int genero = 0;
                    int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["GENERO"].ToString(), out genero);

                    ListItem item = rblGenero.Items.FindByValue(genero.ToString());

                    if (item != null)
                        rblGenero.SelectedValue = genero.ToString();

                    ddlContactos.SelectedValue = idContacto.ToString();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlContactos(). " + ex.Message;
            }
        }

        public void NuevoIngresoRegistro()
        {
            try
            {
                lblIdContacto.Text = "0";
                txtNombreContacto.Text = string.Empty;
                txtCUI.Text = string.Empty;
                txtNIT.Text = string.Empty;
                rblGenero.SelectedValue = "1";
                txtDireccion.Text = string.Empty;
                txtTelefonoCelular.Text = string.Empty;
                txtTelefonoResidencial.Text = string.Empty;
                txtTelefonoTrabajo.Text = string.Empty;
                txtEmailLaboral.Text = string.Empty;
                txtEmailPersonal.Text = string.Empty;
                txtObservacionesContacto.Text = string.Empty;

                cContactosLN = new AgendaLN();
                cContactosLN.DdlContactos(ddlContactos, 0, 0, "", 3);
            }
            catch (Exception ex)
            {
                throw new Exception("NuevoIngresoRegistro(). " + ex.Message);
            }
        }

        protected void limpiarControlesError()
        {
            lblErrorNombreContacto.Text = string.Empty;
            lblError.Text = string.Empty;
        }

        private bool validarControlesABC()
        {
            bool controlesValidos = false;
            limpiarControlesError();

            try
            {
                txtNombreContacto.Text = txtNombreContacto.Text.Replace('\'', ' ');
                txtNombreContacto.Text = txtNombreContacto.Text.Trim();

                txtCUI.Text = txtCUI.Text.Replace('\'', ' ');
                txtCUI.Text = txtCUI.Text.Trim();

                txtNIT.Text = txtNIT.Text.Replace('\'', ' ');
                txtNIT.Text = txtNIT.Text.Trim();

                txtDireccion.Text = txtDireccion.Text.Replace('\'', ' ');
                txtDireccion.Text = txtDireccion.Text.Trim();

                txtTelefonoCelular.Text = txtTelefonoCelular.Text.Replace('\'', ' ');
                txtTelefonoCelular.Text = txtTelefonoCelular.Text.Trim();

                txtTelefonoResidencial.Text = txtTelefonoResidencial.Text.Replace('\'', ' ');
                txtTelefonoResidencial.Text = txtTelefonoResidencial.Text.Trim();

                txtTelefonoTrabajo.Text = txtTelefonoTrabajo.Text.Replace('\'', ' ');
                txtTelefonoTrabajo.Text = txtTelefonoTrabajo.Text.Trim();

                txtEmailLaboral.Text = txtEmailLaboral.Text.Replace('\'', ' ');
                txtEmailLaboral.Text = txtEmailLaboral.Text.Trim();

                txtEmailPersonal.Text = txtEmailPersonal.Text.Replace('\'', ' ');
                txtEmailPersonal.Text = txtEmailPersonal.Text.Trim();

                txtObservacionesContacto.Text = txtObservacionesContacto.Text.Replace('\'', ' ');
                txtObservacionesContacto.Text = txtObservacionesContacto.Text.Trim();

                if (txtNombreContacto.Text.Equals(string.Empty))
                {
                    lblErrorNombreContacto.Text = "Ingrese un valor. ";
                    lblError.Text += "Ingrese nombre del contacto. ";
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
                    int idContacto = 0;
                    int.TryParse(lblIdContacto.Text, out idContacto);

                    cContactosEN = new ContactosEN();
                    cContactosEN.ID_CONTACTO = idContacto.ToString();
                    cContactosEN.NOMBRE = txtNombreContacto.Text;
                    cContactosEN.GENERO = rblGenero.SelectedValue.ToString();
                    cContactosEN.CUI = txtCUI.Text;
                    cContactosEN.NIT = txtNIT.Text;
                    cContactosEN.DIRECCION = txtDireccion.Text;
                    cContactosEN.TELEFONO_RESIDENCIAL = txtTelefonoResidencial.Text;
                    cContactosEN.TELEFONO_CELULAR = txtTelefonoCelular.Text;
                    cContactosEN.TELEFONO_TRABAJO = txtTelefonoTrabajo.Text;
                    cContactosEN.EMAIL_PERSONAL = txtEmailPersonal.Text;
                    cContactosEN.EMAIL_TRABAJO = txtEmailLaboral.Text;
                    cContactosEN.OBSERVACIONES = txtObservacionesContacto.Text;
                    cContactosEN.USUARIO = Session["USUARIO"].ToString();

                    cContactosLN = new AgendaLN();
                    DataSet dsResultado = cContactosLN.AlmacenarContacto(cContactosEN);

                    if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                        throw new Exception("No se INSERTÓ/ACTUALIZÓ el contacto: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                    int.TryParse(dsResultado.Tables[0].Rows[0]["VALOR"].ToString(), out idContacto);
                    lblIdContacto.Text = idContacto.ToString();

                    btnNuevo_Click(sender, e);
                    lblSuccess.Text = "Contacto ALMACENADO exitosamente: ";                 
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