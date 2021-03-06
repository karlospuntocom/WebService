﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WebService
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public List<string> listar()
        {
            List<string> listarOrden = new List<string>();
            string ruta = "Server=localhost; database=mydb; password=admin; user=roota";
            MySqlConnection conexion = new MySqlConnection(ruta);
            conexion.Open();
            MySqlCommand command = conexion.CreateCommand();
            command.CommandText = ("Select * from ordenservicio");
            command.Connection = conexion;
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listarOrden.Add(reader.GetString(0).ToString());
                listarOrden.Add(reader.GetString(1).ToString());
                listarOrden.Add(reader.GetString(2).ToString());
                listarOrden.Add(reader.GetString(3).ToString());
                listarOrden.Add(reader.GetString(4).ToString());
                listarOrden.Add(reader.GetString(5).ToString());
            }
            command.Connection.Close();

            return listarOrden;
        }

        [WebMethod]
        public string eliminar(int id)
        {
            string mensaje = "No se pudo eliminar";
            string ruta = "Server=localhost; database=mydb; password=admin; user=roota";
            MySqlConnection conexion = new MySqlConnection(ruta);
            conexion.Open();
            MySqlCommand command = conexion.CreateCommand();
            command.CommandText = ("DELETE FROM `ordenservicio` WHERE `id` = " + id);
            command.Connection = conexion;
            command.ExecuteNonQuery();
            if (command.ExecuteNonQuery() > 0)
            {
                mensaje = "Se ha eliminado exitosamente!";
            }
            command.Connection.Close();

            return mensaje;
        }

        [WebMethod]
        public string agregar(string idCliente, string fechaHora, string descripcion, int cantidadProductos, int costoTotal)
        {
            string mensaje = "No se pudo registrar";
            string ruta = "Server=localhost; database=mydb; password=admin; user=roota";
            MySqlConnection conexion = new MySqlConnection(ruta);
            conexion.Open();
            MySqlCommand command = conexion.CreateCommand();
            command.CommandText = ("INSERT INTO `ordenservicio`(`idCliente`, `fechaHora`, `descripcion`, `cantidadProductos`, `costoTotal`) VALUES (" + idCliente + "," + fechaHora + "," + descripcion + "," + cantidadProductos + "," + costoTotal + ")");
            command.Connection = conexion;
            command.ExecuteNonQuery();
            if (command.ExecuteNonQuery() > 0)
            {
                mensaje = "Registro exitoso!";
            }
            command.Connection.Close();

            return mensaje;
        }

        [WebMethod]
        public string modificar(int id, string idCliente, string fechaHora, string descripcion, int cantidadProductos, int costoTotal)
        {
            string mensaje = "No se pudo registrar";
            string ruta = "Server=localhost; database=mydb; password=admin; user=roota";
            MySqlConnection conexion = new MySqlConnection(ruta);
            conexion.Open();
            MySqlCommand command = conexion.CreateCommand();
            command.CommandText = ("UPDATE `ordenservicio` SET `idCliente`=[value-2],`fechaHora`=[value-3],`descripcion`="+descripcion+",`cantidadProductos`="+cantidadProductos+",`costoTotal`=" + costoTotal + " WHERE `id` = "+ id);
            command.Connection = conexion;
            command.ExecuteNonQuery();
            if (command.ExecuteNonQuery()>0)
            {
                mensaje = "Modificación exitosa!";
            }
            command.Connection.Close();

            return mensaje;
        }
    }
}
