<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Proyecto_PTC.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="EstilosCss/StyleLogin.css" rel="stylesheet" />
    <script src="SweetAlert/sweetalert2.all.min.js"></script>
    <script src="SweetAlert/sweetalert2.js"></script>
    <title>Login</title>

</head>
<body>
    <form id="formLogin" runat="server">
        <nav class="navbar navbar-expand-sm fixed-top">
                    <a class="navbar-brand" href="index.html">Inicio</a>
            <asp:Button ID="btnregistro" class="btn btn-outline-success my-2 my-sm-0" type="submit" runat="server" Text="Registrarse" OnClick="btnregistro_Click" />
        </nav>

        <div class="container">
            <img src="Img/icono.jpg" />
            <h1>Iniciar Sesion</h1>
            <div class="form-group">
                <asp:TextBox ID="txtUser" runat="server" placeholder="Usuario" type="text" class="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:TextBox ID="txtPassword" runat="server" placeholder="Contraseña" type="password" class="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" CssClass="form-control btn btn-primary" OnClick="btnIngresar_Click" />
            </div>
            <div>
                <asp:HyperLink ID="Olvidastes" runat="server" Text="¿Has olvidado tu contraseña?" />
            </div>
            <asp:Literal ID="alerta" runat="server" Text=""></asp:Literal>
        </div>
    </form>
</body>
</html>
