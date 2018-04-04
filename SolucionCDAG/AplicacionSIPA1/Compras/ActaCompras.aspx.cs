using CapaLN;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionSIPA1.Compras
{
    public partial class ActaCompras : System.Web.UI.Page
    {
        private PlanEstrategicoLN pEstrategicoLN;
        private PlanOperativoLN pOperativoLN;
        private PedidosLN pPedidoLN;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pEstrategicoLN = new PlanEstrategicoLN();
                pOperativoLN = new PlanOperativoLN();
                pEstrategicoLN.DdlAniosPlan(ddlAnio, 2016, 2020);
                ddlAnio.Items.RemoveAt(0);

                int anioActual = DateTime.Now.Year;

                ListItem item = ddlAnio.Items.FindByValue(anioActual.ToString());
                if (item != null)
                    ddlAnio.SelectedValue = anioActual.ToString();
                pOperativoLN.ddlPedidosCompras(ddlRequisicion, ddlAnio.SelectedValue);
            }
        }

        protected void ddlAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            pOperativoLN = new PlanOperativoLN();
            pOperativoLN.ddlPedidosCompras(ddlRequisicion, ddlAnio.SelectedValue);
        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
           
        }

        protected void ddlRequisicion_SelectedIndexChanged(object sender, EventArgs e)
        {
            pPedidoLN = new PedidosLN();

            try
            {
                if (true)
                {

                    Warning[] warnings;
                    string[] streamids;
                    string mimeType;
                    string encoding;
                    string extension;

                    ReportViewer rViewer = new ReportViewer();

                    DataTable dt = new DataTable();
                    GridView gridPlan = new GridView();

                    DataSet dsResultado = pPedidoLN.InformacionPedidoCompras(int.Parse(ddlRequisicion.SelectedValue), txtActaNo.Text, txthora.Text,
                    txtFechaInicio.Text, txtFechaCompromiso.Text);



                    ReportDataSource RD = new ReportDataSource();
                    RD.Value = dsResultado.Tables[1];
                    RD.Name = "DataSet1";



                    if (!bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                        throw new Exception("No se CONSULTÓ la información de los detalles: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());


                    rViewer.LocalReport.DataSources.Clear();
                    rViewer.LocalReport.DataSources.Add(RD);
                    rViewer.LocalReport.ReportEmbeddedResource = "\\Reportes/ActaCompras.rdlc";
                    rViewer.LocalReport.ReportPath = @"Reportes\\ActaCompras.rdlc";
                    rViewer.LocalReport.Refresh();


                    byte[] bytes = rViewer.LocalReport.Render(
                       "WORDOPENXML", null, out mimeType, out encoding,
                        out extension,
                       out streamids, out warnings);

                    string nombreReporte = "Acta Compras";

                    string direccion = Server.MapPath("ArchivoPdf");
                    direccion = (direccion + ("\\\\" + (""
                                + (nombreReporte + ".doc"))));

                    FileStream fs = new FileStream(direccion,
                       FileMode.Create);
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Close();

                    String reDireccion = "\\ArchivoPDF/";
                    reDireccion += "\\" + "" + nombreReporte + ".doc";


                    string jScript = "javascript:window.open('" + reDireccion + "','Compras'," + "'directories=no, location=no, menubar=no, scrollbars=yes, statusbar=no, tittlebar=no, width=750, height=400');";
                    btnImprimir.Attributes.Add("onclick", jScript);
                    btnImprimir_Click(sender, e);
                    btnImprimir_Click(sender, e);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}