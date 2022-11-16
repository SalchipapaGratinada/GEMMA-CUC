<%@ Page Title="" Language="C#" MasterPageFile="~/MpProfesor.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="CCoinsEstudiante.aspx.cs" Inherits="Gemma.Pages.CCoinsEstudiante" %>

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
            <h2>Listado De Estudiantes En Clases</h2>
        </div>
        <br />
        <div class="container">
            <div class="">
                <div class="dropsClasesgrupos">
                   <asp:DropDownList runat="server" AutoPostBack="true" ID="dropClases" CssClass="form-control dropClases" OnSelectedIndexChanged="dropClases_SelectedIndexChanged"  ></asp:DropDownList>
                    <asp:DropDownList runat="server" AutoPostBack="true" ID="dropGrupo" CssClass="form-control dropGrupos" OnSelectedIndexChanged="dropGrupo_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div class="dropsClasesgrupos">
                    <asp:TextBox runat ="server" ID="tbCantidad" CssClass="form-control form" TextMode="Number"></asp:TextBox>
                </div>
            </div>
        </div>
        <br />
        <div class="container row">
            <div class="table small">
                <asp:GridView runat="server" ID="gvuEstudiantes" class="table table-borderless table-hover">
                    <Columns>
                        <asp:TemplateField HeaderText="Opciones De Administrador">
                            <ItemTemplate>
                                <asp:Button runat="server" ID="btnAñadir" Text="Añadir" class="btn form-control-sm btn-success" OnClick="btnAñadir_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>

</asp:Content>
