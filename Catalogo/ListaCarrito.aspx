<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ListaCarrito.aspx.cs" Inherits="Catalogo.WebForm2" %>
<%@ MasterType VirtualPath="~/SiteMaster.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main aria-labelledby="title" class="min-vh-100">
        <%--carrito vacio--%>
        <div class="container-fluid mt-100 min-vh-100 d-flex justify-content-center align-items-center" id="divCarritoVacio" runat="server">
            <div class="row">
                <div class="col-md-12">
                    <div class="col-sm-12 text-center">
                        <img src="https://www.pngkey.com/png/full/411-4119504_el-carrito-de-la-compra-est-vaco-shopping.png" width="200px" height="200px" class="img-fluid mb-4 mr-3">
                        <h3><strong class="fs-1">Tu carrito esta vacío</strong></h3>
                        <h4 class="fs-3">Añade artículos nuevos para visualizarlos acá</h4>
                        <a href="Productos.aspx" class="btn btn-warning fs-5 m-3 mt-5" data-abc="true">Ver artículos</a>
                    </div>
                </div>
            </div>
        </div>
        <%--fin carrito vacio--%>
        <div class="container" runat="server" id="divCarritoConItems">
            <div class="row">
                <div class="col">
                    <!-- CARRITO -->
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="container py-5 mt-5">
                                <div class="row d-flex justify-content-center my-4">
                                    <div class="col-md-8">
                                        <div class="card mb-4">
                                            <div class="card-header py-3 bg-primary text-light d-flex">
                                                <h5 class="mb-0 ">Carrito de compras</h5>
                                            </div>
                                            <asp:Repeater runat="server" ID="dgvCarrito">
                                                <ItemTemplate>
                                                    <div class="card-body mt-4">
                                                        <div class="row">
                                                            <div class="col-lg-3 col-md-12 mb-4 mb-lg-0">
                                                                <img src="<%# Eval("ImagenUrl") %>"
                                                                    class="w-100" alt="Blue Jeans Jacket" />
                                                            </div>

                                                            <div class="col-lg-5 col-md-6 mb-4 mb-lg-0">
                                                                <p><strong><%# Eval("Nombre") %></strong></p>
                                                                <p class="text-start ">
                                                                    <strong><%# string.Format("{0:C2}", Eval("precio")) %></strong>
                                                                </p>
                                                                <asp:ImageButton ID="btnEliminar" CssClass="btn btn-outline-danger mt-5" runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="btnEliminarFila" OnClick="btnEliminar_Click" ImageUrl="~/recursos/bootstrap-icons-1.10.5/trash-fill.svg" />
                                                                <asp:ImageButton ID="btnDetalles" CssClass="btn btn-outline-info mt-5" runat="server" CommandArgument='<%# Eval("Id")%>' OnClick="btnDetalles_Click" ImageUrl="~/recursos/bootstrap-icons-1.10.5/info-circle-fill.svg" />
                                                            </div>

                                                            <div class="col-lg-4 col-md-6 mb-4 mb-lg-0">
                                                                <div class="d-flex mb-4 justify-content-around" style="max-width: 300px">
                                                                    <label for="lblCantidad" class="m-2">Cantidad: </label>
                                                                    <asp:ImageButton ID="btnRestar" CssClass="mt-2 " runat="server" CommandArgument='<%#Eval("Id")%>' OnClick="btnRestar_Click" CommandName="btnRestar" Height="19px" ImageUrl="~/recursos/img/minimizar.png" Width="19px" />
                                                                    <asp:Label runat="server" ID="lblCantidad" Text='<%# Eval("Cantidad") %>' CssClass="ms-3 me-3 mt-1 fs-5"></asp:Label>
                                                                    <asp:ImageButton ID="btnSumar" CssClass="mt-2" runat="server" CommandArgument='<%#Eval("Id")%>' OnClick="btnSumar_Click" CommandName="btnSumar" Height="19px" ImageUrl="~/recursos/img/agregar.png" Width="19px" />
                                                                </div>
                                                                <p class="m-5 fs-5 text-center">
                                                                    Total
                                                                    <label class="fs-5 text-primary"> <%# Eval("TotalParcial") %></label>
                                                                </p>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <hr class="" />
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>
                                    <div class="col-md-4">
                                        <div class="card mb-4">
                                            <div class="card-header py-3 bg-primary text-light">
                                                <h5 class="mb-0">Resumen</h5>
                                            </div>
                                            <div class="card-body">
                                                <ul class="list-group list-group-flush">
                                                    <li class="list-group-item d-flex justify-content-between align-items-center border-0 px-0 pb-0">Total artículos
                                                          <span><strong class="">$<%:TotalAcumulado.ToString() %></strong></span>
                                                    </li>
                                                    <li class="list-group-item d-flex justify-content-between align-items-center px-0">Envío
                                                         <span>Gratis</span>
                                                    </li>
                                                    <li class="list-group-item d-flex justify-content-between align-items-center px-0">Descuentos
                                                         <span>10%</span>
                                                    </li>
                                                    <li
                                                        class="list-group-item d-flex justify-content-between align-items-center border-0 px-0 mb-3">
                                                        <div>
                                                            <strong>Monto total</strong>
                                                            <strong>
                                                                <p class="mb-0">(IVA Incluido)</p>
                                                            </strong>
                                                        </div>
                                                        <span><strong class="fs-5">$<%:TotalAcumulado.ToString() %></strong></span>
                                                    </li>
                                                </ul>
                                                <div class="d-flex justify-content-end">
                                                    <asp:Button Text="❌ Cancelar" ID="btnEliminarListaCarrito" CssClass="btn btn-warning ms-2" OnClick="btnEliminarListaCarrito_Click" runat="server" />
                                                    <button type="button" class="btn btn-primary btn-block ms-2">
                                                        <i class="bi bi-cart-check-fill "> Ir al pago</i>
                                                    </button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <!-- FIN CARRITO -->
                </div>
            </div>
        </div>
    </main>
</asp:Content>
