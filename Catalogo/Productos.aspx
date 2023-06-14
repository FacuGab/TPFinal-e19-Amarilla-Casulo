<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Catalogo.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container text-center">
        <div class="row" style="padding-top: 90px">
            <h3>LISTA DE PRODUCTOS</h3>
            <h4>Filtro Seleccionado: <%:Filtro %></h4>

            <asp:Repeater ID="repArticulos" runat="server">
                <ItemTemplate>
                    <div class="col">
                        <div class="card" style="width: 18rem;">
                            <!-- Ver si hacer un join y traer img con un top 1 para la img, o agregar una img default si se quiere usar -->
                            <img src="<%#Eval("ImagenUrl") %>" class="card-img-top" alt="imagen articulo">
                            <div class="card-body">
                                <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                <p class="card-text"><%#Eval("Descripcion")%></p>
                                <p class="card-text">Categoria: <%#Eval("Categoria")%></p>
                                <a href="ListaCarrito.aspx?id=<%# Eval("Id")%>" class="btn btn-primary">Agregar al Carrito</a>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

        </div>
    </div>
</asp:Content>
