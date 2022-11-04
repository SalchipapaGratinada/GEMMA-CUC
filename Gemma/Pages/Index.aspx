<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Gemma.Pages.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-Zenh87qX5JnK2Jl0vWa8Ck2rdkQ2Bzep5IDxbcnCeuOxjzrPF/et3URy9Bv1WTRi" crossorigin="anonymous" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
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
        <div class="col-sm-6">
            <div class="card">
                <div class="card-body">
                    <form runat="server">
                        <div class="mb-3" style="align-items:center">
                            <label style="font-size:5rem; font-family:Italic">GEMMA</label>
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
        <div class="card">
            <div class="card-body">
                <h5 class="card-title">Special title treatment</h5>
                <p class="card-text">With supporting text below as a natural lead-in to additional content.</p>
                <a href="#" class="btn btn-primary">Go somewhere</a>
            </div>
        </div>
    </div>
    </div>


</body>
</html>
