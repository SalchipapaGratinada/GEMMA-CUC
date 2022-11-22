<%@ Page Title="" Language="C#" MasterPageFile="~/MpProfesor.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="CrudGrupos.aspx.cs" Inherits="Gemma.Pages.CrudGrupos" %>
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

    <div class="contenedorGrupos">
        <div class="mb-3">
            <label class="form-label">Nombre Grupo</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="tbNombreGrupo"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label class="form-label">Tamaño</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="tbTamaño" TextMode="Number"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label class="form-label">Clases</label>
            <asp:DropDownList runat="server" ID="drupClases" CssClass="btn form-control"></asp:DropDownList>
        </div>

        <asp:Button runat="server" CssClass="btn btn-success" ID="BtnCreate" Text="Create" Visible="false" OnClick="BtnCreate_Click"/>
        <asp:Button runat="server" CssClass="btn btn-warning" ID="BtnUpdate" Text="Update" Visible="false" OnClick="BtnUpdate_Click"/>
        <asp:Button runat="server" CssClass="btn btn-danger" ID="BtnDelete" Text="Delete" Visible="false" OnClick="BtnDelete_Click" OnClientClick="return confirm('¿Esta Seguro Que Desea Eliminar El Grupo?');"/>
        <asp:Button runat="server" CssClass="btn btn-primary btn-dark" ID="BtnBack" Text="Back" Visible="True" OnClick="BtnBack_Click" />
    </div>


</asp:Content>
