<%@ Page Title="" Language="C#" MasterPageFile="~/MpEstudiante.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="EstClases.aspx.cs" Inherits="Gemma.Pages.EstClases" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/jquery-3.6.1.min.js"></script>
    <script src="../Script/loginRegister.js"></script>
    <script src="../Scripts/toastr.js"></script>
    <link href="../content/toastr.css" rel="stylesheet" />
    <link href="../Estilos/LoginAndRegister.css" rel="stylesheet" />
    <link href="../Estilos/GestionEstudiantes.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container row">
        <div class="table small">
            <asp:GridView runat="server" ID="gvuClases" class="table table-borderless table-hover">
                <Columns>
                    <asp:TemplateField HeaderText="Opciones De Administrador">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnInfo" Text="Info" class="btn form-control-sm btn-info" OnClick="btnInfo_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>
