﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using CapaEN;

namespace CapaAD
{
    public class PlanOperativoAD
    {
        ConexionBD conectar;

        public DataTable DdlAnios()
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter("SELECT anio as texto, anio as id FROM ccl_anios; ", conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable DdlMeses()
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter("SELECT nombre as texto, id_mes as id FROM ccl_meses; ", conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable DdlUnidades(string usuario)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL slctUnidadesxUsuario('{0}');", usuario);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable DdlDependencias(string id_unidad)
        {
            conectar = new ConexionBD();
            DataTable table = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL slctUnidadesxDependencia({0});", id_unidad);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(table);
            conectar.CerrarConexion();
            return table;
        }

        public DataTable DdlDependenciasmUnidad(string id_unidad)
        {
            conectar = new ConexionBD();
            DataTable table = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("select id, texto FROM (SELECT uu.id_unidad id, CONCAT(uu.codigo_unidad, ' - ', uu.unidad) texto " +
                "FROM ccl_unidades uu WHERE  uu.id_unidad = {0})t", id_unidad);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(table);
            query = string.Format("CALL slctUnidadesxDependencia({0});", id_unidad);
            consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(table);
            conectar.CerrarConexion();
            return table;
        }
        public DataTable DdlDependenciasxAnalista(string usuario, int anio, int unidad)
        {
            conectar = new ConexionBD();
            DataTable table = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL slctDependenciasxAnalista('{0}',{1},{2});", usuario, anio, unidad);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(table);
            conectar.CerrarConexion();
            return table;
        }


        public DataTable DdlUnidades()
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL slctNombreUnidad;");
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }


        public DataTable DdlUnidadesxAnalista(string usuario, int anio)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL slctUnidadesxAnalista('{0}', {1});", usuario, anio);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable DdlProcesos()
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL sp_slctProcesos();");
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable DdlObjetivos(int idOOperativo)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL sp_slctObjOpexObjEstr({0});", idOOperativo);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable DdlObjetivosxMeta(int idMeta, int idUnidad)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL sp_slctObjOpexMetaEstr({0}, {1});", idMeta, idUnidad);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable DdlObjetivosB(int anio, int idUnidad)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL sp_SlctObjOpe_x_Anio({0}, {1});", anio, idUnidad);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable DdlObjetivos(int anio, int idUnidad, int idObjEstrategico)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL sp_slctObjOxObjExUnidadxAnio({0}, {1}, {2});", idObjEstrategico, idUnidad, anio);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable DdlIndicadores(int idOOperativo, int idMetaEstrategica)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL sp_slctKpiOp_ObjOp_MetaEstr({0}, {1});", idOOperativo, idMetaEstrategica);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable DdlIndicadores(int idOOperativo)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL sp_slctKpiOp_ObjOp({0});", idOOperativo);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable DdlMetas(int idIndicador)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL sp_slctMetaOp_KpiOp({0});", idIndicador);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable GridBusqueda(string Usuario)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = string.Format("CALL sp_slctPlanOperativoGB('{0}');", Usuario);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable GridCodificacion(int idPoa)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = string.Format("CALL sp_slctPoaCodificacion({0});", idPoa);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable GridPlanCompleto(int idUnidad, int idPoa, int anio)
        {

            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string permiso = string.Format("SELECT 	 pu.id_Poa,u.id_unidad FROM sipa_poa pu right outer JOIN ccl_unidades u ON pu.id_Unidad = u.id_Unidad WHERE pu.anio = {1}" +
                "   and u.codigo_unidad = (select codigo_unidad from ccl_unidades  where id_unidad = {0});", idUnidad, anio);
            MySqlCommand cmd = new MySqlCommand(permiso, conectar.conectar);
            List<string> id_poas = new List<string>();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                
                id_poas.Add(dr.GetString("id_poa"));
            }
            dr.Close();
            cmd.Dispose();
            DataTable tabla = new DataTable();
            for (int i = 0; i < id_poas.Count; i++ )
            {
                string query = string.Format("CALL sp_slctPoaCodificacion({0});", id_poas[i]);
                MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
                consulta.Fill(tabla);
            }

            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable AlmacenarObjetivo(ObjOperativosEN ObjEN, string usuario,string ip,string mac,string pc)
        {
            DataTable tabla = new DataTable();

            conectar = new ConexionBD();

            conectar.AbrirConexion();
            string query = string.Format("CALL sp_iu_obj_operativo({0}, {1}, {2}, {3}, '{4}', {5}, {6}, '{7}','{8}','{9}','{10}');", ObjEN.Id_Objetivo_Operativo, ObjEN.Id_Objetivo_Estrategico, ObjEN.Id_Meta, ObjEN.Codigo, ObjEN.Nombre, ObjEN.Anio, ObjEN.Id_Unidad, ObjEN.Usuario,ip,mac,pc);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();


            return tabla;
        }

        public DataTable AlmacenarIndicador(IndOperativosEN ObjEN)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format(" CALL sp_iu_kpi_operativo({0}, {1}, {2}, '{3}', {4}, '{5}', '{6}')", ObjEN.Id_Kpi_Operativo, ObjEN.Id_Objetivo_Operativo, ObjEN.Id_Meta_Estrategica, ObjEN.Nombre, ObjEN.Anio, ObjEN.Formula, ObjEN.Usuario);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable AlmacenarMeta(MetasOperativasEN ObjEN, string usuario)
        {
            DataTable tabla = new DataTable();

            conectar = new ConexionBD();

            conectar.AbrirConexion();
            string query = string.Format("CALL sp_iu_meta_operativa({0}, {1}, {2}, '{3}', '{4}');", ObjEN.Id_Meta_Operativa, ObjEN.Id_Kpi_Operativo, ObjEN.Anio, ObjEN.Nombre, ObjEN.Usuario);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;


        }

        public DataTable Insertar(ObjOperativosEN ObjOperativosE)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("CALL insertar_obj_operativo({0}, {1}, {2}, '{3}', '{4}', '{5}', {6});", ObjOperativosE.Id_Meta, ObjOperativosE.Id_Unidad, ObjOperativosE.Codigo, ObjOperativosE.Nombre, ObjOperativosE.Meta, ObjOperativosE.Indicador, ObjOperativosE.Anio);

            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable BuscarId(string id)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("CALL sp_slctPlanOperativoM({0});", id);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable InformacionObjetivo(int id)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("CALL sp_slctObjOperativoM({0});", id);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable InformacionIndicador(int id)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("CALL sp_slctKpiOperativoM({0});", id);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable InformacionMeta(int id)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("CALL sp_slctMetaOperativaM({0});", id);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable EliminarObjetivo(int id)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("CALL sp_el_obj_operativo({0});", id);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable EliminarIndicador(int id)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("CALL sp_el_kpi_operativo({0});", id);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable EliminarMeta(int id)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("CALL sp_el_meta_operativa({0});", id);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable ActualizarEstadoPoa(int idPoa, int idEstado, int anio, string idUsuario, string usuarioAsignado, string usuario, string observaciones,string ip, string mac, string pc, string tipo, string boton)
        {
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string permiso = string.Format("SELECT 	 pu.id_Poa FROM sipa_poa pu right outer JOIN ccl_unidades u ON pu.id_Unidad = u.id_Unidad WHERE pu.anio = 2018" +
                "   and u.codigo_unidad = (select codigo_unidad from ccl_unidades  where id_unidad = (select id_unidad from sipa_poa where id_poa = {0}));",idPoa);
            MySqlCommand cmd = new MySqlCommand(permiso, conectar.conectar);
            List<string> id_poas = new List<string>();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                id_poas.Add(dr.GetString("id_Poa"));
            }
            dr.Close();
            cmd.Dispose();
            DataTable tabla = new DataTable();
            string query = "";
            for (int i = 0; i < id_poas.Count; i++)
            {
                if (idUsuario == null)
                    query = String.Format("CALL sp_cambiaEstadoPoaPac({0}, {1}, {2}, null, '{3}', '{4}', '{5}', 1,'{6}','{7}','{8}','{9}','{10}');", id_poas[i], idEstado, anio, usuarioAsignado, usuario, observaciones,ip,mac,pc,tipo,boton);
                else
                    query = String.Format("CALL sp_cambiaEstadoPoaPac({0}, {1}, {2}, {3}, '{4}', '{5}', '{6}', 1,'{7}','{8}','{9}','{10}','{11}');", id_poas[i], idEstado, anio, idUsuario, usuarioAsignado, usuario, observaciones,ip,mac,pc,tipo,boton);

                MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
                consulta.Fill(tabla);
            }
          
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable DatosPoaUnidad(int idUnidad, int anio, string criterio, int opcion)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("CALL slctDatosPoa({0}, {1}, '{2}', {3});", idUnidad, anio, criterio, opcion);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
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

        public string ObtenerCorreo(int unidad, int menu)
        {
            string correo = "";
            conectar = new ConexionBD();
            string permiso = string.Format(" call sp_Correo ({0},{1}) ", unidad, menu);
            conectar.AbrirConexion();
            MySqlCommand cmd = new MySqlCommand(permiso, conectar.conectar);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                correo = dr.GetString("email");
                if (!string.IsNullOrEmpty(correo))
                {
                    return correo;
                }
            }
            return correo = "Correo no encontrado";
        }

        public bool CantidadPpto(int anio, int unidad)
        {
            int cPoa = 0;
            int cUnidades = 0;

            conectar = new ConexionBD();
            string permiso = string.Format(" select count(id_unidad) cantidad from ccl_unidades where codigo_unidad = (select codigo_unidad from ccl_unidades where id_unidad = {0}); "
            , unidad);


            conectar.AbrirConexion();
            MySqlCommand cmd = new MySqlCommand(permiso, conectar.conectar);

            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cUnidades = dr.GetInt16("cantidad");
            }

            permiso = string.Format("call sp_clsCantidadDePpto({0},{1})", anio, unidad);
            dr.Dispose();
            cmd = new MySqlCommand(permiso, conectar.conectar);

            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cPoa = dr.GetInt32("cantidad");
            }
            if (cPoa == cUnidades)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public string ObtenerCorreoxUsuario(string empleado)
        {
            try
            {
                string correo = "";
                conectar = new ConexionBD();
                string permiso = string.Format(" call sp_CorreoxUsuario ('%" + empleado + "%') ");
                conectar.AbrirConexion();
                MySqlCommand cmd = new MySqlCommand(permiso, conectar.conectar);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    correo = dr.GetString("email");
                    if (!string.IsNullOrEmpty(correo))
                    {
                        return correo;
                    }
                }
                return correo = "Correo no encontrado";
            }
            catch (Exception)
            {
                return "Correo no encontrado";
                throw;
            }
           
        }


        public DataTable DependenciasFaltantes(int anio, int unidad)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            string query = String.Format("CALL sp_listadoPoaNulo({0}, {1});", anio, unidad);
            conectar.AbrirConexion();
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public string ProductoxUnidad(int unidad)
        {
            string producto = "";
            conectar = new ConexionBD();
            string permiso = string.Format("select p.producto from ccl_productos p inner join ccl_subproducto sub on sub.id_producto = p.id_producto where id_unidad ={0} "
                , unidad);
            conectar.AbrirConexion();
            MySqlCommand cmd = new MySqlCommand(permiso, conectar.conectar);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                producto = dr.GetString("producto");
                if (!string.IsNullOrEmpty(producto))
                {
                    return producto;
                }
            }
            return producto = "Producto no encontrado";
        }

        public DataTable ddlSubproducto(int idUnidad)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("select id_subproducto,sub.subproducto from  ccl_subproducto sub  where id_unidad ={0};",idUnidad);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable DdlPedidoCompras(string anio)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("select id_pedido id, no_solicitud texto from sipa_pedidos where anio_solicitud = {0} and id_estado_pedido=12;", anio);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable obtenerAvanceUno(string idUnidad, string anio, string cuatrimestre, string mes, string numero)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("Select d1.id_accion ID, d1.descripcion_avance_kpi descripcionM{4}, d1.observaciones_dge observacionesM{4}, concat(fn_codigo_accion(ac.id_accion, 0, '''', 1),'-',ac.accion) accion " +
                 " from sipa_seguimientos_cmi s " +
                 " inner join sipa_seguimientos_cmi_det d1 on d1.id_seguimiento_cmi = s.id_seguimiento_cmi" +
                 " inner join sipa_acciones ac on ac.id_accion = d1.id_accion " +
                 " where s.id_unidad ={0} and s.anio = {1} and no_cuatrimestre = {2} and mes = {3}", idUnidad, anio, cuatrimestre, mes, numero);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable obtenerAvance(string idUnidad, string anio, string cuatrimestre,string mes,string numero )
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("Select  d1.id_accion ID,d1.descripcion_avance_kpi descripcionM{4}, d1.observaciones_dge observacionesM{4} " +
                 " from sipa_seguimientos_cmi s " +
                 " inner join sipa_seguimientos_cmi_det d1 on d1.id_seguimiento_cmi = s.id_seguimiento_cmi " +
                 " where id_unidad ={0} and anio = {1} and no_cuatrimestre = {2} and mes = {3}",idUnidad,anio,cuatrimestre,mes,numero);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable obtenerAvanceCuatrimestral(string idUnidad, string anio, string cuatrimestre, string mes, string numero)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("Select  d1.id_accion ID,COALESCE(d1.avance_cuatrimestre1,' - ') avanceC1,COALESCE(d1.avance_cuatrimestre2,' - ') avanceC2,COALESCE(d1.avance_cuatrimestre3,' - ') avanceC3, " +
                 " d1.avance_cuatrimestre{2} avance, d1.porcentaje_cuatrimestre{2} porcentaje" +
                 " from sipa_seguimientos_cmi s " +
                 " inner join sipa_seguimientos_cmi_det d1 on d1.id_seguimiento_cmi = s.id_seguimiento_cmi " +
                 " where id_unidad ={0} and anio = {1} and no_cuatrimestre = {2} and mes = {3}", idUnidad, anio, cuatrimestre, mes, numero);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable actualizarAvanceCuatrimestral(string observacion,string accion, string mes)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("UPDATE sipa_seguimientos_cmi_det d" +
                " inner join sipa_seguimientos_cmi s on s.id_seguimiento_cmi = d.id_seguimiento_cmi "+
                " SET d.observaciones_dge = '{0}' WHERE d.id_seguimiento_cmi_det > 0 and id_accion = {1} and s.mes = {2}; ",observacion,accion,mes);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public DataTable actualizarAvanceCuatrimestralResumen(string observacion,string avance, string accion, string mes)
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("UPDATE sipa_seguimientos_cmi_det d" +
                " inner join sipa_seguimientos_cmi s on s.id_seguimiento_cmi = d.id_seguimiento_cmi " +
                " SET d.avance_cuatrimestre{2} = '{0}',d.porcentaje_cuatrimestre{2} = '{3}' WHERE d.id_seguimiento_cmi_det > 0 and id_accion = {1} ; ", observacion,accion,mes,avance);
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        public DataTable DdlUsuarioPpto()
        {
            conectar = new ConexionBD();
            DataTable tabla = new DataTable();
            conectar.AbrirConexion();
            string query = string.Format("select id_empleado,nombres from ccl_empleados where id_puesto in(9,93);");
            MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
    }
}
