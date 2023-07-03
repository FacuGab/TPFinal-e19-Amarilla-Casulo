<%@ Page Title="Panel De Control" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Catalogo.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="row flex-nowrap">

            <!-- Barra de Opciones -->
            <div class="col-auto col-md-3 col-xl-2 px-sm-2 px-0 bg-dark">
                <div class="d-flex flex-column align-items-center align-items-sm-start px-3 pt-2 text-white min-vh-100">
                    <a href="/" class="d-flex align-items-center pb-3 mb-md-0 me-md-auto text-white text-decoration-none"></a>
                    <ul class="nav nav-pills flex-column mb-sm-auto mb-0 align-items-center align-items-sm-start mt-5" id="menu">
                        <li class="nav-item mt-5">
                            <a href="Admin.aspx" class="nav-link align-middle px-0">
                                <i class="fs-3 bi-house text-warning"></i><span class="ms-1 d-none d-sm-inline text-light fs-5 ms-2">Inicio</span>
                            </a>
                        </li>
                        <li>
                            <!-- Menu Pedidos -->
                            <a href="#submenu2" data-bs-toggle="collapse" class="nav-link px-0 align-middle">
                                <i class="fs-3 bi-table text-warning"></i><span class="ms-1 d-none d-sm-inline text-light fs-5 ms-2">Pedidos</span></a>
                            <ul class="collapse nav flex-column ms-1 " id="submenu2" data-bs-parent="#menu">
                                <li class="w-100 ">
                                    <a href="Admin.aspx?id=1" class="nav-link px-0"><span class="d-none d-sm-inline text-light ms-4">Pedidos realizados</span></a>
                                </li>
                                <li>
                                    <a href="Admin.aspx?id=2" class="nav-link px-0"><span class="d-none d-sm-inline text-light ms-4">Todos los pedidos</span></a>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <!-- Menu Articulos, Marcas y Categorias -->
                            <a href="#submenu3" data-bs-toggle="collapse" class="nav-link px-0 align-middle">
                                <i class="fs-3 bi-grid text-warning"></i><span class="ms-1 d-none d-sm-inline text-light fs-5 ms-2">Artículos</span> </a>
                            <ul class="collapse nav flex-column ms-1 " id="submenu3" data-bs-parent="#menu">
                                <li class="w-100 ">
                                    <a href="Admin.aspx?id=3" class="nav-link px-0"><span class="d-none d-sm-inline text-light ms-4">Marcas</span></a>
                                </li>
                                <li class="w-100">
                                    <a href="Admin.aspx?id=4" class="nav-link px-0"><span class="d-none d-sm-inline text-light ms-4">Categorias</span></a>
                                </li>
                                <li>
                                    <a href="Admin.aspx?id=5" class="nav-link px-0"><span class="d-none d-sm-inline text-light ms-4">Todos los artículos</span></a>
                                </li>
                                <li>
                                    <a href="Agregar.aspx" class="nav-link px-0"><span class="d-none d-sm-inline text-light ms-4">Nuevo artículo</span></a>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <!-- Menu Usuarios -->
                            <a href="#submenu4" data-bs-toggle="collapse" class="nav-link px-0 align-middle">
                                <i class="fs-3 bi-people text-warning"></i><span class="ms-1 d-none d-sm-inline text-light fs-5 ms-2">Usuarios</span> </a>
                            <ul class="collapse nav flex-column ms-1 " id="submenu4" data-bs-parent="#menu">
                                <li class="w-100 ">
                                    <a href="Admin.aspx?id=6" class="nav-link px-0"><span class="d-none d-sm-inline text-light ms-4">Todos</span></a>
                                </li>
                                <li>
                                    <asp:Button Text="Crear Nuevo Usuario" ID="btnAgregarNuevoUsuario" OnClick="btnAgregarNuevoUsuario_Click" CssClass="nav-link px-0 d-none d-sm-inline text-light ms-4" runat="server" />
                                </li>
                            </ul>
                        </li>
                    </ul>
                    <hr>
                    <!-- Menu Pedidos -->
                    <div class="dropdown pb-4">
                        <a href="#" class="d-flex align-items-center text-white text-decoration-none dropdown-toggle" id="dropdownUser1" data-bs-toggle="dropdown" aria-expanded="false">
                            <img src="https://github.com/mdo.png" alt="hugenerd" width="30" height="30" class="rounded-circle">
                            <span class="d-none d-sm-inline mx-1">loser</span>
                        </a>
                        <ul class="dropdown-menu dropdown-menu-dark text-small shadow">
                            <li><a class="dropdown-item" href="#">New project...</a></li>
                            <li><a class="dropdown-item" href="#">Settings</a></li>
                            <li><a class="dropdown-item" href="#">Profile</a></li>
                            <li>
                                <hr class="dropdown-divider">
                            </li>
                            <li>
                                <asp:Button Text="Sing Out" ID="btnSingOutMenuAdmin" OnClick="btnSingOutMenuAdmin_Click" CssClass="dropdown-item" runat="server" />
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
            <!--FIn Barra de Opciones -->
            <div class="col-md-1"></div>

            <!-- Cuerpo Principal -->
            <div class="col-md-8 mt-5"  background-image: url(https://img3.wallspic.com/crops/9/3/0/4/6/164039/164039-banner_de_contraccion_de_la_galaxia-contraccion_nerviosa-banner_web-streaming_de_medios_de_comunicacion-gamer-3840x2160.png)">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>

                        <%-- ################################ abm USUARIOS ################################ --%>
                        <%-- Listar Usuarios --%>
                        <asp:GridView ID="dgvAdminUsuario" runat="server" CssClass="table table-striped mt-5 " AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField HeaderText="ID">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nombre">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Apellido">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# Eval("Apellido") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DNI">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# Eval("DNI") %>' CssClass="mt-3"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Mail">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# Eval("Mail") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Direccion" DataField="Direccion" />
                                <asp:BoundField HeaderText="Activo" DataField="MostrarActivo" />
                                <asp:BoundField HeaderText="Nivel" DataField="NivelUpper" />
                                <asp:TemplateField HeaderText="Editar">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibtEditarUsuario" CssClass="mt-3" runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="editar_btn" OnClick="ibtEditarUsuario_Click" Height="29px" ImageUrl="~/recursos/img/editar.png" Width="29px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cambiar Activo">
                                    <ItemTemplate>
                                        <asp:Button Text="Baja" CssClass="btn btn-danger" CommandName="baja_btn" OnClick="btnBajaUsuario_Click" CommandArgument='<%#Eval("Id") %>' runat="server" />
                                        <asp:Button Text="Alta" CssClass="btn btn-info" CommandName="alta_btn" OnClick="btnAltaUsuario_Click" CommandArgument='<%#Eval("Id") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <%-- Fin Listar Usuarios --%>

                        <%-- Modificar/Agregar Usuarios --%>
                        <asp:UpdatePanel ID="updatePanelModificarUsuario" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <section class="vh-100" style="background-color: #f4f5f7;" runat="server" id="sectionModificarUsuario">
                                    <div class="container py-5 h-100">
                                        <!-- Card Usuarios -->
                                        <div class="row d-flex justify-content-center align-items-center h-100">
                                            <div class="col col-lg-8 mb-4 mb-lg-0 ">
                                                <div class="card mb-3" style="border-radius: .5rem;">
                                                    <div class="row g-0">
                                                        <!-- Columna de Imagen -->
                                                        <div class="col-md-4  text-center bg-warning text-white"
                                                            style="border-top-left-radius: .5rem; border-bottom-left-radius: .5rem;">
                                                            <asp:Image ID="userImg" runat="server" ImageUrl="~/recursos/img/avatar.png" Width="120px" CssClass="img-fluid my-5" />
                                                            <h6>
                                                                <!-- ID Usuario -->
                                                                <strong class="fs-5 text-dark">
                                                                    ID Usuario
                                                                    <asp:Label runat="server" ID="txtId" />
                                                                </strong> 
                                                            </h6>
                                                            <i class="far fa-edit mb-5"></i>
                                                        </div>
                                                        <!-- Columna de Inputs -->
                                                        <div class="col-md-8">
                                                            <div class="card-body p-4">
                                                                <h6>Información del usuario</h6>
                                                                <hr class="mt-0 mb-4">
                                                                <div class="row pt-1">
                                                                    <!-- Nombre -->
                                                                    <div class="col-6 mb-3">
                                                                        <h6>Nombre/s</h6>
                                                                        <asp:TextBox runat="server" ID="txtNombre" CssClass="text-muted form-control" required minlength="1" MaxLength="30" pattern="[A-Za-z\s]+" />
                                                                    </div>
                                                                    <!-- Apellido -->
                                                                    <div class="col-6 mb-3">
                                                                        <h6>Apellido/s</h6>
                                                                        <asp:TextBox runat="server" ID="txtApellido" CssClass="text-muted form-control" required minlength="1" MaxLength="30" pattern="[A-Za-z\s]+" />
                                                                    </div>
                                                                    <!-- MAIL -->
                                                                    <div class="col-6 mb-3">
                                                                        <h6>Email</h6>
                                                                        <asp:TextBox runat="server" ID="txtEmail" CssClass="text-muted form-control" required />
                                                                    </div>
                                                                    <!-- DNI -->
                                                                    <div class="col-6 mb-3">
                                                                        <h6>Nro. Documento</h6>
                                                                        <asp:TextBox type="number" runat="server" ID="txtDni" CssClass="text-muted form-control" required pattern="\d{8}" />
                                                                    </div>
                                                                </div>
                                                                <h6>Contacto</h6>
                                                                <hr class="mt-0 mb-4">
                                                                <div class="row pt-1">
                                                                    <!-- PASS -->
                                                                    <div class="col-6 mb-3">
                                                                        <h6>Contraseña</h6>
                                                                        <asp:TextBox type="password" runat="server" ID="txtClave" CssClass="text-muted form-control" required minlength="6" MaxLength="20" />
                                                                        <%--patron para solo aceptar claves con un mayus, numeros y minusculas    pattern="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$"    --%>
                                                                    </div>
                                                                    <!-- DIR -->
                                                                    <div class="col-6 mb-3">
                                                                        <h6>Dirección</h6>
                                                                        <asp:TextBox runat="server" ID="txtDomicilio" CssClass="text-muted form-control" required minlength="6" MaxLength="100" pattern="[A-Za-z0-9\s.,-]+" />
                                                                    </div>
                                                                    <!-- IMG -->
                                                                    <div class="col-6 mb-3">
                                                                        <h6>Imágen de perfil</h6>
                                                                        <asp:TextBox runat="server" ID="txtUrl" CssClass="text-muted form-control" OnTextChanged="txtUrl_TextChanged" />
                                                                    </div>
                                                                    <!-- NIVEL -->
                                                                    <div class="col-6 mb-3">
                                                                        <h6>Nivel de usuario</h6>
                                                                        <asp:TextBox runat="server" ID="txtTipoUsuario" CssClass="text-muted form-control" required minlength="1" MaxLength="1" pattern="[A-Za-z]+" />
                                                                    </div>
                                                                </div>
                                                                <!-- Botones -->
                                                                <div class="d-flex justify-content-end">
                                                                    <asp:Button Text="Dar de alta" runat="server" ID="btnAltaUsuario" OnClick="btnAltaUsuario_Click" CssClass="btn btn-outline-success mt-3 me-3" />
                                                                    <asp:Button Text="Dar de baja" runat="server" ID="btnBajaUsuario" OnClick="btnBajaUsuario_Click" CssClass="btn btn-outline-danger mt-3 me-3" />
                                                                    <asp:Button Text="Eliminar" runat="server" ID="btnEliminarUsuario" OnClick="btnEliminarUsuario_Click" CssClass="btn btn-danger mt-3 me-3" />
                                                                    <asp:Button Text="Guardar Cambios" runat="server" ID="btnGuardarUsuario" OnClick="btnGuardarUsuario_Click" CssClass="btn btn-dark mt-3" />
                                                                </div>
                                                                <!-- Link Volver a Lista Usuarios (TEST) -->
                                                                <div class="col-md-8">
                                                                    <asp:LinkButton Text="Volver a Lista Usuarios" CssClass="link-body-emphasis" ID="lnkVolverListaUsuarios" OnClick="lnkVolverListaUsuarios_Click" runat="server" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <!-- Fin Card Usuarios -->
                                    </div>
                                </section>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%-- Fin Modifciar/Agregar Usuario --%>


                        <!-- ################################ abm PEDIDOS ################################ -->
                        <%--Lista Pedidos--%>
                        <asp:GridView ID="dgvAdminPedidos" runat="server" CssClass="table table-striped table-bordered mt-5" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField HeaderText="ID Pedido">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# Eval("IdPedido") %>' CssClass="mt-3"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cantidad solicitada">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# Eval("Cantidad") %>' CssClass="mt-3"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID Usuario">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# Eval("IdUsuario") %>' CssClass="mt-3"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Usuario">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# Eval("Usuario") %>' CssClass="mt-3"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fecha">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# Eval("Fecha") %>' CssClass="mt-3"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Estado">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# Eval("Estado") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Direccion de entrega">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# Eval("DireccionEntrega") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Descuento">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# Eval("Descuento") %>' CssClass="mt-3"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Monto Total">
                                    <ItemTemplate>
                                        <span>$</span>
                                        <asp:Label runat="server" Text='<%# Eval("PrecioTotal") %>'  CssClass="mt-3"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Baja/Eliminar">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibtEliminarPedido" CssClass="mt-3" runat="server" CommandArgument='<%#Eval("IdPedido") %>' CommandName="eliminar_btn" OnClick="ibtEliminarPedido_Click" Height="29px" ImageUrl="~/recursos/img/boton-eliminar.png" Width="29px" />
                                        <asp:ImageButton ID="ibtBajaPedido" CssClass="mt-3" runat="server" CommandArgument='<%#Eval("IdPedido") %>' CommandName="baja_btn" OnClick="ibtBajaPedido_Click" Height="29px" ImageUrl="~/recursos/img/Eliminar.png" Width="29px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Editar">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibtEditarPedido" CssClass="mt-3" runat="server" CommandArgument='<%#Eval("IdPedido") %>' CommandName="editar_btn" OnClick="ibtEditarPedido_Click" Height="29px" ImageUrl="~/recursos/img/editar.png" Width="29px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <%--fin lista Pedidos--%>

                        <%--Lista Pedido_Articulos--%>
                        <asp:GridView ID="dgvPedido_Articulos" AutoGenerateColumns="false" CssClass="table table-striped mt-5" runat="server">
                            <Columns>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("IdPedido") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="IdArticulo" DataField="Id" />
                                <asp:BoundField HeaderText="Articulo" DataField="Nombre"/>
                                <asp:BoundField HeaderText="Descripcion" DataField="Descripcion"/>
                                <asp:BoundField HeaderText="Marca" DataField="Marca"/>
                                <asp:BoundField HeaderText="Categoria" DataField="Categoria" />
                                <asp:BoundField HeaderText="Estado" DataField="Estado" />
                                <asp:BoundField HeaderText="Stock" DataField="Stock" />
                                <asp:BoundField HeaderText="Precio/u" DataField="Precio" />
                            </Columns>
                        </asp:GridView>
                        <%--Fin Lista Pedido_Articulos--%>

                        <%--<!-- Lista Pedidos Editar --> <!-- Aca tendria que ir lo que falta del crud, para editar un pedido (agregar uno, y dar la opcion de elimnar otra vez) -->--%>
                        <asp:UpdatePanel ID="upadetePanelPedidosEditar" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <section class="vh-100" style="background-color: #f4f5f7;" runat="server" id="sectionEditarPedidos" visible="false">
                                    <div class="container py-5 h-100">
                                        <!-- Card Pedido -->
                                        <div class="row d-flex justify-content-center align-items-center h-100">
                                            <div class="col col-lg-8 mb-4 mb-lg-0 ">
                                                <div class="card mb-3" style="border-radius: .5rem;">
                                                    <div class="row g-0">
                                                        <!-- Columna de Imagen -->
                                                        <div class="col-md-4  text-center bg-warning text-white"
                                                            style="border-top-left-radius: .5rem; border-bottom-left-radius: .5rem;">
                                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/recursos/img/avatar.png" Width="120px" CssClass="img-fluid my-5" />
                                                            <h6>
                                                                <!-- ID Usuario -->
                                                                <strong class="fs-5 text-dark">
                                                                    ID Usuario
                                                                    <asp:Label runat="server" ID="Label1" />
                                                                </strong> 
                                                            </h6>
                                                            <i class="far fa-edit mb-5"></i>
                                                        </div>
                                                        <!-- Columna de Inputs -->
                                                        <div class="col-md-8">
                                                            <div class="card-body p-4">
                                                                <h6>Información del usuario</h6>
                                                                <hr class="mt-0 mb-4">
                                                                <div class="row pt-1">
                                                                    <!-- Nombre -->
                                                                    <div class="col-6 mb-3">
                                                                        <h6>Nombre/s</h6>
                                                                        <asp:TextBox runat="server" ID="TextBox1" CssClass="text-muted form-control" required minlength="1" MaxLength="30" pattern="[A-Za-z\s]+" />
                                                                    </div>
                                                                    <!-- Apellido -->
                                                                    <div class="col-6 mb-3">
                                                                        <h6>Apellido/s</h6>
                                                                        <asp:TextBox runat="server" ID="TextBox2" CssClass="text-muted form-control" required minlength="1" MaxLength="30" pattern="[A-Za-z\s]+" />
                                                                    </div>
                                                                    <!-- MAIL -->
                                                                    <div class="col-6 mb-3">
                                                                        <h6>Email</h6>
                                                                        <asp:TextBox runat="server" ID="TextBox3" CssClass="text-muted form-control" required />
                                                                    </div>
                                                                    <!-- DNI -->
                                                                    <div class="col-6 mb-3">
                                                                        <h6>Nro. Documento</h6>
                                                                        <asp:TextBox type="number" runat="server" ID="TextBox4" CssClass="text-muted form-control" required pattern="\d{8}" />
                                                                    </div>
                                                                </div>
                                                                <h6>Contacto</h6>
                                                                <hr class="mt-0 mb-4">
                                                                <div class="row pt-1">
                                                                    <!-- PASS -->
                                                                    <div class="col-6 mb-3">
                                                                        <h6>Contraseña</h6>
                                                                        <asp:TextBox type="password" runat="server" ID="TextBox5" CssClass="text-muted form-control" required minlength="6" MaxLength="20" />
                                                                        <%--patron para solo aceptar claves con un mayus, numeros y minusculas    pattern="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$"    --%>
                                                                    </div>
                                                                    <!-- DIR -->
                                                                    <div class="col-6 mb-3">
                                                                        <h6>Dirección</h6>
                                                                        <asp:TextBox runat="server" ID="TextBox6" CssClass="text-muted form-control" required minlength="6" MaxLength="100" pattern="[A-Za-z0-9\s.,-]+" />
                                                                    </div>
                                                                    <!-- IMG -->
                                                                    <div class="col-6 mb-3">
                                                                        <h6>Imágen de perfil</h6>
                                                                        <asp:TextBox runat="server" ID="TextBox7" CssClass="text-muted form-control" OnTextChanged="txtUrl_TextChanged" />
                                                                    </div>
                                                                    <!-- NIVEL -->
                                                                    <div class="col-6 mb-3">
                                                                        <h6>Nivel de usuario</h6>
                                                                        <asp:TextBox runat="server" ID="TextBox8" CssClass="text-muted form-control" required minlength="1" MaxLength="1" pattern="[A-Za-z]+" />
                                                                    </div>
                                                                </div>
                                                                <!-- Botones -->
                                                                <div class="d-flex justify-content-end">
                                                                    <asp:Button Text="Dar de alta" runat="server" ID="Button1" OnClick="btnAltaUsuario_Click" CssClass="btn btn-outline-success mt-3 me-3" />
                                                                    <asp:Button Text="Dar de baja" runat="server" ID="Button2" OnClick="btnBajaUsuario_Click" CssClass="btn btn-outline-danger mt-3 me-3" />
                                                                    <asp:Button Text="Eliminar" runat="server" ID="Button3" OnClick="btnEliminarUsuario_Click" CssClass="btn btn-danger mt-3 me-3" />
                                                                    <asp:Button Text="Guardar Cambios" runat="server" ID="Button4" OnClick="btnGuardarUsuario_Click" CssClass="btn btn-dark mt-3" />
                                                                </div>
                                                                <!-- Link Volver a Lista Usuarios (TEST) -->
                                                                <div class="col-md-8">
                                                                    <asp:LinkButton Text="Volver a Lista Usuarios" CssClass="link-body-emphasis" ID="LinkButton1" OnClick="lnkVolverListaUsuarios_Click" runat="server" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <!-- Fin Card Usuarios -->
                                    </div>
                                </section>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%--  Fin Lista Pedidos Editar --%>


                        <%-- ################################ abm ARTICULOS ################################ --%>
                        <%--Lista Articulos--%>
                        <asp:GridView ID="dgvAdmin" runat="server" CssClass="table table-striped mt-5" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField HeaderText="Imágen">
                                    <ItemTemplate>
                                        <asp:Image runat="server" ImageUrl='<%#Eval("ImagenUrl") %>' onerror="this.src='./Recursos/image-not-found.png'" Width="70px" Height="70px" CssClass="ml-2" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nombre">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# Eval("Nombre") %>' CssClass="mt-3"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Descripción">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# Eval("Descripcion") %>' CssClass="mt-3"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Marca">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# Eval("Marca") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Categoría">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# Eval("Categoria") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Precio">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# Eval("Precio") %>' CssClass="mt-3"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Acción">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibtEliminar" CssClass="mt-3" runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="eliminar_btn" OnClick="ibtEliminar_Click" Height="29px" ImageUrl="~/recursos/img/Eliminar.png" Width="29px" />
                                        <asp:ImageButton ID="ibtEditar" CssClass="mt-3" runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="eliminar_btn" OnClick="ibtEditar_Click" Height="29px" ImageUrl="~/recursos/img/editar.png" Width="29px" />
                                        <asp:ImageButton ID="ibtBaja" CssClass="mt-3" runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="eliminar_btn" OnClick="ibtBaja_Click" Height="29px" ImageUrl="~/recursos/img/boton-eliminar.png" Width="29px" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <%--<asp:ImageButton ID="btnAgregar" ImageUrl="~/Recursos/agregar.png" Height="19" Width="20" runat="server" OnClick="btnAgregar_Click"
                                                        CommandArgument='<%#Eval("Id") %>' CommandName="btnAgregar" cssClass="mt-3"/>--%>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <%--<asp:ImageButton ID="btnQuitar" ImageUrl="~/Recursos/minimizar.png" Height="19" Width="20" runat="server" OnClick="btnQuitar_Click"
                                                        CommandArgument='<%#Eval("Id") %>' CommandName="btnRestar" cssClass="mt-3" />--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <%--fin lista Articulos--%>

                        <%-- ################################ abm CATEGORIAS ################################ --%>
                        <%--lista categorias--%>
                        <asp:GridView ID="dgvAdminCate" runat="server" CssClass="table table-striped mt-5 " AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField HeaderText="Imágen">
                                    <ItemTemplate>
                                        <asp:Image runat="server" ImageUrl='<%#Eval("UrlImagen") %>' onerror="this.src='./Recursos/image-not-found.png'" Width="70px" Height="70px" CssClass="ml-2" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID Categoria">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# Eval("Id") %>' CssClass="mt-3"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Descripción">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# Eval("Descripcion") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Acción">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibtEliminar" CssClass="mt-3" runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="eliminar_btn" OnClick="ibtEliminar_Click" Height="29px" ImageUrl="~/recursos/img/Eliminar.png" Width="29px" />
                                        <asp:ImageButton ID="ibtEditar" CssClass="mt-3" runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="eliminar_btn" OnClick="ibtEditar_Click" Height="29px" ImageUrl="~/recursos/img/editar.png" Width="29px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <%--fin lista categorias--%>

                        <%-- ################################ abm MARCAS ################################ --%>
                        <%--lista marcas--%>
                        <asp:GridView ID="dgvAdminMarca" runat="server" CssClass="table table-striped mt-5" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField HeaderText="Imágen">
                                    <ItemTemplate>
                                        <asp:Image runat="server" ImageUrl='<%#Eval("UrlImagen") %>' onerror="this.src='./Recursos/image-not-found.png'" Width="70px" Height="70px" CssClass="ml-2" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID Categoria">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# Eval("Id") %>' CssClass="mt-3"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Descripción">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# Eval("Descripcion") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Acción">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibtEliminar" CssClass="mt-3" runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="eliminar_btn" OnClick="ibtEliminar_Click" Height="29px" ImageUrl="~/recursos/img/Eliminar.png" Width="29px" />
                                        <asp:ImageButton ID="ibtEditar" CssClass="mt-3" runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="eliminar_btn" OnClick="ibtEditar_Click" Height="29px" ImageUrl="~/recursos/img/editar.png" Width="29px" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <%--<asp:ImageButton ID="btnAgregar" ImageUrl="~/Recursos/agregar.png" Height="19" Width="20" runat="server" OnClick="btnAgregar_Click"
                                                        CommandArgument='<%#Eval("Id") %>' CommandName="btnAgregar" cssClass="mt-3"/>--%>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <%--<asp:ImageButton ID="btnQuitar" ImageUrl="~/Recursos/minimizar.png" Height="19" Width="20" runat="server" OnClick="btnQuitar_Click"
                                                        CommandArgument='<%#Eval("Id") %>' CommandName="btnRestar" cssClass="mt-3" />--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <%--Fin lista marcas--%>


                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <!-- Fin Cuerpo Principal -->
            <div class="col py-3"></div>
        </div>
    </div>
    <!-- fin -->
</asp:Content>
