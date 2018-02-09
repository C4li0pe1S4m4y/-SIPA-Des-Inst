using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLN;
using System.Data;

namespace AgendaTel.Usuario
{
    public partial class Permisos_aspx : System.Web.UI.Page
    {
        private UsuariosLN usuarioL;
        

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                usuarioL = new UsuariosLN();
                usuarioL.gridUsuario(gridUsuario);
                usuarioL.dropMenuPadre(dropMenu);

                rblCriterio.Items.Add(new ListItem("Usuario", "usuario"));
                rblCriterio.Items.Add(new ListItem("Empleado", "empleado"));
                rblCriterio.Items.Add(new ListItem("Activo", "habilitado"));
                rblCriterio.SelectedValue = "usuario";
                rblCriterio.DataBind();
            }
        }

        protected void dropMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            usuarioL = new UsuariosLN();
           
            usuarioL.listbtenerMenus(cbListMenus, int.Parse(dropMenu.SelectedValue));

            if(!lblUsuario.Text.Split('-')[0].Trim().Equals(string.Empty))
                usuarioL.listUsuariosMenus(cbListMenus, int.Parse(lblUsuario.Text.Split('-')[0].Trim()));

            ocultarLblSuccess();
            ocultarLblError();
        }

        protected void gridUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            usuarioL = new UsuariosLN();
            usuarioL.listUsuariosMenus(cbListMenus, int.Parse(gridUsuario.SelectedValue.ToString()));

            lblUsuario.Text = gridUsuario.SelectedValue.ToString() + " - " + gridUsuario.SelectedRow.Cells[2].Text;

            ocultarLblSuccess();
            ocultarLblError();
        }


        protected void gridUsuario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            usuarioL = new UsuariosLN();

            gridUsuario.PageIndex = e.NewPageIndex;
            usuarioL.gridUsuario(gridUsuario);
        }

        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dropMenu.SelectedIndex < 1)
                    throw new Exception("Seleccione un menú!");

                string idUsuario = lblUsuario.Text.Split('-')[0].Trim();

                if (idUsuario.Equals(string.Empty))
                    throw new Exception("Seleccione un usuario!");

                usuarioL = new UsuariosLN();
                usuarioL.AsignarPermisos(cbListMenus, int.Parse(idUsuario));

                lblSuccessM.Text = "El registro fue ingresado correctamente ";
                lblErrorM.Text = string.Empty;

                lblError.Text = string.Empty;
                lblSuccess.Text = string.Empty;
            }
            catch (Exception ex)
            {
                string mensaje = "Error al ingresar el registro: " + ex.Message;
                if (ex.Message.Equals("Seleccione un usuario!") || ex.Message.Equals("Seleccione un menú!"))
                    mensaje = "Seleccione un usuario!";

                if (ex.Message.Equals("Seleccione un menú!"))
                    mensaje = "Seleccione un menú!";

                lblErrorM.Text = mensaje;
                lblSuccessM.Text = string.Empty;
            }
            lblError.Text = string.Empty;
            lblSuccess.Text = string.Empty;
        }

        protected void rblCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBValor.Focus();

            ocultarLblSuccess();
            ocultarLblError();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            usuarioL = new UsuariosLN();
            usuarioL.gridUsuario(gridUsuario);

            string vBuscado = txtBValor.Text.Replace('\'', ' ');

            string filtro = string.Empty;

            object obj = gridUsuario.DataSource;
            System.Data.DataTable tbl = gridUsuario.DataSource as System.Data.DataTable;
            System.Data.DataView dv = tbl.DefaultView;

            filtro = " 0 = 0 ";

            if (!vBuscado.Equals(string.Empty))
            {
                if (rblCriterio.SelectedValue.Equals("usuario"))
                    filtro = filtro + " AND " + rblCriterio.SelectedValue + " LIKE '%" + vBuscado + "%'";

                if (rblCriterio.SelectedValue.Equals("empleado"))
                    filtro = filtro + " AND " + rblCriterio.SelectedValue + " LIKE '%" + vBuscado + "%'";

                if (rblCriterio.SelectedValue.Equals("habilitado"))
                {
                    if (vBuscado.ToUpper().Equals("SI"))
                        vBuscado = "true";

                    if (vBuscado.ToUpper().Equals("NO"))
                        vBuscado = "false";

                    bool b = true;
                    bool.TryParse(vBuscado, out b);
                    
                    if(b)
                        filtro = filtro + " AND " + rblCriterio.SelectedValue + " = " + vBuscado + "";
                    else
                        filtro = filtro + " AND 0 > 1 ";
                }
            }
            dv.RowFilter = filtro;

            gridUsuario.DataSource = dv;
            gridUsuario.DataBind();

            dropMenu.ClearSelection();
            cbListMenus.Items.Clear();
            
            ocultarLblSuccess();
            ocultarLblError();
        }

        private bool validarControlesInsertar()
        {
            bool controlesValidos = false;

            try
            {
                controlesValidos = true;
            }
            catch (Exception ex)
            {
                throw new Exception("validarControlesInsertar(). " + ex.Message);
            }

            return controlesValidos;
        }

        protected void ocultarLblError()
        {
            lblError.Text = string.Empty;
            lblErrorM.Text = string.Empty;
        }

        protected void ocultarLblSuccess()
        {
            lblSuccess.Text = string.Empty;
            lblSuccessM.Text = string.Empty;
        }
       
    }
}