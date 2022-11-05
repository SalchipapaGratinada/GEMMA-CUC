<%@ Page Title="" Language="C#" MasterPageFile="~/MpLoginAndRegister.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Gemma.Pages.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="titulo" runat="server">
    Register 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/jquery-3.6.1.min.js"></script>
    <link href="../Estilos/LoginAndRegister.css" rel="stylesheet" />
    <script src="../Script/loginRegister.js"></script>
    <link href="../content/toastr.css" rel="stylesheet" />
    <script src="../Scripts/toastr.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >

    <div class="tituloRegistro">
        <h2>UNETE A GEMMA!! - TE DAREMOS 200 SETCOINS!</h2>
    </div>
    <form runat="server" class="formRegistro">
        <div>
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="tbnombre"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Apellido</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="tbApellido"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">NickName</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="tbNickName"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">PassWord</label>
                <asp:TextBox runat="server" TextMode="Password" CssClass="form-control" ID="tbPassword"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Repita PassWord</label>
                <asp:TextBox runat="server" TextMode="Password" CssClass="form-control" ID="tbConfirmacionPassword"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label">Correo Electronico</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="tbEmail"></asp:TextBox>
            </div>
            <asp:Button runat="server" CssClass="btn btn-primary" ID="btnRegistrar" Text="Registrar" OnClick="btnRegistrar_Click" />
            <asp:Button runat="server" CssClass="btn btn-secondary" ID="btnClear" Text="Clear" OnClick="btnClear_Click" />
        </div>
    </form>

</asp:Content>
