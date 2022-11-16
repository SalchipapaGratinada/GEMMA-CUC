﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MpProfesor.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="CrudClases.aspx.cs" Inherits="Gemma.Pages.CrudClases" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/jquery-3.6.1.min.js"></script>
    <script src="../Script/loginRegister.js"></script>
    <script src="../Scripts/toastr.js"></script>
    <link href="../content/toastr.css" rel="stylesheet" />
    <link href="../Estilos/LoginAndRegister.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <div class="mx-auto" style="width: 250px">
        <asp:Label runat="server" CssClass="h2" ID="lbltitulo"></asp:Label>
    </div>

    <div class="contenedorClases">
        <div class="mb-3">
            <label class="form-label">Nombre Clase</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="tbNombreClase"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label class="form-label">Codigo</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="tbCodigo"></asp:TextBox>
        </div>
        <asp:Button runat="server" CssClass="btn btn-success" ID="BtnCreate" Text="Create" Visible="false" OnClick="BtnCreate_Click"/>
        <asp:Button runat="server" CssClass="btn btn-warning" ID="BtnUpdate" Text="Update" Visible="false" OnClick="BtnUpdate_Click" />
        <asp:Button runat="server" CssClass="btn btn-danger" ID="BtnDelete" Text="Delete" Visible="false"  OnClick="BtnDelete_Click" OnClientClick="return confirm('¿Esta Seguro Que Desea Eliminar La Clase?');" />
        <asp:Button runat="server" CssClass="btn btn-primary btn-dark" ID="BtnBack" Text="Back" Visible="True" OnClick="BtnBack_Click" />
    </div>


</asp:Content>
