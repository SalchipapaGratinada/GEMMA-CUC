<%@ Page Title="" Language="C#" MasterPageFile="~/MpProfesor.Master" AutoEventWireup="true" CodeBehind="GestionarClase.aspx.cs" Inherits="Gemma.Pages.GestionarClase" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Script/loginRegister.js"></script>
    <script src="../Scripts/toastr.js"></script>
    <script src="../Scripts/toastr.min.js"></script>
    <link href="../content/toastr.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <br />
        <div class="mx-auto" style="width:300px">
            <h2>Listado De Clases</h2>
        </div>
        <br />
        <div class="container">
            <div class="row">
                <div class="col align-self-end">
                    <asp:Button runat="server" ID="btnCrear" CssClass="btn btn-success form-control-sm " Text="Crear" OnClick="btnCrear_Click" />
                </div>
            </div>
        </div>
        <br />
        <div class="container row">
            <div class="table small">
                <asp:GridView runat="server" ID="gvuClases" class="table table-borderless table-hover">
                    <Columns>
                        <asp:TemplateField HeaderText="Opciones De Administrador">
                            <ItemTemplate>
                                <asp:Button runat="server" ID="BtnRead" Text="Read" class="btn form-control-sm btn-info" OnClick="BtnRead_Click" />
                                <asp:Button runat="server" ID="BtnUpdate" Text="Update" class="btn form-control-sm btn-warning" OnClick="BtnUpdate_Click" />
                                <asp:Button runat="server" ID="BtnDelete" Text="Delete" class="btn form-control-sm btn-danger" OnClick="BtnDelete_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>



</asp:Content>
