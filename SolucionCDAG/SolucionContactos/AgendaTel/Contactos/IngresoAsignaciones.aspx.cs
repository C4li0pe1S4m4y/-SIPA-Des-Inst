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
    public partial class IngresoAsignaciones : System.Web.UI.Page
    {
        private AgendaLN cContactosLN;
        private AgendaLN cCasosLN;
        private AgendaLN aAsignacionesLN;

        private ContactosEN cContactosEN;
        private AsignacionCasosEN aAsignacionEN;
        private CasosEN cCasosEN;
        
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
                NuevoIngresoContacto();

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

                filtrarGridAsignaciones(idContacto);
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
                lblIdAsignacion.Text = "0";
                NuevoIngresoContacto();
                NuevoIngresoCaso();

                filtrarGridAsignaciones(0);
            }
            catch (Exception ex)
            {
                throw new Exception("NuevoIngresoRegistro(). " + ex.Message);
            }
        }

        public void NuevoIngresoContacto()
        {
            try
            {
                lblIdAsignacion.Text = "0";
                //CONTACTOS
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

        public void NuevoIngresoCaso()
        {
            try
            {
                lblIdAsignacion.Text = "0";

                //CASOS
                lblIdCaso.Text = "0";
                txtNombreCaso.Text = string.Empty;
                txtDescripcion.Text = string.Empty;
                txtFechaApertura.Text = string.Empty;
                txtFechaFinalizacion.Text = string.Empty;
                txtObservacionesCaso.Text = string.Empty;

                cCasosLN = new AgendaLN();
                cCasosLN.DdlCasos(ddlCasos, 0, 0, "", 3);

                cCasosLN.DdlTiposCasos(ddlTiposCaso, 0, 0, "", 1);
            }
            catch (Exception ex)
            {
                throw new Exception("NuevoIngresoRegistro(). " + ex.Message);
            }
        }

        protected void limpiarControlesError()
        {

            lblErrorContactoExistente.Text = string.Empty;
            lblErrorCasoExistente.Text = string.Empty;

            lblErrorNombreContacto.Text = string.Empty;
            lblErrorNombreCaso.Text = string.Empty;
            lblErrorTipoCaso.Text = string.Empty;
            lblErrorFechas.Text = string.Empty;

            lblSuccess.Text = string.Empty;
            lblError.Text = string.Empty;
        }

        private bool validarControlesContacto()
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
                throw new Exception("validarControlesContacto(). " + ex.Message);
            }
            return controlesValidos;
        }

        private bool validarControlesAsignacion()
        {
            bool controlesValidos = false;
            limpiarControlesError();

            try
            {
                if (ddlContactos.SelectedValue.Equals("0") == true || ddlContactos.SelectedValue.Equals(string.Empty) == true || ddlContactos.SelectedValue.Equals("") == true)
                {
                    lblErrorContactoExistente.Text = "Seleccione un valor. ";
                    lblError.Text += "Seleccione un contacto. ";
                }

                if (ddlCasos.SelectedValue.Equals("0") == true || ddlCasos.SelectedValue.Equals(string.Empty) == true || ddlCasos.SelectedValue.Equals("") == true)
                {
                    lblErrorCasoExistente.Text = "Seleccione un valor. ";
                    lblError.Text += "Seleccione un caso. ";
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
                throw new Exception("validarControlesAsignacion(). " + ex.Message);
            }
            return controlesValidos;
        }

        private bool validarControlesCaso()
        {
            bool controlesValidos = false;
            limpiarControlesError();

            try
            {
                txtNombreCaso.Text = txtNombreCaso.Text.Replace('\'', ' ');
                txtNombreCaso.Text = txtNombreCaso.Text.Trim();

                txtDescripcion.Text = txtDescripcion.Text.Replace('\'', ' ');
                txtDescripcion.Text = txtDescripcion.Text.Trim();

                txtObservacionesCaso.Text = txtObservacionesCaso.Text.Replace('\'', ' ');
                txtObservacionesCaso.Text = txtObservacionesCaso.Text.Trim();

                if (txtNombreCaso.Text.Equals(string.Empty))
                {
                    lblErrorNombreCaso.Text = "Ingrese un valor. ";
                    lblError.Text += "Ingrese nombre del caso. ";
                }

                if (ddlTiposCaso.SelectedValue.Equals("0") == true || ddlTiposCaso.SelectedValue.Equals(string.Empty) == true || ddlTiposCaso.SelectedValue.Equals("") == true)
                {
                    lblErrorTipoCaso.Text = "Seleccione un valor. ";
                    lblError.Text += "Seleccione un tipo caso. ";
                }

                string[] sValor = "VALOR".Split('-');
                DateTime fechaApertura = new DateTime();
                DateTime fechaFinalizacion = new DateTime();

                if (txtFechaApertura.Text.Equals("") == false && txtFechaApertura.Text.Equals(string.Empty) == false)
                {
                    try
                    {
                        if (txtFechaApertura.Text.Contains("/"))
                            sValor = txtFechaApertura.Text.Split('/');
                        else if (txtFechaApertura.Text.Contains("-"))
                            sValor = txtFechaApertura.Text.Split('-');

                        int dia, mes, anio;
                        dia = mes = anio = 0;

                        if (sValor.Length != 3)
                            throw new Exception();

                        if (txtFechaApertura.Text.Contains("/"))
                        {
                            int.TryParse(sValor[0], out dia);
                            int.TryParse(sValor[1], out mes);
                            int.TryParse(sValor[2], out anio);
                        }
                        else if (txtFechaApertura.Text.Contains("-"))
                        {
                            int.TryParse(sValor[0], out anio);
                            int.TryParse(sValor[1], out mes);
                            int.TryParse(sValor[2], out dia);
                        }

                        fechaApertura = new DateTime(anio, mes, dia);
                    }
                    catch (Exception)
                    {
                        lblErrorFechas.Text = "Ingrese una fecha de apertura válida. ";
                        lblError.Text += "Ingrese una fecha de apertura válida. ";
                    }
                }

                if (lblErrorFechas.Text.Equals(""))
                {
                    if (txtFechaFinalizacion.Text.Equals("") == false && txtFechaFinalizacion.Text.Equals(string.Empty) == false)
                    {
                        try
                        {
                            sValor = "VALOR".Split('.');
                            if (txtFechaFinalizacion.Text.Contains("/"))
                                sValor = txtFechaFinalizacion.Text.Split('/');
                            else if (txtFechaFinalizacion.Text.Contains("-"))
                                sValor = txtFechaFinalizacion.Text.Split('-');

                            DateTime fecha = new DateTime();
                            int dia, mes, anio;
                            dia = mes = anio = 0;

                            if (sValor.Length != 3)
                                throw new Exception("Ingrese una fecha válida");

                            if (txtFechaFinalizacion.Text.Contains("/"))
                            {
                                int.TryParse(sValor[0], out dia);
                                int.TryParse(sValor[1], out mes);
                                int.TryParse(sValor[2], out anio);
                            }
                            else if (txtFechaFinalizacion.Text.Contains("-"))
                            {
                                int.TryParse(sValor[0], out anio);
                                int.TryParse(sValor[1], out mes);
                                int.TryParse(sValor[2], out dia);
                            }

                            fechaFinalizacion = new DateTime(anio, mes, dia);

                            if (fechaApertura > fechaFinalizacion)
                                throw new Exception("Rango no válido");
                        }
                        catch (Exception ex)
                        {
                            lblErrorFechas.Text = ex.Message;
                            lblError.Text += ex.Message;
                        }
                    }
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
                throw new Exception("validarControlesCaso(). " + ex.Message);
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
                if (validarControlesAsignacion())
                {
                    int idAsignacion, idContacto, idCaso = 0;
                    int.TryParse(lblIdAsignacion.Text, out idAsignacion);
                    int.TryParse(lblIdContacto.Text, out idContacto);
                    int.TryParse(lblIdCaso.Text, out idCaso);

                    aAsignacionEN = new AsignacionCasosEN();
                    aAsignacionEN.ID_ASIGNACION = idAsignacion.ToString();
                    aAsignacionEN.ID_CONTACTO = idContacto.ToString();
                    aAsignacionEN.ID_CASO = idCaso.ToString();
                    aAsignacionEN.OBSERVACIONES = "";
                    aAsignacionEN.USUARIO = Session["USUARIO"].ToString();

                    cContactosLN = new AgendaLN();
                    DataSet dsResultado = cContactosLN.AlmacenarAsignacionCaso(aAsignacionEN);

                    if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                        throw new Exception("No se INSERTÓ/ACTUALIZÓ la asignación: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                    int.TryParse(dsResultado.Tables[0].Rows[0]["VALOR"].ToString(), out idAsignacion);
                    //lblIdAsignacion.Text = idAsignacion.ToString();

                    filtrarGridAsignaciones(idContacto);
                    lblSuccess.Text = "Asignación ALMACENADA exitosamente: ";                 
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

        protected void ddlCasos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idCaso = 0;
                int.TryParse(ddlCasos.SelectedValue, out idCaso);

                limpiarControlesError();
                NuevoIngresoCaso();

                if (idCaso > 0)
                {
                    cCasosLN = new AgendaLN();
                    DataSet dsResultado = cCasosLN.InformacionCasos(idCaso, 0, "", 2);

                    if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                        throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                    if (dsResultado.Tables.Count == 0)
                        throw new Exception("Error al consultar la información del caso.");

                    if (dsResultado.Tables[0].Rows.Count == 0)
                        throw new Exception("No existe información del caso");

                    lblIdCaso.Text = idCaso.ToString();
                    txtNombreCaso.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["NOMBRE"].ToString();
                    txtDescripcion.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["DESCRIPCION"].ToString();
                    txtFechaApertura.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["FECHA_APERTURA_TEXT_BOX"].ToString();
                    txtFechaFinalizacion.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["FECHA_FINALIZACION_TEXT_BOX"].ToString();
                    txtObservacionesCaso.Text = dsResultado.Tables["BUSQUEDA"].Rows[0]["OBSERVACIONES"].ToString();

                    int idTipoCaso = 0;
                    int.TryParse(dsResultado.Tables["BUSQUEDA"].Rows[0]["ID_TIPO_CASO"].ToString(), out idTipoCaso);

                    ListItem item = ddlTiposCaso.Items.FindByValue(idTipoCaso.ToString());
                    if (item != null)
                        ddlTiposCaso.SelectedValue = idTipoCaso.ToString();

                    ddlCasos.SelectedValue = idCaso.ToString();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlCasos(). " + ex.Message;
            }
        }

        protected void btnGuardarContacto_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                if (validarControlesContacto())
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
                    
                    limpiarControlesError();
                    NuevoIngresoContacto();

                    ListItem item = ddlContactos.Items.FindByValue(idContacto.ToString());

                    if (item != null)
                    {
                        ddlContactos.SelectedValue = idContacto.ToString();
                        ddlContactos_SelectedIndexChanged(sender, e);
                    }

                    filtrarGridAsignaciones(idContacto);
                    lblSuccess.Text = "Contacto ALMACENADO exitosamente: ";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "btnGuardarContacto(). " + ex.Message;
            }
        }

        protected void btnGuardarCaso_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControlesError();
                if (validarControlesCaso())
                {
                    int idCaso, idTipoCaso = 0;
                    int.TryParse(lblIdCaso.Text, out idCaso);
                    int.TryParse(ddlTiposCaso.SelectedValue, out idTipoCaso);


                    cCasosEN = new CasosEN();
                    cCasosEN.ID_CASO = idCaso.ToString();
                    cCasosEN.NOMBRE = txtNombreCaso.Text;
                    cCasosEN.DESCRIPCION = txtDescripcion.Text;
                    cCasosEN.ID_TIPO_CASO = idTipoCaso.ToString(); ;
                    cCasosEN.FECHA_APERTURA = txtFechaApertura.Text;
                    cCasosEN.FECHA_FINALIZACION = txtFechaFinalizacion.Text;
                    cCasosEN.OBSERVACIONES = txtObservacionesCaso.Text;
                    cCasosEN.USUARIO = Session["USUARIO"].ToString();

                    cCasosLN = new AgendaLN();
                    DataSet dsResultado = cCasosLN.AlmacenarCaso(cCasosEN);

                    if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                        throw new Exception("No se INSERTÓ/ACTUALIZÓ el caso: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                    int.TryParse(dsResultado.Tables[0].Rows[0]["VALOR"].ToString(), out idCaso);
                    lblIdCaso.Text = idCaso.ToString();

                    limpiarControlesError();
                    NuevoIngresoCaso();

                    ListItem item = ddlContactos.Items.FindByValue(idCaso.ToString());

                    if (item != null)
                    {
                        ddlCasos.SelectedValue = idCaso.ToString();
                        ddlCasos_SelectedIndexChanged(sender, e);
                    }

                    int idContacto = 0;
                    int.TryParse(ddlContactos.SelectedValue, out idContacto);

                    filtrarGridAsignaciones(idContacto);
                    lblSuccess.Text = "Caso ALMACENADO exitosamente: ";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "btnGuardarCaso(). " + ex.Message;
            }
        }

        protected void filtrarGridAsignaciones(int id)
        {
            try
            {
                gridAsignaciones.DataSource = null;
                gridAsignaciones.DataBind();
                gridAsignaciones.SelectedIndex = -1;

                aAsignacionesLN = new AgendaLN();
                DataSet dsResultado = aAsignacionesLN.InformacionAsignaciones(0, 0, " AND a.id_contacto = " + id, 1);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0 && dsResultado.Tables["BUSQUEDA"].Rows[0]["ID"].ToString() != "")
                {
                    gridAsignaciones.DataSource = dsResultado.Tables["BUSQUEDA"];
                    gridAsignaciones.DataBind();
                }
                else
                {
                    gridAsignaciones.DataSource = null;
                    gridAsignaciones.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("filtrarGridAsignaciones(). " + ex.Message);
            }
        }

        protected void gridAsignaciones_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                limpiarControlesError();
                int idDetalle = int.Parse(e.Keys["ID"].ToString());

                if (idDetalle == 0)
                    throw new Exception("No existe Asignación para eliminar");

                //EL PEDIDO TIENE POR LO MENOS UN DETALLE, DE LO CONTRARIO SE ELIMINARE EL ENCABEZADO Y EL DETALLE
                if (gridAsignaciones.Rows.Count > 1)
                {
                    cContactosLN = new AgendaLN();
                    DataSet dsResultado = cContactosLN.EliminarAsignacion(idDetalle, Session["USUARIO"].ToString());

                    if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                        throw new Exception("No se INSERTÓ/ACTUALIZÓ la asignación: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

                    int idContacto, idCaso = 0;
                    int.TryParse(lblIdContacto.Text, out idContacto);
                    int.TryParse(lblIdCaso.Text, out idCaso);

                    filtrarGridAsignaciones(idContacto);

                    lblSuccess.Text = "Asignación eliminada correctamente!";
                }
                else
                    throw new Exception("Se necesita al menos un detalle");
            }
            catch (Exception ex)
            {
                lblError.Text = "gridDet(). " + ex.Message;
            }
        }
    }
}