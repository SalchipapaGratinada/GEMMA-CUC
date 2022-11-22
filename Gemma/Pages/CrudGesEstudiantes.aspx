<%@ Page Title="" Language="C#" MasterPageFile="~/MpProfesor.Master" AutoEventWireup="true" CodeBehind="CrudGesEstudiantes.aspx.cs" Inherits="Gemma.Pages.CrudGesEstudiantes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/jquery-3.6.1.min.js"></script>
    <script src="../Script/loginRegister.js"></script>
    <script src="../Scripts/toastr.js"></script>
    <link href="../content/toastr.css" rel="stylesheet" />
    <link href="../Estilos/LoginAndRegister.css" rel="stylesheet" />
    <link href="../Estilos/EGestionarClase.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


     <br />
    <div class="mx-auto" style="width: 250px">
        <asp:Label runat="server" CssClass="h2" ID="lbltitulo"></asp:Label>
    </div>

    <div class="contenedorDatosEstudiante">
        <div class="mb-3">
            <label class="form-label">Nombre Estudiante</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="tbNombreEstudiante"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label class="form-label">Apellido Estudiante</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="tbApellidoEstudiante" ></asp:TextBox>
        </div>
         <div class="mb-3">
            <label class="form-label">Nick Estudiante</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="tbNickEstudiante" ></asp:TextBox>
        </div>
        <div class="mb-3">
            <label class="form-label">Correo Estudiante</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="tbEmailEstudiante" ></asp:TextBox>
        </div>
        <asp:Button runat="server" CssClass="btn btn-primary btn-dark" ID="BtnBack" Text="Back" Visible="True" OnClick="BtnBack_Click" />
    </div>




</asp:Content>
