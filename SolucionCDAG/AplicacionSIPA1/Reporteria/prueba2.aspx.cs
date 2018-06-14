using AplicacionSIPA1.Reportes;
using CapaAD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionSIPA1.Reporteria
{
    public partial class prueba2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btns_Click(object sender, EventArgs e)
        {
            reportePrueba rpt;
            PedidosAD pedido = new PedidosAD();
            DataTable dt = pedido.DataReportePrueba();

            rpt = new reportePrueba();
            rpt.SetDataSource(dt);

            this.CrystalReportViewer1.ReportSource = rpt;
        }
    }
}