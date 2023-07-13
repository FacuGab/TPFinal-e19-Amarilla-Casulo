<%@ Page Title="Registrarse" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Catalogo.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="scripts/validaciones.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main aria-labelledby="title">
        <section class="vh-100" style="background-image:url(https://static.vecteezy.com/system/resources/previews/002/490/551/original/abstract-technology-geometric-overlapping-hi-speed-line-movement-design-background-with-copy-space-for-text-free-vector.jpg);">
            <div class="container h-100 ">
                <div class="row d-flex justify-content-center align-items-center h-100">
                    <div class="col-lg-12 col-xl-11">
                        <div class="card text-light " style="border-radius: 25px; background-image:url(https://img3.wallspic.com/crops/9/3/0/4/6/164039/164039-banner_de_contraccion_de_la_galaxia-contraccion_nerviosa-banner_web-streaming_de_medios_de_comunicacion-gamer-3840x2160.png)">

                            <!-- CARD REGISTRO -->
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <div class="card-body p-md-5">
                                        <div class="row justify-content-center">
                                            <div class="col-md-10 col-lg-6 col-xl-5 order-2 order-lg-1">
                                                <p class="text-center h1 fw-bold mb-5 mx-1 mx-md-4 mt-4">Nuevo usuario</p>

                                                <div class="mx-1 mx-md-4" id="form">

                                                    <div class="d-flex flex-row align-items-center mb-4">
                                                        <div class="input-group">
                                                            <span class="input-group-text mb-1"><i class="bi bi-person-fill"></i></span>
                                                            <div class="form-floating flex-fill mb-1">
                                                                <asp:TextBox type="text" class="form-control" runat="server" ID="txtNombre" required/>
                                                                <label type="text" for="txtNombre" class="text-dark">Nombre/s</label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="d-flex flex-row align-items-center mb-4">
                                                        <div class="input-group">
                                                            <span class="input-group-text mb-1"><i class="bi bi-person-fill"></i></span>
                                                            <div class="form-floating flex-fill mb-1">
                                                                <asp:TextBox type="text" class="form-control" runat="server" ID="txtApellido" required/>
                                                                <label type="text" for="txtApellido" class="text-dark">Apellido/s</label>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="d-flex flex-row align-items-center mb-4">
                                                        <div class="input-group">
                                                            <span class="input-group-text mb-1"><i class="bi bi-123"></i></span>
                                                            <div class="form-floating flex-fill mb-1">
                                                                <asp:TextBox type="text" class="form-control" runat="server" ID="txtDni" required/>
                                                                <label type="text" for="txtDni" class="text-dark">Documento Nacional de identidad</label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="d-flex flex-row align-items-center mb-4">
                                                        <div class="input-group ">
                                                            <span class="input-group-text mb-1"><i class="bi bi-envelope-at-fill"></i></span>
                                                            <div class="form-floating flex-fill mb-1">
                                                                <asp:TextBox type="email" class="form-control" runat="server" ID="txtMail" required/>
                                                                <label type="email" for="txtMail" class="text-dark">Correo electrónico</label>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="d-flex flex-row align-items-center mb-4">
                                                        <div class="input-group ">
                                                            <span class="input-group-text mb-1"><i class="bi bi-house-door-fill"></i></span>
                                                            <div class="form-floating flex-fill mb-1">
                                                                <asp:TextBox type="text" class="form-control" runat="server" ID="txtDomicilio" required/>
                                                                <label type="text" for="txtDomicilio" class="text-dark">Domicilio</label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <%--<div class="d-flex flex-row align-items-center mb-4">
                                                        <div class="input-group ">
                                                            <span class="input-group-text mb-1"><i class="bi bi-person-fill "></i></span>
                                                            <div class="form-floating flex-fill mb-1">
                                                                <asp:TextBox Enabled="false" class="form-control" runat="server" ID="txtTipoUsuario" Text="C" MaxLength="1" />
                                                                <label type="text" for="txttipousuario" class="text-dark">Tipo de usuario</label>
                                                            </div>
                                                        </div>
                                                    </div>--%>
                                                    <div class="d-flex flex-row align-items-center mb-4">
                                                        <div class="input-group ">
                                                            <span class="input-group-text mb-1"><i class="bi bi-key-fill"></i></span>
                                                            <div class="form-floating flex-fill mb-1">
                                                                <asp:TextBox type="password" class="form-control" runat="server" ID="txtPassword" required/>
                                                                <label type="text" for="txtPassword" class="text-dark">Contraseña</label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="d-flex justify-content-center ">
                                                        <asp:Button Text="Registrarse" runat="server" ID="btnRegistroUsu" OnClick="btnRegistroUsu_Click"  CssClass="btn btn-warning btn-lg flex-fill" ValidationGroup="GuardarUsuario"/>
                                                    </div>
                                                    <%--validaciones--%>
                                                    <asp:UpdatePanel runat="server">
                                                        <ContentTemplate>
                                                            <asp:ValidationSummary runat="server" ID="validationSummary" ValidationGroup="GuardarUsuario" CssClass="validation-summary fw-bold text-danger mt-5 col-form-label bg-light border rounded-3 " />
                                                            <asp:CustomValidator runat="server" ID="customValidatorNombre" ControlToValidate="txtNombre" OnServerValidate="customValidatorNombre_ServerValidate" ValidationGroup="GuardarUsuario" ErrorMessage="El nombre es inválido" />
                                                            <asp:CustomValidator runat="server" ID="customValidatorApellido" ControlToValidate="txtApellido" OnServerValidate="customValidatorApellido_ServerValidate" ValidationGroup="GuardarUsuario" ErrorMessage="El apellido es inválido" />
                                                            <asp:CustomValidator runat="server" ID="customValidatorDocumento" ControlToValidate="txtDni" OnServerValidate="customValidatorDocumento_ServerValidate" ValidationGroup="GuardarUsuario" ErrorMessage="El número de documento es inválido" />
                                                            <asp:CustomValidator runat="server" ID="customValidatorMail" ControlToValidate="txtMail" OnServerValidate="customValidatorMail_ServerValidate" ValidationGroup="GuardarUsuario" ErrorMessage="El correo electrónico es inválido" />
                                                            <asp:CustomValidator runat="server" ID="customValidatorDomicilio" ControlToValidate="txtDomicilio" OnServerValidate="customValidatorDomicilio_ServerValidate" ValidationGroup="GuardarUsuario" ErrorMessage="El domicilio es inválido" />
                                                            <asp:CustomValidator runat="server" ID="customValidatorPassword" ControlToValidate="txtPassword" OnServerValidate="customValidatorPassword_ServerValidate" ValidationGroup="GuardarUsuario" ErrorMessage="La contraseña es inválida" />

                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                    <%--validaciones--%>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <!-- CARD REGISTRO -->

                        </div>
                    </div>
                </div>
            </div>
        </section>
    </main>

</asp:Content>