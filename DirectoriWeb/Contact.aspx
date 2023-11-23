<%@ Page Title="Contactos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="DirectoriWeb.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="contact-container">
        <h2>Contactos</h2>
        <p>¡Bienvenido a nuestra página de contactos!</p>

        <asp:Panel ID="pnlContacto" runat="server" CssClass="contact-form">
            <div class="form-group">
                <label for="txtNombre">Nombre:</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="txtEmail">Correo electrónico:</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="txtMensaje">Mensaje:</label>
                <asp:TextBox ID="txtMensaje" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
            </div>

            <asp:Button ID="btnEnviar" runat="server" Text="Enviar"  CssClass="btn btn-primary" />
        </asp:Panel>
    </div>
    
</asp:Content>
