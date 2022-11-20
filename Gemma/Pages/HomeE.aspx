<%@ Page Title="" Language="C#" MasterPageFile="~/MpLoginAndRegister.Master" AutoEventWireup="true" CodeBehind="HomeE.aspx.cs" Inherits="Gemma.Pages.HomeE" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titulo" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/jquery-3.6.1.min.js"></script>
    <script src="../Script/loginRegister.js"></script>
    <script src="../Scripts/toastr.js"></script>
    <link href="../content/toastr.css" rel="stylesheet" />
    <link href="../Estilos/LoginAndRegister.css" rel="stylesheet" />
    <link href="../Estilos/GestionEstudiantes.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <p>
            Aqui Es Pagina Home de Estudiante
        </p>
    </div>
</asp:Content>
