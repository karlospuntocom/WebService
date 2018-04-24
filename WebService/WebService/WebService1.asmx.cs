using System;
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
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public List<string> listar()
        {
            List<string> listarAlumno = new List<string>();
            string ruta = "Server=localhost; database=mydb; password=admin; user=roota";
            MySqlConnection conexion = new MySqlConnection(ruta);
            conexion.Open();
            MySqlCommand command = conexion.CreateCommand();
            command.CommandText = ("Select * from ordenservicio");
            command.Connection = conexion;
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listarAlumno.Add(reader.GetString(0).ToString());
                listarAlumno.Add(reader.GetString(1).ToString());
                listarAlumno.Add(reader.GetString(2).ToString());
                listarAlumno.Add(reader.GetString(3).ToString());
            }
            command.Connection.Close();

            return listarAlumno;
        }

        [WebMethod]
        public string agregarOt(int id, string idCliente, string fechaHora, string descripcion, int cantidadProductos, int costoTotal)
        {
            string mensaje = "No se pudo registrar";
            string ruta = "Server=localhost; database=colegio; password=admin; user=roota";
            MySqlConnection conexion = new MySqlConnection(ruta);
            conexion.Open();
            MySqlCommand command = conexion.CreateCommand();
            command.CommandText = ("INSERT INTO `alumnos`(`id`, `nombre`, `apellido`, `edad`) VALUES ("+id+","+idCliente+","+fechaHora+","+descripcion+","+cantidadProductos+","+costoTotal+")");
            command.Connection = conexion;
            command.ExecuteNonQuery();
            if (command.ExecuteNonQuery()>0)
            {
                mensaje = "Reigstro exitoso!";
            }
            command.Connection.Close();

            return mensaje;
        }
    }
}
