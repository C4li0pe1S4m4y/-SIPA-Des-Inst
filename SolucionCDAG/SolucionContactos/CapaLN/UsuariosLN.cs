using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAD;
using CapaEN;
using System.Web.UI.WebControls;
using System.Web;
using System.Data;


namespace CapaLN
{
   public class UsuariosLN
    {
        UsuarioAD ADusuario;
        public void gridCargoUsuario(GridView grid, int idusr)
        {
            ADusuario = new UsuarioAD();
            grid.DataSource = ADusuario.datosCargoUsuario(idusr);
            grid.DataBind();
        }

       
        /*public void dropUnidad(DropDownList drop)
        {
            
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija Unidad >>");
            drop.Items[0].Value = "0";
            //drop.Items.Add("--Agregar Nueva Unidad--");
            //drop.Items[1].Value = "-1";
            ADusuario = new UsuarioAD();
            drop.DataSource = ADusuario.dropUnidad();
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }

        public void dropEmpleados(DropDownList drop)
        {

            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija Empleado >>");
            drop.Items[0].Value = "0";
            ADusuario = new UsuarioAD();
            drop.DataSource = ADusuario.dropEmpleados();
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }

        public void dropAnalistas(DropDownList drop)
        {

            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija Analista >>");
            drop.Items[0].Value = "0";
            //drop.Items.Add("--Agregar Nueva Unidad--");
            //drop.Items[1].Value = "-1";
            ADusuario = new UsuarioAD();
            drop.DataSource = ADusuario.dropAnalistas();
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }
        public void dropDependencia(DropDownList drop,int id)
        {
            
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija Dependencia >>");
            drop.Items[0].Value = "0";
            //drop.Items.Add("--Agregar Nueva Unidad--");
            //drop.Items[1].Value = "-1";
            ADusuario = new UsuarioAD();
            drop.DataSource = ADusuario.dropDependencia(id);
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();

            if (drop.Items.Count == 2)
                drop.Items.RemoveAt(0);
        }*/

        public void dropMenuPadre(DropDownList drop)
        {
            
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija Menu >>");
            drop.Items[0].Value = "0";
            //drop.Items.Add("--Agregar Nueva Unidad--");
            //drop.Items[1].Value = "-1";
            ADusuario = new UsuarioAD();
            drop.DataSource = ADusuario.MenusPadre();
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();

        }
        public void listbtenerMenus(CheckBoxList cbList, int idMenu)
        {
            ADusuario = new UsuarioAD();
            cbList.DataSource = ADusuario.ObtenerMenus(idMenu);
            cbList.DataTextField = "Descripcion";
            cbList.DataValueField = "id_Menu";
            cbList.DataBind();

        }
        public void listUsuariosMenus(CheckBoxList cbList,int idUsuario)
        {
            
            foreach (ListItem menuList in cbList.Items)
            {
                menuList.Selected = false;
            }

            DataTable menusActivos = new DataTable();
            ADusuario = new UsuarioAD();
            menusActivos = ADusuario.ObtenerUsuariosMenus(idUsuario);

            foreach (ListItem item in cbList.Items)
            {
                for (int i = 0; i < menusActivos.Rows.Count; i++)
                {
                    if (item.Value == menusActivos.Rows[i][0].ToString())
                    {
                        item.Selected = true;
                    }
                }
            }
        }

        public DataTable usuarios()
        {
            ADusuario = new UsuarioAD();
            return ADusuario.obtener_Usuarios();
        }

        public void gridUsuario(GridView grid)
        {
            ADusuario = new UsuarioAD();
            grid.DataSource = ADusuario.gridUsuario();
            grid.DataBind();
        }
        public DataTable datosUsuario(int idUsuario)
        {
            ADusuario = new UsuarioAD();
            return ADusuario.datosUsuario(idUsuario);
        }
        /*public void dropEmpleado(DropDownList drop)
        {
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Eliga Empleado >>");
            drop.Items[0].Value = "0";
            //drop.Items.Add("--Agregar Nueva Unidad--");
            //drop.Items[1].Value = "-1";
            ADusuario = new UsuarioAD();
            drop.DataSource = ADusuario.dropEmpleado();
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();

        }*/

