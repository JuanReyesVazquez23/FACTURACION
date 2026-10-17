<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FRMLOGIN.aspx.cs" Inherits="FACTURACION.LOGIN.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=1280, initial-scale=1.0"/>
    <!-- Titulo de la aplicación -->
    <title>Sistema Facturación</title>

    <!-- Icono que identifica la aplicación -->
    <link rel="shortcut icon" type="image/x-icon" href="/IMAGENES/Favicon.png"/>

    <!-- Colocar fondo y fijar resolución a 1280x1024 -->
    <style type="text/css">
        html {
            width: 100%;
            height: 100%;
            margin: 0;
            padding: 0;
            background-color: #0b0f19;
        }
        body {
            width: 1280px;
            height: 1024px;
            min-height: 1024px;
            max-width: 1280px;
            max-height: 1024px;
            margin: 0 auto;
            position: relative;
            background-image: url('/IMAGENES/Fondo1.jpg');
            background-size: 1280px 1024px;
            background-repeat: no-repeat;
            background-position: center top;
            box-shadow: 0px 0px 30px rgba(0, 0, 0, 0.85);
            overflow: hidden;
            box-sizing: border-box;
        }
        #contenedorLogin {
            width: 1280px;
            height: 1024px;
            position: relative;
            margin: 0 auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="contenedorLogin">
            <asp:ScriptManager ID="scriptManager" runat="server"></asp:ScriptManager>

            <asp:Image ID="warehouseImage" runat="server"
                ImageUrl="~/IMAGENES/CajasAlmacen.png" CssClass="CajasAlmacen" Height="430px"
                Width="790px" />

            <div id="Logo">
                <h1>SISTEMA</h1>
                <h3>DE FACTURACION ELECTRONICA</h3>
            </div>

            <asp:Panel ID="accessPanel" runat="server" BorderColor="Black" BorderStyle="Solid"
                CssClass="accessPanel" Width="520px" Height="268px"
                BackImageUrl="~/IMAGENES/FondoLogin.png">

                <asp:Panel ID="controlPanel" runat="server" Height="37px" Width="520px"
                    BackColor="#3399FF">
                    <asp:Label ID="controlLabel" runat="server" Text="Control de Acceso" Font-Bold="True"
                        ForeColor="White" Font-Size="Larger" CssClass="controlLabel"></asp:Label>
                </asp:Panel>

                <asp:Image ID="lockImage" runat="server"
                    ImageUrl="~/IMAGENES/CerraduraRoja.png" Height="85px" Width="95px"
                    CssClass="lockImage" />

                <asp:Label ID="usernameLabel" runat="server" Text="Usuario.:" Font-Bold="True"
                    ForeColor="White" Font-Size="Large" CssClass="usernameLabel"></asp:Label>

                <asp:Label ID="passwordLabel" runat="server" Text="Clave.:" Font-Bold="True"
                    ForeColor="White" Font-Size="Large" CssClass="passwordLabel"></asp:Label>

                <asp:TextBox ID="usernameTextBox" runat="server" Font-Bold="True" ToolTip="Introduzca su Usuario"
                    Font-Size="Large" ForeColor="#0066FF" AutoCompleteType="Disabled"
                    CssClass="usernameTextBox"></asp:TextBox>

                <asp:TextBox ID="passwordTextBox" runat="server" Font-Bold="True" ToolTip="Introduzca su Clave"
                    Font-Size="Large" ForeColor="#0066FF" AutoCompleteType="Disabled"
                    CssClass="passwordTextBox" TextMode="Password"></asp:TextBox>

                <asp:Button ID="acceptButton" runat="server" Text="Aceptar" Font-Bold="True"
                    ToolTip="Presione para Aceptar la validacion" BorderStyle="Outset" Width="80px"
                    Height="40px" CssClass="acceptButton" OnClick="AcceptButton_Click"/>

                <asp:Panel ID="messagePanel" runat="server" Height="37px" Width="520px"
                    CssClass="messagePanel" BackColor="Black">
                    <asp:Label ID="messageLabel" runat="server" Text="Mensaje.:" Font-Bold="True"
                        ForeColor="White" CssClass="messageLabel"></asp:Label>
                </asp:Panel>
            </asp:Panel>

            <asp:Timer ID="sessionTimer" runat="server" Interval="5000" Enabled="False"
                OnTick="SessionTimer_Tick"></asp:Timer>
        </div>
    </form>
</body>
</html>
