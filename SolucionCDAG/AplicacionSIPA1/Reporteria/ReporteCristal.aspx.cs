using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data;
using CapaAD;
using System.Web.UI.WebControls;
using AplicacionSIPA1.Reportes;

namespace AplicacionSIPA1.Reporteria
{
    public partial class ReporteCristal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnS_Click(object sender, EventArgs e)
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