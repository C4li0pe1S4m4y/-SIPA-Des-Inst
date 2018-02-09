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
    public class AgendaLN
    {
        AgendaAD ObjAD;

        public void DdlContactos(DropDownList drop, int id, int id2, string criterio, int opcion)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Nuevo Ingreso >>");
            drop.Items[0].Value = "0";

            DataSet dsResultado = InformacionContactos(id, id2, "", opcion);

            if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                throw new Exception("No se CONSULTARON los casos existentes: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

            drop.DataSource = dsResultado.Tables["BUSQUEDA"];
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }

        public void DdlCasos(DropDownList drop, int id, int id2, string criterio, int opcion)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Nuevo Ingreso >>");
            drop.Items[0].Value = "0";

            DataSet dsResultado = InformacionCasos(id, id2, "", opcion);

            if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                throw new Exception("No se CONSULTARON los casos existentes: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

            drop.DataSource = dsResultado.Tables["BUSQUEDA"];
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }

        public void DdlTiposCasos(DropDownList drop, int id, int id2, string criterio, int opcion)
        {
            drop.ClearSelection();
            drop.Items.Clear();

            drop.AppendDataBoundItems = true;
            drop.Items.Add("<< Nuevo Ingreso >>");
            drop.Items[0].Value = "0";

            DataSet dsResultado = InformacionTiposCasos(id, id2, "", opcion);

            if (bool.Parse(dsResultado.Tables[0].Rows[0]["ERRORES"].ToString()))
                throw new Exception("No se CONSULTARON los tipos de casos existentes: " + dsResultado.Tables[0].Rows[0]["MSG_ERROR"].ToString());

            drop.DataSource = dsResultado.Tables["BUSQUEDA"];
            drop.DataTextField = "texto";
            drop.DataValueField = "id";
            drop.DataBind();
        }

        public DataSet AlmacenarContacto(ContactosEN ObjEN)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new AgendaAD();
            try
            {
                DataTable dt = ObjAD.AlmacenarContacto(ObjEN);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = dt.Rows[0]["MENSAJE"].ToString(); ;
                return dsResultado;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.AlmacenarContacto(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet AlmacenarCaso(CasosEN ObjEN)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new AgendaAD();
            try
            {
                DataTable dt = ObjAD.AlmacenarCaso(ObjEN);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = dt.Rows[0]["MENSAJE"].ToString(); ;
                return dsResultado;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.AlmacenarCaso(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet AlmacenarTipoCaso(TiposCasosEN ObjEN)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new AgendaAD();
            try
            {
                DataTable dt = ObjAD.AlmacenarTipoCaso(ObjEN);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = dt.Rows[0]["MENSAJE"].ToString(); ;
                return dsResultado;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.AlmacenarTipoCaso(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet AlmacenarAsignacionCaso(AsignacionCasosEN ObjEN)
        {
            DataSet dsResultado = armarDsResultado();

            ObjAD = new AgendaAD();
            try
            {
                DataTable dt = ObjAD.AlmacenarAsignacionCaso(ObjEN);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = dt.Rows[0]["MENSAJE"].ToString(); ;
                return dsResultado;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.AlmacenarAsignacionCaso(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet EliminarAsignacion(int id, string usuario)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new AgendaAD();
            try
            {
                DataTable dt = ObjAD.EliminarAsignacion(id, usuario);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                dsResultado.Tables[0].Rows[0]["ERRORES"] = "false";
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
                dsResultado.Tables[0].Rows[0]["VALOR"] = id;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.EliminarAsignacion(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet InformacionContactos(int id, int id2, string criterio, int opcion)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new AgendaAD();

            try
            {
                DataTable dt = ObjAD.InformacionContactos(id, id2, criterio, opcion);

                dt.TableName = "BUSQUEDA";
                dsResultado.Tables.Add(dt);
                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.InformacionContactos(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet InformacionCasos(int id, int id2, string criterio, int opcion)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new AgendaAD();

            try
            {
                DataTable dt = ObjAD.InformacionCasos(id, id2, criterio, opcion);

                dt.TableName = "BUSQUEDA";
                dsResultado.Tables.Add(dt);
                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.InformacionCasos(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet InformacionTiposCasos(int id, int id2, string criterio, int opcion)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new AgendaAD();

            try
            {
                DataTable dt = ObjAD.InformacionTiposCasos(id, id2, criterio, opcion);

                dt.TableName = "BUSQUEDA";
                dsResultado.Tables.Add(dt);
                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.InformacionTiposCasos(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet InformacionAsignaciones(int id, int id2, string criterio, int opcion)
        {
            DataSet dsResultado = armarDsResultado();
            ObjAD = new AgendaAD();

            try
            {
                DataTable dt = ObjAD.InformacionAsignaciones(id, id2, criterio, opcion);

                dt.TableName = "BUSQUEDA";
                dsResultado.Tables.Add(dt);
                dsResultado.Tables[0].Rows[0]["ERRORES"] = false;
            }
            catch (Exception ex)
            {
                dsResultado.Tables[0].Rows[0]["MSG_ERROR"] = " CapaLN.InformacionAsignaciones(). " + ex.Message;
            }

            return dsResultado;
        }

        public DataSet armarDsResultado()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("RESULTADO");

            dt.Columns.Add("ERRORES", typeof(String));
            dt.Columns.Add("MSG_ERROR", typeof(String));
            dt.Columns.Add("VALOR", typeof(String));
            dt.Columns.Add("CODIGO", typeof(String));
            ds.Tables.Add(dt);

            DataRow dr = ds.Tables[0].NewRow();
            ds.Tables[0].Rows.Add(dr);
            ds.Tables[0].Rows[0]["ERRORES"] = true;
            ds.Tables[0].Rows[0]["MSG_ERROR"] = string.Empty;
            return ds;
        }
    }
}
