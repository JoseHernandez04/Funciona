using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;

namespace Proyecto_PTC
{
    public partial class Login : System.Web.UI.Page
    {

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != "" && txtUser.Text != "") //Validadndo espacio vacio
            {
                string contra, user;
                contra = EncryptString(txtPassword.Text, initVector);
                user = txtUser.Text;
                Datos1.valorGlobal = user; //llamamos la lcase Datos

                MySqlConnection conexion = new MySqlConnection("server=127.0.0.1; database=frankgael; Uid=root; pwd=");
                var cmd = "SELECT Id_Usuario from usuarios WHERE Nombre_Usuario='" + user + "' AND Password='" + contra + "';";
                MySqlCommand comando = new MySqlCommand(cmd, conexion);
                conexion.Open();
                int retorno = Convert.ToInt32(comando.ExecuteScalar());
                if (retorno != 0)
                {
                    Session["username"] = txtUser; //Craamos una sesion
                    Response.Redirect("Inicio.html"); // Nos redirecciona a nuetro formulario
                }
                else
                {
                    //Mensaje de alerta que se nos muestra; es lo mismo que MessageBox solo que con animacion javascript de SweetAlert
                    alerta.Text = "<script>Swal.fire('Error de los credenciales', 'Su usuario o contraseña son incorrectos', ' error') </script>";
                    txtPassword.Text = ""; //Limpiamos los textbox
                    txtUser.Text = "";
                }
            }
            else
            {
                alerta.Text = "<script>Swal.fire('ADVERTENCIA', 'No deje espacios en blanco', error') </script>";
            }
        }

        private const string initVector = "inf2020bttyearpry"; // Llave de incriptado
        
        private const int keysize = 256; //Esta constante se usa  para determinar  el tamaño de la clave del algoritmo de cifrado
        //Encriptar
        public static string EncryptString(string plainText, string passPhrase)
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            return Convert.ToBase64String(cipherTextBytes);
        }

        protected void btnregistro_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registro.aspx");//nos redirecciona al formulario Web de registro
            //Este es un mensaje de prueba 
        }

    }
}