<%@ Page Title="Productos" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Catalogo.Productos" %>
<%@ MasterType VirtualPath="~/SiteMaster.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="background-image:url(https://img3.wallspic.com/previews/9/2/0/5/6/165029/165029-imac_color_matching_wallpaper_in_dark_purple_for_ipad_or_desktop-x750.jpg);
         background-repeat: no-repeat;
         background-attachment: fixed;
         background-size: cover;">
    <div class="container mt-5 pt-5 min-vh-100" >
        <h4 class="mb-5 text-center fs-3 text-bg-dark">Catalogo</h4>
        <div class="row g-0">

            <div class="col-md-3 bg-light border mb-3 p-1">
                <%--FILTROS AUTOMÁTICOS--%>
                <div class="p-5">
                    <h5>Filtro automático</h5>
                    <div class="dropend">
                        <button class="btn dropdown-toggle " type="button" data-bs-toggle="dropdown" aria-expanded="false">
                            Marcas
                        </button>
                        <ul class="dropdown-menu ">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:Repeater runat="server" ID="rptMarcas">
                                        <ItemTemplate>
                                            <li>
                                                <asp:Button CssClass="btn" Text='<%#Eval("Descripcion") %>' runat="server" ID="btnFiltroMarca" OnClick="btnFiltroMarca_Click" CommandArgument='<%#Eval("Id") %>' />
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </ul>
                    </div>
                    <div class="dropend ">
                        <button class="btn dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                            Categorias
                        </button>
                        <ul class="dropdown-menu">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:Repeater runat="server" ID="rptCategorias">
                                        <ItemTemplate>
                                            <li>
                                                <asp:Button CssClass="btn" Text='<%#Eval("Descripcion") %>' runat="server" ID="btnFiltroCate" OnClick="btnFiltroCate_Click" CommandArgument='<%#Eval("Id") %>' />
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </ul>
                    </div>
                    <div class="dropend mb-4">
                        <button class="btn dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
                            Ordenar
                        </button>
                        <ul class="dropdown-menu">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <li>
                                        <asp:Button CssClass="btn" Text="Menor precio" runat="server" ID="btnFiltroPrecioAsc" OnClick="btnFiltroPrecioAsc_Click" />
                                    </li>
                                    <li>
                                        <asp:Button CssClass="btn" Text="Mayor precio" runat="server" ID="btnFiltroPrecioDesc" OnClick="btnFiltroPrecioDesc_Click" />
                                    </li>
                                    </ItemTemplate>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </ul>
                    </div>
                    <%--FIN FILTRO AUTOMÁTICO--%>

                    <%--filtro manual--%>
                    <h5>Filtro Manual</h5>
                    <asp:DropDownList ID="ddlFiltroCategoria" CssClass="form-select h-1 mb-4" runat="server" AutoPostBack="false"></asp:DropDownList>
                    <asp:DropDownList ID="ddlFiltroMarca" CssClass="form-select h-1 mb-4" runat="server" AutoPostBack="false"></asp:DropDownList>
                    <asp:Button CssClass="btn btn-primary btn-sm mb-5" Text="Aplicar" runat="server" ID="btnFiltro" OnClick="btnFiltro_Click" />
                    <asp:Button CssClass="btn btn-info btn-sm mb-5" Text="Eliminar Filtros" runat="server" ID="btnBorrarFilros" OnClick="btnBorrarFilros_Click" />
                </div>
                    <%--fin filtro manual--%>
                <img src="https://imagenes.compragamer.com/espacioWeb/DC_20230609164245_TKUu6ZRC.jpg" alt="Alternate Text" class="img-fluid" />
            </div>

            <div class="col-md-1"></div>
            <%--Lista de articulos--%>
            <div class="col-md-8 ">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
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
                                                <p class="card-text text-primary fs-4 mt-4">$ <%#Eval("Precio")%></p>
                                                <asp:Button Text="🛒  Agregar" type="button" runat="server" ID="btnAgregar" CssClass="btn btn-warning mt-4" CommandArgument='<%# Eval("Id")%>' OnClick="btnAgregarArt_Click" />
                                                <asp:Button Text="ℹ Detalles" type="button" runat="server" ID="btnDetalles" CssClass="btn btn-primary mt-4" CommandArgument='<%# Eval("Id")%>' OnClick="btnDetalles_Click" />
                                               
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <%--fin lista articulos--%>

        </div>
    </div>
    <div class="container text-center bg-white border rounded-3 p-3">
        <div class="row aling-items-center">
            <div class="col">
                <div>
                    <%-- En teoria un link asi vuelve al link anterior si existe --%>
                    <p><a href='<%:Request.UrlReferrer != null? Request.UrlReferrer.ToString() : "#" %>' class="link-dark">Volver</a></p>
                </div>
                <div>
                    <p><a href="Default.aspx" class="link-dark">Volver al inicio</a></p>
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>
