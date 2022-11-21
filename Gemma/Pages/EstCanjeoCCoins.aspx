<%@ Page Title="" Language="C#" MasterPageFile="~/MpEstudiante.Master" EnableEventValidation="false"
 AutoEventWireup="true" CodeBehind="EstCanjeoCCoins.aspx.cs" Inherits="Gemma.Pages.EstCanjeoCCoins" %>

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
    <div class="mx-auto" style="width: 300px">
        <h2>Listado De Premios</h2>
    </div>
    <br />
    <div class="container">
        <div class="dropsClasesgrupos">
            <asp:DropDownList runat="server" AutoPostBack="true" ID="dropClases" CssClass="form-control dropClases" OnSelectedIndexChanged="dropClases_SelectedIndexChanged"></asp:DropDownList>
        </div>
    </div>
    <br />
    <div class="container row">
        <div class="table small">
            <asp:GridView runat="server" ID="gvuPremios" class="table table-borderless table-hover">
                <Columns>
                    <asp:TemplateField HeaderText="Opciones De Administrador">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnCanjear" Text="Canjear" class="btn form-control-sm btn-success" OnClick="btnCanjear_Click" OnClientClick="return confirm('¿Esta Seguro Que Desea Canjear El Premio?');" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>
