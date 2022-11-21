<%@ Page Title="" Language="C#" MasterPageFile="~/MpProfesor.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="SolicitudesPremios.aspx.cs" Inherits="Gemma.Pages.SolicitudesPremios" %>

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
        <h2>Listado De Clases</h2>
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
            <asp:GridView runat="server" ID="gvuSolicitudes" class="table table-borderless table-hover">
                <Columns>
                    <asp:TemplateField HeaderText="Opciones De Administrador">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="BtnDelete" Text="Delete" class="btn form-control-sm btn-danger" OnClick="BtnDelete_Click" OnClientClick="return confirm('¿Esta Seguro Que Desea Eliminar La Solicitud?');" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
