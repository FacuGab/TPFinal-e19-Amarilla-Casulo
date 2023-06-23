<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Catalogo.WebForm3" %>

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
                            <a href="#" class="nav-link align-middle px-0">
                                <i class="fs-3 bi-house text-warning"></i><span class="ms-1 d-none d-sm-inline text-light fs-5 ms-2">Inicio</span>
                            </a>
                        </li>
                        <li>
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
                            </ul>
                        </li>
                        <li>
                            <a href="#submenu4" data-bs-toggle="collapse" class="nav-link px-0 align-middle">
                                <i class="fs-3 bi-people text-warning"></i><span class="ms-1 d-none d-sm-inline text-light fs-5 ms-2">Usuarios</span> </a>
                            <ul class="collapse nav flex-column ms-1 " id="submenu4" data-bs-parent="#menu">
                                <li class="w-100 ">
                                    <a href="Admin.aspx?id=6" class="nav-link px-0"><span class="d-none d-sm-inline text-light ms-4">Todos</span></a>
                                </li>
                                <li class="w-100">
                                    <a href="Admin.aspx?id=7" class="nav-link px-0"><span class="d-none d-sm-inline text-light ms-4">Eliminar</span></a>
                                </li>
                                <li>
                                    <a href="Admin.aspx?id=8" class="nav-link px-0"><span class="d-none d-sm-inline text-light ms-4">Modificar</span></a>
                                </li>
                                <li>
                                    <a href="Registro.aspx" class="nav-link px-0"><span class="d-none d-sm-inline text-light ms-4">Crear nuevo usuario</span></a>
                                    <%--<a href="Admin.aspx?id=4" class="nav-link px-0" data-bs-toggle="modal" data-bs-target="#nuevoUsuario"> <span class="d-none d-sm-inline text-light ms-4"> Crear nuevo usuario</span></a>--%>
                                </li>
                            </ul>
                        </li>
                    </ul>
                    <hr>
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
                            <li><a class="dropdown-item" href="#">Sign out</a></li>
                        </ul>
                    </div>
                </div>
            </div>
            <!--FIn Barra de Opciones -->
            <div class="col-md-1"></div>

            <div class="col-md-8 mt-5">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
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

                        <%--Carga nuevo artículo--%>
                        <div class="modal fade" id="nuevoArticulo" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <h1 class="modal-title fs-5 text-center" id="exampleModalLabel">🆕 Nuevo Artículo 🆕</h1>
                                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                    </div>
                                    <div class="modal-body">
                                        <div class="col-12 mt-3">
                                            <label for="IdArticulo" class="form-label">Número de ID <span class="text-danger">*</span></label>
                                            <asp:TextBox CssClass="form-control" ID="tbIdArt" placeholder="ID Articulo" runat="server" />
                                        </div>
                                        <div class="col-12 mt-3">
                                            <label for="Nombre" class="form-label">Nombre <span class="text-danger">*</span></label>
                                            <asp:TextBox CssClass="form-control" ID="tbNombreArt" runat="server" />
                                        </div>
                                        <div class="col-12 mt-3">
                                            <label for="Descripcion" class="form-label">Descripcion <span class="text-danger">*</span></label>
                                            <asp:TextBox CssClass="form-control" ID="tbDescripArt" runat="server" />
                                        </div>
                                        <div class="col-12 mt-3">
                                            <label for="Marca" class="form-label">ID Marca <span class="text-danger">*</span></label>
                                            <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" />
                                        </div>
                                        <div class="col-12 mt-3">
                                            <label for="Categoria" class="form-label">ID Categoría <span class="text-danger">*</span></label>
                                            <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" />
                                        </div>
                                        <div class="col-12 mt-3">
                                            <label for="img" class="form-label">Imágen <span class="text-danger">*</span></label>
                                            <asp:TextBox CssClass="form-control" ID="tbImgArt" runat="server" />
                                        </div>
                                        <div class="col-12 mt-3">
                                            <label for="Precio" class="form-label">Precio <span class="text-danger">*</span></label>
                                            <asp:TextBox CssClass="form-control" ID="tbPrecioArt" runat="server" />
                                            <asp:Image ID="imgNuevoArt" runat="server" ImageUrl="#" Width="170px" Height="170px" CssClass="mt-3" />
                                        </div>
                                        <div class="col-12 mt-2">
                                            <div class="form-check">
                                                <label class="form-check-label text-secondary" for="remember_me">
                                                    Artículo activo?
                                                </label>
                                                <input class="form-check-input" type="checkbox" value="" name="Artículo activo" id="Artículo activo">
                                            </div>
                                        </div>
                                        <div class="col-12 mt-3">
                                            <%--SI EL ESTADO NO TIENE EL CHECK DEBERIA CARGAR 0 STOCK POR DEFECTO--%>
                                            <label for="Stock" class="form-label">Stock <span class="text-danger">*</span></label>
                                            <asp:TextBox CssClass="form-control" ID="tbStockArt" ToolTip="Ingrese contraseña" runat="server" />
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <div class="d-grid">
                                            <button class="btn btn-primary " type="submit">Cargar nuevo artículo</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%--Fin Carga nuevo artículo--%>

                        <%--Lista Pedidos--%>
                        <asp:GridView ID="dgvAdminPedidos" runat="server" CssClass="table table-striped mt-5" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField HeaderText="ID Pedido">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# Eval("IdPedido") %>' CssClass="mt-3"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="ID Cliente">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("IdUsuario") %>' CssClass="mt-3"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Artículo">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# Eval("NombreArt") %>' CssClass="mt-3"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cantidad solicitada">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# Eval("Cantidad") %>' CssClass="mt-3"></asp:Label>
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
                                        <asp:Label runat="server" Text='<%# Eval("PrecioTotal") %>' CssClass="mt-3"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Acción">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibtEliminarPedido" CssClass="mt-3" runat="server" CommandArgument='<%#Eval("IdPedido") %>' CommandName="eliminar_btn" OnClick="ibtEliminarPedido_Click" Height="29px" ImageUrl="~/recursos/img/Eliminar.png" Width="29px" />
                                        <asp:ImageButton ID="ibtEditarPedido" CssClass="mt-3" runat="server" CommandArgument='<%#Eval("IdPedido") %>' CommandName="eliminar_btn" OnClick="ibtEditarPedido_Click" Height="29px" ImageUrl="~/recursos/img/editar.png" Width="29px" />
                                        <asp:ImageButton ID="ibtBajaPedido" CssClass="mt-3" runat="server" CommandArgument='<%#Eval("IdPedido") %>' CommandName="eliminar_btn" OnClick="ibtBajaPedido_Click" Height="29px" ImageUrl="~/recursos/img/boton-eliminar.png" Width="29px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <%--fin lista Pedidos--%>

                        <%--Lista Pedido_Articulos--%>
                        <asp:GridView ID="dgvPedido_Articulos" AutoGenerateColumns="false" CssClass="table table-striped mt-5" runat="server">
                            <Columns>
                                <asp:TemplateField HeaderText="IdPedido">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("IdPedido") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="IdArticulo">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("Id") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cantidad Por Articulo">
                                    <ItemTemplate>
                                        <asp:Label Text='<%#Eval("Cantidad") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <%--Fin Lista Pedido_Articulos--%>

                        <%--Carga nuevo usuario--%>
                        <div class="modal fade" id="nuevoUsuario" tabindex="-1" aria-labelledby="PedidoModalLabel" aria-hidden="true">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header bg-warning">
                                        <h1 class="modal-title fs-4 " id="PedidoModalLabel"><strong>Nuevo Usuario </strong></h1>
                                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                    </div>
                                    <div class="modal-body">
                                        <div class="col-12 mt-3">
                                            <label for="IdUsuario" class="form-label">Nombre<span class="text-danger">*</span></label>
                                            <asp:TextBox CssClass="form-control" ID="IdUsuario" placeholder="Ingrese número de ID" runat="server" />
                                        </div>
                                        <div class="col-12 mt-3">
                                            <label for="idArt" class="form-label">Apellido <span class="text-danger">*</span></label>
                                            <asp:TextBox CssClass="form-control" ID="idArt" runat="server" placeholder="Ingrese número de ID" />
                                        </div>
                                        <div class="col-12 mt-3">
                                            <label for="cantidadArt" class="form-label">Documento nacional de identidad <span class="text-danger">*</span></label>
                                            <asp:TextBox CssClass="form-control" ID="cantidadArt" runat="server" placeholder="Ingrese la cantidad solicitada" />
                                        </div>
                                        <div class="col-12 mt-3">
                                            <label for="FechaPed" class="form-label">Correo electrónico <span class="text-danger">*</span></label>
                                            <asp:TextBox CssClass="form-control" ID="FechaPed" runat="server" />
                                        </div>
                                        <div class="col-12 mt-3">
                                            <label for="estadoPed" class="form-label">Contraseña<span class="text-danger">*</span></label>
                                            <asp:TextBox CssClass="form-control" ID="estadoPed" runat="server" placeholder="Ingrese el estado actual del pedido" />
                                        </div>
                                        <div class="col-12 mt-3">
                                            <label for="direccion" class="form-label">Dirección <span class="text-danger">*</span></label>
                                            <asp:TextBox CssClass="form-control" ID="direccion" runat="server" />
                                        </div>
                                        <div class="col-12 mt-3">
                                            <label for="precioArt" class="form-label">Precio</label>
                                            <asp:TextBox CssClass="form-control" ID="precioArt" runat="server" Enabled="false" />
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <div class="d-grid">
                                            <button class="btn btn-warning " type="submit">Registrar</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%--Fin Carga nuevo usuario--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

            <div class="col py-3"></div>
        </div>
    </div>



</asp:Content>
