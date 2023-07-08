<%@ Page Title="Panel De Control" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Catalogo.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid" >
        <div class="row flex-nowrap">

            <!-- MENU DE OPCIONES -->
            <div class="col-auto col-md-3 col-xl-2 px-sm-2 px-0 bg-dark">
                <div class="d-flex flex-column align-items-center align-items-sm-start px-3 pt-2 text-white min-vh-100">
                    <a href="/" class="d-flex align-items-center pb-3 mb-md-0 me-md-auto text-white text-decoration-none"></a>
                    <ul class="nav nav-pills flex-column mb-sm-auto mb-0 align-items-center align-items-sm-start mt-5" id="menu">
                        <li class="nav-item mt-5">
                            <a href="Admin.aspx" class="nav-link align-middle px-0">
                                <i class="fs-3 bi-house text-warning"></i><span class="ms-1 d-none d-sm-inline text-light fs-5 ms-2">Inicio</span>
                            </a>
                        </li>
                        <!-- Menu Pedidos -->
                        <li>
                            <a href="#submenu2" data-bs-toggle="collapse" class="nav-link px-0 align-middle">
                                <i class="fs-3 bi-table text-warning"></i><span class="ms-1 d-none d-sm-inline text-light fs-5 ms-2">Pedidos</span></a>
                            <ul class="collapse nav flex-column ms-1 " id="submenu2" data-bs-parent="#menu">
                                <li class="w-100 ">
                                    <asp:LinkButton Text="Todos los Pedidos" CssClass="nav-link px-0 d-none d-sm-inline text-light ms-4" CommandName="btnPedidosTodos" OnClick="btnPedidosMenu_Click" runat="server" />
                                </li>
                                <li>
                                    <asp:Button ID="btnCrearNuevoPedidoMenu" Text="Crear Nuevo Pedido" CssClass="nav-link px-0 d-none d-sm-inline text-light ms-4" OnClick="btnCrearNuevoPedidoMenu_Click" runat="server" />
                                </li>
                            </ul>
                        </li>
                        <!-- Menu Articulos, Marcas y Categorias -->
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
                                <li>
                                    <a href="Admin.aspx?id=7" class="nav-link px-0"><span class="d-none d-sm-inline text-light ms-4">Nuevo artículo</span></a>
                                </li>
                            </ul>
                        </li>
                        <!-- Menu Usuarios -->
                        <li>
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
                    <!-- Menu Usuario Session (el que tiene foto) -->
                    <div class="dropdown pb-4">
                        <a href="#" class="d-flex align-items-center text-white text-decoration-none dropdown-toggle" id="dropdownUser1" data-bs-toggle="dropdown" aria-expanded="false">
                            <img src="https://github.com/mdo.png" alt="hugenerd" width="30" height="30" class="rounded-circle">
                            <span class="d-none d-sm-inline mx-1" id="btnUserMenu">User</span>
                        </a>
                        <ul class="dropdown-menu dropdown-menu-dark text-small shadow">
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
            <!-- Fin MENU DE OPCIONES -->
            <div class="col-md-1"></div>

            <!-- Cuerpo Principal -->
            <div class="col-md-8 mt-5" background-image: url(https://img3.wallspic.com/crops/9/3/0/4/6/164039/164039-banner_de_contraccion_de_la_galaxia-contraccion_nerviosa-banner_web-streaming_de_medios_de_comunicacion-gamer-3840x2160.png)">
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
                                <!-- Card Usuarios -->
                                <div class="row d-flex justify-content-center align-items-center vh-100" runat="server" id="sectionModificarUsuario" visible="false">
                                    <div class="col col-lg-10 mb-4 mb-lg-0 ">
                                        <div class="card mb-3" style="border-radius: .5rem;">
                                            <div class="row g-0">
                                                <!-- Columna de Imagen -->
                                                <div class="col-md-4  text-center bg-warning text-white"
                                                    style="border-top-left-radius: .5rem; border-bottom-left-radius: .5rem;">
                                                    <asp:Image ID="userImg" runat="server" ImageUrl="~/recursos/img/avatar.png" Width="120px" CssClass="img-fluid my-5" />
                                                    <h6>
                                                        <!-- ID Usuario -->
                                                        <strong class="fs-5 text-dark">ID Usuario
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
                                                        <div class="row">
                                                            <div class="d-flex justify-content-end">
                                                                <asp:Button Text="Dar de alta" runat="server" ID="btnAltaUsuario" OnClick="btnAltaUsuario_Click" CssClass="btn btn-outline-success mt-3 me-3" />
                                                                <asp:Button Text="Dar de baja" runat="server" ID="btnBajaUsuario" OnClick="btnBajaUsuario_Click" CssClass="btn btn-outline-danger mt-3 me-3" />
                                                                <asp:Button Text="Eliminar" runat="server" ID="btnEliminarUsuario" OnClick="btnEliminarUsuario_Click" CssClass="btn btn-danger mt-3 me-3" />
                                                                <asp:Button Text="Guardar Cambios" runat="server" ID="btnGuardarUsuario" OnClick="btnGuardarUsuario_Click" CssClass="btn btn-dark mt-3" />
                                                            </div>
                                                            <!-- Link Volver a Lista Usuarios (TEST) -->
                                                            <div class="d-flex justify-content-center">
                                                                <asp:LinkButton Text="Volver a Lista Usuarios" CssClass="link-body-emphasis" ID="lnkVolverListaUsuarios" CommandName="btnVolverListaUsuarios" OnClick="lnkVolverListaUsuarios_Click" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- Fin Card Usuarios -->
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%-- Fin Modifciar/Agregar Usuario --%>


                        <!-- ################################ abm PEDIDOS ################################ -->
                        <%-- Lista Pedidos Todos --%>
                        <asp:Panel ID="sectionDgvAdminPedidos" runat="server">  
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
                                <asp:TemplateField HeaderText="Cancelar">
                                    <ItemTemplate>
                                        <asp:Button Text="Cancelar" CssClass="btn btn-outline-danger mt-3" ID="btnCancelarPedido" CommandName="Cancelar" CommandArgument='<%#Eval("IdPedido") %>' OnClick="btnCancelarTerminarPedido" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Terminar">
                                    <ItemTemplate>
                                        <asp:Button Text="Terminar" CssClass="btn btn-outline-success mt-3" ID="btnTerminarPedido" CommandName="Terminar" CommandArgument='<%#Eval("IdPedido") %>' OnClick="btnCancelarTerminarPedido" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Editar">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ibtEditarPedido" CssClass="mt-3" runat="server" CommandArgument='<%#Eval("IdPedido") %>' CommandName="editar_btn" OnClick="ibtEditarPedido_Click" Height="29px" ImageUrl="~/recursos/img/editar.png" Width="29px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            </asp:GridView>
                        </asp:Panel>
                        <%-- Fin Lista Pedidos Todos --%>

                        <%-- Lista Pedido Unitario --%>
                        <asp:Panel ID="sectionAdminPedidoUnitario" runat="server">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="dgvAdminPedido" runat="server" CssClass="table table-striped table-bordered mt-5" AutoGenerateColumns="False">
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
                                                    <asp:Label runat="server" Text='<%# string.Format("{0:C2}", Eval("PrecioTotal")) %>'  CssClass="mt-3"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <%-- botones --%>
                            <div class="col-10 mt-5">
                                <asp:Button ID="btnAgregarArticuloPedido_Articulos" Text="➕ Agregar nuevo Articulo" CssClass="m-3 btn btn-primary btn-lg m-3" OnClick="btnAgregarArticuloPedido_Articulos_Click" Visible ="false" runat="server"/>
                                <div class="col-6 mt-5">
                                    <asp:Label runat="server" ID="lblArticulosXidPedido_Articulos" Text="Articulos por Id" CssClass="badge rounded-pill text-bg-warning mt-3" Visible="false"></asp:Label>
                                    <asp:DropDownList runat="server" ID="ddlAgregarArticuloPedido_Articulos" CssClass="form-control m-3" Visible="false"></asp:DropDownList>
                                    <asp:Button runat="server" Text="Agregar" ID="btnAgregarArticuloPedido_ArticulosFinal" CssClass="m-3 btn btn-primary btn-lg m-3" OnClick="btnAgregarArticuloPedido_ArticulosFinal_Click" Visible="false"/>
                                </div>
                            </div>
                        </asp:Panel>
                        <%-- fin Lista Pedido Unitario --%>

                        <%-- Lista Pedido_Articulos --%>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="dgvPedido_Articulos" AutoGenerateColumns="false" CssClass="table table-striped table-bordered mt-5" runat="server">
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

                                        <asp:TemplateField HeaderText="Precio">
                                            <ItemTemplate>
                                                <asp:Label Text='<%#string.Format("{0:C2}", Eval("Precio"))%>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />

                                        <asp:TemplateField HeaderText="Agregar">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnAgregarArtPedido" ImageUrl="~/recursos/img/agregar.png" CommandArgument='<%#Eval("Id")%>' OnClick="btnAgregarArtPedido_Click" Height="19" Width="20" runat="server"/>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Quitar">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnRestarArtPedido" ImageUrl="~/recursos/img/minimizar.png" CommandArgument='<%#Eval("Id")%>' Height="19" Width="20" OnClick="btnRestarArtPedido_Click" runat="server"/>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Eliminar">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnEliminarArtPedido" ImageUrl="~/recursos/img/eliminar.png" CommandArgument='<%#Eval("Id")%>' OnClick="btnEliminarArtPedido_Click" Height="40" Width="40" runat="server"/>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%-- Fin Lista Pedido_Articulos --%>

                        <%-- Lista Pedidos Editar --%>
                        <asp:UpdatePanel ID="upadetePanelPedidosEditar" Visible="false" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                  <div class="row d-flex justify-content-center align-items-center">
                                    <div class="card rounded-4 col-10 bg-warning ms-5" style="margin-top: 100px; margin-bottom: 100px;" id="Div1" runat="server">
                                        <div class=" card-header text-center">
                                            <h1 id="lblEditarPedido" runat="server"> Editar Pedido </h1>
                                            <h1 id="lblNuevoPedido" runat="server" visible="false">🆕 Nuevo Pedido 🆕</h1>
                                        </div>
                                        <div class="row p-2">
                                            <div class="col-6 mt-3">
                                                <label for="txtIdUsuarioEditarPedido" class="form-label">Numero de Usuario<span class="text-danger">*</span></label>
                                                <asp:TextBox CssClass="form-control" ID="txtIdUsuarioEditarPedido" placeholder="ID Usuario" runat="server" />
                                                <asp:TextBox ID="txtIdPedidoEditar" Visible="false" runat="server"/>
                                            </div>
                                            <div class="col-6 mt-3">
                                                <label for="txtNombreUsuarioEditarPedido" class="form-label">Nombre <span class="text-danger">*</span></label>
                                                <asp:TextBox CssClass="form-control" ID="txtNombreUsuarioEditarPedido" placeholder="Nombre Usuario" runat="server" />
                                            </div>
                                            <div class="col-6 mt-3">
                                                <label for="txtEstadoEditarPedido" class="form-label">Estado <span class="text-danger">*</span></label>
                                                <asp:TextBox CssClass="form-control" ID="txtEstadoEditarPedido" placeholder="Pendiente" runat="server" />
                                            </div>
                                            <div class="col-6 mt-3">
                                                <label for="txtDirEditarPedido" class="form-label">Direccion de Entrega</label>
                                                <asp:TextBox CssClass="form-control" ID="txtDirEditarPedido" placeholder="Dir de Entrega" runat="server" />
                                            </div>
                                            <div class="col-6 mt-3">
                                                <label for="txtFechaEditarPedido" class="form-label">Fecha de Inicio</label>
                                                <asp:TextBox CssClass="form-control" TextMode="DateTime" ID="txtFechaEditarPedido" placeholder="Fecha de Inicio" runat="server" />
                                            </div>
                                            <div class="col-6 mt-3">
                                                <label for="txtDescuentoEditarPedido" class="form-label">Descuento</label>
                                                <asp:TextBox CssClass="form-control" ID="txtDescuentoEditarPedido" placeholder="Descuento" runat="server" />
                                            </div>
                                            <div class="col-6 mt-3">
                                                <label for="txtTotalEditarPedido" class="form-label">Total</label>
                                                <asp:TextBox CssClass="form-control" ID="txtTotalEditarPedido" placeholder="Total" runat="server" />
                                            </div>
                                            <%-- Botones --%>
                                            <div class="col-12 mt-3">
                                                <div class="d-flex justify-content-center align-items-center">
                                                    <asp:Button Text="Guardar Cambios" ID="btnModificarAgregarPedido" CssClass="btn btn-dark text-light mb-3 ps-5 pe-5 fs-4" OnClick="btnModificarAgregarPedido_Click" OnClientClick="return confirm('¿Seguro de Modificar?');"  runat="server" />
                                                </div>
                                                <div class="d-flex justify-content-center align-items-center">
                                                    <asp:Button ID="btnEliminarPedido_Articulos" Text="Eliminar" CssClass="btn btn-danger mb-3 ps-5 pe-5 fs-4" OnClick="btnEliminarPedido_Articulos_Click" OnClientClick="return confirm('¿Seguro de Eliminar?');" runat="server" />
                                                </div>
                                                <div class="d-flex justify-content-center">
                                                    <asp:LinkButton Text="Volver a Lista Pedidos" CssClass="link-body-emphasis" ID="btnVolverListaPedidos" CommandName="btnVolverListaPedidos" OnClick="btnVolverListaPedidos_Click" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%-- Fin Lista Pedidos Editar --%>


                        <%-- ################################ abm ARTICULOS ################################ --%>
                        <%-- Lista Articulos --%>  <!-- Mal el ID, cuidado --> 
                        <asp:GridView ID="dgvAdmin" runat="server" CssClass="table table-striped mt-5" AutoGenerateColumns="False"
                            AllowPaging="true"
                            PageSize="10"
                            OnPageIndexChanging="dgvAdmin_PageIndexChanging">
                            <PagerSettings Mode="NumericFirstLast"/>
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
                                <asp:BoundField HeaderText="Estado" DataField="EstadoStr"/>
                                <asp:TemplateField HeaderText="Acción">
                                    <ItemTemplate>
                                        <asp:Button Text="ALTA" ID="btnDarAltaArticuloLista" CssClass="btn btn-outline-success mt-3" runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="alta_btn" OnClick="btnDarAltaArticuloLista_Click"/>
                                        <asp:Button Text="BAJA" ID="btnDarBajaArticuloLista" CssClass="btn btn-outline-danger mt-3" runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="baja_btn" OnClick="btnDarBajaArticuloLista_Click" />
                                        <asp:Button Text="EDITAR" ID="btnEditarArticuloLista" CssClass="btn btn-outline-secondary mt-3" runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="editar_btn" OnClick="btnEditarArticuloLista_Click"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <%-- fin lista Articulos --%>

                        <%-- Lista Articulo (unitario) --%>
                        <asp:GridView ID="dgvAdminArtUnitario" runat="server" CssClass="table table-striped mt-5" AutoGenerateColumns="False"
                            AllowPaging="true"
                            PageSize="10"
                            OnPageIndexChanging="dgvAdmin_PageIndexChanging">
                            <PagerSettings Mode="NumericFirstLast"/>
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
                                <asp:BoundField HeaderText="Estado" DataField="EstadoStr"/>
                            </Columns>
                        </asp:GridView>
                        <%-- fin Lista Articulo (unitario) --%>

                        <%-- Registrar nuevos Artículos --%>
                        <div class="row d-flex justify-content-center align-items-center">
                            <div class="card rounded-4 col-10 bg-warning ms-5" style="margin-top: 100px; margin-bottom: 100px;" id="SectionCrearArt" runat="server">
                                <div class=" card-header text-center">
                                    <h1 id="tituloEditarArticulo" runat="server">🆕 Editar Artículo 🆕</h1>
                                    <h1 id="tituloNuevoArticulo" runat="server">🆕 Nuevo Artículo 🆕</h1>
                                </div>
                                <div class="row p-2">
                                    <div class="col-6 mt-3">
                                        <label for="IdArticulo" class="form-label">Número de ID <span class="text-danger">*</span></label>
                                        <asp:TextBox CssClass="form-control" ID="tbIdArt" placeholder="ID Articulo" runat="server" />
                                    </div>
                                    <div class="col-6 mt-3">
                                        <label for="Nombre" class="form-label">Nombre <span class="text-danger">*</span></label>
                                        <asp:TextBox CssClass="form-control" ID="tbNombreArt" runat="server" />
                                    </div>
                                    <div class="col-4 mt-3">
                                        <label for="Marca" class="form-label">Marca<span class="text-danger">*</span></label>
                                        <asp:DropDownList runat="server" ID="ddlMarca" CssClass="btn btn-light dropdown-toggle" Width="280px"></asp:DropDownList>
                                    </div>
                                    <div class="col-4 mt-3">
                                        <label for="Categoria" class="form-label">Categoría <span class="text-danger">*</span></label>
                                        <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="btn btn-light dropdown-toggle" Width="280px"></asp:DropDownList>
                                    </div>
                                    <div class="col-4 mt-3">
                                        <label for="Stock" class="form-label">Stock <span class="text-danger">*</span></label>
                                        <asp:TextBox CssClass="form-control" ID="tbStockArt" runat="server" />
                                    </div>
                                    <div class="col-4 mt-3">
                                        <label for="Precio" class="form-label">Precio <span class="text-danger">*</span></label>
                                        <asp:TextBox CssClass="form-control" ID="tbPrecioArt" runat="server" />
                                    </div>
                                    <div class="col-4 mt-3">
                                        <label for="img" class="form-label">URL imágen <span class="text-danger">*</span></label>
                                        <asp:TextBox CssClass="form-control" ID="tbImgArt" runat="server" AutoPostBack="true" OnTextChanged="tbImgArt_TextChanged" />
                                    </div>
                                    <div class="col-4 mt-3">
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <asp:Image ID="imgNuevoArt" runat="server" ImageUrl="~/recursos/img/agregar-img.png" Width="200px" CssClass="mt-3 ms-5" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="col-12 mt-3">
                                        <label for="Descripcion" class="form-label">Descripcion <span class="text-danger">*</span></label>
                                        <asp:TextBox CssClass="form-control pb-4" ID="tbDescripArt" runat="server" />
                                    </div>
                                    <div class="col-12 mt-3">
                                        <div class="d-flex justify-content-center align-items-center">
                                            <asp:Button Text="Guardar artículo" ID="btnAgregar" CssClass="btn btn-dark text-light mb-3 ps-5 pe-5 fs-4" runat="server" OnClick="btnAgregar_Click" />
                                        </div>
                                        <div class="d-flex justify-content-center align-items-center">
                                            <asp:Button Text="Eliminar" CssClass="btn btn-danger mb-3 ps-5 pe-5 fs-4" runat="server" />
                                        </div>
                                        <div class="d-flex justify-content-center">
                                            <asp:LinkButton Text="Volver a Lista Articulos" CssClass="link-body-emphasis mt-5" ID="linkButtonVolverListaArticulos" OnClick="btnLinkVolverListaArticulos_Click"  runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%-- fin Registrar nuevos Artículos--%>


                        <%-- ################################ ABM CATEGORIAS ################################ --%>
                        <%-- lista categorias--%>
                        <div class="row">
                            <h1 class="text-light text-center bg-dark border border-light rounded-2 p-2" style="margin-top: 100px;" id="dgvAdminCateTitle" visible="false" runat="server"><strong>Administración de Categorias</strong></h1>
                            <div class="col-10 mt-5" id="dgvAdminCrearCate" runat="server" visible="false">
                                <asp:Button ID="btnAgregarCategoria" Text="➕ Agregar nueva categoría" CssClass="m-3 btn btn-primary btn-lg m-3" runat="server" OnClick="btnAgregarCategoria_Click" />
                            </div>
                            <asp:Repeater ID="dgvAdminCate" runat="server">
                                <ItemTemplate>
                                    <div class="col-3 mt-2 mb-3 text-center">
                                        <div class="card h-100 m-3 bg-warning border-primary" runat="server" id="cardContainer">
                                            <div class="card-header">
                                                <asp:Label Text="Imágen" ID="btnCambiarImg1" runat="server" />
                                            </div>
                                            <div class="d-flex justify-content-center align-items-center mt-5">
                                                <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>
                                                        <asp:Image ID="imgCate" runat="server" ImageUrl='<%#Eval("UrlImagen") %>' onerror="this.src='./Recursos/image-not-found.png'" Width="170px" Height="170px" CssClass="ml-2" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                            <div class="card-body">
                                                <h5 class="card-title">
                                                    <asp:Label runat="server" ID="lblCategoria" Text='<%# Eval("Descripcion") %>' Visible="true"></asp:Label>
                                                    <asp:TextBox runat="server" ID="txtCategoria" Visible="false" CssClass="form-control"></asp:TextBox>
                                                </h5>
                                                <p class="card-text">
                                                    <p>
                                                        ID Categoría:
                                                    <asp:Label runat="server" ID="lblIdCate" Text='<%# Eval("Id") %>' CssClass="mt-3"></asp:Label>
                                                    </p>
                                                    <asp:Label ID="lblCambiarImg" Text="URL Imágen" runat="server" Visible="false" CssClass="mt-5" />
                                                    <asp:Label runat="server" ID="lblUrl" Text='<%# Eval("UrlImagen") %>' CssClass="mt-3" Visible="false"></asp:Label>
                                                    <asp:TextBox runat="server" ID="tbUrlImg" AutoPostBack="true" Visible="false" CssClass="form-control mt-3" OnTextChanged="tbUrlImg_TextChanged"></asp:TextBox>
                                                </p>
                                            </div>
                                            <div class="d-flex">
                                                <div class="col-6 card-footer text-center bg-danger-subtle">
                                                    <i class="bi bi-x-circle-fill fs-5"></i><asp:Button runat="server" ID="btnBajaCate" Text="Dar baja" CssClass="btn" OnClick="btnBajaCate_Click" />
                                                    <%--deberiamos evaluar si darle baja logica alas categorias y marcas, no se es tan necesario, por que sino hay que modificar el script de la bd--%>
                                                </div>
                                                <div class="col-6 card-footer text-center bg-danger">
                                                    <i class="bi bi-trash-fill fs-5"></i><asp:Button runat="server" ID="btnEliminarCate" Text="Eliminar" CssClass="btn" OnClick="btnEliminarCate_Click" />
                                                </div>
                                            </div>
                                            <div class="col-12 card-footer text-center bg-primary">
                                                <i class="bi bi-pencil-fill fs-5"></i><asp:Button runat="server" ID="btnEditarCate" Text="Editar" Visible="true" CssClass="btn btn-primary" OnClick="btnEditarCate_Click" />
                                                <asp:Button runat="server" ID="btnGuardarCate" Text="Guardar" Visible="false" CssClass="btn btn-primary" OnClick="btnGuardarCate_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <%-- fin lista categorias--%>

                        <%-- registrar nueva categoria--%>
                        <div class="row d-flex justify-content-center align-items-center">
                            <div class="card rounded-4 col-8 bg-primary text-light ms-5" style="margin-top: 100px; margin-bottom: 100px;" id="SectionNuevaCate" visible="false" runat="server">
                                <div class=" card-header text-center">
                                    <h1>🆕 Nueva Categoria 🆕</h1>
                                </div>
                                <div class="row p-2">
                                    <div class="col-6 mt-3">
                                        <label for="IdArticulo" class="form-label">Número de ID <span class="text-danger">*</span></label>
                                        <asp:TextBox CssClass="form-control" ID="tbIdCate" placeholder="ID Articulo" runat="server" />
                                    </div>
                                    <div class="col-6 mt-3">
                                        <label for="Nombre" class="form-label">Nombre <span class="text-danger">*</span></label>
                                        <asp:TextBox CssClass="form-control" ID="tbNombreCate" runat="server" />
                                    </div>
                                    <div class="col-8 mt-3">
                                        <label for="img" class="form-label">URL imágen <span class="text-danger">*</span></label>
                                        <asp:TextBox CssClass="form-control" ID="tbUrlImgCate" runat="server" AutoPostBack="true" OnTextChanged="tbUrlImgCate_TextChanged" />
                                    </div>
                                    <div class="col-4 mt-3">
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <asp:Image ID="imgNuevaCate" runat="server" ImageUrl="~/recursos/img/agregar-img.png" Width="200px" CssClass="mt-3 ms-5" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>

                                    <div class="col-12 mt-3">
                                        <div class="d-flex justify-content-center align-items-center">
                                            <asp:Button Text="Guardar categoría" ID="btnAgregarCate" CssClass="btn btn-light mb-3 ps-5 pe-5 fs-4" runat="server" OnClick="btnAgregarCate_Click" />
                                        </div>
                                        <div class="d-flex justify-content-start align-items-start">
                                            <asp:LinkButton Text="Volver a categorías" CssClass="link-body-emphasis m-3" ID="volverCate" OnClick="volverCate_Click" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        </div>
                        <%--fin registro categoria--%>


                        <%-- ################################ ABM MARCAS ################################ --%>
                        <%-- lista marcas--%>
                        <div class="row">
                            <h1 class="text-light text-center bg-dark border border-light rounded-2 p-2" style="margin-top: 100px;" id="titleMarcas" visible="false" runat="server"><strong>Administración de Marcas</strong></h1>
                            <div class="col-10 mt-5" id="sectionAgregarMarca" runat="server" visible="false">
                                <asp:Button ID="btnAgregarMarca" Text="➕ Agregar nueva Marca" CssClass="fs-5 m-3 btn btn-warning btn-lg m-3" runat="server" OnClick="btnAgregarMarca_Click" />
                            </div>
                            <asp:Repeater ID="dgvAdminMarca" runat="server">
                                <ItemTemplate>
                                    <div class="col-3 mt-2 mb-3 text-center">
                                        <div class="card h-100 m-3 bg-light border-primary " runat="server" id="cardContainerMarca">
                                            <div class="card-header">
                                                <asp:Label Text="Imágen" ID="btnCambiarImgMarca" runat="server" />
                                            </div>
                                            <div class="d-flex justify-content-center align-items-center mt-5">
                                                <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>
                                                        <asp:Image ID="imgMarca" runat="server" ImageUrl='<%#Eval("UrlImagen") %>' onerror="this.src='./Recursos/image-not-found.png'" Width="170px" Height="170px" CssClass="ml-2" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                            <div class="card-body">
                                                <h5 class="card-title">
                                                    <asp:Label runat="server" ID="lblMarca" Text='<%# Eval("Descripcion") %>'></asp:Label>
                                                    <asp:TextBox runat="server" ID="txtMarca" Visible="false" CssClass="form-control"></asp:TextBox>
                                                </h5>
                                                <p class="card-text">
                                                    <p>
                                                        ID Categoría:
                                                    <asp:Label runat="server" ID="lblIdMarca" Text='<%# Eval("Id") %>' CssClass="mt-3"></asp:Label>
                                                    </p>
                                                    <asp:Label ID="lblCambiarImgMarca" Text="URL Imágen" runat="server" Visible="false" CssClass="mt-5" />
                                                    <asp:Label runat="server" ID="lblUrlMarca" Text='<%# Eval("UrlImagen") %>' CssClass="mt-3" Visible="false"></asp:Label>
                                                    <asp:TextBox runat="server" ID="tbUrlImgMarca" AutoPostBack="true" Visible="false" CssClass="form-control mt-3" OnTextChanged="tbUrlImgMarca_TextChanged"></asp:TextBox>
                                                </p>
                                            </div>
                                            <div class="col-12 bg-danger text-center">
                                                <i class="bi bi-trash-fill fs-5"></i>
                                                <asp:Button runat="server" ID="btnEliminarMarca" Text="Eliminar" Font-Bold="true" CssClass="btn" OnClick="btnEliminarMarca_Click" OnClientClick="return confirm('¿Estás seguro de que deseas eliminar esta marca?');"/>
                                            </div>
                                            <div class="col-12 card-footer text-center bg-primary">
                                                <i class="bi bi-pencil-fill fs-5"></i>
                                                <asp:Button runat="server" ID="btnEditarMarca" Text="Editar" Font-Bold="true" Visible="true" CssClass="btn btn-primary" OnClick="btnEditarMarca_Click"/>
                                                <asp:Button runat="server" ID="btnGuardarMarca" Text="Guardar" Font-Bold="true" Visible="false" CssClass="btn btn-warning" OnClick="btnGuardarMarca_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <%-- Fin lista marcas--%>

                        <%-- registrar nueva marca--%>
                        <div class="row d-flex justify-content-center align-items-center vh-100">
                            <div class="card rounded-4 col-8 bg-light ms-5" style="margin-top: 100px; margin-bottom: 100px;" id="SectionNuevaMarca" visible="false" runat="server">
                                <div class=" card-header text-center">
                                    <h1>🆕 Nueva Marca 🆕</h1>
                                </div>
                                <div class="row p-2">
                                    <div class="col-6 mt-3">
                                        <label for="IdArticulo" class="form-label">ID de la Marca<span class="text-danger">*</span></label>
                                        <asp:TextBox CssClass="form-control" ID="tbIdMarca" placeholder="ID Articulo" runat="server" />
                                    </div>
                                    <div class="col-6 mt-3">
                                        <label for="Nombre" class="form-label">Nombre <span class="text-danger">*</span></label>
                                        <asp:TextBox CssClass="form-control" ID="tbNombreMarca" runat="server" />
                                    </div>
                                    <div class="col-8 mt-3">
                                        <label for="img" class="form-label">URL imágen <span class="text-danger">*</span></label>
                                        <asp:TextBox CssClass="form-control" ID="tbUrlImgNuevaMarca" runat="server" AutoPostBack="true" OnTextChanged="tbUrlImgNuevaMarca_TextChanged" />
                                    </div>
                                    <div class="col-4 mt-3">
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <asp:Image ID="imgNuevaMarca" runat="server" ImageUrl="~/recursos/img/agregar-img.png" Width="200px" CssClass="mt-3 ms-5" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>

                                    <div class="col-12 mt-3">
                                        <div class="d-flex justify-content-center align-items-center">
                                            <asp:Button Text="Guardar Marca" ID="btnGuardarMarca" CssClass="btn btn-light mb-3 ps-5 pe-5 fs-4" runat="server" OnClick="btnGuardarNewMarca_Click" />
                                        </div>
                                        <div class="d-flex justify-content-start align-items-start">
                                            <asp:LinkButton Text="Volver a Marcas" CssClass="link-body-emphasis m-3" ID="btnVolverMarca" OnClick="btnVolverMarca_Click" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <%--</div>--%> 
                        <%-- fin registro marca--%>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <!-- Fin Cuerpo Principal -->
            <div class="col py-3"></div>

        </div>
    </div>
    <!-- fin -->
</asp:Content>
