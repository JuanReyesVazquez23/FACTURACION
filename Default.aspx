<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/LOGIN/MainMaster.master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FACTURACION.HomePage" %>

<asp:Content ID="headContent" ContentPlaceHolderID="headPlaceholder" runat="server">
</asp:Content>

<asp:Content ID="menuContent" ContentPlaceHolderID="contextualMenuPlaceholder" runat="server">
</asp:Content>

<asp:Content ID="mainContent" ContentPlaceHolderID="mainContentPlaceholder" runat="server">
    <div style="text-align: center; padding-top: 30px;">
        <h2>Bienvenido al Sistema de Facturaci&oacute;n</h2>
        <img src="/IMAGENES/CajasAlmacen.png" alt="Cajas Almacen" style="max-width: 790px; height: auto;" />
    </div>

    <asp:Label ID="codeLabel" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="usernameLabel" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="nameLabel" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="surnameLabel" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="departmentLabel" runat="server" Text="" Visible="false"></asp:Label>
    <asp:Label ID="roleLabel" runat="server" Text="" Visible="false"></asp:Label>
</asp:Content>
