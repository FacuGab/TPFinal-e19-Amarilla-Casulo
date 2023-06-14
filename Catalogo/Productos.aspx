<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Catalogo.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-5 pt-5 min-vh-100">
        <h4 class="mb-5 text-center fs-3">Filtro Seleccionado: <%:Filtro %></h4>
        <div class="row g-0">

            <div class="col-md-3 bg-light border mb-3 p-5">
                <asp:DropDownList ID="ddlFiltroCategoria" CssClass="form-select h-1 mb-4" runat="server" AutoPostBack="false"></asp:DropDownList>
                <asp:DropDownList ID="ddlFiltroMarca" CssClass="form-select h-1 mb-4" runat="server" AutoPostBack="false"></asp:DropDownList>
                
                <%--FILTRO DE PRUEBA PARA VER CUAL DEJAMOS--%>
                <div class="dropend">
                    <button class="btn btn-secondary dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                        Marcas
                    </button>
                    <ul class="dropdown-menu">
                        <asp:Repeater runat="server" ID="rptMarcas">
                            <ItemTemplate>
                                <li><a class="dropdown-item" href="#"><%#Eval("Descripcion") %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <div class="dropend mt-3">
                    <button class="btn btn-secondary dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                        Categorias
                    </button>
                    <ul class="dropdown-menu">
                        <asp:Repeater runat="server" ID="rptCategorias">
                            <ItemTemplate>
                                <li><a class="dropdown-item" href="#"><%#Eval("Descripcion") %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>

            <div class="col-md-1"></div>
            <div class="col-md-8 ">
                <!-- Repeater de prueba -->
                <asp:Repeater ID="repArticulos" runat="server">
                    <ItemTemplate>
                        <div class="card mb-3 ms-4" style="max-width: 740px;">
                            <div class="row g-0 m-4">
                                <div class="col-md-4">
                                    <img src="<%#Eval("ImagenUrl") %>" class="img-fluid rounded-start" alt="...">
                                </div>
                                <div class="col-md-8">
                                    <div class="card-body ">
                                        <h5 class="card-title fs-3"><%#Eval("Nombre") %></h5>
                                        <p class="card-text"><%#Eval("Descripcion")%></p>
                                        <p class="card-text">Categoria: <%#Eval("Categoria")%></p>
                                        <div class="d-flex justify-content-end">
                                            <a href="ListaCarrito.aspx?id=<%# Eval("Id")%>" class="btn btn-primary mt-3"><i class="bi bi-bag-plus-fill">Agregar</i></a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>

</asp:Content>
