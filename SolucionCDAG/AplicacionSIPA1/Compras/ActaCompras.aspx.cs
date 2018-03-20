using CapaLN;
using System;
using System.Collections.Generic;
using System.Data;
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
            pPedidoLN = new PedidosLN();
            DataSet dsResultado = pPedidoLN.InformacionPedidoCompras(int.Parse(ddlRequisicion.SelectedValue),txtActaNo.Text,txthora.Text,
                txtFechaInicio.Text,txtFechaCompromiso.Text);
            
        }
    }
}