<%@ Page Title="" Language="C#" MasterPageFile="~/MpProfesor.Master" AutoEventWireup="true" CodeBehind="Profesor.aspx.cs" Inherits="Gemma.Pages.Profesor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <p>Aqui Va Todo Lo Del Profesor</p>

    <asp:Label runat="server" ID="lblusuario"></asp:Label>
    <asp:Label runat="server" ID="lblid"></asp:Label>
    <asp:Button runat="server" Text="PRobar" CssClass="btn btn-success" ID="btnprueba" OnClick="btnprueba_Click"/>


</asp:Content>
