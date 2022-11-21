<%@ Page Title="" Language="C#" MasterPageFile="~/MpProfesor.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="CrudPremios.aspx.cs" Inherits="Gemma.Pages.CrudPremios" %>

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
    <div class="mx-auto" style="width: 250px">
        <asp:Label runat="server" CssClass="h2" ID="lbltitulo"></asp:Label>
    </div>

    <div class="contenedorClases">
        <div class="mb-3">
            <label class="form-label">Nombre</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="tbNombre"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label class="form-label">Costo</label>
            <asp:TextBox runat="server" TextMode="Number" CssClass="form-control" ID="tbCosto"></asp:TextBox>
        </div>
        <asp:Button runat="server" CssClass="btn btn-success" ID="BtnCreate" Text="Create" Visible="false" OnClick="BtnCreate_Click" />
        <asp:Button runat="server" CssClass="btn btn-danger" ID="BtnDelete" Text="Delete" Visible="false" OnClick="BtnDelete_Click" OnClientClick="return confirm('¿Esta Seguro Que Desea Eliminar El Premio?');" />
         <asp:Button runat="server" CssClass="btn btn-danger" ID="btnActualizar" Text="Update" Visible="false" OnClick="btnActualizar_Click" />
        <asp:Button runat="server" CssClass="btn btn-primary btn-dark" ID="BtnBack" Text="Back" Visible="True" OnClick="BtnBack_Click" />
    </div>

</asp:Content>
