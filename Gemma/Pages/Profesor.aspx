<%@ Page Title="" Language="C#" MasterPageFile="~/MpProfesor.Master" EnableEventValidation="false"
 AutoEventWireup="true" CodeBehind="Profesor.aspx.cs" Inherits="Gemma.Pages.Profesor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/jquery-3.6.1.min.js"></script>
    <script src="../Script/loginRegister.js"></script>
    <script src="../Scripts/toastr.js"></script>
    <link href="../content/toastr.css" rel="stylesheet" />
    <link href="../Estilos/LoginAndRegister.css" rel="stylesheet" />
    <link href="../Estilos/GestionEstudiantes.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%-- <p>Aqui Va Todo Lo Del Profesor</p>

    <asp:Label runat="server" ID="lblusuario"></asp:Label>
    <asp:Label runat="server" ID="lblid"></asp:Label>
    <asp:Button runat="server" Text="PRobar" CssClass="btn btn-success" ID="btnprueba" OnClick="btnprueba_Click"/>--%>
    <div id="carouselExampleCaptions" class="carousel slide" data-bs-ride="false">
        <div class="carousel-indicators">
            <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
            <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="1" aria-label="Slide 2"></button>
            <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="2" aria-label="Slide 3"></button>
        </div>
        <div class="carousel-inner">
            <div class="carousel-item active">
                <img src="/Images/PPG.png" class="d-block w-100" alt="...">
                <div class="carousel-caption d-none d-md-block" style="color:black;font-size:3rem;">
                    <h1>Bienvenidos</h1>
                    <p>GEMMA - CUC Sistema de gamificacion.</p>
                </div>
            </div>
            <div class="carousel-item">
                <img src="/Images/PPG2.jpg" class="d-block w-100" alt="...">
                <div class="carousel-caption d-none d-md-block" style="color:black;font-size:3rem;">
<%--                    <h1>Bienvenidos</h1>
                    <p>GEMMA - CUC Sistema de gamificacion.</p>--%>
                </div>
            </div>
            <div class="carousel-item">
                <img src="/Images/PPG3.jpg" class="d-block w-100" alt="...">
                <div class="carousel-caption d-none d-md-block" style="color:black;font-size:3rem;">
<%--                    <h1>Bienvenidos</h1>
                    <p>GEMMA - CUC Sistema de gamificacion.</p>--%>
                </div>
            </div>
        </div>
        <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Previous</span>
        </button>
        <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Next</span>
        </button>
    </div>


</asp:Content>
