<%@ Page Title="Mantenimiento" Language="C#" MasterPageFile="~/mantenimiento/MPMantenimiento.master" AutoEventWireup="true" CodeBehind="Mantenimiento.aspx.cs" Inherits="FACTURACION.mantenimiento.Mantenimiento" %>

<asp:Content ID="ContentMantenimiento" ContentPlaceHolderID="ContenidoMantenimiento" runat="server">
    <div>
        <h2>Mantenimiento</h2>
        <img src="../IMAGENES/CajasAlmacen.png" alt="Mantenimiento" />
        <p>Seleccione una opci&oacute;n del men&uacute; de mantenimiento.</p>

        <section id="empresa">
            <h3>Crear Empresa</h3>
        </section>

        <section id="cajas">
            <h3>Crear Cajas</h3>
        </section>

        <section id="bodegas">
            <h3>Crear Bodegas</h3>
        </section>

        <section id="clientes">
            <h3>Crear Clientes</h3>
        </section>

        <section id="productos">
            <h3>Crear Productos</h3>
        </section>

        <section id="suplidores">
            <h3>Crear Suplidores</h3>
        </section>

        <section id="codigo">
            <h3>Crear Codigo Barra y QR</h3>
        </section>
    </div>
</asp:Content>
