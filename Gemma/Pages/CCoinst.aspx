<%@ Page Title="" Language="C#" MasterPageFile="~/MpProfesor.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="CCoinst.aspx.cs" Inherits="Gemma.Pages.CCoinst" %>
<%@ Register TagPrefix="ajax" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %> 
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/jquery-3.6.1.min.js"></script>
    <script src="../Script/loginRegister.js"></script>
    <script src="../Scripts/toastr.js"></script>
    <link href="../content/toastr.css" rel="stylesheet" />
    <link href="../Estilos/LoginAndRegister.css" rel="stylesheet" />
    <link href="../Estilos/GestionEstudiantes.css" rel="stylesheet" />
    <link href="../Estilos/PaginaEmergente.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="asm"></asp:ScriptManager>
    <div class="card-group">
        <div class="card">
            <img src="/Images/ccoins.png" class="card-img-top" alt="Cargando Imagen...">
            <div class="card-body">
                <h5 class="card-title">C-Coins - Clase</h5>
                <p class="card-text">Aqui puede agregar C-Coins a toda la clase en general, tenga n cuenta que solo puede agregar a las clases creadas por usted.</p>
                <asp:Button runat="server" Text="Asignar" CssClass="btn btn-success" ID="btnCoinsClases" OnClick="btnCoinsClases_Click"/>
                <p class="card-text"><small class="text-muted">C-Coins: Moneda de cambio no legal</small></p>
            </div>
        </div>
        <div class="card">
            <img src="/Images/ccoins.png" class="card-img-top" alt="Cargando Imagen...">
            <div class="card-body">
                <h5 class="card-title">C-Coins - Grupo</h5>
                <p class="card-text">Aqui puede agregar C-Coins a los grupos que estan agregados a las clases. </p>
                <asp:Button runat="server" Text="Asignar" CssClass="btn btn-success" ID="btnCoinsGrupal" OnClick="btnCoinsGrupal_Click" />
                <p class="card-text"><small class="text-muted">C-Coins: Moneda de cambio no legal</small></p>
            </div>
        </div>
        <div class="card">
            <img src="/Images/ccoins.png" class="card-img-top" alt="Cargando Imagen...">
            <div class="card-body">
                <h5 class="card-title">C-Coins - Individual</h5>
                <p class="card-text">Aqui puede agregar C-Coins individuales a los estudiantes que pertenezan  su clase.</p>
                <asp:Button runat="server" Text="Asignar" CssClass="btn btn-success" ID="btnCoinsIndividual" OnClick="btnCoinsIndividual_Click" />
                <p class="card-text"><small class="text-muted">C-Coins: Moneda de cambio no legal</small></p>
            </div>
        </div>
    </div>



</asp:Content>
