using CapaLN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionSIPA1.Compras
{
    public partial class IngresoInsumo : System.Web.UI.Page
    {
        PedidosLN pedidoLN;
        private Type mbox;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            pedidoLN = new PedidosLN();
            try
            {
                if (pedidoLN.Ingresar_Insumo(txtRenglon.Text, txtCodigoInsumo.Text, txtNombre.Text, txtCaracteristicas.Text, txtPresentacion.Text, txtCantidadInusmo.Text, txtCodigoPresentacion.Text) >= 0)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Almacenado", "alert('Insumo Almacenado Exitosamente');", true);
                    txtRenglon.Text = string.Empty;
                    txtCodigoInsumo.Text = string.Empty;
                    txtNombre.Text = string.Empty;
                    txtCaracteristicas.Text = string.Empty;
                    txtPresentacion.Text = string.Empty;
                    txtCantidadInusmo.Text = string.Empty;
                    txtCodigoPresentacion.Text = string.Empty;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Almacenado", "alert('Ocurrio un Error al Ingresar');", true);
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Almacenado", "alert('Ocurrio un Error al Ingresar');", true);
                throw;
            }
           
        }

        protected void btnCargarArchivo_Click(object sender, EventArgs e)
        {
            if (CargaArchivo.HasFile)
            {
                string fileExt = System.IO.Path.GetExtension(CargaArchivo.FileName);
                if (fileExt == ".csv")
                {
                    try
                    {
                        log.Visible = true;
                        CargaArchivo.SaveAs("C:\\ProgramData\\MySQL\\MySQL Server 5.7\\Uploads\\Catalogo.csv");
                        pedidoLN = new PedidosLN();
                        
                        pedidoLN.Ingresar_Insumo_Catalgo();
                        ScriptManager.RegisterStartupScript(this, typeof(string), "Almaceado", "alert('El archivo se almaceno correctamente');", true);
                        log.Visible = false;
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(string), "Error", "alert('Error " + ex.Message.ToString()+ "');", true);
                        throw;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(string), "Error", "alert('El formato del archivo no es correcto');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "Error", "alert('No se a seleccionado ningun archivo');", true);
            }
        }
    }
}