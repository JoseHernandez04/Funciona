using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using MySql.Data.MySqlClient;
namespace Proyecto_PTC
{
    public class Conexiones
    {
        public static int UsuariosRepetidos(string usuario, string contra, string nombre, string apellido, string correo)
        {
            int valor = 0;
            MySqlConnection conexion = datos.ObtenerConexion();
            MySqlCommand cmd = new MySqlCommand("SELECT Id_Usuario FROM usuarios WHERE Nombre_Usuario='" + usuario + "'", conexion);
            valor = Convert.ToInt32(cmd.ExecuteScalar());
            if (valor != 0)
            {
                //no es necasario validar aqui ya que en el formulario Registro tenemos alertas si valor = 0
            }
            else
            {
                Conexiones.AgregarUsuario(nombre, apellido, usuario, contra, correo);
            }
            conexion.Close();
            return valor;
        }
        //********************************************************************************
        public static int AgregarUsuario(string nombre, string apellido, string usuario, string contra, string correo)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("Insert into usuarios (Nombre, Apellido, Nombre_Usuario, Password,Correo) values ('{0}','{1}','{2}','{3}','{4}')", nombre, apellido, usuario, contra, correo), datos.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();

            return retorno;
        }
        //********************************************************************************

        public static int agregar(Agregar pAlumno)
        {
            int retorno = 0;
            MySqlCommand comado = new MySqlCommand(string.Format("Insert into productos (ID, Marca, Producto, Precio, Cantidad) values('{0}','{1}','{2}','{3}','{4}')", pAlumno.Id, pAlumno.Marca, pAlumno.Producto, pAlumno.Precio, pAlumno.Cantidad), datos.ObtenerConexion());
            retorno = comado.ExecuteNonQuery();
            return retorno;
        }
    }
}
