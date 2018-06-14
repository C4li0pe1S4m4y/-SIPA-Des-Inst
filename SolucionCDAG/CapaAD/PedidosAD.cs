using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using CapaEN;

namespace CapaAD
{
    public class PedidosAD
    {
        ConexionBD conectar;

        //EMPLEADOS
        public DataTable DataReportePrueba()
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable("select 1 as campo1, 2 as campo2, 3 as campo3, 4 as campo4 from dual");
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter("select 1 as campo1, 2 as campo2, 3 as campo3, 4 as campo4 from dual", conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }


        public DataTable DdlSolicitantes(string usuario, int idUnidad)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL sp_slctDatosEmpleado(0, 0, '{0}', {1}, 1);", usuario, idUnidad);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        //SUBGERENTES Y DIRECTORES DE ÁREA
        public DataTable DdlJefes(string usuario, int idUnidad)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL sp_slctDatosEmpleado(0, 0, '{0}', {1}, 2);", usuario, idUnidad);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        //TECNICOS DE COMPRAS
        public DataTable DdlTecnicosCompras()
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL sp_slctDatosEmpleado(0, 0, '{0}', {1}, 7);", "", 0);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable DdlSubGerentes(string usuario, int idUnidad)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL sp_slctDatosEmpleado(0, 0, '{0}', {1}, 2);", usuario, idUnidad);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable DdlPuestosEmpleado(string usuario, int idUnidad)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL sp_slctDatosEmpleado(0, 0, '{0}', {1}, 4);", usuario, idUnidad);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable DdlTiposPedido()
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL sp_slctDatosTipoPedido(1);");
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable DdlUnidadesMedida(int idTipoPedido)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL sp_slctUnidadMedida(" + idTipoPedido + ", 1);");
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable DdlFand()
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL sp_slctDatosFand(1);");
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable DdlPacsxAccion(int idAccion)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL sp_slctPac({0}, 2);", idAccion);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable DdlRenglonesxAcion(int idAccion)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("select pd.id_detalle,CONCAT(r.No_Renglon, ' - ',  r.descripcion) texto " +
                                 " from sipa_detalles_accion pd inner join sipa_renglones r on r.no_renglon = pd.no_renglon where id_accion = {0}; ", idAccion);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable DdlInsumosxAccion(int idAccion)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL sp_slctInsumos({0}, 2);", idAccion);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable DdlRenglonesCodificarPedido(int idSalida, int id2, string criterio, int opcion)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL sp_slctRenglonesCodPedido({0}, {1}, '{2}', {3});", idSalida, id2, criterio, opcion);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable InformacionInsumoPac(int idPac)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("CALL sp_slctInsumos({0}, 3);", idPac);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataSet AlmacenarPedido(PedidosEN ObjEN, string usuariop)
        {
            DataSet dsResultado = new DataSet();

            string query = "";

            DataTable dt;
            DataTable dtEnc;
            DataTable dtDet;
            MySqlTransaction sqlTransaction;
            MySqlDataAdapter sqlAdapter;
            conectar = new ConexionBD();

            string idPedido, idPoa, idAccion, idTipoPedido, idSolicitante, idJefe, justificacion, destino, idFand, idTipoAnexo, usuario,id_producto;
            idPedido = ObjEN.ID_PEDIDO.ToString();
            idPoa = ObjEN.ID_POA.ToString();
            idAccion = ObjEN.ID_ACCION.ToString();
            idTipoPedido = ObjEN.ID_TIPO_PEDIDO.ToString();
            idSolicitante = ObjEN.ID_SOLICITANTE.ToString();
            idJefe = ObjEN.ID_JEFE_DIRECCION.ToString();
            justificacion = ObjEN.JUSTIFICACION;
            destino = ObjEN.DESTINO.ToString();
            idFand = ObjEN.ID_FAND.ToString();
            idTipoAnexo = ObjEN.ID_TIPO_ANEXO.ToString();
            usuario = ObjEN.USUARIO;
            id_producto = ObjEN.id_subproducto.ToString();

            if (destino.Equals("1"))
                idFand = "null";

            query = "CALL sp_iue_pedido(" + idPedido + ", " + idPoa + ", " + idAccion + ", " + idTipoPedido + ", " + idSolicitante + ", " + idJefe + ", '" + justificacion + "', " + idFand + ", " + idTipoAnexo + ", 0, 0, '', 0, 0, 0, 0, 0, 0, 0, '" + usuario + "', 1,null,null,null,"+id_producto+");";

            dt = armarDsResultado().Tables[0].Copy();
            dtEnc = armarDsResultado().Tables[0].Copy();

            conectar.AbrirConexion();
            sqlTransaction = conectar.conectar.BeginTransaction();
            try
            {
                dt = new DataTable();
                sqlAdapter = new MySqlDataAdapter(query, conectar.conectar);
                sqlAdapter.Fill(dt);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                int idPedidoEncabezado = int.Parse(dt.Rows[0]["MENSAJE"].ToString());
                dtEnc.Rows[0]["ERRORES"] = false;
                dtEnc.Rows[0]["MSG_ERROR"] = "";
                dtEnc.Rows[0]["VALOR"] = idPedidoEncabezado;

            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                conectar.CerrarConexion();

                dtEnc.Rows[0]["ERRORES"] = true;
                dtEnc.Rows[0]["MSG_ERROR"] = ex.Message;
                dtEnc.Rows[0]["VALOR"] = "";
            }

            dtDet = armarDsResultado().Tables[0].Copy();
            dtDet.TableName = "DETALLES";
            dtDet.Rows.RemoveAt(0);
            if (ObjEN.ID_PEDIDO_DETALLE >= 0 && dtEnc.Rows.Count > 0 && !bool.Parse(dtEnc.Rows[0]["ERRORES"].ToString()))
            {
                int idEncabezado = int.Parse(dtEnc.Rows[0]["VALOR"].ToString());

                try
                {
                    string idPedidoDetalle, idPac, cantidad, idUnidadMedida, descripcion, costoEstimado;
                    idPedidoDetalle = ObjEN.ID_PEDIDO_DETALLE.ToString();

                    cantidad = ObjEN.CANTIDAD_ESTIMADA.ToString();
                    idUnidadMedida = ObjEN.ID_UNIDAD_MEDIDA.ToString();
                    descripcion = ObjEN.DESCRIPCION;
                    costoEstimado = ObjEN.COSTO_ESTIMADO.ToString();
                    idPac = ObjEN.ID_PAC.ToString();

                    query = "CALL sp_iue_pedido_detalles(" + idPedidoDetalle + ", " + idEncabezado + "," + idPac + ", " + cantidad + ", " + idUnidadMedida + ", '" + descripcion + "', " + costoEstimado + ", 0, 0, 0, 0, '', 0, 0, 0, 0, '" + usuario + "'," + ObjEN.Codigo_Insumo + "," + ObjEN.Codigo_Presentacion + ", 1);";

                    dt = new DataTable();
                    sqlAdapter = new MySqlDataAdapter(query, conectar.conectar);
                    sqlAdapter.Fill(dt);

                    if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                        throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                    DataRow drDet = dtDet.NewRow();
                    drDet["ERRORES"] = dt.Rows[0]["RESULTADO"].ToString();
                    drDet["MSG_ERROR"] = "";
                    drDet["VALOR"] = dt.Rows[0]["MENSAJE"].ToString();
                    dtDet.Rows.Add(drDet);
                }
                catch (Exception ex)
                {
                    sqlTransaction.Rollback();
                    conectar.CerrarConexion();

                    dtEnc.Rows[0]["ERRORES"] = true;
                    dtEnc.Rows[0]["MSG_ERROR"] = ex.Message;
                }
            }

            if (dtEnc.Rows.Count > 0 && !bool.Parse(dtEnc.Rows[0]["ERRORES"].ToString()))
                sqlTransaction.Commit();

            conectar.CerrarConexion();

            dsResultado = new DataSet();
            dsResultado.Tables.Add(dtEnc.Copy());
            dsResultado.Tables.Add(dtDet);

            return dsResultado;
        }

        public DataSet AlmacenarPedidoMultianual(PedidosEN ObjEN, string usuariop)
        {
            DataSet dsResultado = new DataSet();

            string query = "";

            DataTable dt;
            DataTable dtEnc;
            DataTable dtDet;
            MySqlTransaction sqlTransaction;
            MySqlDataAdapter sqlAdapter;
            conectar = new ConexionBD();

            string idPedido, idPoa, idAccion, idTipoPedido, idSolicitante, idJefe, justificacion, destino, idFand, multianual, idTipoAnexo, usuario;
            idPedido = ObjEN.ID_PEDIDO.ToString();
            idPoa = ObjEN.ID_POA.ToString();
            idAccion = ObjEN.ID_ACCION.ToString();
            idTipoPedido = ObjEN.ID_TIPO_PEDIDO.ToString();
            idSolicitante = ObjEN.ID_SOLICITANTE.ToString();
            idJefe = ObjEN.ID_JEFE_DIRECCION.ToString();
            justificacion = ObjEN.JUSTIFICACION;
            destino = ObjEN.DESTINO.ToString();
            idFand = ObjEN.ID_FAND.ToString();
            multianual = ObjEN.MULTIANUAL.ToString();
            idTipoAnexo = ObjEN.ID_TIPO_ANEXO.ToString();
            usuario = ObjEN.USUARIO;


            if (destino.Equals("1"))
                idFand = "null";

            query = "CALL sp_iue_pedido_multianual(" + idPedido + ", " + idPoa + ", " + idAccion + ", " + idTipoPedido + ", " + idSolicitante + ", " + idJefe + ", '" + justificacion + "', " + idFand + ", " + idTipoAnexo + ", 0, 0, '', 0, 0, 0, 0, 0, 0, 0, 1, '" + usuario + "', 1,null,null,null);";

            dt = armarDsResultado().Tables[0].Copy();
            dtEnc = armarDsResultado().Tables[0].Copy();

            conectar.AbrirConexion();
            sqlTransaction = conectar.conectar.BeginTransaction();
            try
            {
                dt = new DataTable();
                sqlAdapter = new MySqlDataAdapter(query, conectar.conectar);
                sqlAdapter.Fill(dt);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                int idPedidoEncabezado = int.Parse(dt.Rows[0]["MENSAJE"].ToString());
                dtEnc.Rows[0]["ERRORES"] = false;
                dtEnc.Rows[0]["MSG_ERROR"] = "";
                dtEnc.Rows[0]["VALOR"] = idPedidoEncabezado;

            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                conectar.CerrarConexion();

                dtEnc.Rows[0]["ERRORES"] = true;
                dtEnc.Rows[0]["MSG_ERROR"] = ex.Message;
                dtEnc.Rows[0]["VALOR"] = "";
            }

            dtDet = armarDsResultado().Tables[0].Copy();
            dtDet.TableName = "DETALLES";
            dtDet.Rows.RemoveAt(0);
            if (ObjEN.ID_PEDIDO_DETALLE >= 0 && dtEnc.Rows.Count > 0 && !bool.Parse(dtEnc.Rows[0]["ERRORES"].ToString()))
            {
                int idEncabezado = int.Parse(dtEnc.Rows[0]["VALOR"].ToString());

                try
                {
                    string idPedidoDetalle, idPac, cantidad, idUnidadMedida, descripcion, costoEstimado, cantidadMultianual, costoMultianual;
                    idPedidoDetalle = ObjEN.ID_PEDIDO_DETALLE.ToString();
                    idPac = ObjEN.ID_PAC.ToString();
                    cantidad = ObjEN.CANTIDAD_ESTIMADA.ToString();
                    idUnidadMedida = ObjEN.ID_UNIDAD_MEDIDA.ToString();
                    descripcion = ObjEN.DESCRIPCION;
                    costoEstimado = ObjEN.COSTO_ESTIMADO.ToString();

                    cantidadMultianual = ObjEN.VCANTIDAD_PEDIDO_MULTIANUAL;
                    costoMultianual = ObjEN.VCOSTO_PEDIDO_MULTIANUAL.ToString();

                    query = "CALL sp_iue_pedido_detalles_multianual(" + idPedidoDetalle + ", " + idEncabezado + ", " + idPac + ", " + cantidad + ", " + idUnidadMedida + ", '" + descripcion + "', " + costoEstimado + ", 0, 0, 0, 0, '', 0, 0, 0, " + cantidadMultianual + ", " + costoMultianual + ", 0, '" + usuario + "', 1);";

                    dt = new DataTable();
                    sqlAdapter = new MySqlDataAdapter(query, conectar.conectar);
                    sqlAdapter.Fill(dt);

                    if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                        throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                    DataRow drDet = dtDet.NewRow();
                    drDet["ERRORES"] = dt.Rows[0]["RESULTADO"].ToString();
                    drDet["MSG_ERROR"] = "";
                    drDet["VALOR"] = dt.Rows[0]["MENSAJE"].ToString();
                    dtDet.Rows.Add(drDet);
                }
                catch (Exception ex)
                {
                    sqlTransaction.Rollback();
                    conectar.CerrarConexion();

                    dtEnc.Rows[0]["ERRORES"] = true;
                    dtEnc.Rows[0]["MSG_ERROR"] = ex.Message;
                }
            }

            if (dtEnc.Rows.Count > 0 && !bool.Parse(dtEnc.Rows[0]["ERRORES"].ToString()))
                sqlTransaction.Commit();

            conectar.CerrarConexion();

            dsResultado = new DataSet();
            dsResultado.Tables.Add(dtEnc.Copy());
            dsResultado.Tables.Add(dtDet);

            return dsResultado;
        }

        public DataSet AlmacenarVale(PedidosEN ObjEN, string usuariop)
        {
            DataSet dsResultado = new DataSet();

            string query = "";

            DataTable dt;
            DataTable dtEnc;
            DataTable dtDet;
            MySqlTransaction sqlTransaction;
            MySqlDataAdapter sqlAdapter;
            conectar = new ConexionBD();

            string idPedido, idPoa, idAccion, idTipoPedido, idSolicitante, idJefe, justificacion, destino, idFand, idTipoAnexo, usuario;
            idPedido = ObjEN.ID_PEDIDO.ToString();
            idPoa = ObjEN.ID_POA.ToString();
            idAccion = ObjEN.ID_ACCION.ToString();
            idTipoPedido = ObjEN.ID_TIPO_PEDIDO.ToString();
            idSolicitante = ObjEN.ID_SOLICITANTE.ToString();
            idJefe = ObjEN.ID_JEFE_DIRECCION.ToString();
            justificacion = ObjEN.JUSTIFICACION;
            destino = ObjEN.DESTINO.ToString();
            idFand = ObjEN.ID_FAND.ToString();
            idTipoAnexo = ObjEN.ID_TIPO_ANEXO.ToString();
            usuario = ObjEN.USUARIO;


            if (destino.Equals("1"))
                idFand = "null";

            query = "CALL sp_iue_ccvale(" + idPedido + ", " + idPoa + ", " + idAccion + ", " + idTipoPedido + ", " + idSolicitante + ", " + idJefe + ", '" + justificacion + "', " + idFand + ", " + idTipoAnexo + ", 0, 0, '', '" + usuario + "', 1);";

            dt = armarDsResultado().Tables[0].Copy();
            dtEnc = armarDsResultado().Tables[0].Copy();

            conectar.AbrirConexion();
            sqlTransaction = conectar.conectar.BeginTransaction();
            try
            {
                dt = new DataTable();
                sqlAdapter = new MySqlDataAdapter(query, conectar.conectar);
                sqlAdapter.Fill(dt);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                int idPedidoEncabezado = int.Parse(dt.Rows[0]["MENSAJE"].ToString());
                dtEnc.Rows[0]["ERRORES"] = false;
                dtEnc.Rows[0]["MSG_ERROR"] = "";
                dtEnc.Rows[0]["VALOR"] = idPedidoEncabezado;

            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                conectar.CerrarConexion();

                dtEnc.Rows[0]["ERRORES"] = true;
                dtEnc.Rows[0]["MSG_ERROR"] = ex.Message;
                dtEnc.Rows[0]["VALOR"] = "";
            }

            dtDet = armarDsResultado().Tables[0].Copy();
            dtDet.TableName = "DETALLES";
            dtDet.Rows.RemoveAt(0);
            if (ObjEN.ID_PEDIDO_DETALLE >= 0 && dtEnc.Rows.Count > 0 && !bool.Parse(dtEnc.Rows[0]["ERRORES"].ToString()))
            {
                int idEncabezado = int.Parse(dtEnc.Rows[0]["VALOR"].ToString());

                try
                {
                    string idPedidoDetalle, idPac, cantidad, idUnidadMedida, descripcion, costoEstimado;
                    idPedidoDetalle = ObjEN.ID_PEDIDO_DETALLE.ToString();
                    idPac = ObjEN.ID_PAC.ToString();
                    cantidad = ObjEN.CANTIDAD_ESTIMADA.ToString();
                    idUnidadMedida = ObjEN.ID_UNIDAD_MEDIDA.ToString();
                    descripcion = ObjEN.DESCRIPCION;
                    costoEstimado = ObjEN.COSTO_ESTIMADO.ToString();

                    query = "CALL sp_iue_ccvale_detalles(" + idPedidoDetalle + ", " + idEncabezado + ", NULL, " + cantidad + ", " + idUnidadMedida + ", '" + descripcion + "', " + costoEstimado + ", '" + usuario + "', 1);";

                    dt = new DataTable();
                    sqlAdapter = new MySqlDataAdapter(query, conectar.conectar);
                    sqlAdapter.Fill(dt);

                    if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                        throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                    DataRow drDet = dtDet.NewRow();
                    drDet["ERRORES"] = dt.Rows[0]["RESULTADO"].ToString();
                    drDet["MSG_ERROR"] = "";
                    drDet["VALOR"] = dt.Rows[0]["MENSAJE"].ToString();
                    dtDet.Rows.Add(drDet);
                }
                catch (Exception ex)
                {
                    sqlTransaction.Rollback();
                    conectar.CerrarConexion();

                    dtEnc.Rows[0]["ERRORES"] = true;
                    dtEnc.Rows[0]["MSG_ERROR"] = ex.Message;
                }
            }

            if (dtEnc.Rows.Count > 0 && !bool.Parse(dtEnc.Rows[0]["ERRORES"].ToString()))
                sqlTransaction.Commit();

            conectar.CerrarConexion();

            dsResultado = new DataSet();
            dsResultado.Tables.Add(dtEnc.Copy());
            dsResultado.Tables.Add(dtDet);

            return dsResultado;
        }

        public DataSet ActualizarTotalEnLetras(int id, int id2, string totalEnLetras, int opcion)
        {
            string query = "";
            DataSet dsResultado;
            DataTable dt;
            DataTable dtEnc;
            MySqlTransaction sqlTransaction;
            MySqlDataAdapter sqlAdapter;
            conectar = new ConexionBD();

            query = string.Format("CALL sp_act_total_en_letras({0}, {1}, '{2}', {3});", id, id2, totalEnLetras, opcion);

            dt = armarDsResultado().Tables[0].Copy();
            dtEnc = armarDsResultado().Tables[0].Copy();

            conectar.AbrirConexion();
            sqlTransaction = conectar.conectar.BeginTransaction();
            try
            {
                dt = new DataTable();
                sqlAdapter = new MySqlDataAdapter(query, conectar.conectar);
                sqlAdapter.Fill(dt);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                int idPedidoEncabezado = int.Parse(dt.Rows[0]["MENSAJE"].ToString());
                dtEnc.Rows[0]["ERRORES"] = false;
                dtEnc.Rows[0]["MSG_ERROR"] = "";
                dtEnc.Rows[0]["VALOR"] = idPedidoEncabezado;

            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                conectar.CerrarConexion();

                dtEnc.Rows[0]["ERRORES"] = true;
                dtEnc.Rows[0]["MSG_ERROR"] = ex.Message;
                dtEnc.Rows[0]["VALOR"] = "";
            }

            if (dtEnc.Rows.Count > 0 && !bool.Parse(dtEnc.Rows[0]["ERRORES"].ToString()))
                sqlTransaction.Commit();

            conectar.CerrarConexion();

            dsResultado = new DataSet();
            dsResultado.Tables.Add(dtEnc.Copy());

            return dsResultado;
        }

        public DataSet AlmacenarGasto(PedidosEN ObjEN, string usuariop)
        {
            DataSet dsResultado = new DataSet();

            string query = "";

            DataTable dt;
            DataTable dtEnc;
            DataTable dtDet;
            MySqlTransaction sqlTransaction;
            MySqlDataAdapter sqlAdapter;
            conectar = new ConexionBD();

            string idPedido, idPoa, idAccion, idTipoPedido, idSolicitante, idJefe, justificacion, destino, idFand, idTipoAnexo, usuario;
            idPedido = ObjEN.ID_PEDIDO.ToString();
            idPoa = ObjEN.ID_POA.ToString();
            idAccion = ObjEN.ID_ACCION.ToString();
            idTipoPedido = ObjEN.ID_TIPO_PEDIDO.ToString();
            idSolicitante = ObjEN.ID_SOLICITANTE.ToString();
            idJefe = ObjEN.ID_JEFE_DIRECCION.ToString();
            justificacion = ObjEN.JUSTIFICACION;
            destino = ObjEN.DESTINO.ToString();
            idFand = ObjEN.ID_FAND.ToString();
            idTipoAnexo = ObjEN.ID_TIPO_ANEXO.ToString();
            usuario = ObjEN.USUARIO;


            if (destino.Equals("1"))
                idFand = "null";

            query = "CALL sp_iue_gasto(" + idPedido + ", " + idPoa + ", " + idAccion + ", " + idTipoPedido + ", " + idFand + ", " + idSolicitante + ", " + idJefe + ", '" + justificacion + "', 0, 0, '', '" + usuario + "', 1);";

            dt = armarDsResultado().Tables[0].Copy();
            dtEnc = armarDsResultado().Tables[0].Copy();

            conectar.AbrirConexion();
            sqlTransaction = conectar.conectar.BeginTransaction();
            try
            {
                dt = new DataTable();
                sqlAdapter = new MySqlDataAdapter(query, conectar.conectar);
                sqlAdapter.Fill(dt);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                int idPedidoEncabezado = int.Parse(dt.Rows[0]["MENSAJE"].ToString());
                dtEnc.Rows[0]["ERRORES"] = false;
                dtEnc.Rows[0]["MSG_ERROR"] = "";
                dtEnc.Rows[0]["VALOR"] = idPedidoEncabezado;

            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                conectar.CerrarConexion();

                dtEnc.Rows[0]["ERRORES"] = true;
                dtEnc.Rows[0]["MSG_ERROR"] = ex.Message;
                dtEnc.Rows[0]["VALOR"] = "";
            }

            dtDet = armarDsResultado().Tables[0].Copy();
            dtDet.TableName = "DETALLES";
            dtDet.Rows.RemoveAt(0);
            if (ObjEN.ID_PEDIDO_DETALLE >= 0 && dtEnc.Rows.Count > 0 && !bool.Parse(dtEnc.Rows[0]["ERRORES"].ToString()))
            {
                int idEncabezado = int.Parse(dtEnc.Rows[0]["VALOR"].ToString());

                try
                {
                    string idPedidoDetalle, idPac, cantidad, idUnidadMedida, descripcion, costoEstimado;
                    idPedidoDetalle = ObjEN.ID_PEDIDO_DETALLE.ToString();
                    idPac = ObjEN.ID_PAC.ToString();
                    cantidad = ObjEN.CANTIDAD_ESTIMADA.ToString();
                    idUnidadMedida = ObjEN.ID_UNIDAD_MEDIDA.ToString();
                    descripcion = ObjEN.DESCRIPCION;
                    costoEstimado = ObjEN.COSTO_ESTIMADO.ToString();

                    query = "CALL sp_iue_gasto_detalles(" + idPedidoDetalle + ", " + idEncabezado + ", NULL, " + cantidad + ", NULL, '" + descripcion + "', " + costoEstimado + ", '" + usuario + "', 1);";

                    dt = new DataTable();
                    sqlAdapter = new MySqlDataAdapter(query, conectar.conectar);
                    sqlAdapter.Fill(dt);

                    if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                        throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                    DataRow drDet = dtDet.NewRow();
                    drDet["ERRORES"] = dt.Rows[0]["RESULTADO"].ToString();
                    drDet["MSG_ERROR"] = "";
                    drDet["VALOR"] = dt.Rows[0]["MENSAJE"].ToString();
                    dtDet.Rows.Add(drDet);
                }
                catch (Exception ex)
                {
                    sqlTransaction.Rollback();
                    conectar.CerrarConexion();

                    dtEnc.Rows[0]["ERRORES"] = true;
                    dtEnc.Rows[0]["MSG_ERROR"] = ex.Message;
                }
            }

            if (dtEnc.Rows.Count > 0 && !bool.Parse(dtEnc.Rows[0]["ERRORES"].ToString()))
                sqlTransaction.Commit();

            conectar.CerrarConexion();

            dsResultado = new DataSet();
            dsResultado.Tables.Add(dtEnc.Copy());
            dsResultado.Tables.Add(dtDet);

            return dsResultado;
        }

        public DataSet AlmacenarEspecificacion(PedidosEN ObjEN, DataTable dtDetallesEsp)
        {
            string query = "";
            DataSet dsResultado;
            DataTable dt;
            DataTable dtEnc;
            DataTable dtDet;
            MySqlTransaction sqlTransaction;
            MySqlDataAdapter sqlAdapter;
            conectar = new ConexionBD();

            string idEspecificacion, idPedido, idTipoDocumento, usuario;
            idEspecificacion = ObjEN.ID_ESPECIFICACION.ToString();
            idPedido = ObjEN.ID_PEDIDO.ToString();
            idTipoDocumento = ObjEN.VID_TIPO_DOCUMENTO;
            usuario = ObjEN.USUARIO;

            query = "CALL sp_iue_especificaciones(" + idEspecificacion + ", " + idTipoDocumento + ", " + idPedido + ", 0, 0, '" + usuario + "', 1);";

            dt = armarDsResultado().Tables[0].Copy();
            dtEnc = armarDsResultado().Tables[0].Copy();

            conectar.AbrirConexion();
            sqlTransaction = conectar.conectar.BeginTransaction();
            try
            {
                dt = new DataTable();
                sqlAdapter = new MySqlDataAdapter(query, conectar.conectar);
                sqlAdapter.Fill(dt);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                int idPedidoEncabezado = int.Parse(dt.Rows[0]["MENSAJE"].ToString());
                dtEnc.Rows[0]["ERRORES"] = false;
                dtEnc.Rows[0]["MSG_ERROR"] = "";
                dtEnc.Rows[0]["VALOR"] = idPedidoEncabezado;

            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                conectar.CerrarConexion();

                dtEnc.Rows[0]["ERRORES"] = true;
                dtEnc.Rows[0]["MSG_ERROR"] = ex.Message;
                dtEnc.Rows[0]["VALOR"] = "";
            }

            dtDet = armarDsResultado().Tables[0].Copy();
            dtDet.TableName = "DETALLES";
            dtDet.Rows.RemoveAt(0);
            if (ObjEN.ID_PEDIDO_DETALLE >= 0 && dtEnc.Rows.Count > 0 && !bool.Parse(dtEnc.Rows[0]["ERRORES"].ToString()))
            {
                int idEncabezado = int.Parse(dtEnc.Rows[0]["VALOR"].ToString());

                try
                {
                    string idEspecificacionDetalle, idPedidoDetalle, descripcionEspecifica;
                    foreach (DataRow drDetallesEsp in dtDetallesEsp.Rows)
                    {
                        idEspecificacionDetalle = drDetallesEsp["ID_ESPECIFICACION_DETALLE"].ToString();
                        idPedidoDetalle = drDetallesEsp["ID_PEDIDO_DETALLE"].ToString();
                        descripcionEspecifica = drDetallesEsp["DESCRIPCION_ESPECIFICA"].ToString();

                        query = "CALL sp_iue_especificaciones_detalle(" + idEspecificacionDetalle + ", " + idEncabezado + ", " + idPedidoDetalle + ", '" + descripcionEspecifica + "', '" + usuario + "', 1);";

                        dt = new DataTable();
                        sqlAdapter = new MySqlDataAdapter(query, conectar.conectar);
                        sqlAdapter.Fill(dt);

                        if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                            throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                        DataRow drDet = dtDet.NewRow();
                        drDet["ERRORES"] = dt.Rows[0]["RESULTADO"].ToString();
                        drDet["MSG_ERROR"] = "";
                        drDet["VALOR"] = dt.Rows[0]["MENSAJE"].ToString();
                        dtDet.Rows.Add(drDet);
                    }
                }
                catch (Exception ex)
                {
                    sqlTransaction.Rollback();
                    conectar.CerrarConexion();

                    dtEnc.Rows[0]["ERRORES"] = true;
                    dtEnc.Rows[0]["MSG_ERROR"] = ex.Message;
                }
            }

            if (dtEnc.Rows.Count > 0 && !bool.Parse(dtEnc.Rows[0]["ERRORES"].ToString()))
                sqlTransaction.Commit();

            conectar.CerrarConexion();

            dsResultado = new DataSet();
            dsResultado.Tables.Add(dtEnc.Copy());
            dsResultado.Tables.Add(dtDet);

            return dsResultado;
        }

        public DataSet AlmacenarProveedor(ProveedoresEN ObjEN, string usuario)
        {
            DataSet dsResultado = new DataSet();
            if (!validarPermiso(usuario))
            {
                string query = "";

                DataTable dt;
                DataTable dtEnc;
                MySqlTransaction sqlTransaction;
                MySqlDataAdapter sqlAdapter;
                conectar = new ConexionBD();

                //PROCEDURE `sp_iue_proveedores`(vid_proveedor int(11), vrazon_social varchar(250), vnombre_proveedor varchar(250), vnit varchar(25), vdireccion varchar(200), vtelefono varchar(50), vactivo int(11), vusuario varchar(45), vOpcion int(11))
                query = "CALL sp_iue_proveedores(" + ObjEN.vid_proveedor + ", '" + ObjEN.vrazon_social + "', '" + ObjEN.vnombre_proveedor + "', '" + ObjEN.vnit + "', '" + ObjEN.vdireccion + "', '" + ObjEN.vtelefono + "', " + ObjEN.vactivo + ", '" + ObjEN.vusuario + "', 1)";
                query = query.Replace("''", "null");

                dt = armarDsResultado().Tables[0].Copy();
                dtEnc = armarDsResultado().Tables[0].Copy();

                conectar.AbrirConexion();
                sqlTransaction = conectar.conectar.BeginTransaction();
                try
                {
                    dt = new DataTable();
                    sqlAdapter = new MySqlDataAdapter(query, conectar.conectar);
                    sqlAdapter.Fill(dt);

                    if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                        throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                    int idPedidoEncabezado = int.Parse(dt.Rows[0]["MENSAJE"].ToString());
                    dtEnc.Rows[0]["ERRORES"] = false;
                    dtEnc.Rows[0]["MSG_ERROR"] = "";
                    dtEnc.Rows[0]["VALOR"] = idPedidoEncabezado;

                }
                catch (Exception ex)
                {
                    sqlTransaction.Rollback();
                    conectar.CerrarConexion();

                    dtEnc.Rows[0]["ERRORES"] = true;
                    dtEnc.Rows[0]["MSG_ERROR"] = ex.Message;
                    dtEnc.Rows[0]["VALOR"] = "";
                }

                if (dtEnc.Rows.Count > 0 && !bool.Parse(dtEnc.Rows[0]["ERRORES"].ToString()))
                    sqlTransaction.Commit();

                conectar.CerrarConexion();

                dsResultado = new DataSet();
                dsResultado.Tables.Add(dtEnc.Copy());

                return dsResultado;
            }
            return dsResultado;
        }

        public DataSet AlmacenarCriterio(int idCriterioPedido, int idCriterio, int idPedido, string nombre, decimal puntuacion, int criterioPrecio, string usuario, int opcion)
        {
            DataSet dsResultado = new DataSet();
            string query = "";

            DataTable dt;
            DataTable dtEnc;
            MySqlTransaction sqlTransaction;
            MySqlDataAdapter sqlAdapter;
            conectar = new ConexionBD();

            query = "CALL sp_iue_criterio_compra(" + idCriterio + ", " + idPedido + ",'" + nombre + "', " + puntuacion + ", " + criterioPrecio + ", " + idCriterioPedido + ", '" + usuario + "', " + opcion + ")";
            query = query.Replace("''", "null");

            dt = armarDsResultado().Tables[0].Copy();
            dtEnc = armarDsResultado().Tables[0].Copy();

            conectar.AbrirConexion();
            sqlTransaction = conectar.conectar.BeginTransaction();
            try
            {
                dt = new DataTable();
                sqlAdapter = new MySqlDataAdapter(query, conectar.conectar);
                sqlAdapter.Fill(dt);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                int idPedidoEncabezado = int.Parse(dt.Rows[0]["MENSAJE"].ToString());
                dtEnc.Rows[0]["ERRORES"] = false;
                dtEnc.Rows[0]["MSG_ERROR"] = "";
                dtEnc.Rows[0]["VALOR"] = idPedidoEncabezado;

            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                conectar.CerrarConexion();

                dtEnc.Rows[0]["ERRORES"] = true;
                dtEnc.Rows[0]["MSG_ERROR"] = ex.Message;
                dtEnc.Rows[0]["VALOR"] = "";
            }

            if (dtEnc.Rows.Count > 0 && !bool.Parse(dtEnc.Rows[0]["ERRORES"].ToString()))
                sqlTransaction.Commit();

            conectar.CerrarConexion();

            dsResultado = new DataSet();
            dsResultado.Tables.Add(dtEnc.Copy());

            return dsResultado;
        }

        public DataSet AlmacenarAjustePedido(AJUSTE_PEDIDO ObjEN, DataSet dsDetalles, string usuario)
        {
            DataSet dsResultado = new DataSet();
            string query = "";

            DataTable dt;
            DataTable dtEnc;
            DataTable dtDet;
            MySqlTransaction sqlTransaction;
            MySqlDataAdapter sqlAdapter;
            conectar = new ConexionBD();


            ObjEN.VID_AJUSTE_PEDIDO = ConstruirCampoInsertMySQL(ObjEN.VID_AJUSTE_PEDIDO, 1, ',');
            ObjEN.VID_POA = ConstruirCampoInsertMySQL(ObjEN.VID_POA, 1, ',');
            ObjEN.VID_UNIDAD = ConstruirCampoInsertMySQL(ObjEN.VID_UNIDAD, 1, ',');
            ObjEN.VANIO = ConstruirCampoInsertMySQL(ObjEN.VANIO, 1, ',');
            ObjEN.VID_TIPO_DOCUMENTO = ConstruirCampoInsertMySQL(ObjEN.VID_TIPO_DOCUMENTO, 1, ',');
            ObjEN.VID_PEDIDO = ConstruirCampoInsertMySQL(ObjEN.VID_PEDIDO, 1, ',');
            ObjEN.VNO_SOLICITUD = ConstruirCampoInsertMySQL(ObjEN.VNO_SOLICITUD, 1, ',');
            ObjEN.VANIO_SOLICITUD = ConstruirCampoInsertMySQL(ObjEN.VANIO_SOLICITUD, 1, ',');
            ObjEN.VFECHA_AJUSTE = ConstruirCampoInsertMySQL(ObjEN.VFECHA_AJUSTE, 2, ',');
            ObjEN.VJUSTIFICACION = ConstruirCampoInsertMySQL(ObjEN.VJUSTIFICACION, 2, ',');
            ObjEN.VOBSERVACIONES = ConstruirCampoInsertMySQL(ObjEN.VOBSERVACIONES, 2, ',');
            ObjEN.VID_ESTADO_AJUSTE = ConstruirCampoInsertMySQL(ObjEN.VID_ESTADO_AJUSTE, 1, ',');
            ObjEN.VANULADO = ConstruirCampoInsertMySQL(ObjEN.VANULADO, 1, ',');
            ObjEN.VID_SOLICITANTE = ConstruirCampoInsertMySQL(ObjEN.VID_SOLICITANTE, 1, ',');
            ObjEN.VID_SUBGERENTE_DIRECTOR = ConstruirCampoInsertMySQL(ObjEN.VID_SUBGERENTE_DIRECTOR, 1, ',');
            ObjEN.VID_ANALISTA_PPTO = ConstruirCampoInsertMySQL(ObjEN.VID_ANALISTA_PPTO, 1, ',');
            ObjEN.VUSUARIO = ConstruirCampoInsertMySQL(ObjEN.VUSUARIO, 2, ',');
            ObjEN.VOPCION = ObjEN.VOPCION + ");";

            StringBuilder stringB = new StringBuilder();
            stringB.Append("CALL sp_iue_ajuste_pedido(");
            stringB.Append(ObjEN.VID_AJUSTE_PEDIDO);
            stringB.Append(ObjEN.VID_POA);
            stringB.Append(ObjEN.VID_UNIDAD);
            stringB.Append(ObjEN.VANIO);
            stringB.Append(ObjEN.VID_TIPO_DOCUMENTO);
            stringB.Append(ObjEN.VID_PEDIDO);
            stringB.Append(ObjEN.VNO_SOLICITUD);
            stringB.Append(ObjEN.VANIO_SOLICITUD);
            stringB.Append(ObjEN.VFECHA_AJUSTE);
            stringB.Append(ObjEN.VJUSTIFICACION);
            stringB.Append(ObjEN.VOBSERVACIONES);
            stringB.Append(ObjEN.VID_ESTADO_AJUSTE);
            stringB.Append(ObjEN.VANULADO);
            stringB.Append(ObjEN.VID_SOLICITANTE);
            stringB.Append(ObjEN.VID_SUBGERENTE_DIRECTOR);
            stringB.Append(ObjEN.VID_ANALISTA_PPTO);
            stringB.Append(ObjEN.VUSUARIO);
            stringB.Append(ObjEN.VOPCION);


            query = stringB.ToString();

            dt = armarDsResultado().Tables[0].Copy();
            dtEnc = armarDsResultado().Tables[0].Copy();

            conectar.AbrirConexion();
            sqlTransaction = conectar.conectar.BeginTransaction();
            try
            {
                dt = new DataTable();
                sqlAdapter = new MySqlDataAdapter(query, conectar.conectar);
                sqlAdapter.Fill(dt);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                int idPedidoEncabezado = int.Parse(dt.Rows[0]["MENSAJE"].ToString());
                dtEnc.Rows[0]["ERRORES"] = false;
                dtEnc.Rows[0]["MSG_ERROR"] = "";
                dtEnc.Rows[0]["VALOR"] = idPedidoEncabezado;

            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                conectar.CerrarConexion();

                dtEnc.Rows[0]["ERRORES"] = true;
                dtEnc.Rows[0]["MSG_ERROR"] = ex.Message;
                dtEnc.Rows[0]["VALOR"] = "";
            }

            dtDet = armarDsResultado().Tables[0].Copy();
            dtDet.TableName = "DETALLES";
            dtDet.Rows.RemoveAt(0);

            if (dtEnc.Rows.Count > 0 && !bool.Parse(dtEnc.Rows[0]["ERRORES"].ToString()))
            {
                int idEncabezado = int.Parse(dtEnc.Rows[0]["VALOR"].ToString());

                try
                {

                    foreach (DataRow drDetalles in dsDetalles.Tables[0].Rows)
                    {
                        AJUSTE_PEDIDO_DET ObjEN_DET = new AJUSTE_PEDIDO_DET();

                        ObjEN_DET.VID_AJUSTE_PEDIDO_DET = ConstruirCampoInsertMySQL(drDetalles["VID_AJUSTE_PEDIDO_DET"].ToString(), 1, ',');
                        ObjEN_DET.VID_AJUSTE_PEDIDO = ConstruirCampoInsertMySQL(idEncabezado.ToString(), 1, ',');
                        ObjEN_DET.VID_PEDIDO_DETALLE = ConstruirCampoInsertMySQL(drDetalles["VID_PEDIDO_DETALLE"].ToString(), 1, ',');
                        ObjEN_DET.VMONTO_AJUSTE = ConstruirCampoInsertMySQL(drDetalles["VMONTO_AJUSTE"].ToString(), 2, ',');
                        ObjEN_DET.VOBSERVACIONES = ConstruirCampoInsertMySQL(drDetalles["VOBSERVACIONES"].ToString(), 2, ',');
                        ObjEN_DET.VID_DETALLE_ACCION = ConstruirCampoInsertMySQL(drDetalles["VID_DETALLE_ACCION"].ToString(), 1, ',');
                        ObjEN_DET.VUSUARIO = ConstruirCampoInsertMySQL(drDetalles["VUSUARIO"].ToString(), 2, ',');
                        ObjEN_DET.VOPCION = drDetalles["VOPCION"].ToString() + ");";
                        //ObjEN_DET.VOPCION = "null";

                        stringB = new StringBuilder();
                        stringB.Append("CALL sp_iue_ajuste_pedido_det(");
                        stringB.Append(ObjEN_DET.VID_AJUSTE_PEDIDO_DET);
                        stringB.Append(ObjEN_DET.VID_AJUSTE_PEDIDO);
                        stringB.Append(ObjEN_DET.VID_PEDIDO_DETALLE);
                        stringB.Append(ObjEN_DET.VMONTO_AJUSTE);
                        stringB.Append(ObjEN_DET.VOBSERVACIONES);
                        stringB.Append(ObjEN_DET.VID_DETALLE_ACCION);
                        stringB.Append(ObjEN_DET.VUSUARIO);
                        stringB.Append(ObjEN_DET.VOPCION);
                        query = stringB.ToString();

                        dt = new DataTable();
                        sqlAdapter = new MySqlDataAdapter(query, conectar.conectar);
                        sqlAdapter.Fill(dt);


                        DataRow drDet = dtDet.NewRow();
                        drDet["ERRORES"] = dt.Rows[0]["RESULTADO"].ToString();
                        drDet["MSG_ERROR"] = "";
                        drDet["VALOR"] = dt.Rows[0]["MENSAJE"].ToString();
                        dtDet.Rows.Add(drDet);
                    }
                }
                catch (Exception ex)
                {
                    sqlTransaction.Rollback();
                    conectar.CerrarConexion();

                    dtEnc.Rows[0]["ERRORES"] = true;
                    dtEnc.Rows[0]["MSG_ERROR"] = ex.Message;
                }
            }

            if (dtEnc.Rows.Count > 0 && !bool.Parse(dtEnc.Rows[0]["ERRORES"].ToString()))
                sqlTransaction.Commit();

            conectar.CerrarConexion();

            dsResultado = new DataSet();
            dsResultado.Tables.Add(dtEnc.Copy());
            dsResultado.Tables.Add(dtDet);

            return dsResultado;
        }

        public String ConstruirCampoInsertMySQL(string valor, int tipoDato, char separador)
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            string campoMySQL = "";

            //Numérico
            if (tipoDato == 1)
            {
                stringBuilder.Append("");
                stringBuilder.Append(valor);
                stringBuilder.Append("");

                if (separador != null)
                    stringBuilder.Append(separador + " ");

                campoMySQL = stringBuilder.ToString();
            }
            else if (tipoDato == 2)
            {
                stringBuilder.Append("'");
                stringBuilder.Append(valor);
                stringBuilder.Append("'");

                if (separador != null)
                    stringBuilder.Append(separador + " ");

                campoMySQL = stringBuilder.ToString();
                campoMySQL = campoMySQL.Replace("'', ", "null, ");
            }


            return campoMySQL;
        }

        //ENVIAR EL PEDIDO A EXISTENCIAS EN BODEGA(BIENES) O APROBACIÓN DE SUB/DIR(SERVICIO)
        public DataTable EnviarPedidoARevision(int idPedido, int idTipoSalida, string usuario, string ip, string mac, string pc)
        {

            conectar = new ConexionBD();
            DataTable dt = new DataTable();
            string query = "CALL sp_iue_pedido(" + idPedido + ", 0, 0, 0, 0, 0, '',0 , 0, 0, 0, '', 0, 0, 0, 0, 0, 0, " + idTipoSalida + ", '" + usuario + "', 3,'"
                 + ip + "','" + mac + "','" + pc + "',0);";
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }

        //ENVIAR EL AJUSTE DEL PEDIDO PEDIDO A APROBACIÓN DE SUB/DIR
        public DataTable EnviarAjustePedidoARevision(int idAjuste, int idTipoSalida, string usuario, string ip, string mac, string pc)
        {

            conectar = new ConexionBD();
            DataTable dt = new DataTable();
            string query = "CALL sp_iue_ajuste_pedido(" + idAjuste + ", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, '" + usuario + "',  2);";
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }

        //Vo.Bo. Nivel 1
        public DataTable AprobacionBodega(int idPedido, int idTipoDocumento, string observaciones, string usuario, string ip, string mac, string pc)
        {

            conectar = new ConexionBD();
            DataTable dt = new DataTable();
            string query = "CALL sp_iue_pedido(" + idPedido + ", 0, 0, 0, 0, 0, '',0 , 0, 0, 0, '', 0, 0, 0, 0, 0, 0, " + idTipoDocumento + ", '" + usuario + "', 4 ,'"
                 + ip + "','" + mac + "','" + pc + "',0);";
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }

        public DataTable RechazoBodega(int idPedido, int idTipoDocumento, string observaciones, string usuario, string ip, string mac, string pc)
        {

            conectar = new ConexionBD();
            DataTable dt = new DataTable();
            string query = "CALL sp_iue_pedido(" + idPedido + ", 0, 0, 0, 0, 0, '',0 , 0, 0, 0, '" + observaciones + "', 0, 0, 0, 0, 0, 0, " + idTipoDocumento + ", '" + usuario + "', 5 ,'"
                 + ip + "','" + mac + "','" + pc + "',0);";
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }

        //Vo.Bo. Nivel 2
        public DataTable AprobacionEncargado(int idPedido, int idTipoSalida, string observaciones, string usuario, string ip, string mac, string pc)
        {

            conectar = new ConexionBD();
            DataTable dt = new DataTable();
            string query = "CALL sp_iue_pedido(" + idPedido + ", 0, 0, 0, 0, 0, '',0 , 0, 0, 0, '" + observaciones + "', 0, 0, 0, 0, 0, 0, " + idTipoSalida + ", '" + usuario + "', 6 ,'"
                 + ip + "','" + mac + "','" + pc + "',0);";
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }

        //ENVIAR EL AJUSTE DEL PEDIDO PEDIDO A APROBACIÓN DE PRESUPUESTO
        public DataTable AprobacionEncargadoAjuste(int idAjuste, int idTipoSalida, string observaciones, string usuario, string ip, string mac, string pc)
        {

            conectar = new ConexionBD();
            DataTable dt = new DataTable();
            string query = "CALL sp_iue_ajuste_pedido(" + idAjuste + ", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, '" + usuario + "',  3);";
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }

        public DataTable RechazoEncargado(int idPedido, int idTipoSalida, string observaciones, string usuario, string ip, string mac, string pc)
        {
            DataTable dt = new DataTable();

            conectar = new ConexionBD();

            string query = "CALL sp_iue_pedido(" + idPedido + ", 0, 0, 0, 0, 0, '',0 , 0, 0, 0, '" + observaciones + "', 0, 0, 0, 0, 0, 0, " + idTipoSalida + ", '" + usuario + "', 7,'"
                 + ip + "','" + mac + "','" + pc + "',0);";
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }


        public DataTable RechazoEncargadoAjuste(int idAjuste, int idTipoSalida, string observaciones, string usuario)
        {

            conectar = new ConexionBD();
            DataTable dt = new DataTable();
            string query = "CALL sp_iue_ajuste_pedido(" + idAjuste + ", 0, 0, 0, 0, 0, 0, 0, 0, 0, '" + observaciones + "', 0, 0, 0, 0, 0, '" + usuario + "', 4);";
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }

        //Vo.Bo. Nivel 3
        public DataTable AprobacionPresupuesto(int idPedido, int idTipoSalida, string observaciones, string usuario, string ip, string mac, string pc)
        {

            conectar = new ConexionBD();
            DataTable dt = new DataTable();
            string query = "CALL sp_iue_pedido(" + idPedido + ", 0, 0, 0, 0, 0, '',0 , 0, 0, 0, '" + observaciones + "', 0, 0, 0, 0, 0, 0, " + idTipoSalida + ", '" + usuario + "', 8 ,'"
                 + ip + "','" + mac + "','" + pc + "',0);";
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }

        public DataTable RecodificacionPpto(int idPedido, int idTipoSalida, string observaciones, string usuario, string ip, string mac, string pc)
        {

            conectar = new ConexionBD();
            DataTable dt = new DataTable();
            string query = "CALL sp_iue_pedido(" + idPedido + ", 0, 0, 0, 0, 0, '',0 , 0, 0, 0, '" + observaciones + "', 0, 0, 0, 0, 0, 0, " + idTipoSalida + ", '" + usuario + "', 17 ,'"
                 + ip + "','" + mac + "','" + pc + "',0);";
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }

        public DataTable AprobacionPresupuestoAjuste(int idAjuste, int idTipoSalida, string observaciones, string usuario)
        {

            conectar = new ConexionBD();
            DataTable dt = new DataTable();
            string query = "CALL sp_iue_ajuste_pedido(" + idAjuste + ", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, '" + usuario + "', 5);";
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }

        public DataTable RechazoPresupuesto(int idPedido, int idTipoSalida, string observaciones, string usuario, string ip, string mac, string pc)
        {

            DataTable dt = new DataTable();
            if (!validarPermiso(usuario))
            {
                conectar = new ConexionBD();

                string query = "CALL sp_iue_pedido(" + idPedido + ", 0, 0, 0, 0, 0, '',0 , 0, 0, 0, '" + observaciones + "', 0, 0, 0, 0, 0, 0, " + idTipoSalida + ", '" + usuario + "', 9,'"
                + ip + "','" + mac + "','" + pc + "',0);";
                conectar.AbrirConexion();
                MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
                consulta.Fill(dt);
                conectar.CerrarConexion();
                return dt;
            }

            return dt;
        }

        public DataTable RechazoPresupuestoAjuste(int idAjuste, int idTipoSalida, string observaciones, string usuario)
        {

            conectar = new ConexionBD();
            DataTable dt = new DataTable();
            string query = "CALL sp_iue_ajuste_pedido(" + idAjuste + ", 0, 0, 0, 0, 0, 0, 0, 0, 0, '" + observaciones + "', 0, 0, 0, 0, 0, '" + usuario + "', 6);";
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }

        //Vo.Bo. Nivel 4
        public DataTable AprobacionMesaEntrada(int idPedido, int idTipoSalida, string observaciones, string usuario, string ip, string mac, string pc)
        {

            conectar = new ConexionBD();
            DataTable dt = new DataTable();
            string query = "CALL sp_iue_pedido(" + idPedido + ", 0, 0, 0, 0, 0, '',0 , 0, 0, 0, '', 0, 0, 0, 0, 0, 0, " + idTipoSalida + ", '" + usuario + "', 10 ,'"
                 + ip + "','" + mac + "','" + pc + "',0);";
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }

        public DataTable RechazoMesaEntrada(int idPedido, int idTipoSalida, string observaciones, string usuario, string ip, string mac, string pc)
        {

            conectar = new ConexionBD();
            DataTable dt = new DataTable();
            string query = "CALL sp_iue_pedido(" + idPedido + ", 0, 0, 0, 0, 0, '',0 , 0, 0, 0, '" + observaciones + "', 0, 0, 0, 0, 0, 0, " + idTipoSalida + ", '" + usuario + "', 11 ,'"
                 + ip + "','" + mac + "','" + pc + "',0);";
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }

        public DataTable AsignacionTecnicoCompras(int idPedido, int idTipoSalida, int idTecnico, string observaciones, string usuario, string ip, string mac, string pc)
        {

            conectar = new ConexionBD();
            DataTable dt = new DataTable();
            string query = "CALL sp_iue_pedido(" + idPedido + ", 0, 0, 0, 0, 0, '',0 , 0, 0, 0, '', 0, 0, 0, 0, " + idTecnico + ", 0, " + idTipoSalida + ", '" + usuario + "', 12,'"
                 + ip + "','" + mac + "','" + pc + "',0);";
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }

        public DataSet AsignarValorReal(DataSet dsDetalles, string ip, string mac, string pc)
        {
            string query = "";
            DataSet dsResultado = new DataSet();
            DataTable dt;
            DataTable dtEnc;
            DataTable dtDet;
            MySqlTransaction sqlTransaction;
            MySqlDataAdapter sqlAdapter;
            conectar = new ConexionBD();

            string idPedido = dsDetalles.Tables[0].Rows[0]["ID_PEDIDO"].ToString();
            string idTipoSalida = dsDetalles.Tables[0].Rows[0]["VID_TIPO_DOCUMENTO"].ToString();

            query = "CALL sp_iue_pedido(" + idPedido + ", 0, 0, 0, 0, 0, '',0 , 0, 0, 0, '', 0, 0, 0, 0, 0, 0, " + idTipoSalida + ", '', -1,'"
                 + ip + "','" + mac + "','" + pc + "',0);";

            dt = armarDsResultado().Tables[0].Copy();
            dtEnc = armarDsResultado().Tables[0].Copy();

            conectar.AbrirConexion();
            sqlTransaction = conectar.conectar.BeginTransaction();
            try
            {
                dt = new DataTable();
                sqlAdapter = new MySqlDataAdapter(query, conectar.conectar);
                sqlAdapter.Fill(dt);

                //if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                if (false)
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                //int idPedidoEncabezado = int.Parse(dt.Rows[0]["MENSAJE"].ToString());
                int idPedidoEncabezado = int.Parse(idPedido);
                dtEnc.Rows[0]["ERRORES"] = false;
                dtEnc.Rows[0]["MSG_ERROR"] = "";
                dtEnc.Rows[0]["VALOR"] = idPedidoEncabezado;

            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                conectar.CerrarConexion();

                dtEnc.Rows[0]["ERRORES"] = true;
                dtEnc.Rows[0]["MSG_ERROR"] = ex.Message;
                dtEnc.Rows[0]["VALOR"] = "";
            }

            dtDet = armarDsResultado().Tables[0].Copy();
            dtDet.TableName = "DETALLES";
            dtDet.Rows.RemoveAt(0);

            if (!bool.Parse(dtEnc.Rows[0]["ERRORES"].ToString()))
            {
                int idEncabezado = int.Parse(dsDetalles.Tables[0].Rows[0]["ID_PEDIDO"].ToString());

                string vid_pedido, vid_tipo_documento, vid_pedido_detalle, vid_proveedor, vid_tipo_documento_compra, vno_orden_compra, vcantidad_compra, vcosto_unitario_compra, vcosto_real, vfecha_orden_compra, viva, vliquidaciones_parciales, vusuario = "";

                try
                {
                    foreach (DataRow dr in dsDetalles.Tables["DETALLES"].Rows)
                    {

                        vid_pedido = dr["ID_PEDIDO"].ToString();
                        vid_tipo_documento = dr["VID_TIPO_DOCUMENTO"].ToString();
                        vid_pedido_detalle = dr["VID_PEDIDO_DETALLE"].ToString();
                        vid_proveedor = dr["VID_PROVEEDOR"].ToString();
                        vid_tipo_documento_compra = dr["VID_TIPO_DOCUMENTO_COMPRA"].ToString();
                        vno_orden_compra = dr["VNO_ORDEN_COMPRA"].ToString();
                        vcantidad_compra = dr["VCANTIDAD_COMPRA"].ToString();
                        vcosto_unitario_compra = dr["VCOSTO_U_COMPRAS"].ToString();
                        vcosto_real = dr["VCOSTO_REAL"].ToString();
                        viva = dr["VIVA"].ToString();
                        vfecha_orden_compra = dr["VFECHA_ORDEN_COMPRA"].ToString();
                        vliquidaciones_parciales = dr["VLIQUIDACIONES_PARCIALES"].ToString();
                        vusuario = dr["USUARIO"].ToString();

                        if (vid_tipo_documento != "1")
                        {
                            vno_orden_compra = "null";
                            vfecha_orden_compra = "null";
                        }
                        query = "CALL sp_iue_pedido_detalles(" + vid_pedido_detalle + ", " + vid_pedido + ", 0, " + vcantidad_compra + ", 0, '', 0, " + vid_tipo_documento + ", " + vid_proveedor + ", " + vno_orden_compra + ", " + vcosto_real + ", '" + vfecha_orden_compra + "', " + viva + ", " + vliquidaciones_parciales + ", " + vcosto_unitario_compra + ", " + vid_tipo_documento_compra + ", '" + vusuario + "', 0,0,6);";
                        query = query.Replace("'null'", "null");

                        dt = new DataTable();
                        sqlAdapter = new MySqlDataAdapter(query, conectar.conectar);
                        sqlAdapter.Fill(dt);

                        if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                            throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                        DataRow drDet = dtDet.NewRow();
                        drDet["ERRORES"] = dt.Rows[0]["RESULTADO"].ToString();
                        drDet["MSG_ERROR"] = "";
                        drDet["VALOR"] = dt.Rows[0]["MENSAJE"].ToString();
                        dtDet.Rows.Add(drDet);
                    }
                }
                catch (Exception ex)
                {
                    sqlTransaction.Rollback();
                    conectar.CerrarConexion();

                    dtEnc.Rows[0]["ERRORES"] = true;
                    dtEnc.Rows[0]["MSG_ERROR"] = ex.Message;
                }
            }

            if (dtEnc.Rows.Count > 0 && !bool.Parse(dtEnc.Rows[0]["ERRORES"].ToString()))
                sqlTransaction.Commit();

            conectar.CerrarConexion();

            dsResultado = new DataSet();
            dsResultado.Tables.Add(dtEnc.Copy());
            dsResultado.Tables.Add(dtDet);

            return dsResultado;
        }


        public DataSet AprobacionTecnico(DataSet dsDetalles, string ip, string mac, string pc)
        {
            string query = "";
            DataSet dsResultado = new DataSet();
            DataTable dt;
            DataTable dtEnc;
            DataTable dtDet;
            MySqlTransaction sqlTransaction;
            MySqlDataAdapter sqlAdapter;
            conectar = new ConexionBD();

            string idPedido = dsDetalles.Tables[0].Rows[0]["ID_PEDIDO"].ToString();
            string idTipoSalida = dsDetalles.Tables[0].Rows[0]["VID_TIPO_DOCUMENTO"].ToString();

            query = "CALL sp_iue_pedido(" + idPedido + ", 0, 0, 0, 0, 0, '',0 , 0, 0, 0, '', 0, 0, 0, 0, 0, 0, " + idTipoSalida + ", '', 13,'"
                + ip + "','" + mac + "','" + pc + "',0);";

            dt = armarDsResultado().Tables[0].Copy();
            dtEnc = armarDsResultado().Tables[0].Copy();

            conectar.AbrirConexion();
            sqlTransaction = conectar.conectar.BeginTransaction();
            try
            {
                dt = new DataTable();
                sqlAdapter = new MySqlDataAdapter(query, conectar.conectar);
                sqlAdapter.Fill(dt);

                if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                    throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                int idPedidoEncabezado = int.Parse(dt.Rows[0]["MENSAJE"].ToString());
                dtEnc.Rows[0]["ERRORES"] = false;
                dtEnc.Rows[0]["MSG_ERROR"] = "";
                dtEnc.Rows[0]["VALOR"] = idPedidoEncabezado;

            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                conectar.CerrarConexion();

                dtEnc.Rows[0]["ERRORES"] = true;
                dtEnc.Rows[0]["MSG_ERROR"] = ex.Message;
                dtEnc.Rows[0]["VALOR"] = "";
            }

            dtDet = armarDsResultado().Tables[0].Copy();
            dtDet.TableName = "DETALLES";
            dtDet.Rows.RemoveAt(0);

            if (!bool.Parse(dtEnc.Rows[0]["ERRORES"].ToString()))
            {
                int idEncabezado = int.Parse(dsDetalles.Tables[0].Rows[0]["ID_PEDIDO"].ToString());

                string vid_pedido, vid_tipo_documento, vid_pedido_detalle, vid_proveedor, vid_tipo_documento_compra, vno_orden_compra, vcantidad_compra, vcosto_unitario_compra, vcosto_real, vfecha_orden_compra, viva, vliquidaciones_parciales, vusuario = "";

                try
                {
                    foreach (DataRow dr in dsDetalles.Tables["DETALLES"].Rows)
                    {

                        vid_pedido = dr["ID_PEDIDO"].ToString();
                        vid_tipo_documento = dr["VID_TIPO_DOCUMENTO"].ToString();
                        vid_pedido_detalle = dr["VID_PEDIDO_DETALLE"].ToString();
                        vid_proveedor = dr["VID_PROVEEDOR"].ToString();
                        vid_tipo_documento_compra = dr["VID_TIPO_DOCUMENTO_COMPRA"].ToString();
                        vno_orden_compra = dr["VNO_ORDEN_COMPRA"].ToString();
                        vcantidad_compra = dr["VCANTIDAD_COMPRA"].ToString();
                        vcosto_unitario_compra = dr["VCOSTO_U_COMPRAS"].ToString();
                        vcosto_real = dr["VCOSTO_REAL"].ToString();
                        viva = dr["VIVA"].ToString();
                        vfecha_orden_compra = dr["VFECHA_ORDEN_COMPRA"].ToString();
                        vliquidaciones_parciales = dr["VLIQUIDACIONES_PARCIALES"].ToString();
                        vusuario = dr["USUARIO"].ToString();

                        if (vid_tipo_documento != "1")
                        {
                            vno_orden_compra = "null";
                            vfecha_orden_compra = "null";
                        }
                        query = "CALL sp_iue_pedido_detalles(" + vid_pedido_detalle + ", " + vid_pedido + ", 0, " + vcantidad_compra + ", 0, '', 0, " + vid_tipo_documento + ", " + vid_proveedor + ", " + vno_orden_compra + ", " + vcosto_real + ", '" + vfecha_orden_compra + "', " + viva + ", " + vliquidaciones_parciales + ", " + vcosto_unitario_compra + ", " + vid_tipo_documento_compra + ", '" + vusuario + "',0,0 ,3);";
                        query = query.Replace("'null'", "null");

                        dt = new DataTable();
                        sqlAdapter = new MySqlDataAdapter(query, conectar.conectar);
                        sqlAdapter.Fill(dt);

                        if (!bool.Parse(dt.Rows[0]["RESULTADO"].ToString()))
                            throw new Exception(dt.Rows[0]["MENSAJE"].ToString());

                        DataRow drDet = dtDet.NewRow();
                        drDet["ERRORES"] = dt.Rows[0]["RESULTADO"].ToString();
                        drDet["MSG_ERROR"] = "";
                        drDet["VALOR"] = dt.Rows[0]["MENSAJE"].ToString();
                        dtDet.Rows.Add(drDet);
                    }
                }
                catch (Exception ex)
                {
                    sqlTransaction.Rollback();
                    conectar.CerrarConexion();

                    dtEnc.Rows[0]["ERRORES"] = true;
                    dtEnc.Rows[0]["MSG_ERROR"] = ex.Message;
                }
            }

            if (dtEnc.Rows.Count > 0 && !bool.Parse(dtEnc.Rows[0]["ERRORES"].ToString()))
                sqlTransaction.Commit();

            conectar.CerrarConexion();

            dsResultado = new DataSet();
            dsResultado.Tables.Add(dtEnc.Copy());
            dsResultado.Tables.Add(dtDet);

            return dsResultado;
        }

        public DataTable RevertirValorReal(int idPedido, int idTipoSalida, string criterio, int opcion)
        {

            conectar = new ConexionBD();
            DataTable dt = new DataTable();
            string query = "CALL sp_iue_pedido_detalles(0, " + idPedido + ", 0, 0, 0, '', 0, " + idTipoSalida + ", 0, 0, 0, null, 0, 0, 0, 0, '',0,0, 7);";
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }

        public DataTable AprobarEspecificacion(int idEspecificacion, int idTipoSalida, string criterio, int opcion)
        {

            conectar = new ConexionBD();
            DataTable dt = new DataTable();
            string query = string.Format("CALL sp_iue_anexos({0}, {1}, '{2}', {3});", idEspecificacion, idTipoSalida, criterio, opcion);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }

        public DataTable RechazarEspecificacion(int idPedido, int idTipoSalida, string criterio, int opcion)
        {

            conectar = new ConexionBD();
            DataTable dt = new DataTable();
            string query = string.Format("CALL sp_iue_anexos({0}, {1}, '{2}', {3});", idPedido, idTipoSalida, criterio, 2);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }

        public DataTable AnulacionTecnico(int idPedido, int idTipoSalida, string observaciones, string usuario, string ip, string mac, string pc)
        {

            conectar = new ConexionBD();
            DataTable dt = new DataTable();
            string query = "CALL sp_iue_pedido(" + idPedido + ", 0, 0, 0, 0, 0, '',0 , 0, 0, 0, '" + observaciones + "', 0, 0, 0, 0, 0, 0, " + idTipoSalida + ", '" + usuario + "', 14,'"
                + ip + "','" + mac + "','" + pc + "',0);";
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }

        public DataTable RechazoTecnico(int idPedido, int idTipoSalida, string observaciones, string usuario, string ip, string mac, string pc)
        {

            conectar = new ConexionBD();
            DataTable dt = new DataTable();

            string query = "CALL sp_iue_pedido(" + idPedido + ", 0, 0, 0, 0, 0, '',0 , 0, 0, 0, '" + observaciones + "', 0, 0, 0, 0, 0, 0, " + idTipoSalida + ", '" + usuario + "', 15,'"
                 + ip + "','" + mac + "','" + pc + "',0);";
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }

        public DataTable Reactivacion(int idPedido, int idTipoSalida, string observaciones, string usuario, string ip, string mac, string pc)
        {

            conectar = new ConexionBD();
            DataTable dt = new DataTable();
            string query = "CALL sp_iue_pedido(" + idPedido + ", 0, 0, 0, 0, 0, '',0 , 0, 0, 0, '" + observaciones + "', 0, 0, 0, 0, 0, 0, " + idTipoSalida + ", '" + usuario + "', 15,'"
               + ip + "','" + mac + "','" + pc + "',0);";
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dt);
            conectar.CerrarConexion();
            return dt;
        }

        public DataTable EliminarEncabezado(int id)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = "CALL sp_iue_pedido(" + id + ", 0, 0, 0, 0, 0, '',0 , 0, 0, 0, '', 0, 0, 0, 0, 0, 0, 0, '', 2,null,null,null,0);";
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable EliminarProveedor(int id)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();

            ProveedoresEN ObjEN = new ProveedoresEN();

            //PROCEDURE `sp_iue_proveedores`(vid_proveedor int(11), vnombre_proveedor varchar(250), vnit varchar(25), vdireccion varchar(200), vtelefono varchar(50), vactivo int(11), vusuario varchar(45), vOpcion int(11))
            string query = "CALL sp_iue_proveedores(" + id + ", '" + ObjEN.vnombre_proveedor + "', '" + ObjEN.vnit + "', '" + ObjEN.vdireccion + "', '" + ObjEN.vtelefono + "', " + ObjEN.vactivo + ", '" + ObjEN.vusuario + "', 2)";
            query = query.Replace("''", "null");

            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable EliminarDetalle(int id)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = "CALL sp_iue_pedido_detalles(" + id + ", 0, 0, 0, 0, '', 0, 0, 0, 0, 0, '', 0, 0, 0, 0, '', 2);";
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable EliminarDetalleVale(int id)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = "CALL sp_iue_pedido_detalles(" + id + ", 0, 0, 0, 0, '', 0, 0, 0, 0, 0, '', 0, 0, 0, 0, '', 4);";
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable EliminarDetalleGasto(int id)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = "CALL sp_iue_pedido_detalles(" + id + ", 0, 0, 0, 0, '', 0, 0, 0, 0, 0, '', 0, 0, 0, 0, '', 5);";
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable CodificarSalida(int idDetalleSalida, int idTipoSalida, int idDetalleAccion, string programa, string subprograma, string proyecto, string actividad, string obra, int opcion)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("CALL sp_codificarSalida({0}, {1}, {2}, '{3}', '{4}', '{5}', '{6}', '{7}', {8});", idDetalleSalida, idTipoSalida, idDetalleAccion, programa, subprograma, proyecto, actividad, obra, opcion);
            query.Replace("''", "null");

            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable InformacionPedido(int id, int id2, int id3, string criterio, int opcion)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("CALL sp_slctPedidos({0}, {1}, {2}, '{3}', {4});", id, id2, id3, criterio, opcion);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

      

        public DataTable InformacionPedidoDep(int id, int id2, int id3, string criterio, int opcion)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("CALL sp_slctPedidos({0}, {1}, {2}, '{3}', {4});", id, id2, id3, criterio, opcion);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable InformacionVale(int id, int id2, int opcion)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("CALL sp_slctVales({0}, {1}, '', {2});", id, id2, opcion);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable InformacionPermisos(int id, int id2, string criterio, int opcion)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("CALL sp_slctPermisos({0}, {1}, '{2}', {3});", id, id2, criterio, opcion);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable InformacionGasto(int id, int id2, int opcion)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("CALL sp_slctGastos({0}, {1}, '', {2});", id, id2, opcion);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable InformacionProveedores(int id, int id2, int opcion)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("CALL sp_slctProveedores({0}, {1}, '', {2});", id, id2, opcion);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable InformacionCriteriosCompra(int id, int id2, string criterio, int opcion)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("CALL sp_slctCriteriosCompra({0}, {1}, '{2}', {3});", id, id2, criterio, opcion);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable InformacionTiposDocumentoCompra(int id, int id2, string criterio, int opcion)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("CALL sp_slctTiposDocumentoCompra({0}, {1}, '{2}', {3});", id, id2, criterio, opcion);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable InformacionEstadosPedido(int id, int id2, int id3, string criterio, int opcion)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("CALL sp_slctEstadosPedido({0}, {1}, {2}, '{3}', {4});", id, id2, id3, criterio, opcion);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable InformacionAjustesPedido(int id, int id2, string criterio, int opcion)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("CALL sp_slctAjustes({0}, {1}, '{2}', {3});", id, id2, criterio, opcion);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable DetallesPedidoAprobacion(int id, int id2, string criterio, int opcion, int anio)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("CALL sp_slctSalidasDetalles({0}, {1}, '{2}', {3},{4});", id, id2, criterio, opcion, anio);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable PptoAprobacionSubgerente(int id, int id2, string criterio, int opcion)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("CALL sp_slctPptoAprobarPedido({0}, {1}, '{2}', {3});", id, id2, criterio, opcion);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable PptoCodificarSalida(int id, int id2, string criterio, int opcion)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("CALL sp_slctPptoCodificarPedido({0}, {1}, '{2}', {3});", id, id2, criterio, opcion);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        private DataSet armarDsResultado()
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
        public bool validarPermiso(string Usuario)
        {
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string permiso = string.Format("SELECT id_cargo_usuario from sipa_cargo_usuario where id_usuario="
                 + "(select id_usuario from ccl_usuarios where Usuario = '{0}')  AND id_tipo_usuario=50;", Usuario);
            MySqlCommand cmd = new MySqlCommand(permiso, conectar.conectar);
            MySqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                conectar.CerrarConexion();
                return true;
            }
            else
            {
                conectar.CerrarConexion();
                return false;
            }
        }

        public DataSet PedidoDetallePac(int idPedido)
        {
            conectar = new ConexionBD();
            DataSet tabla = new DataSet();
            string query = String.Format("select pd.id_pedido_detalle id, p.no_solicitud Solicitud, pd.Descripcion, pd.costo_pedido Monto, pd.id_pac PAC, acp.no_renglon as 'Renglon PAC', da.no_renglon as 'Renglon Ppto' from sipa_pedido_detalle pd inner " +
                                            "join sipa_pedidos p on pd.id_pedido = p.id_pedido inner join sipa_pac pac on pac.id_pac = pd.id_pac inner " +
                                            "join sipa_detalles_accion acp on acp.id_detalle = pac.id_detalle inner join sipa_detalles_accion da on da.id_detalle = pd.id_detalle_accion " +
                                            "where p.no_solicitud = {0}  ; ", idPedido);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable BusquedaInsumo(string codigo)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("select renglon,Nombre,Caracteristicas from ccl_catalogo where codigo_insumo = {0}", codigo);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable BusquedaPedido(string codigo, string insumo)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("select presentacion,cantidad_unidad from ccl_catalogo where codigo_presentacion = {0} and codigo_insumo = {1}", codigo, insumo);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public string BusquedaCatalgoInsumo(string busqueda)
        {
            conectar = new ConexionBD();

            string query = String.Format(" select renglon,codigo_insumo,Nombre,Caracteristicas,Presentacion,Cantidad_Unidad,Codigo_presentacion from ccl_catalogo where renglon > 0 {0}",
                busqueda);

            return query;
        }

        public DataTable InforamcionPresentacion(int id)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format(" select p.descripcion_especifica,pd.descripcion ,pd.cantidad,c.Presentacion,c.cantidad_unidad from ccl_catalogo c inner join sipa_pedido_detalle pd on c.codigo_presentacion = pd.codigo_presentacion " +
                      "inner join sipa_especificaciones_detalle p on p.id_pedido_detalle = pd.id_pedido_detalle " +
                     "where pd.id_pedido = {0} ; ", id);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            if (tabla.Rows.Count == 0)
            {
                query = String.Format(" select p.descripcion_especifica,pd.descripcion ,pd.cantidad,' ' as Presentacion ,' ' as cantidad_unidad  from sipa_pedido_detalle pd   " +
                     "inner join sipa_especificaciones_detalle p on p.id_pedido_detalle = pd.id_pedido_detalle  " +
                    "where pd.id_pedido = {0} ; ", id);
                conectar.AbrirConexion();
                consulta = new MySqlDataAdapter(query, conectar.conectar);
                consulta.Fill(tabla);
            }
            conectar.CerrarConexion();
            return tabla;
        }

        public int Ingresar_Insumo(string renglon,string codigo_insumo,string nombre,string caracteristicas,string presentacion,string cantidad_unidad,string codigo_presentacion)
        {
            try
            {
                int result = 0;
                conectar = new ConexionBD();

                string query = String.Format("INSERT INTO `dbcdagsipa`.`ccl_catalogo` VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');",
                    renglon, codigo_insumo, nombre, caracteristicas, presentacion, cantidad_unidad, codigo_presentacion);
                conectar.AbrirConexion();
                MySqlCommand cmd = new MySqlCommand(query, conectar.conectar);
                result = cmd.ExecuteNonQuery();
                conectar.CerrarConexion();
                return result;
            }
            catch (Exception)
            {
                return -1;
                throw;
            }
          
        }

        public int Ingresar_Inusmo_Catalogo()
        {
            try
            {
                int result = 0;
                conectar = new ConexionBD();
                string query = string.Format("TRUNCATE `dbcdagsipa`.`ccl_catalogo`;");
                
                conectar.AbrirConexion();
                MySqlCommand cmd = new MySqlCommand(query, conectar.conectar);
                result = cmd.ExecuteNonQuery();
                query = String.Format("LOAD DATA local INFILE 'C:\\\\ProgramData\\\\MySQL\\\\MySQL Server 5.7\\\\Uploads\\\\Catalogo.csv' INTO TABLE dbcdagsipa.ccl_catalogo " +
                  "FIELDS TERMINATED BY ',' ENCLOSED BY '\"' " +
                  "LINES TERMINATED BY '\\n' " +
                  "IGNORE 2 LINES;");
                cmd = new MySqlCommand(query, conectar.conectar);
                result = cmd.ExecuteNonQuery();
                conectar.CerrarConexion();
                return result;
            }
            catch (Exception ex)
            {
                return -1;
                throw;
            }

        }

        public DataTable InformacionPedidoCompras(int id)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("SELECT e.nombres, CONCAT(p.no_solicitud, '-', p.anio_solicitud) AS solicitud, p.Justificacion, pr.razon_social, pr.nit, pd.no_orden_compra, SUM(pd.costo_real) AS costo, u.Unidad, " +
                          " concat( date_format(pd.fecha_orden_compra ,'%d') , ' de ',fn_nombre_meses(date_format(pd.fecha_orden_compra,'%m')),' ', date_format(pd.fecha_orden_compra,' %Y')) fecha_compromiso " +   
                          " FROM     sipa_pedidos p INNER JOIN "+
                          " ccl_empleados e ON e.id_empleado = p.id_tecnico INNER JOIN" +
                          " sipa_pedido_detalle pd ON pd.id_pedido = p.id_pedido INNER JOIN " +
                          " sipa_proveedores pr ON pr.id_proveedor = pd.id_proveedor INNER JOIN "+ 
                          " ccl_unidades u ON u.id_unidad = p.id_unidad "+
                          " WHERE(p.id_pedido = {0});", id);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable DdlSubproducto(int idUnidad)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("SELECT id_subproducto id,concat(codigo,'-',subproducto) subproducto FROM ccl_subproducto where id_unidad ={0};"
                , idUnidad);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable InformacionProductoSub(string id)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format(" select pro.codigo id_producto,sub.codigo codigo,sub.subproducto from ccl_subproducto sub " +
                " inner join ccl_productos pro on pro.id_producto = sub.id_producto where sub.id_subproducto ={0};", id);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable InformacionProductoSub(int id)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format(" select pro.id_producto,concat(pro.resultado,' ', pro.codigo,' ',sub.codigo) codigo,sub.subproducto from ccl_subproducto sub "+
                "inner join sipa_pedidos p on p.id_subproducto = sub.id_subproducto "+
                "inner join ccl_productos pro on pro.id_producto = sub.id_producto "+
                "where id_pedido = {0}; ", id);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }


        public DataTable InformacionDetallePedidoPpto(string id)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("CALL sp_pedidoPpto({0});", id);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable InformacionPedidoCompras(int no,int anio)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("select u.Unidad,p.id_pedido,p.id_tipo_anexo, "+
               " (select unidad from ccl_unidades where id_padre = u.id_padre and id_unidad = id_padre) padre,"+
                "date_format(p.fecha_pedido, '%Y-%m-%d') fecha_ingreso,date_format(p.fecha_ingreso_compras, '%Y-%m-%d') fecha_ingreso_compras, " +
                "date_format(p.Fecha_Asignacion_Tecnico, '%Y-%m-%d') fecha_tecnico,e.nombres,p.Justificacion,tp.nombre tipo_compra, concat('Q.', format(sum(pd.costo_pedido),4)) costo_pedido, " +
                "p.id_centro_costo,pac.id_modalidad,date_format(p.fecha_act, '%Y-%m-%d') fecha_modificacion, p.acta_negociacion,p.notas,p.fecha_traslado_visa,p.Fecha_retorno, " +
                "(select date_format(ap.fecha_aprobacion_ppto,'%d/%m/%Y') from sipa_ajuste_pedido ap where ap.id_pedido = p.id_pedido and ap.anio_solicitud = p.anio_solicitud ) fecha_ampliacion  " +
                " from sipa_pedidos p "+
                "inner join ccl_unidades u on u.id_unidad = p.id_unidad "+
                "inner join ccl_empleados e on e.id_empleado = p.id_tecnico "+
                "inner join sipa_tipo_pedido tp on tp.id_tipo_pedido = p.id_tipo_pedido "+
                "inner join sipa_pedido_detalle pd on pd.id_pedido = p.id_pedido "+
                "inner join sipa_pac pac on pac.id_pac = pd.id_pac "+
                "where p.no_solicitud = {0} and p.anio_solicitud = {1} and pac.anio = {1};",no,anio);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }


        public DataTable InformacionPedidoComprasDetalle(int no, int anio)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("select pd.id_pedido_detalle ID,pd.descripcion,da.no_renglon,pd.cantidad, concat('Q.',format(pd.costo_u_pedido,2)) costo_u_pedido ," +
            "concat('Q.',format((pd.costo_pedido * 1.12),2)) monto, concat('Q.',format(pd.costo_pedido,2)) costo_pedido ,pd.id_estatus_compras,pd.id_proveedor, " +
            "pd.fecha_traslado_orden,pd.no_orden_compra,pd.fecha_orden_compra,pd.fecha_ingreso_BS,pd.fecha_traslado_almacen, pd.costo_u_compras, pd.cantidad_compras,pd.costo_real subtotal," +
            "CASE WHEN (SELECT spe2.ajuste FROM sipa_pedidos spe2 WHERE spe2.id_pedido = pd.id_pedido) = 0 "+ 
                    " THEN 'N/A' " +
                    "ELSE CONCAT(pd.costo_pedido, '+', pd.ajuste_monto, '=', pd.costo_estimado) "+
                " END ajuste "+
            "from sipa_pedido_detalle pd " +
            "inner join sipa_detalles_accion da on da.id_detalle = pd.id_detalle_accion "+
            "inner join sipa_pedidos p on p.id_pedido = pd.id_pedido "+
            "where p.no_solicitud = {0} and p.anio_solicitud = {1} and p.id_estado_pedido in (10,12);", no,anio);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable DdlEstatusCompras()
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("select id_estado id, nombre texto from ccl_estatus_compras;");
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }


        public DataSet AlmacenarDatosTecnico(string encabezado, string id)
        {
            DataSet dsResultado = new DataSet();
            conectar = new ConexionBD();
            string query = string.Format("Update sipa_pedidos SET "+ encabezado +" fecha_act= now()  WHERE id_pedido ={0}",id);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dsResultado);
            conectar.CerrarConexion();
            return dsResultado;
        }
        public DataSet AlmacenarDatosTecnicoDetalle(string encabezado, string id)
        {
            DataSet dsResultado = new DataSet();
            conectar = new ConexionBD();
            string query = string.Format("Update sipa_pedido_detalle SET " + encabezado + " fecha_act= now()  WHERE id_pedido_detalle ={0}", id);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dsResultado);
            conectar.CerrarConexion();
            return dsResultado;
        }

        /// <summary>
        /// Obtiene el usuario que creo la requisicion.
        /// </summary>
        /// <remarks>
        /// Tabla a consultar:
        ///     -sipa_pedido
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Dataset con el nombre del usuario</returns>
        public DataSet UsuarioRequisicon(string id)
        {
            DataSet dsResultado = new DataSet();
            conectar = new ConexionBD();
            string query = string.Format("select usuario_ing from sipa_pedidos where id_pedido={0}", id);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dsResultado);
            conectar.CerrarConexion();
            return dsResultado;
        }
        /// <summary>
        ///  Obtiene el usuario que creo la especificacion de una requisicion.
        /// </summary>
        /// <remarks>
        /// Tabla a consultar:
        ///     -sipa_especificaciones_pedido
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Dataset con el nombre del usuario</returns>
        public DataSet UsuarioRequisiconEsp(string id)
        {
            DataSet dsResultado = new DataSet();
            conectar = new ConexionBD();
            string query = string.Format("select usuario_ing from sipa_especificaciones_pedido where id_pedido={0}", id);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(dsResultado);
            conectar.CerrarConexion();
            return dsResultado;
        }
    }
}