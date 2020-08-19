using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
namespace Proyecto_PTC
{
    public class datos
    {
        //Metodo costructor...
        public static  MySqlConnection ObtenerConexion()
        {  
          MySqlConnection datos = new MySqlConnection("server=127.0.0.1; database=frankgael; Uid=root; pwd=;");
          datos.Open();
          return datos;
        }    
    }
}