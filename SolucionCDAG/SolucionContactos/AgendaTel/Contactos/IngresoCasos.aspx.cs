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
    public partial class IngresoCasos : System.Web.UI.Page
    {
        private AgendaLN cCasosLN;
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
                        int idCaso = 0;
                        int.TryParse(s, out idCaso);
                        lblIdCaso.Text = idCaso.ToString();

                        ddlCasos.SelectedValue = idCaso.ToString();
                        ddlCasos_SelectedIndexChanged(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    lblError.Text = "Page_LoadComplete(). " + ex.Message;
                }
            }
        }

        protected void ddlCasos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idCaso = 0;
                int.TryParse(ddlCasos.SelectedValue, out idCaso);

                limpiarControlesError();
                NuevoIngresoRegistro();

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

        public void NuevoIngresoRegistro()
        {
            try
            {
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
            lblErrorNombreCaso.Text = string.Empty;
            lblErrorTipoCaso.Text = string.Empty;
            lblErrorFechas.Text = string.Empty;
            lblError.Text = string.Empty;
        }

        private bool validarControlesABC()
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

                    btnNuevo_Click(sender, e);
                    lblSuccess.Text = "Caso ALMACENADO exitosamente: ";                    
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