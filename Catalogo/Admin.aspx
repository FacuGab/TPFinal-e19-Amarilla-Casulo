<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Catalogo.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
    <div class="row flex-nowrap">
        <div class="col-auto col-md-3 col-xl-2 px-sm-2 px-0 bg-dark">
            <div class="d-flex flex-column align-items-center align-items-sm-start px-3 pt-2 text-white min-vh-100">
                <a href="/" class="d-flex align-items-center pb-3 mb-md-0 me-md-auto text-white text-decoration-none">
                    <span class="fs-5 d-none d-sm-inline">Menu</span>
                </a>
                <ul class="nav nav-pills flex-column mb-sm-auto mb-0 align-items-center align-items-sm-start" id="menu">
                    <li class="nav-item mt-5">
                        <a href="#" class="nav-link align-middle px-0">
                            <i class="fs-4 bi-house"></i> <span class="ms-1 d-none d-sm-inline">Inicio</span>
                        </a>
                    </li>
                    <li>
                        <a href="#" class="nav-link px-0 align-middle">
                            <i class="fs-4 bi-table"></i> <span class="ms-1 d-none d-sm-inline">Pedidos</span></a>
                    </li>
                    <li>
                        <a href="#submenu3" data-bs-toggle="collapse" class="nav-link px-0 align-middle">
                            <i class="fs-4 bi-grid"></i> <span class="ms-1 d-none d-sm-inline">Artículos</span> </a>
                            <ul class="collapse nav flex-column ms-1 " id="submenu3" data-bs-parent="#menu">
                            <li class="w-100 ">
                                <a href="Admin.aspx?id=1" class="nav-link px-0"> <span class="d-none d-sm-inline text-light ms-4"> Marcas</span></a>
                            </li>
                            <li class="w-100">
                                <a href="Admin.aspx?id=2" class="nav-link px-0"> <span class="d-none d-sm-inline text-light ms-4"> Categorias</span></a>
                            </li>
                            <li>
                                <a href="Admin.aspx?id=3" class="nav-link px-0"> <span class="d-none d-sm-inline text-light ms-4"> Todos los artículos</span></a>
                            </li>
                            <li>
                                <a href="Admin.aspx?id=4" class="nav-link px-0" data-bs-toggle="modal" data-bs-target="#nuevoArticulo"> <span class="d-none d-sm-inline text-light ms-4"> Cargar nuevo artículo</span></a>
                            </li>
                        </ul>
                    </li>
                    <li>
                        <a href="#" class="nav-link px-0 align-middle">
                            <i class="fs-4 bi-people"></i> <span class="ms-1 d-none d-sm-inline">Usuarios</span> </a>
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
        <div class="col-md-1"></div>

            <div class="col-md-8 mt-5">
                <%--Lista Articulos--%>
                <asp:GridView ID="dgvAdmin" runat="server" CssClass="table table-striped mt-5" AutoGenerateColumns="False" >
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
                <asp:GridView ID="dgvAdminCate" runat="server" CssClass="table table-striped mt-5 " AutoGenerateColumns="False" >
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
                <%--fin lista categorias--%>
                <%--lista marcas--%>
                <asp:GridView ID="dgvAdminMarca" runat="server" CssClass="table table-striped mt-5" AutoGenerateColumns="False" >
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
                                    <label for="IdArticulo" class="form-label"  >Número de ID <span class="text-danger">*</span></label>
                                    <asp:TextBox CssClass="form-control" ID="tbIdArt"  placeholder="ID Articulo" runat="server" />
                                </div>
                                <div class="col-12 mt-3">
                                    <label for="Nombre" class="form-label">Nombre <span class="text-danger">*</span></label>
                                    <asp:TextBox CssClass="form-control" ID="tbNombreArt"  runat="server" />
                                </div>
                                <div class="col-12 mt-3">
                                    <label for="Descripcion" class="form-label">Descripcion <span class="text-danger">*</span></label>
                                    <asp:TextBox CssClass="form-control" ID="tbDescripArt"  runat="server" />
                                </div>
                                <div class="col-12 mt-3">
                                    <label for="Marca" class="form-label">ID Marca <span class="text-danger">*</span></label>
                                    <asp:TextBox CssClass="form-control" ID="TextBox1"  runat="server" />
                                </div>
                                <div class="col-12 mt-3">
                                    <label for="Categoria" class="form-label">ID Categoría <span class="text-danger">*</span></label>
                                    <asp:TextBox CssClass="form-control" ID="TextBox2"  runat="server" />
                                </div>
                                <div class="col-12 mt-3">
                                    <label for="img" class="form-label">Imágen <span class="text-danger">*</span></label>
                                    <asp:TextBox CssClass="form-control" ID="tbImgArt" runat="server" />
                                </div>
                                <div class="col-12 mt-3">
                                    <label for="Precio" class="form-label">Precio <span class="text-danger">*</span></label>
                                    <asp:TextBox CssClass="form-control" ID="tbPrecioArt"  runat="server" />
                                    <asp:Image ID="imgNuevoArt" runat="server" ImageUrl="#" Width="170px" Height="170px" CssClass="mt-3"/>
                                </div>
                                <div class="col-12 mt-2">
                                    <div class="form-check">
                                        <label class="form-check-label text-secondary" for="remember_me">
                                            Artículo activo?
                                        </label>
                                        <input class="form-check-input" type="checkbox" value="" name="Artículo activo" id="Artículo activo">
                                    </div>
                                </div>
                                <div class="col-12 mt-3"><%--SI EL ESTADO NO TIENE EL CHECK DEBERIA CARGAR 0 STOCK POR DEFECTO--%>
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

            </div> 
        <div class="col py-3">
            Content area...
        </div>
    </div>
</div>

    <%--<div class="container mt-5 pt-5 min-vh-100">--%>
        <%--<h4 class="mb-5 text-center fs-3">Administración WEBAPP</h4>
        <div class="row g-0 min-vh-100">
            <div class="col-md-3 bg-light border mb-3 p-1">

            </div>
            <div class="col-md-1"></div>

            <div class="col-md-8 ">

            </div> 
        </div>--%>

    <%--</div>--%>

</asp:Content>
