using CapaAD;
using CapaLN;
using Microsoft.Reporting.WebForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionSIPA1.PedidoInsumos
{
    public partial class BusquedaInsumos : System.Web.UI.Page
    {
        private PedidosAD pedidoA;
        public string thisConnectionString = ConfigurationManager.ConnectionStrings["dbcdagsipaConnectionString1"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pedidoA = new PedidosAD();
                MySqlConnection thisConnection = new MySqlConnection(thisConnectionString);
                System.Data.DataSet thisDataSet = new System.Data.DataSet();
                thisDataSet = MySqlHelper.ExecuteDataset(thisConnection, pedidoA.BusquedaCatalgoInsumo(" "));
                ReportDataSource datasource = new ReportDataSource("DataSet1", thisDataSet.Tables[0]);
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource);
                ReportViewer1.LocalReport.Refresh();
            }
        }

        protected void btnRenglon_Click(object sender, ImageClickEventArgs e)
        {
            pedidoA = new PedidosAD();
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            if (!string.IsNullOrEmpty(txtRenglon.Text))
                stringBuilder.Append(" And renglon = " + txtRenglon.Text);
            if (!string.IsNullOrEmpty(txtCodigoInsumo.Text))
                stringBuilder.Append(" And codigo_insumo = " + txtCodigoInsumo.Text);
            if (!string.IsNullOrEmpty(txtNombre.Text))
                stringBuilder.Append(" And Nombre like '%" + txtNombre.Text + "%'");
            if (!string.IsNullOrEmpty(txtCaracteristicas.Text))
                stringBuilder.Append(" And Caracteristicas like '% " + txtCaracteristicas.Text + "%'");
            if (!string.IsNullOrEmpty(txtPresentacion.Text))
                stringBuilder.Append(" And Presentacion like '% " + txtPresentacion.Text + "%'");
            if (!string.IsNullOrEmpty(txtCantidad.Text))
                stringBuilder.Append(" And Cantidad_Unidad '% " + txtCantidad.Text + "%'");
            if (!string.IsNullOrEmpty(txtCodigoPresentacion.Text))
                stringBuilder.Append(" And Codigo_presentacion = " + txtCodigoPresentacion.Text);
            MySqlConnection thisConnection = new MySqlConnection(thisConnectionString);
            System.Data.DataSet thisDataSet = new System.Data.DataSet();
            thisDataSet = MySqlHelper.ExecuteDataset(thisConnection, pedidoA.BusquedaCatalgoInsumo(stringBuilder.ToString()));
            ReportDataSource datasource = new ReportDataSource("DataSet1", thisDataSet.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            ReportViewer1.LocalReport.Refresh();
        }
    }
}