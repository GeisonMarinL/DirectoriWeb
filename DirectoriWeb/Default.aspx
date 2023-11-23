<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DirectoriWeb._Default"  %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="content/default.css" rel="stylesheet" />

    <main>
        <section class="row1" aria-labelledby="aspnetTitle">
            <h1 id="titulo">Directorio</h1>
            <div id="container">
                <p id ="texto">
                    En nuestro directorio web, hemos diseñado una experiencia intuitiva para que encuentres fácilmente información esencial sobre nuestros valiosos empleados. 
                    Cada perfil incluye detalles importantes, como el nombre completo, apellido, cargo, número de oficina y número de teléfono móvil. 
                    Además, hemos integrado una sección visual donde podrás ver la fotografía de cada miembro de nuestro talentoso equipo
                </p>
                <img id="logo"src="Content/imagenes/logopng.png" alt="Descripción de la imagen" >
                 
            </div>
        </section>

        <div class="row">
            <section class="col-md-4" aria-labelledby="gettingStartedTitle">
                <h2 id="gettingStartedTitle">Descripción</h2>
                <p>
                    El formulario está diseñado para que los empleados puedan ingresar su información personal de forma rápida y sencilla.
                    Los datos ingresados en el formulario se pueden utilizar para fines administrativos, como la creación de registros de empleados o la facturación.
                </p>
                <p>
                    <a class="btn btn-default" href="Empleados.aspx">Formulario &raquo;</a>
                </p>
            </section>
            <section class="col-md-4" aria-labelledby="librariesTitle">
                <h2 id="librariesTitle">Compatibilidad confirmada</h2>
                <p>
                    Windows 10 y 11: Rendimiento optimizado para una experiencia fluida.<br />

                </p>
                <p>
                    <a class="btn btn-default" href="https://learn.microsoft.com/es-es/aspnet/overview">Learn more &raquo;</a>
                </p>
            </section>
            <section class="col-md-4" aria-labelledby="hostingTitle">
                <h2 id="hostingTitle">Aplicación (versión preliminar)</h2>
                <p>
                    Es fácil de usar y proporciona una forma conveniente para que los usuarios envíen sus datos de contacto a una empresa o organización.
                <p>
                    <a class="btn btn-default" href="https://github.com/GeisonMarinL/GestorContactosEmple.git">Learn more &raquo;</a>
                </p>
            </section>
        </div>
    </main>

</asp:Content>
