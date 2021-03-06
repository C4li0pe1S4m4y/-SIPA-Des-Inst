﻿using CapaLN;
using Microsoft.Reporting.WebForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionSIPA1.ReporteriaSistema
{
    public partial class ReportePedidos : System.Web.UI.Page
    {
        private PlanEstrategicoLN pEstrategicoLN;
        private PlanOperativoLN pOperativoLN;
        private PlanAccionLN pAccionLN;
        private PlanAnualLN pAnualLN;

        private PedidosLN pInsumoLN;
        public string thisConnectionString = ConfigurationManager.ConnectionStrings["dbcdagsipaConnectionString1"].ConnectionString;

        /*I used the following statement to show if you have multiple 
          input parameters, declare the parameter with the number 
          of parameters in your application, ex. New SqlParameter[4]; */

        public MySqlParameter[] SearchValue = new MySqlParameter[2];
        public MySqlParameter[] SearchValue2 = new MySqlParameter[3];
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    pEstrategicoLN = new PlanEstrategicoLN();
                    pOperativoLN = new PlanOperativoLN();
                    pAccionLN = new PlanAccionLN();
                    pAnualLN = new PlanAnualLN();
                    string usuario = Session["Usuario"].ToString().ToLower();
                    pEstrategicoLN = new PlanEstrategicoLN();
                    pEstrategicoLN.DdlAniosPlan(ddlAnios, 2017, 2020);
                    ddlAnios.Items.RemoveAt(0);
                    ddlAnios.SelectedValue = "2018";

                    string criterio = "AND c.id_tipo IN(48) AND a.usuario = ''" + usuario + "''";
                    pInsumoLN = new PedidosLN();
                    DataSet dsResultado = pInsumoLN.InformacionPermisos(0, 0, criterio, 12);

                    if (bool.Parse(dsResultado.Tables["RESULTADO"].Rows[0]["ERRORES"].ToString()))
                        throw new Exception(dsResultado.Tables["RESULTADO"].Rows[0]["MSG_ERROR"].ToString());

                    if (dsResultado.Tables["BUSQUEDA"].Rows.Count > 0)
                    {
                        pOperativoLN.DdlUnidades(ddlUnidades);
                        pOperativoLN.DdlDependencias(ddlDependencias, ddlUnidades.SelectedValue);
                    }
                    else
                    {
                        pOperativoLN.DdlUnidades(ddlUnidades, usuario);
                        pOperativoLN.DdlDependencias(ddlDependencias, ddlUnidades.SelectedValue);
                    }
                    if (ddlUnidades.Items.Count < 2)
                    {
                        ddlUnidades_SelectedIndexChanged(sender, e);
                    }

                    int idPoa = 0;
                    int.TryParse(lblIdPoa.Text, out idPoa);
                    obtenerPresupuesto(idPoa, 0);
                    pAccionLN = new PlanAccionLN();
                    pAccionLN.DdlAcciones(ddlAcciones, 0, 0, "", 3);
                    ddlAcciones.Items[0].Text = "<< TODAS >>";
                }
                catch (Exception ex)
                {
                }
            }
        }

        public void btnBusquedaAccion_Click(object sender, EventArgs e)
        {
        }

        public string busqueda(int opcion)
        {
            string valor = "";
            if (opcion == 1)
            {
                valor = "SELECT no_solicitud, Año, Accion, Documento, fecha_pedido, Descripcion, Estado, unidad_administrativa, Pedido, costo_estimado, costo_real, no_renglon, no_pac, anio_solicitud, id_unidad,id_padre," +
               "id_accion, id_tipo_documento, id_estado_pedido, Solicitante,justificacion FROM (SELECT a.no_solicitud, a.anio_solicitud AS Año, fn_codigo_accion(b.id_accion, 0, '', 1) AS Accion, a.Documento, a.fecha_pedido, c.Descripcion," +
               " a.estado_salida AS Estado, a.unidad_administrativa, c.costo_pedido AS Pedido, c.costo_estimado, c.costo_real, d.no_renglon, p.id_pac AS no_pac, a.anio_solicitud, a.id_unidad,u.id_padre ,b.id_accion, a.id_tipo_documento, " +
               "a.id_estado_pedido, CONCAT(se.id_empleado, ' - ', se.nombres) AS Solicitante,a.justificacion FROM unionpedidocc a INNER JOIN sipa_acciones b ON a.id_accion = b.id_accion INNER JOIN sipa_pedido_detalle c ON a.id_pedido = c.id_pedido " +
               "LEFT JOIN sipa_detalles_accion d ON d.id_detalle = c.id_detalle_accion INNER JOIN sipa_pac p ON p.id_pac = c.id_pac INNER JOIN ccl_empleados se ON se.id_empleado = a.id_solicitante INNER JOIN ccl_unidades u on u.id_unidad = a.id_unidad " +
               " WHERE (a.id_tipo_documento = 1) and p.anio = @Año " +
               "UNION ALL SELECT a.no_solicitud, a.anio_solicitud AS Año, fn_codigo_accion(b.id_accion, 0, '', 1) AS Accion, a.Documento, a.fecha_pedido, c.descripcion, a.estado_salida AS Estado, a.unidad_administrativa, c.costo_vale AS Pedido," +
               " c.costo_estimado, c.costo_real, d.no_renglon, 'N/A' AS no_pac, a.anio_solicitud, a.id_unidad,u.id_padre, b.id_accion, a.id_tipo_documento, a.id_estado_pedido, CONCAT(se.id_empleado, ' - ', se.nombres) AS Solicitante,a.justificacion FROM unionpedidocc a " +
               " INNER JOIN sipa_acciones b ON a.id_accion = b.id_accion INNER JOIN sipa_ccvale_detalle c ON a.id_pedido = c.id_ccvale LEFT JOIN sipa_detalles_accion d ON d.id_detalle = c.id_detalle_accion INNER JOIN ccl_empleados se ON se.id_empleado " +
               "= a.id_solicitante INNER JOIN ccl_unidades u on u.id_unidad = a.id_unidad WHERE (a.id_tipo_documento = 2) UNION ALL SELECT a.no_solicitud, a.anio_solicitud AS Año, fn_codigo_accion(b.id_accion, 0, '', 1) AS Accion, CONCAT(a.Documento, '/', tv.abreviatura) AS Expr1, a.fecha_pedido, c.justificacion," +
               " a.estado_salida AS Estado, a.unidad_administrativa, c.costo_viatico + c.pasajes + c.kilometraje AS Pedido, c.costo_estimado + c.pasajes_estimado + c.kilometraje_estimado AS costo_estimado, c.costo_real + c.pasajes_real + c.kilometraje_real AS costo_real" +
               ", d.no_renglon, 'N/A' AS no_pac, a.anio_solicitud, a.id_unidad,u.id_padre, b.id_accion, a.id_tipo_documento, a.id_estado_pedido, CONCAT(se.id_empleado, ' - ', se.nombres) AS Solicitante,a.justificacion FROM unionpedidocc a INNER JOIN sipa_acciones b ON a.id_accion = b.id_accion " +
               " INNER JOIN sipa_viaticos c ON a.id_pedido = c.id_viatico LEFT JOIN sipa_detalles_accion d ON d.id_detalle = c.id_detalle_accion INNER JOIN ccl_empleados se ON se.id_empleado = a.id_solicitante INNER JOIN sipa_tipos_viatico tv ON tv.id_tipo_viatico = " +
               "c.id_tipo_viatico INNER JOIN ccl_unidades u on u.id_unidad = a.id_unidad WHERE (a.id_tipo_documento = 3) UNION ALL SELECT a.no_solicitud, a.anio_solicitud AS Año, fn_codigo_accion(b.id_accion, 0, '', 1) AS Accion, CONCAT(a.Documento, '/', tv.abreviatura) AS Expr1, a.fecha_pedido, c.justificacion, a.estado_salida " +
               "AS Estado, a.unidad_administrativa, c.costo_viatico + c.pasajes + c.kilometraje AS Pedido, c.costo_estimado + c.pasajes_estimado + c.kilometraje_estimado AS costo_estimado, c.costo_real + c.pasajes_real + c.kilometraje_real AS costo_real, d.no_renglon, 'N/A' " +
               "AS no_pac, a.anio_solicitud, a.id_unidad,u.id_padre ,b.id_accion, a.id_tipo_documento, a.id_estado_pedido, CONCAT(se.id_empleado, ' - ', se.nombres) AS Solicitante,a.justificacion FROM unionpedidocc a INNER JOIN sipa_acciones b ON a.id_accion = b.id_accion INNER JOIN sipa_viaticos c ON " +
               "a.id_pedido = c.id_viatico LEFT JOIN sipa_detalles_accion d ON d.id_detalle = c.id_detalle_accion INNER JOIN ccl_empleados se ON se.id_empleado = a.id_solicitante INNER JOIN sipa_tipos_viatico tv ON tv.id_tipo_viatico = c.id_tipo_viatico INNER JOIN ccl_unidades u on u.id_unidad = a.id_unidad WHERE (a.id_tipo_documento = 4))" +
               " t WHERE (1 > 0) AND (id_estado_pedido IN (8, 10, 12)) and id_padre = @Unidad and Año=@Año  ";
            }
            if (opcion == 2)
            {
                valor = "SELECT no_solicitud, Año, Accion, Documento, fecha_pedido, Descripcion, Estado, unidad_administrativa, Pedido, costo_estimado, costo_real, no_renglon, no_pac, anio_solicitud, id_unidad," +
               "id_accion, id_tipo_documento, id_estado_pedido, Solicitante,justificacion FROM (SELECT a.no_solicitud, a.anio_solicitud AS Año, fn_codigo_accion(b.id_accion, 0, '', 1) AS Accion, a.Documento, a.fecha_pedido, c.Descripcion," +
               " a.estado_salida AS Estado, a.unidad_administrativa, c.costo_pedido AS Pedido, c.costo_estimado, c.costo_real, d.no_renglon, p.id_pac AS no_pac, a.anio_solicitud, a.id_unidad, b.id_accion, a.id_tipo_documento, " +
               "a.id_estado_pedido, CONCAT(se.id_empleado, ' - ', se.nombres) AS Solicitante,a.justificacion FROM unionpedidocc a INNER JOIN sipa_acciones b ON a.id_accion = b.id_accion INNER JOIN sipa_pedido_detalle c ON a.id_pedido = c.id_pedido " +
               "LEFT JOIN sipa_detalles_accion d ON d.id_detalle = c.id_detalle_accion INNER JOIN sipa_pac p ON p.id_pac = c.id_pac INNER JOIN ccl_empleados se ON se.id_empleado = a.id_solicitante WHERE (a.id_tipo_documento = 1) and p.anio = @Año " +
               "UNION ALL SELECT a.no_solicitud, a.anio_solicitud AS Año, fn_codigo_accion(b.id_accion, 0, '', 1) AS Accion, a.Documento, a.fecha_pedido, c.descripcion, a.estado_salida AS Estado, a.unidad_administrativa, c.costo_vale AS Pedido," +
               " c.costo_estimado, c.costo_real, d.no_renglon, 'N/A' AS no_pac, a.anio_solicitud, a.id_unidad, b.id_accion, a.id_tipo_documento, a.id_estado_pedido, CONCAT(se.id_empleado, ' - ', se.nombres) AS Solicitante,a.justificacion FROM unionpedidocc a " +
               " INNER JOIN sipa_acciones b ON a.id_accion = b.id_accion INNER JOIN sipa_ccvale_detalle c ON a.id_pedido = c.id_ccvale LEFT JOIN sipa_detalles_accion d ON d.id_detalle = c.id_detalle_accion INNER JOIN ccl_empleados se ON se.id_empleado " +
               "= a.id_solicitante WHERE (a.id_tipo_documento = 2) UNION ALL SELECT a.no_solicitud, a.anio_solicitud AS Año, fn_codigo_accion(b.id_accion, 0, '', 1) AS Accion, CONCAT(a.Documento, '/', tv.abreviatura) AS Expr1, a.fecha_pedido, c.justificacion," +
               " a.estado_salida AS Estado, a.unidad_administrativa, c.costo_viatico + c.pasajes + c.kilometraje AS Pedido, c.costo_estimado + c.pasajes_estimado + c.kilometraje_estimado AS costo_estimado, c.costo_real + c.pasajes_real + c.kilometraje_real AS costo_real" +
               ", d.no_renglon, 'N/A' AS no_pac, a.anio_solicitud, a.id_unidad, b.id_accion, a.id_tipo_documento, a.id_estado_pedido, CONCAT(se.id_empleado, ' - ', se.nombres) AS Solicitante,a.justificacion FROM unionpedidocc a INNER JOIN sipa_acciones b ON a.id_accion = b.id_accion " +
               " INNER JOIN sipa_viaticos c ON a.id_pedido = c.id_viatico LEFT JOIN sipa_detalles_accion d ON d.id_detalle = c.id_detalle_accion INNER JOIN ccl_empleados se ON se.id_empleado = a.id_solicitante INNER JOIN sipa_tipos_viatico tv ON tv.id_tipo_viatico = " +
               "c.id_tipo_viatico WHERE (a.id_tipo_documento = 3) UNION ALL SELECT a.no_solicitud, a.anio_solicitud AS Año, fn_codigo_accion(b.id_accion, 0, '', 1) AS Accion, CONCAT(a.Documento, '/', tv.abreviatura) AS Expr1, a.fecha_pedido, c.justificacion, a.estado_salida " +
               "AS Estado, a.unidad_administrativa, c.costo_viatico + c.pasajes + c.kilometraje AS Pedido, c.costo_estimado + c.pasajes_estimado + c.kilometraje_estimado AS costo_estimado, c.costo_real + c.pasajes_real + c.kilometraje_real AS costo_real, d.no_renglon, 'N/A' " +
               "AS no_pac, a.anio_solicitud, a.id_unidad, b.id_accion, a.id_tipo_documento, a.id_estado_pedido, CONCAT(se.id_empleado, ' - ', se.nombres) AS Solicitante,a.justificacion FROM unionpedidocc a INNER JOIN sipa_acciones b ON a.id_accion = b.id_accion INNER JOIN sipa_viaticos c ON " +
               "a.id_pedido = c.id_viatico LEFT JOIN sipa_detalles_accion d ON d.id_detalle = c.id_detalle_accion INNER JOIN ccl_empleados se ON se.id_empleado = a.id_solicitante INNER JOIN sipa_tipos_viatico tv ON tv.id_tipo_viatico = c.id_tipo_viatico WHERE (a.id_tipo_documento = 4))" +
               " t WHERE (1 > 0) AND (id_estado_pedido IN (8, 10, 12)) and id_unidad = @Unidad ";
            }
            if (opcion == 3)
            {
                valor = "SELECT no_solicitud, Año, Accion, Documento, fecha_pedido, Descripcion, Estado, unidad_administrativa, Pedido, costo_estimado, costo_real, no_renglon, no_pac, anio_solicitud, id_unidad,id_padre," +
               "id_accion, id_tipo_documento, id_estado_pedido, Solicitante,justificacion FROM (SELECT a.no_solicitud, a.anio_solicitud AS Año, fn_codigo_accion(b.id_accion, 0, '', 1) AS Accion, a.Documento, a.fecha_pedido, c.Descripcion," +
               " a.estado_salida AS Estado, a.unidad_administrativa, c.costo_pedido AS Pedido, c.costo_estimado, c.costo_real, d.no_renglon, p.id_pac AS no_pac, a.anio_solicitud, a.id_unidad,u.id_padre ,b.id_accion, a.id_tipo_documento, " +
               "a.id_estado_pedido, CONCAT(se.id_empleado, ' - ', se.nombres) AS Solicitante,a.justificacion FROM unionpedidocc a INNER JOIN sipa_acciones b ON a.id_accion = b.id_accion INNER JOIN sipa_pedido_detalle c ON a.id_pedido = c.id_pedido " +
               "LEFT JOIN sipa_detalles_accion d ON d.id_detalle = c.id_detalle_accion INNER JOIN sipa_pac p ON p.id_pac = c.id_pac INNER JOIN ccl_empleados se ON se.id_empleado = a.id_solicitante INNER JOIN ccl_unidades u on u.id_unidad = a.id_unidad " +
               " WHERE (a.id_tipo_documento = 1) and p.anio = @Año " +
               "UNION ALL SELECT a.no_solicitud, a.anio_solicitud AS Año, fn_codigo_accion(b.id_accion, 0, '', 1) AS Accion, a.Documento, a.fecha_pedido, c.descripcion, a.estado_salida AS Estado, a.unidad_administrativa, c.costo_vale AS Pedido," +
               " c.costo_estimado, c.costo_real, d.no_renglon, 'N/A' AS no_pac, a.anio_solicitud, a.id_unidad,u.id_padre, b.id_accion, a.id_tipo_documento, a.id_estado_pedido, CONCAT(se.id_empleado, ' - ', se.nombres) AS Solicitante,a.justificacion FROM unionpedidocc a " +
               " INNER JOIN sipa_acciones b ON a.id_accion = b.id_accion INNER JOIN sipa_ccvale_detalle c ON a.id_pedido = c.id_ccvale LEFT JOIN sipa_detalles_accion d ON d.id_detalle = c.id_detalle_accion INNER JOIN ccl_empleados se ON se.id_empleado " +
               "= a.id_solicitante INNER JOIN ccl_unidades u on u.id_unidad = a.id_unidad WHERE (a.id_tipo_documento = 2) UNION ALL SELECT a.no_solicitud, a.anio_solicitud AS Año, fn_codigo_accion(b.id_accion, 0, '', 1) AS Accion, CONCAT(a.Documento, '/', tv.abreviatura) AS Expr1, a.fecha_pedido, c.justificacion," +
               " a.estado_salida AS Estado, a.unidad_administrativa, c.costo_viatico + c.pasajes + c.kilometraje AS Pedido, c.costo_estimado + c.pasajes_estimado + c.kilometraje_estimado AS costo_estimado, c.costo_real + c.pasajes_real + c.kilometraje_real AS costo_real" +
               ", d.no_renglon, 'N/A' AS no_pac, a.anio_solicitud, a.id_unidad,u.id_padre, b.id_accion, a.id_tipo_documento, a.id_estado_pedido, CONCAT(se.id_empleado, ' - ', se.nombres) AS Solicitante,a.justificacion FROM unionpedidocc a INNER JOIN sipa_acciones b ON a.id_accion = b.id_accion " +
               " INNER JOIN sipa_viaticos c ON a.id_pedido = c.id_viatico LEFT JOIN sipa_detalles_accion d ON d.id_detalle = c.id_detalle_accion INNER JOIN ccl_empleados se ON se.id_empleado = a.id_solicitante INNER JOIN sipa_tipos_viatico tv ON tv.id_tipo_viatico = " +
               "c.id_tipo_viatico INNER JOIN ccl_unidades u on u.id_unidad = a.id_unidad WHERE (a.id_tipo_documento = 3) UNION ALL SELECT a.no_solicitud, a.anio_solicitud AS Año, fn_codigo_accion(b.id_accion, 0, '', 1) AS Accion, CONCAT(a.Documento, '/', tv.abreviatura) AS Expr1, a.fecha_pedido, c.justificacion, a.estado_salida " +
               "AS Estado, a.unidad_administrativa, c.costo_viatico + c.pasajes + c.kilometraje AS Pedido, c.costo_estimado + c.pasajes_estimado + c.kilometraje_estimado AS costo_estimado, c.costo_real + c.pasajes_real + c.kilometraje_real AS costo_real, d.no_renglon, 'N/A' " +
               "AS no_pac, a.anio_solicitud, a.id_unidad,u.id_padre ,b.id_accion, a.id_tipo_documento, a.id_estado_pedido, CONCAT(se.id_empleado, ' - ', se.nombres) AS Solicitante,a.justificacion FROM unionpedidocc a INNER JOIN sipa_acciones b ON a.id_accion = b.id_accion INNER JOIN sipa_viaticos c ON " +
               "a.id_pedido = c.id_viatico LEFT JOIN sipa_detalles_accion d ON d.id_detalle = c.id_detalle_accion INNER JOIN ccl_empleados se ON se.id_empleado = a.id_solicitante INNER JOIN sipa_tipos_viatico tv ON tv.id_tipo_viatico = c.id_tipo_viatico INNER JOIN ccl_unidades u on u.id_unidad = a.id_unidad WHERE (a.id_tipo_documento = 4))" +
               " t WHERE (1 > 0) AND (id_estado_pedido IN (8, 10, 12)) and id_unidad = @Unidad and Año=@Año ";
            }
            return valor;
        }

        public string querypoa()
        {
            string valor = "";
            valor = "SELECT SUM(d.monto) AS monto FROM sipa_detalles_accion d INNER JOIN sipa_acciones aa ON aa.id_accion = d.id_accion INNER JOIN sipa_renglones r ON d.no_renglon = r.No_Renglon INNER JOIN sipa_tipos_financiamiento f ON d.id_tipo_financiamiento = f.id_tipo INNER JOIN sipa_poa p on p.id_poa = aa.id_poa INNER JOIN ccl_unidades u on u.id_unidad = p.id_unidad ";
            return valor;
        }

        protected bool validarPoa(int idUnidad, int anio)
        {
            bool poaValido = false;
            try
            {
                pOperativoLN = new PlanOperativoLN();
                DataSet dsPoa = pOperativoLN.DatosPoaUnidad(idUnidad, anio);

                if (dsPoa.Tables.Count == 0)
                    lblErrorPoa.Text = "Error al consultar el presupuesto.";

                if (dsPoa.Tables[0].Rows.Count == 0)
                    lblErrorPoa.Text = "No existe presupuesto asignado";

                if (dsPoa.Tables[0].Rows.Count != 0)
                    lblErrorPoa.Text = "";

                int idPoa = 0;
                int.TryParse(dsPoa.Tables[0].Rows[0]["ID_POA"].ToString(), out idPoa);
                lblIdPoa.Text = idPoa.ToString();
            }
            catch (Exception ex)
            {
            }
            return poaValido;
        }



        protected void ddlUnidades_SelectedIndexChanged(object sender, EventArgs e)
        {

            pOperativoLN = new PlanOperativoLN();
            pOperativoLN.DdlDependencias(ddlDependencias, ddlUnidades.SelectedValue);

            validarPoa(int.Parse(ddlUnidades.SelectedValue), int.Parse(ddlAnios.SelectedValue));

            int idPoa = 0;
            int.TryParse(lblIdPoa.Text, out idPoa);
            obtenerPresupuesto(idPoa, 0);
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            stringBuilder.Append(querypoa());
            stringBuilder.Append(" Where u.id_padre  = " + ddlUnidades.SelectedValue);
            stringBuilder.Append(" and p.anio  = " + ddlAnios.SelectedValue);
            pAccionLN = new PlanAccionLN();
            pAccionLN.DdlAcciones(ddlAcciones, idPoa, 0, "", 3);
            ddlAcciones.Items[0].Text = "<< TODAS >>";

            MySqlConnection thisConnection = new MySqlConnection(thisConnectionString);
            System.Data.DataSet thisDataSet = new System.Data.DataSet();
            SearchValue[0] = new MySqlParameter("@Unidad", ddlUnidades.SelectedValue);
            SearchValue[1] = new MySqlParameter("@Año", ddlAnios.SelectedValue);
            /* Put the stored procedure result into a dataset */
            thisDataSet = MySqlHelper.ExecuteDataset(thisConnection, busqueda(1), SearchValue);

            ReportDataSource datasource = new ReportDataSource("DataSet1", thisDataSet.Tables[0]);
            System.Data.DataSet thisDataSet2 = new System.Data.DataSet();
            thisDataSet2 = MySqlHelper.ExecuteDataset(thisConnection, stringBuilder.ToString());
            ReportDataSource datasource1 = new ReportDataSource("DataSet2", thisDataSet2.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            ReportViewer1.LocalReport.DataSources.Add(datasource1);

            if (thisDataSet.Tables[0].Rows.Count == 0)
            {

            }
            ReportViewer1.LocalReport.Refresh();
        }

        protected void obtenerPresupuesto(int idPoa, int idDependencia)
        {
            try
            {
                pAccionLN = new PlanAccionLN();
                DataSet dsPpto = pAccionLN.PptoPoa(idPoa, 0);
                int unidads = 0;

                if (ddlDependencias.SelectedValue == "0")
                    int.TryParse(ddlUnidades.SelectedValue, out unidads);
                else
                    int.TryParse(ddlDependencias.SelectedValue, out unidads);

                decimal pptoPoaUnidad = decimal.Parse(dsPpto.Tables["BUSQUEDA"].Rows[0]["PPTO_POA_UNIDAD"].ToString());

                if (unidads > 0)
                {
                    dsPpto = pAccionLN.CostoEstimado(unidads, int.Parse(ddlAnios.SelectedValue));
                    decimal pptoPoaDependencia = decimal.Parse(dsPpto.Tables["BUSQUEDA"].Rows[0]["Gasto"].ToString());
                    decimal disponible = pptoPoaUnidad - pptoPoaDependencia;
                    if (disponible < 0)
                    {
                        disponible = 0;
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void ddlAcciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            validarPoa(int.Parse(ddlUnidades.SelectedValue), int.Parse(ddlAnios.SelectedValue));
            System.Text.StringBuilder consulta = new System.Text.StringBuilder();
            consulta.Append(busqueda(1));
            int idPoa = 0;
            int.TryParse(lblIdPoa.Text, out idPoa);
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            
            if (ddlAcciones.SelectedValue !="0")
            {
                stringBuilder.Append("select sum(monto) as monto from sipa_detalles_accion ");
                stringBuilder.Append("Where id_accion  = " + ddlAcciones.SelectedValue);
                consulta.Append(" and id_accion = " + ddlAcciones.SelectedValue + " ");
                
            }
            else
            {
                stringBuilder.Append(querypoa());
                stringBuilder.Append(" Where u.id_padre  = " + ddlUnidades.SelectedValue);
                stringBuilder.Append(" and p.anio  = " + ddlAnios.SelectedValue);
            }
            

            MySqlConnection thisConnection = new MySqlConnection(thisConnectionString);
            System.Data.DataSet thisDataSet = new System.Data.DataSet();
            if (ddlDependencias.SelectedIndex >= 1)
            {
                SearchValue[0] = new MySqlParameter("@Unidad", ddlDependencias.SelectedValue);
            }
            else
            {
                SearchValue[0] = new MySqlParameter("@Unidad", ddlUnidades.SelectedValue);
            }

            
            SearchValue[1] = new MySqlParameter("@Año", ddlAnios.SelectedValue);
            /* Put the stored procedure result into a dataset */
            thisDataSet = MySqlHelper.ExecuteDataset(thisConnection, consulta.ToString(), SearchValue);

            ReportDataSource datasource = new ReportDataSource("DataSet1", thisDataSet.Tables[0]);
            System.Data.DataSet thisDataSet2 = new System.Data.DataSet();
            thisDataSet2 = MySqlHelper.ExecuteDataset(thisConnection, stringBuilder.ToString());
            ReportDataSource datasource1 = new ReportDataSource("DataSet2", thisDataSet2.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            ReportViewer1.LocalReport.DataSources.Add(datasource1);

            if (thisDataSet.Tables[0].Rows.Count == 0)
            {

            }
            ReportViewer1.LocalReport.Refresh();
        }

        protected void ddlAnios_SelectedIndexChanged(object sender, EventArgs e)
        {
            validarPoa(int.Parse(ddlUnidades.SelectedValue), int.Parse(ddlAnios.SelectedValue));

            int idPoa = 0;
            int.TryParse(lblIdPoa.Text, out idPoa);
            obtenerPresupuesto(idPoa, 0);
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            stringBuilder.Append(querypoa());
            stringBuilder.Append("Where aa.id_poa  = " + idPoa);
            pAccionLN = new PlanAccionLN();
            pAccionLN.DdlAcciones(ddlAcciones, idPoa, 0, "", 3);

            MySqlConnection thisConnection = new MySqlConnection(thisConnectionString);
            System.Data.DataSet thisDataSet = new System.Data.DataSet();
            SearchValue[0] = new MySqlParameter("@Unidad", ddlUnidades.SelectedValue);
            SearchValue[1] = new MySqlParameter("@Año", ddlAnios.SelectedValue);
            /* Put the stored procedure result into a dataset */
            thisDataSet = MySqlHelper.ExecuteDataset(thisConnection, busqueda(1), SearchValue);

            ReportDataSource datasource = new ReportDataSource("DataSet1", thisDataSet.Tables[0]);
            System.Data.DataSet thisDataSet2 = new System.Data.DataSet();
            thisDataSet2 = MySqlHelper.ExecuteDataset(thisConnection, stringBuilder.ToString());
            ReportDataSource datasource1 = new ReportDataSource("DataSet2", thisDataSet2.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            ReportViewer1.LocalReport.DataSources.Add(datasource1);

            if (thisDataSet.Tables[0].Rows.Count == 0)
            {

            }
            ReportViewer1.LocalReport.Refresh();
        }

        protected void ddlDependencias_SelectedIndexChanged(object sender, EventArgs e)
        {
            validarPoa(int.Parse(ddlDependencias.SelectedValue), int.Parse(ddlAnios.SelectedValue));

            int idPoa = 0;
            int.TryParse(lblIdPoa.Text, out idPoa);
            obtenerPresupuesto(idPoa, 0);
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            stringBuilder.Append(querypoa());
            stringBuilder.Append("Where aa.id_poa  = " + idPoa);
            pAccionLN = new PlanAccionLN();
            pAccionLN.DdlAcciones(ddlAcciones, idPoa, 0, "", 3);

            MySqlConnection thisConnection = new MySqlConnection(thisConnectionString);
            System.Data.DataSet thisDataSet = new System.Data.DataSet();
            SearchValue[0] = new MySqlParameter("@Unidad", ddlDependencias.SelectedValue);
            SearchValue[1] = new MySqlParameter("@Año", ddlAnios.SelectedValue);
            /* Put the stored procedure result into a dataset */
            thisDataSet = MySqlHelper.ExecuteDataset(thisConnection, busqueda(3), SearchValue);

            ReportDataSource datasource = new ReportDataSource("DataSet1", thisDataSet.Tables[0]);
            System.Data.DataSet thisDataSet2 = new System.Data.DataSet();
            thisDataSet2 = MySqlHelper.ExecuteDataset(thisConnection, stringBuilder.ToString());
            ReportDataSource datasource1 = new ReportDataSource("DataSet2", thisDataSet2.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            ReportViewer1.LocalReport.DataSources.Add(datasource1);

            if (thisDataSet.Tables[0].Rows.Count == 0)
            {

            }
            ReportViewer1.LocalReport.Refresh();
        }

        protected void btnBusquedDoc_Click(object sender, EventArgs e)
        {
            System.Text.StringBuilder consulta = new System.Text.StringBuilder();
            consulta.Append(busqueda(1));
            string tiposSalida = "";
            for (int i = 0; i < chkTiposSalida.Items.Count; i++)
                if (chkTiposSalida.Items[i].Selected == true)
                    tiposSalida += chkTiposSalida.Items[i].Value + ", ";

            if (tiposSalida.Equals("") == false)
                consulta.Append(" AND t.id_tipo_documento IN(" + tiposSalida + "0)");

            validarPoa(int.Parse(ddlUnidades.SelectedValue), int.Parse(ddlAnios.SelectedValue));

            int idPoa = 0;
            int.TryParse(lblIdPoa.Text, out idPoa);
            obtenerPresupuesto(idPoa, 0);
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            stringBuilder.Append(querypoa());
            stringBuilder.Append(" Where u.id_padre  = " + ddlUnidades.SelectedValue);
            stringBuilder.Append(" and p.anio  = " + ddlAnios.SelectedValue);
            pAccionLN = new PlanAccionLN();
            pAccionLN.DdlAcciones(ddlAcciones, idPoa, 0, "", 3);
            ddlAcciones.Items[0].Text = "<< TODAS >>";

            MySqlConnection thisConnection = new MySqlConnection(thisConnectionString);
            System.Data.DataSet thisDataSet = new System.Data.DataSet();
            SearchValue[0] = new MySqlParameter("@Unidad", ddlUnidades.SelectedValue);
            SearchValue[1] = new MySqlParameter("@Año", ddlAnios.SelectedValue);
            /* Put the stored procedure result into a dataset */
            thisDataSet = MySqlHelper.ExecuteDataset(thisConnection,consulta.ToString(), SearchValue);

            ReportDataSource datasource = new ReportDataSource("DataSet1", thisDataSet.Tables[0]);
            System.Data.DataSet thisDataSet2 = new System.Data.DataSet();
            thisDataSet2 = MySqlHelper.ExecuteDataset(thisConnection, stringBuilder.ToString());
            ReportDataSource datasource1 = new ReportDataSource("DataSet2", thisDataSet2.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            ReportViewer1.LocalReport.DataSources.Add(datasource1);

            if (thisDataSet.Tables[0].Rows.Count == 0)
            {

            }
            ReportViewer1.LocalReport.Refresh();
        }

        protected void btnBusqueda_Click(object sender, ImageClickEventArgs e)
        {
            System.Text.StringBuilder consulta = new System.Text.StringBuilder();
            consulta.Append(busqueda(1));
            string tiposSalida = "";
            for (int i = 0; i < chkTiposSalida.Items.Count; i++)
                if (chkTiposSalida.Items[i].Selected == true)
                    tiposSalida += chkTiposSalida.Items[i].Value + ", ";

            if (tiposSalida.Equals("") == false)
                consulta.Append(" AND id_tipo_documento IN(" + tiposSalida + "0)");

            validarPoa(int.Parse(ddlUnidades.SelectedValue), int.Parse(ddlAnios.SelectedValue));

            if (!string.IsNullOrEmpty(txtNoReq.Text))
                consulta.Append(" AND no_solicitud = " + txtNoReq.Text + " ");
            if(!string.IsNullOrEmpty(txtJustificacion.Text))
                consulta.Append(" AND justificacion like'%" + txtJustificacion.Text + "%' ");
            if(!string.IsNullOrEmpty(txtDescripcion.Text))
                consulta.Append(" AND descripcion like'%" + txtDescripcion.Text + "%'");
            int idPoa = 0;
            int.TryParse(lblIdPoa.Text, out idPoa);
            obtenerPresupuesto(idPoa, 0);
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            stringBuilder.Append(querypoa());
            stringBuilder.Append(" Where u.id_padre  = " + ddlUnidades.SelectedValue);
            stringBuilder.Append(" and p.anio  = " + ddlAnios.SelectedValue);
            pAccionLN = new PlanAccionLN();
            pAccionLN.DdlAcciones(ddlAcciones, idPoa, 0, "", 3);
            ddlAcciones.Items[0].Text = "<< TODAS >>";

            MySqlConnection thisConnection = new MySqlConnection(thisConnectionString);
            System.Data.DataSet thisDataSet = new System.Data.DataSet();
            SearchValue[0] = new MySqlParameter("@Unidad", ddlUnidades.SelectedValue);
            SearchValue[1] = new MySqlParameter("@Año", ddlAnios.SelectedValue);
            /* Put the stored procedure result into a dataset */
            string result = consulta.ToString();
            thisDataSet = MySqlHelper.ExecuteDataset(thisConnection, result, SearchValue);

            ReportDataSource datasource = new ReportDataSource("DataSet1", thisDataSet.Tables[0]);
            System.Data.DataSet thisDataSet2 = new System.Data.DataSet();
            thisDataSet2 = MySqlHelper.ExecuteDataset(thisConnection, stringBuilder.ToString());
            ReportDataSource datasource1 = new ReportDataSource("DataSet2", thisDataSet2.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
            ReportViewer1.LocalReport.DataSources.Add(datasource1);

            if (thisDataSet.Tables[0].Rows.Count == 0)
            {

            }
            ReportViewer1.LocalReport.Refresh();
        }
    }
}