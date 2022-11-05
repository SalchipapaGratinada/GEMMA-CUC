<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Gemma.Pages.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-Zenh87qX5JnK2Jl0vWa8Ck2rdkQ2Bzep5IDxbcnCeuOxjzrPF/et3URy9Bv1WTRi" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.6/dist/umd/popper.min.js" integrity="sha384-oBqDVmMz9ATKxIep9tiCxS/Z9fNfEXiDAYTujMAeBAsjFuCZSmKbSSUnQlmh/jp3" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/js/bootstrap.min.js" integrity="sha384-IDwe1+LCz02ROU9k972gdyvl+AESN10+x7tBKgc9I5HFtuNz0wWnPclzo6p9vxnk" crossorigin="anonymous"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../Scripts/jquery-3.6.1.min.js"></script>
    <script src="../Script/loginRegister.js"></script>
    <script src="../Scripts/toastr.js"></script>
    <link href="../content/toastr.css" rel="stylesheet" />
    <link href="../Estilos/LoginAndRegister.css" rel="stylesheet" />
    <title></title>
</head>
<body class="cuerpo">
    <nav class="navbar bg-light">
        <div class="container-fluid">
            <a class="navbar-brand">GEMMA - UNIVERSIDAD DE LA COSTA</a>
            <form class="d-flex" role="search">
                <input class="form-control me-2" type="search" placeholder="Buscar..." aria-label="Search" />
                <a class="btn btn-outline-success" href="index.aspx">Login</a>
                <a class="btn btn-outline-primary" href="Register.aspx">Registrar</a>
            </form>
        </div>
    </nav>
    <br />
    <br />
    <div class="row">
        <div class="col-sm-5">
            <div class="card">
                <div class="card-body">
                    <form runat="server">
                        <div class="mb-3" style="align-items: center">
                            <label style="font-size: 5rem; font-family:'Maiandra GD'">GEMMA</label>
                        </div>
                        <div class="mb-3">
                            <label class="form-label">Usuario</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="tbusuario"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label class="form-label">PassWord</label>
                            <asp:TextBox runat="server" TextMode="Password" CssClass="form-control" ID="tbpassword"></asp:TextBox>
                        </div>
                        <asp:Button runat="server" CssClass="btn btn-primary" ID="btnIniciarSecion" Text="Entrar" Visible="true" OnClick="btnIniciarSecion_Click" />
                    </form>
                </div>
            </div>
        </div>
        <div class="col-sm-6">
            <div id="carouselExampleControls" class="carousel slide" data-bs-ride="carousel">
                <div class="carousel-inner">
                    <div class="carousel-item active">
                        <img src="/Images/inicio3.jpg" class="d-block w-100" alt="..."/>
                    </div>
                    <div class="carousel-item">
                        <img src="/Images/inicio2.jpg" class="d-block w-100" alt="..."/>
                    </div>
                    <div class="carousel-item">
                        <img src="/Images/inicio.jpg" class="d-block w-100" alt="..."/>
                    </div>
                </div>
                <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Previous</span>
                </button>
                <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Next</span>
                </button>
            </div>
        </div>
    </div>
</body>
</html>
