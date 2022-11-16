<%@ Page Title="" Language="C#" MasterPageFile="~/MpProfesor.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="CCoinsGrupos.aspx.cs" Inherits="Gemma.Pages.CCoinsGrupos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/jquery-3.6.1.min.js"></script>
    <script src="../Script/loginRegister.js"></script>
    <script src="../Scripts/toastr.js"></script>
    <link href="../content/toastr.css" rel="stylesheet" />
    <link href="../Estilos/LoginAndRegister.css" rel="stylesheet" />
    <link href="../Estilos/GestionEstudiantes.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br />
        <div class="mx-auto" style="width:300px">
            <h2>Listado De Grupos</h2>
        </div>
        <br />
        <div class="container">
            <div class="">
                <div class="dropsClasesgrupos">
                   <asp:DropDownList runat="server" ID="dropClases" AutoPostBack="true" CssClass="form-control dropClases"  OnSelectedIndexChanged="dropClases_SelectedIndexChanged" ></asp:DropDownList>
                </div>
                <div class="dropsClasesgrupos">
                   <asp:DropDownList runat="server" ID="dropGrupos" AutoPostBack="true" CssClass="form-control dropClases"  OnSelectedIndexChanged="dropGrupos_SelectedIndexChanged" ></asp:DropDownList>
                </div>
                <div class="">
                    <asp:TextBox runat="server" ID="tbCantidadCCoins" CssClass="form-control form"  TextMode="Number"></asp:TextBox>
                </div>
                <br />
                <div class="">
                    <asp:Button runat="server" ID="btnAgregar" Text="Agregar" CssClass="btn btn-success" OnClick="btnAgregar_Click" />
                </div>
            </div>
        </div>
        <br />
</asp:Content>