        /*public void dropEmpleadoUsuario(DropDownList drop)
        {
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija Empleado >>");
            drop.Items[0].Value = "0";
            //drop.Items.Add("--Agregar Nueva Unidad--");
            //drop.Items[1].Value = "-1";
            ADusuario = new UsuarioAD();
            drop.DataSource = ADusuario.dropEmpleadoUsuario();
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
         * 
         * 
        }*/

        public void dropTipoUsuario(DropDownList drop)
        {
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Elija Tipo Usuario >>");
            drop.Items[0].Value = "0";
            //drop.Items.Add("--Agregar Nueva Unidad--");
            //drop.Items[1].Value = "-1";
            ADusuario = new UsuarioAD();
            drop.DataSource = ADusuario.dropTipoUsuario();
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();

        }
 
        public int UsuarioExiste(UsuariosEN usuario)
        {
            ADusuario = new UsuarioAD();
            return ADusuario.PassAntiguo(usuario).Rows.Count;
        }


        
        public int Exite_NombreUsuario(string nombreUsuario,int idusr)
        {
            ADusuario = new UsuarioAD();
            return ADusuario.VerificarSiExite_Nombre(nombreUsuario,idusr).Rows.Count;
        }


        
        public void ModificaPass(UsuariosEN usuario)
        {
            ADusuario = new UsuarioAD();
            ADusuario.ModificaPass(usuario);

        }

        public int IngresarUsuario(UsuariosEN usuarioE)
        {

            ADusuario = new UsuarioAD();
            return ADusuario.IngresarUsuario(usuarioE);
            
            
        }

        private DataSet armarDsResultado()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("RESULTADO");

            dt.Columns.Add("ERRORES", typeof(String));
            dt.Columns.Add("MSG_ERROR", typeof(String));
            dt.Columns.Add("VALOR", typeof(String));
            ds.Tables.Add(dt);

            DataRow dr = ds.Tables[0].NewRow();
            ds.Tables[0].Rows.Add(dr);
            ds.Tables[0].Rows[0]["ERRORES"] = true;
            ds.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
            return ds;
        }

        public void ModificarUsuario(UsuariosEN usuario)
        {
            ADusuario = new UsuarioAD();
            ADusuario.ModificarUsuario(usuario);
        }
        public int EliminarUsuario(UsuariosEN usuarioE)
        {
            ADusuario = new UsuarioAD();
            return ADusuario.EliminarUsuario(usuarioE);
        }

        public void AsignarPermisos(CheckBoxList cbList,int idUsuario)
        {
            ADusuario = new UsuarioAD();
            foreach (ListItem menuList in cbList.Items)
            {
                if (menuList.Selected)
                {
                    UsuarioAD ObjAD = new UsuarioAD();
                    DataSet dsResultado = armarDsResultado();

                    try
                    {
                        DataTable dt = ObjAD.IngresarPermiso(idUsuario, Convert.ToInt32(menuList.Value));

                        //if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                        //    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                        /*dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
                        dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                        dsResultado.Tables[0].Rows[0]["VALOR"] = dt.Rows[0]["MENSAJE"].ToString();*/
                    }
                    catch (Exception ex)
                    {
                        dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.Insertar(). " + ex.Message;
                        throw new Exception(dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());
                    }

                    //return dsResultado;
                }
                else
                {
                    ADusuario.EliminarPermiso(idUsuario, Convert.ToInt32(menuList.Value));
                }
           }
             

        }
        public DataSet IngresarCargoUsuario(int idUsuario, int idU, int idd, int idtu)
        {
            UsuarioAD ObjAD = new UsuarioAD();
            DataSet dsResultado = armarDsResultado();

            try
            {
                DataTable dt = ObjAD.IngresarCargoUsuario(idUsuario, idU, idd, idtu);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());
                
                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = dt.Rows[0]["MENSAJE"].ToString();
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.Insertar(). " + ex.Message;
            }

            return dsResultado;
        }
        public void desactivarCargoUsuario(int idcu)
        {
            ADusuario = new UsuarioAD();
            ADusuario.desactivarCargoUsuario(idcu);
        }
        


    }
}
