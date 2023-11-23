<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="DirectoriWeb.Empleados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
        <div>
            <h2>Formulario de Usuario</h2>
            <label for="txtDocumento">Documento:</label>
            <asp:TextBox ID="txtDocumento" runat="server" CssClass="form-control"></asp:TextBox>
            <br />

            <label for="txtNombre">Nombre:</label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            <br />

            <label for="txtApellido">Apellido:</label>
            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
            <br />

            <label for="txtCargo">Cargo:</label>
            <asp:TextBox ID="txtCargo" runat="server" CssClass="form-control"></asp:TextBox>
            <br />

            <label for="txtNumeroOficina">Número de Oficina:</label>
            <asp:TextBox ID="txtNumeroOficina" runat="server" CssClass="form-control"></asp:TextBox>
            <br />

            <label for="txtTelefonoMovil">Teléfono Móvil:</label>
            <asp:TextBox ID="txtTelefonoMovil" runat="server" CssClass="form-control"></asp:TextBox>
            <br />

            <label for="fuFotografia">Fotografía:</label>
            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" Accept=".png,.jpeg"/>
            <br />

        </div>
    
     <br />
     <br />
    <h2>Acciones</h2>
    
    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn btn-primary" OnClick="btnGuardar_Click" />
    <asp:Button ID="btnAtualizar" runat="server" Text="Actualizar" CssClass="btn btn btn-success" OnClick="btnAtualizar_Click"/>
    <asp:Button ID="btnBorrar" runat="server" Text="Borrar" CssClass="btn btn btn-danger" OnClick="btnBorrar_Click"/>
    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn btn-dark" OnClick="btnLimpiar_Click"/>
     
    
     <br />
     <br />
     <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" Width="873px" AutoGenerateColumns="False">
         <Columns>
              <asp:BoundField DataField="id" HeaderText="ID" />
             <asp:BoundField DataField="documento" HeaderText="Documento" />
             <asp:BoundField DataField="nombre" HeaderText="Nombre" />
             <asp:BoundField DataField="apellido" HeaderText="Apellido" />
             <asp:BoundField DataField="cargo" HeaderText="Cargo" />
             <asp:BoundField DataField="numeroOficina" HeaderText="Numero-Oficina" />
             <asp:BoundField DataField="telefonoMovil" HeaderText="Telefono-Movil" />
            <asp:TemplateField HeaderText="Fotografia">
            <ItemTemplate>
                <asp:Image ID="Image1" runat="server" ImageUrl='<%# "data:image/jpg;base64," + Convert.ToBase64String((byte[])Eval("fotografia")) %>' Height="70px" Width="70px"/>
            </ItemTemplate>
        </asp:TemplateField>      
         </Columns>

     </asp:GridView>

</asp:Content>
