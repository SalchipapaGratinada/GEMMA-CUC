<%@ Page Title="" Language="C#" MasterPageFile="~/MpProfesor.Master" AutoEventWireup="true" CodeBehind="GestionarEstudiantes.aspx.cs" Inherits="Gemma.Pages.GestionarEstudiantes" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/jquery-3.6.1.min.js"></script>
    <script src="../Script/loginRegister.js"></script>
    <script src="../Scripts/toastr.js"></script>
    <link href="../content/toastr.css" rel="stylesheet" />
    <link href="../Estilos/LoginAndRegister.css" rel="stylesheet" />
    <link href="../Estilos/GestionEstudiantes.css" rel="stylesheet" />
    <link href="../Estilos/EGestionarClase.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
        <div class="mx-auto" style="width:300px">
            <h2>Listado De Estudiantes</h2>
        </div>
        <br />
        <div class="container">
            <div class="">
                <div class="dropsClasesgrupos">
                   <asp:DropDownList runat="server" AutoPostBack="true" ID="dropClases" CssClass=" form-control dropClases"  OnSelectedIndexChanged="dropClases_SelectedIndexChanged" ></asp:DropDownList>
                </div>
                <div class="contenedorBusqueda">
                    <asp:TextBox runat="server" ID="tbBuscar" CssClass="form-control"></asp:TextBox>
                    <asp:Button runat="server" ID="btnBuscar" Text="Buscar" CssClass="btn btn-lg btn-success form-control-sm" OnClick="btnBuscar_Click" />
                </div>
            </div>
        </div>
    <br />
    <div class="container row">
        <div class="table small">
            <div style="overflow:auto; height:400px">
                <asp:GridView runat="server" ID="gvuEstudiantes" class="table table-borderless table-hover">
                    <Columns>
                        <asp:TemplateField HeaderText="Opciones De Administrador">
                            <ItemTemplate>
                                <asp:Button runat="server" ID="BtnRead" Text="Info" class="btn btn-lg form-control-sm btn-info" OnClick="BtnRead_Click" />
                                <asp:Button runat="server" ID="BtnAñadir" Text="Añadir" class="btn btn-lg form-control-sm btn-primary" OnClick="BtnAñadir_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            </div>
        </div>

</asp:Content>
