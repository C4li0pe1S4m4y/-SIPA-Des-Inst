﻿using System;
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

using Microsoft.Reporting.WebForms;
using System.IO;
using ExportToExcel;


namespace AplicacionSIPA1.ReporteriaSistema.Pedidos
{
    public partial class HistorialEstados : System.Web.UI.Page
    {
        private PlanEstrategicoLN pEstrategicoLN;
        private PlanOperativoLN pOperativoLN;
        private PlanAccionLN pAccionLN;
        private PlanAnualLN pAnualLN;
        
        private PedidosLN pInsumoLN;

        double total = 0, total2 = 0, total3 = 0, total4 = 0, total5 = 0;

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                try
                {

                    NuevoEncabezadoPoa();                    
                }
                catch (Exception ex)
                {
                    lblError.Text =  ("Escoger la Dependencia para Visualizar los Datos" + ex.Message);
                }
            }
        }


        public void NuevoEncabezadoPoa()
        {
            try
            {
                upIngreso.Visible = true;
                pEstrategicoLN = new PlanEstrategicoLN();
                pOperativoLN = new PlanOperativoLN();
                pAccionLN = new PlanAccionLN();
                pAnualLN = new PlanAnualLN();

                pEstrategicoLN.DdlPlanes(ddlPlanes);

                int idPlan = 0;
                int anioIni = 0;
                int anioFin = 0;
                if (ddlPlanes.Items.Count == 2)
                {
                    ddlPlanes.SelectedIndex = 1;
                    idPlan = int.Parse(ddlPlanes.SelectedValue);
                    anioIni = int.Parse(ddlPlanes.SelectedItem.Text.Split('-')[0].Trim());
                    anioFin = int.Parse(ddlPlanes.SelectedItem.Text.Split('-')[1].Trim());
                    lblPlanE.Visible = false;
                    ddlPlanes.Visible = false;
                }
                pEstrategicoLN.DdlAniosPlan(ddlAnios, anioIni, anioFin);
                ddlAnios.Items.RemoveAt(0);

                int anioActual = DateTime.Now.Year;

                ListItem item = ddlAnios.Items.FindByValue(anioActual.ToString());
                if (item != null)
                    ddlAnios.SelectedValue = anioActual.ToString();

                string usuario = Session["Usuario"].ToString().ToLower();


                string criterio = "AND c.id_tipo IN(48) AND a.usuario = ''" + usuario + "''";
                pInsumoLN = new PedidosLN();
                DataSet dsResultado = pInsumoLN.InformacionPermisos(0, 0, criterio, 12);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString())) { 
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());
                }
                if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0) { 
                    pOperativoLN.DdlUnidades(ddlUnidades);
                    pOperativoLN.DdlDependencias(ddlDependencias, ddlUnidades.SelectedValue);
                }
                else { 
                    pOperativoLN.DdlUnidades(ddlUnidades, usuario);
                    pOperativoLN.DdlDependencias(ddlDependencias, ddlUnidades.SelectedValue);
                }
                if (ddlDependencias.Items.Count == 1)
                {
                    if (!ddlAnios.SelectedValue.Equals("0"))
                    {
                        validarPoa(int.Parse(ddlDependencias.SelectedValue), int.Parse(ddlAnios.SelectedValue));
                    }
                }

                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);

                pAccionLN = new PlanAccionLN();
                obtenerPresupuesto(idPoa, 0);
                pAccionLN.DdlAcciones(ddlAcciones, idPoa, 0, "", 3);
                ddlAcciones.Items[0].Text = "<< TODAS >>";

                pInsumoLN = new PedidosLN();
                pInsumoLN.ChkEstadosPedido(chkEstados);
                chkEstados.Items.RemoveAt(0);

                for(int i = 0; i < chkEstados.Items.Count; i++)
                    chkEstados.Items[i].Selected = true;

                pAccionLN = new PlanAccionLN();
                pAccionLN.DdlRenglones(ddlRenglones);
                ddlRenglones.Items[0].Text = "<< TODOS >>";
                ddlRenglones.Items.Add(new ListItem("S/A", "S/A"));

                filtrarGrid();
            }
            catch (Exception ex)
            {
                throw new Exception("NuevoEncabezadoPoa(). " + ex.Message);
            }
        }


        protected bool validarPoa(int idUnidad, int anio)
        {
            bool poaValido = false;
            try
            {
                pOperativoLN = new PlanOperativoLN();
                DataSet dsPoa = pOperativoLN.DatosPoaUnidad(idUnidad, anio);

                if (dsPoa.Tables.Count == 0)
                    throw new Exception("Error al consultar el presupuesto.");

                if (dsPoa.Tables[0].Rows.Count == 0)
                    throw new Exception("No existe presupuesto asignado");

                int idPoa = 0;
                int.TryParse(dsPoa.Tables[0].Rows[0]["ID_POA"].ToString(), out idPoa);
                lblIdPoa.Text = idPoa.ToString();
            }
            catch (Exception ex)
            {
                lblErrorPoa.Text = lblError.Text = "Error: " + ex.Message;
            }
            return poaValido;
        }

        protected void filtrarGrid()
        {
            try
            {
                gridReportes.DataSource = null;
                gridReportes.DataBind();
                gridReportes.SelectedIndex = -1;
                DataSet dsResultado = new DataSet();

                System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();


                if (ddlAnios.SelectedValue.Equals("0") == false) { 
                    stringBuilder.Append(" AND t.anio_solicitud = " + ddlAnios.SelectedValue);
                }
                if (ddlUnidades.SelectedValue.Equals("0") == false) { 
                    stringBuilder.Append(" AND t.id_unidad = " + ddlUnidades.SelectedValue);
                }
                if (ddlDependencias.SelectedValue.Equals("0") == false)
                {
                    stringBuilder.Append(" AND t.id_unidad = " + ddlDependencias.SelectedValue);
                }
                else
                {
                    stringBuilder.Append(" AND t.id_unidad IN(");

                    int cantidad = (ddlUnidades.Items.Count - 1);

                    for (int i = 1; i <= cantidad; i++)
                    {
                        stringBuilder.Append(ddlUnidades.Items[i].Value.ToString());

                        if(i < cantidad)
                            stringBuilder.Append(", ");
                    }

                    stringBuilder.Append(")");
                }

                if (ddlAcciones.SelectedValue.Equals("0") == false)
                    stringBuilder.Append(" AND t.id_accion = " + ddlAcciones.SelectedValue);                

                string tiposSalida = "";
                for (int i = 0; i < chkTiposSalida.Items.Count; i++)
                    if (chkTiposSalida.Items[i].Selected == true)
                        tiposSalida += chkTiposSalida.Items[i].Value + ", ";
                
                if(tiposSalida.Equals("") == false)
                    stringBuilder.Append(" AND t.id_tipo_documento IN(" + tiposSalida + "0)");

                string estadosSalida = "";
                for (int i = 0; i < chkEstados.Items.Count; i++)
                    if (chkEstados.Items[i].Selected == true)
                        estadosSalida += chkEstados.Items[i].Value + ", ";

                if(estadosSalida.Equals("") == false)
                    stringBuilder.Append(" AND t.id_estado_pedido IN(" + estadosSalida + "0)");

                if (ddlRenglones.SelectedValue.Equals("0") == false)
                    stringBuilder.Append(" AND t.renglon_ppto = ''" + ddlRenglones.SelectedValue + "''");

                if (ddlNumeroDocumento.SelectedValue.Equals("0") == false && ddlNumeroDocumento.SelectedValue.Equals("") == false)
                    stringBuilder.Append(" AND t.no_solicitud = " + ddlNumeroDocumento.SelectedValue.Split('-')[0].Trim() + " AND t.documento = ''" + ddlNumeroDocumento.SelectedValue.Split('-')[1].Trim() + "''");
                else
                {
                    pAccionLN = new PlanAccionLN();
                    pAccionLN.DdlDocumentos(ddlNumeroDocumento, stringBuilder.ToString());
                }

                pInsumoLN = new PedidosLN(); 
                dsResultado = pInsumoLN.InformacionPedido(0, 0, 0, stringBuilder.ToString(), 15);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0)
                {
                    //dsResultado.Tables["BUSQUEDA"].Columns.Remove("anio_solicitud");
                    dsResultado.Tables["BUSQUEDA"].Columns.Remove("id_unidad");
                    dsResultado.Tables["BUSQUEDA"].Columns.Remove("id_accion");
                    dsResultado.Tables["BUSQUEDA"].Columns.Remove("id_tipo_documento");
                    dsResultado.Tables["BUSQUEDA"].Columns.Remove("id_estado_pedido");
                    
                    gridReportes.DataSource = dsResultado.Tables["BUSQUEDA"];
                    gridReportes.DataBind();

                    lblStringBuilder.Text = stringBuilder.ToString();

                }
            }
            catch (Exception ex)
            {
                throw new Exception("filtrarGrid(). " + ex.Message);
            }
        }

        protected DataTable armarDtDetalles()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID_ESPECIFICACION_DETALLE", Type.GetType("System.String"));
            dt.Columns.Add("ID_ESPECIFICACION", Type.GetType("System.String"));
            dt.Columns.Add("ID_PEDIDO_DETALLE", Type.GetType("System.String"));
            dt.Columns.Add("DESCRIPCION_ESPECIFICA", Type.GetType("System.String"));
            dt.Columns.Add("USUARIO", Type.GetType("System.String"));

            return dt;
        }


        protected void busqueda(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = lblErrorPoa.Text = string.Empty;           
                filtrarGrid();

                int idAccion = 0;
                int.TryParse(ddlAcciones.SelectedValue, out idAccion);
            }
            catch (Exception ex)
            {
                lblError.Text = "busqueda(). " + ex.Message;
            }
        }

        protected void ddlPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gridReportes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlAnios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                validarPoa(int.Parse(ddlDependencias.SelectedValue), int.Parse(ddlAnios.SelectedValue));

                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);

                obtenerPresupuesto(idPoa, 0);
                pAccionLN = new PlanAccionLN();
                pAccionLN.DdlAcciones(ddlAcciones, idPoa, 0, "", 3);

                busqueda(sender, e);
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlAnios(). " + ex.Message;
            }
        }

        protected void ddlUnidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                validarPoa(int.Parse(ddlDependencias.SelectedValue), int.Parse(ddlAnios.SelectedValue));

                pOperativoLN = new PlanOperativoLN();
                pOperativoLN.DdlDependencias(ddlDependencias, ddlUnidades.SelectedValue);

                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);

                obtenerPresupuesto(idPoa, 0);
                pAccionLN = new PlanAccionLN();
                pAccionLN.DdlAcciones(ddlAcciones, idPoa, 0, "", 3);
                ddlAcciones.Items[0].Text = "<< TODAS >>";

                busqueda(sender, e);
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlUnidades(). " + ex.Message;
            }
        }

        protected void ddlDependencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                validarPoa(int.Parse(ddlDependencias.SelectedValue), int.Parse(ddlAnios.SelectedValue));

                int idPoa = 0;
                int.TryParse(lblIdPoa.Text, out idPoa);

                obtenerPresupuesto(idPoa, 0);
                pAccionLN = new PlanAccionLN();
                pAccionLN.DdlAcciones(ddlAcciones, idPoa, 0, "", 3);

                busqueda(sender, e);
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlDependencias(). " + ex.Message;
            }
        }

        protected void obtenerPresupuesto(int idPoa, int idDependencia)
        {
            try
            {
                pAccionLN = new PlanAccionLN();
                DataSet dsPpto = pAccionLN.PptoPoa(idPoa, 0);

                decimal pptoPoaUnidad = decimal.Parse(dsPpto.Tables["BUSQUEDA"].Rows[0]["PPTO_POA_UNIDAD"].ToString());
                decimal pptoDisponibleUnidad = decimal.Parse(dsPpto.Tables["BUSQUEDA"].Rows[0]["DISPONIBLE_UNIDAD"].ToString());
                decimal pptoPoaDependencia = decimal.Parse(dsPpto.Tables["BUSQUEDA"].Rows[0]["PPTO_POA_DEPENDENCIA"].ToString());
                decimal pptoDisponibleDep = decimal.Parse(dsPpto.Tables["BUSQUEDA"].Rows[0]["DISPONIBLE_DEPENDENCIA"].ToString());


                lblTechoU.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", pptoPoaUnidad);
                lblDisponibleU.Text = String.Format(CultureInfo.InvariantCulture, "Q.{0:0,0.00}", pptoDisponibleUnidad);
            }
            catch (Exception ex)
            {
                throw new Exception("obtenerPresupuesto(). " + ex.Message);
            }
        }

        protected void ddlRenglones_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = lblErrorPoa.Text = string.Empty;
                filtrarGrid();
            }
            catch (Exception ex)
            {
                lblError.Text = "ddlRenglones(). " + ex.Message;
            }
        }

        protected void rblEstadosPedido_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnEnviarCorreo_Click(object sender, EventArgs e)
        {
            try
            {
                System.Net.Mail.SmtpClient clienteCorreo = new System.Net.Mail.SmtpClient();

                System.Net.Mail.MailMessage objEmail = new System.Net.Mail.MailMessage();
                objEmail.From = new System.Net.Mail.MailAddress("soporte.sistemas@cdag.com.gt");
                //objEmail.ReplyToList = new System.Net.Mail.MailAddressCollection();


//Destinatario
                objEmail.To.Add("ottomansketa@hotmail.com");
                objEmail.Priority = System.Net.Mail.MailPriority.Normal;
                objEmail.Subject = "Asunto";
                objEmail.Body = "Otto apurate con la función para enviar correos jaja";
                
                
                System.Net.Mail.SmtpClient objSmtp = new System.Net.Mail.SmtpClient();
                objSmtp.Host = "smtp.office365.com";
                objSmtp.Port = 587;

                objSmtp.UseDefaultCredentials = false;
                objSmtp.Credentials = new System.Net.NetworkCredential("soporte.sistemas@cdag.com.gt", "sistemas2017*");
                objSmtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                objSmtp.EnableSsl = true;
                
                objSmtp.Send(objEmail);

                lblSuccess.Text = "Correo enviado con éxito!";
            }
            catch (Exception ex)
            {
                lblError.Text = "btnEnviarCorreo(). " + ex.Message;
            }
        }

        protected void chkTiposSalida_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = lblErrorPoa.Text = string.Empty;
                filtrarGrid();
            }
            catch (Exception ex)
            {
                lblError.Text = "chkTiposSalida(). " + ex.Message;
            }
        }

        protected void ddlNumeroDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblError.Text = lblErrorPoa.Text = string.Empty;
                filtrarGrid();
            }
            catch (Exception ex)
            {
                lblError.Text = "chkTiposSalida(). " + ex.Message;
            }

        }

        protected void lbExportar_Click(object sender, EventArgs e)
        {
            try
            {

                pInsumoLN = new PedidosLN();
                DataSet dsResultado = pInsumoLN.InformacionPedido(0, 0, 0, lblStringBuilder.Text, 15);

                if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                    throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0)
                {
                    //dsResultado.Tables["BUSQUEDA"].Columns.Remove("anio_solicitud");
                    dsResultado.Tables["BUSQUEDA"].Columns.Remove("id_unidad");
                    dsResultado.Tables["BUSQUEDA"].Columns.Remove("id_accion");
                    dsResultado.Tables["BUSQUEDA"].Columns.Remove("id_tipo_documento");
                    dsResultado.Tables["BUSQUEDA"].Columns.Remove("id_estado_pedido");
                }

                string nombreArchivo = "HistorialEstadosPedido" + DateTime.Now.ToShortDateString() + ".xlsx";
                bool b = CreateExcelFile.CreateExcelDocument(dsResultado.Tables["BUSQUEDA"].Copy(), nombreArchivo, Response);

            }
            catch (Exception ex)
            {
                lblError.Text = "lbExportar(). " + ex.Message;
            }
        }
    }
}