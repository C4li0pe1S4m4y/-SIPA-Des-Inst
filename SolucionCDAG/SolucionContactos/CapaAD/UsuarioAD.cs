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
   public class UsuarioAD
    {
       ConexionBD conectar;

       public DataTable datosCargoUsuario(int idusr)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter("call slctDatosCargoUsuario(" + idusr + ");", conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public  DataTable MenusPadre()
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter("call slctMenusPadre; ", conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }
       public DataTable ObtenerUsuariosMenus(int idUsuario)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter("call slctUsuarioMenu(" + idUsuario + ");", conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }
       public DataTable ObtenerMenus(int idMenu)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter("call slctObtenerMenus(" + idMenu + ");", conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable gridUsuario()
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter("call slctNombreUsuario; ", conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }
       public DataTable datosUsuario(int idUsuario)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter("call slctUsuarios(" + idUsuario + ");", conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }
 
       public DataTable dropTipoUsuario()
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter("call slctTipoUsuario; ", conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }
       public DataTable obtener_Usuarios()
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter("call clsObtenerUsuarios; ", conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable PassAntiguo(UsuariosEN Usuarios)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter("call clsLogearse('" + Usuarios.Usuario + "','" + Usuarios.Contrasena + "'); ", conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public DataTable VerificarSiExite_Nombre(String usuario,int idusr)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           MySqlDataAdapter consulta = new MySqlDataAdapter("call slctValNombre('" + usuario + "'," + idusr + ");", conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }
       public void ModificaPass (UsuariosEN Usuarios) {
                conectar = new ConexionBD();
                conectar.AbrirConexion();
                MySqlCommand procedimiento = new MySqlCommand("Modificar_Pass");
                procedimiento.CommandType = CommandType.StoredProcedure;

                procedimiento.Parameters.AddWithValue("@usr",  Usuarios.Usuario);
                procedimiento.Parameters.AddWithValue("@pass",Usuarios.Contrasena);

                conectar.AbrirConexion();
                procedimiento.Connection = conectar.conectar;
                procedimiento.ExecuteNonQuery();
        }
       public int IngresarUsuario(UsuariosEN usuarioE)
       {
           int NoIngreso;
           conectar = new ConexionBD();
           MySqlCommand procedimiento = new MySqlCommand("insertar_usuario");
           procedimiento.CommandType = CommandType.StoredProcedure;
           procedimiento.Parameters.AddWithValue("usr", usuarioE.Usuario);
           procedimiento.Parameters.AddWithValue("contra",  usuarioE.Contrasena);
           
           if(usuarioE.idEmpleado > 0)
               procedimiento.Parameters.AddWithValue("idEm", usuarioE.idEmpleado);
           else
               procedimiento.Parameters.AddWithValue("idEm", null);

           procedimiento.Parameters.AddWithValue("v_nombre", usuarioE.Nombre);
           

           conectar.AbrirConexion();
           procedimiento.Connection = conectar.conectar;
           NoIngreso = procedimiento.ExecuteNonQuery();
           conectar.CerrarConexion();
           return NoIngreso;

       }
       public void ModificarUsuario(UsuariosEN usuarioE)
       {
           conectar = new ConexionBD();
           MySqlCommand procedimiento = new MySqlCommand("Modificar_Usuario");
           procedimiento.CommandType = CommandType.StoredProcedure;
           procedimiento.Parameters.AddWithValue("idusr", usuarioE.IdUsuario);
           procedimiento.Parameters.AddWithValue("usr", usuarioE.Usuario);
           procedimiento.Parameters.AddWithValue("contra", usuarioE.Contrasena);
           procedimiento.Parameters.AddWithValue("idTU", usuarioE.idTipoUsuario);
           procedimiento.Parameters.AddWithValue("est", usuarioE.Habilitado);
           procedimiento.Parameters.AddWithValue("v_nombre", null);
           if(usuarioE.idEmpleado > 0)
               procedimiento.Parameters.AddWithValue("vid_empleado", usuarioE.idEmpleado);
           else
               procedimiento.Parameters.AddWithValue("vid_empleado", null);

           conectar.AbrirConexion();
           procedimiento.Connection = conectar.conectar;
           procedimiento.ExecuteNonQuery();

           conectar.CerrarConexion();
           
       }


       public int EliminarUsuario(UsuariosEN usuarioE)
       {
           int NoIngreso;
           conectar = new ConexionBD();
           MySqlCommand procedimiento = new MySqlCommand("Eliminar_Usuario");
           procedimiento.CommandType = CommandType.StoredProcedure;
           procedimiento.Parameters.AddWithValue("idusr", usuarioE.IdUsuario);

           conectar.AbrirConexion();
           procedimiento.Connection = conectar.conectar;
           NoIngreso = procedimiento.ExecuteNonQuery();
           conectar.CerrarConexion();
           return NoIngreso;

       }

       

       public DataTable IngresarPermiso(int idUsuario, int idMenu)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           string query = string.Format("CALL Insertar_Permisos({0}, {1});", idUsuario, idMenu);
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }
 
       public void  EliminarPermiso(int idUsuario,int idMenu)
       {
           int NoIngreso;
           conectar = new ConexionBD();
           MySqlCommand procedimiento = new MySqlCommand("Eliminar_Permisos");
           procedimiento.CommandType = CommandType.StoredProcedure;
           procedimiento.Parameters.AddWithValue("idusr", idUsuario);
           procedimiento.Parameters.AddWithValue("idm", idMenu);
           
           conectar.AbrirConexion();
           procedimiento.Connection = conectar.conectar;
           NoIngreso = procedimiento.ExecuteNonQuery();
           conectar.CerrarConexion();
       }

       public DataTable IngresarCargoUsuario(int idUsuario, int idU,int idd,int idtu)
       {
           conectar = new ConexionBD();
           DataTable tabla = new DataTable();
           conectar.AbrirConexion();
           string query = string.Format("CALL Insertar_CargoUsuario({0}, {1}, {2}, {3});", idUsuario, idU, idd, idtu);
           MySqlDataAdapter consulta = new MySqlDataAdapter(query, conectar.conectar);
           consulta.Fill(tabla);
           conectar.CerrarConexion();
           return tabla;
       }

       public void desactivarCargoUsuario(int idcu)
       {

           conectar = new ConexionBD();
           MySqlCommand procedimiento = new MySqlCommand("Desactivar_CargoUsuario");
           procedimiento.CommandType = CommandType.StoredProcedure;
           procedimiento.Parameters.AddWithValue("idcu", idcu);
           
           conectar.AbrirConexion();
           procedimiento.Connection = conectar.conectar;
           procedimiento.ExecuteNonQuery();
           conectar.CerrarConexion();
       }


       
    }
}
