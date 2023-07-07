<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="Catalogo.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="container text-center min-vh-100 ">
        <div class="row d-flex justify-content-center mt-5">
            <div class="card mb-3 w-75 mt-5">
                <div id="carouselExample" class="carousel slide">
                    <div class="carousel-inner">
                        <%if (listImg != null)
                        {%> 
                        
                        <% foreach (var item in listImg)
                            { %>
                        <div class="carousel-item active">
                            <img src="<%= item %>" class="d-block w-100 mt-5" alt="...">
                        </div>
                        <% } %>
                        
                        <%}%>
                    </div>
                    <button class="carousel-control-prev" type="button" data-bs-target="#carouselExample" data-bs-slide="prev">
                        <span class="carousel-control-prev-icon bg-black" aria-hidden="true"></span>
                        <span class="visually-hidden">Previous</span>
                    </button>
                    <button class="carousel-control-next" type="button" data-bs-target="#carouselExample" data-bs-slide="next">
                        <span class="carousel-control-next-icon bg-black" aria-hidden="true"></span>
                        <span class="visually-hidden ">Next</span>
                    </button>
                </div>
                <asp:Repeater runat="server" ID="rptDetalleArt">
                    <ItemTemplate>
                        <%foreach (var item in listArt)
                            {
                                if (item.Id == idMatch)
                                {%>
                                <div class="card-body bg-warning-subtle">
                                    <h5 class="card-title fs-3"><%=item.Nombre%></h5>
                                    <p class="card-text"><%=item.Descripcion%></p>
                                    <p class="card-text">Marca: <%= item.Marca%></p>
                                    <p class="card-text">Categoria: <%= item.Categoria%></p>
                                    <p class="card-text text-primary fs-4 mt-4">$ <%=item.precio%></p>
                                    <a href="Productos.aspx" class="btn btn-warning "><i class="bi bi-cart-plus-fill">Volver</i></a>
                                </div>
                                <%}
                            }%>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </section>

</asp:Content>
