using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace Proyecto_PTC
{
    public partial class WebForm1 : System.Web.UI.Page
    {
      
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Trim() != "" && txtPassword.Text.Trim() != "" && txtPassword2.Text.Trim() != "" && txtName.Text.Trim() != "" && txtLastname.Text.Trim() != "" && txtGMAIL.Text.Trim() != "")
            {
                if (txtPassword.Text == txtPassword2.Text)
                {
                    string nombre;
                    string apellido;
                    string encriptada;
                    string usuario;
                    string correo;

                    nombre = txtName.Text;
                    apellido = txtLastname.Text;
                    usuario = txtUser.Text;
                    encriptada = EncryptString(txtPassword.Text, initVector);
                    correo = txtGMAIL.Text;
                    if (Conexiones.UsuariosRepetidos(usuario, encriptada, nombre, apellido, correo) == 0)
                    {
                        alerta.Text = "<script>Swal.fire('Registrado con éxito', '¡Gracias por preferirnos!', 'success'); </script>";
                        
                        txtName.Text = "";
                        txtLastname.Text = "";
                        txtUser.Text = "";
                        txtPassword.Text = "";
                        txtPassword2.Text = "";
                        txtGMAIL.Text = "";
                    }
                    else
                    {
                        alerta.Text = "<script>Swal.fire('Este usuario ya existe', 'Elije nuevo nombre de usuario', 'error'); </script>";
                    }
                }
                else
                {
                    alerta.Text = "<script>Swal.fire('Contraseña incorrecta', 'Repita su contraseña.', 'error');</script>";
                }
            }
            else
            {
                alerta.Text = "<script>Swal.fire('ADVERTENCIA', 'No deje espacios en blanco', 'error') </script>";
            }
        }
        private const string initVector = "inf2020bttyearpry";
        // This constant is used to determine the keysize of the encryption algorithm
        private const int keysize = 256;
        //Encrypt
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

        protected void btnLogin_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }

}
