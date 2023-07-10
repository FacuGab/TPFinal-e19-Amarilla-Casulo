<%@ Page Title="Carrito" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ListaCarrito.aspx.cs" Inherits="Catalogo.WebForm2" %>

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
                                                                    <label class="fs-5 text-primary"><%# Eval("TotalParcial") %></label>
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
                                                    <li>
                                                        <hr class="dropdown-divider">
                                                    </li>
                                                    <li class="list-group-item d-flex justify-content-between align-items-center px-0">Envío
                                                         <span>Gratis</span>
                                                    </li>
                                                    <li class="list-group-item d-flex justify-content-between align-items-center px-0">
                                                            Descuentos
                                                         <span>10%</span>
                                                    </li>
                                                    <li class="list-group-item d-flex justify-content-between align-items-center border-0 px-0 mb-3">
                                                        <div>
                                                            <strong>Monto total</strong>
                                                            <strong><p class="mb-0">(IVA Incluido)</p></strong>
                                                        </div>
                                                        <span><strong class="fs-5">$<%:TotalAcumulado.ToString() %></strong></span>
                                                    </li>
                                                </ul>
                                                <%-- Botones Cancelar / Continuar Compra --%>
                                                <div class="d-flex justify-content-end">
                                                    <asp:Button Text="❌ Cancelar" ID="btnEliminarListaCarrito" CssClass="btn btn-warning ms-2" OnClick="btnEliminarListaCarrito_Click" runat="server" />
                                                    <button type="button" class="btn btn-primary btn-block ms-2" id="btnContinuarCompra" onserverclick="btnContinuarCompra_Click" runat="server">
                                                        <i class="bi bi-cart-check-fill ">Continuar compra</i>
                                                    </button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <!-- FIN CARRITO -->
                </div>
            </div>
        </div>

        <div class="container" runat="server" id="divConfirmarPedido">
            <div class="row">
                <div class="col">
                    <!-- CONTROL ITEMS PRE COMPRA -->
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="container py-5 mt-5">
                                <div class="row d-flex justify-content-center my-4">
                                    <div class="col-md-12">
                                        <div class="card mb-4">
                                            <div class="card-header py-3 bg-warning">
                                                <h4 class="mb-0 "><strong>Finalizar reserva</strong></h4>
                                            </div>
                                            <table class="table">
                                                <thead class="fs-5">
                                                    <tr class="text-center">
                                                        <th scope="col">Imágen</th>
                                                        <th scope="col">Producto</th>
                                                        <th scope="col">Cantidad</th>
                                                        <th scope="col">Precio</th>
                                                        <th scope="col">Total</th>
                                                    </tr>
                                                </thead>
                                                <%-- Repeater Items --%>
                                                <asp:Repeater runat="server" ID="rptCarrito">
                                                    <ItemTemplate>
                                                        <tbody>
                                                            <tr class="text-center fs-5 ">
                                                                <td class="">
                                                                    <img src="<%# Eval("ImagenUrl") %>" class="w-25" alt="img_producto" />
                                                                </td>
                                                                <td class="pt-5"><%# Eval("Nombre") %></td>
                                                                <td class="pt-5"><%# Eval("Cantidad") %></td>
                                                                <td class="pt-5"><%# string.Format("{0:C2}", Eval("precio")) %></td>
                                                                <td class="pt-5"><%# Eval("TotalParcial") %></td>
                                                            </tr>
                                                        </tbody>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </table>
                                            <div class="card-header py-3 d-flex justify-content-end">
                                                <h4 class="mb-0 "><strong>Precio total:  <span class="text-primary ms-5">$<%:TotalAcumulado.ToString() %></span></strong></h4>
                                            </div>
                                        </div>
                                        <div id="divBtnConfirmarReserva" runat="server">
                                            <!-- Boton Cargar Pedido -->
                                            <div class="card text-center mt-5">
                                                <asp:Button ID="btnConfirmarPedido" Text="Confirmar Reserva" CssClass="btn fs-3 bg-black text-light p-3" OnClientClick="return confirm('¿Seguro de Confirmar?');" OnClick="btnConfirmarPedido_Click" runat="server" />
                                            </div>
                                        </div>
                                    </div>

                                    <!-- Boton de Login -->
                                    <div class="col-12 card text-center mt-5" id="divRegistroOLoginNecesario" runat="server">
                                        <p class="fs-4 card-title pt-4 pb-1">
                                            <strong>Para completar la compra necesitas 
                                            <button type="button" class="btn fs-4 bg-black text-light p-1" data-bs-toggle="modal" data-bs-target="#exampleModal"><b>iniciar sesión.</b></button>
                                                No tenes una cuenta?
                                            <a href="Registro.aspx?text=registroCompra" class="link-secondary text-decoration-none">
                                                <button type="button" class="btn btn-success fs-5 p-1" data-bs-toggle="modal" data-bs-target="#exampleModal"><i class="bi bi-person-add">Crear cuenta</i></button>
                                            </a>
                                            </strong>
                                        </p>
                                    </div>

                                    <%--Metodos de pago--%>
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <div id="datosDePago" runat="server" style="margin-top: 150px; margin-bottom: 200px;">
                                                <h1>Elija un metodo de pago</h1>
                                                <div class="accordion mt-5" id="accordionExample">
                                                    <div class="accordion-item ">
                                                        <h2 class="accordion-header">
                                                            <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                                                                Mercado Pago
                                                            </button>
                                                        </h2>
                                                        <div id="collapseOne" class="accordion-collapse collapse show" data-bs-parent="#accordionExample">
                                                            <div class="accordion-body text-center">
                                                                <img src="https://logotipoz.com/wp-content/uploads/2021/10/version-horizontal-large-logo-mercado-pago.webp" alt="logo-MP" class="img-fluid w-25" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="accordion-item">
                                                        <h2 class="accordion-header">
                                                            <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
                                                                Tarjeta de débito
                                                            </button>
                                                        </h2>
                                                        <div id="collapseTwo" class="accordion-collapse collapse" data-bs-parent="#accordionExample">
                                                            <div class="accordion-body">
                                                                <div class="row gy-3">
                                                                    <div class="col-md-6">
                                                                        <label for="nombreDebito" class="form-label">Nombre del titular</label>
                                                                        <input type="text" class="form-control" id="nombreDebito" placeholder="" required>
                                                                        <small class="text-body-secondary">Nombre que figura en la tarjeta</small>
                                                                    </div>

                                                                    <div class="col-md-6">
                                                                        <label for="numeroDebito" class="form-label">Número de tarjeta</label>
                                                                        <input type="text" class="form-control" id="numeroDebito" placeholder="" required>
                                                                    </div>

                                                                    <div class="col-md-3">
                                                                        <label for="fechaVenDebito" class="form-label">Fecha de vencimiento</label>
                                                                        <input type="text" class="form-control" id="fechaVenDebito" placeholder="" required>
                                                                    </div>

                                                                    <div class="col-md-3">
                                                                        <label for="codSegDebito" class="form-label">CVV</label>
                                                                        <input type="text" class="form-control" id="codSegDebito" placeholder="" required>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <label for="dniDebito" class="form-label">Número de documento</label>
                                                                        <input type="text" class="form-control" id="dniDebito" placeholder="" required>
                                                                        <small class="text-body-secondary">Nombre que figura en la tarjeta</small>
                                                                    </div>
                                                                </div>
                                                                <hr class="my-4">
                                                                <button class="w-100 btn btn-warning btn-lg " type="submit">Pagar</button>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="accordion-item">
                                                        <h2 class="accordion-header">
                                                            <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
                                                                Tarjeta de crédito
                                                            </button>
                                                        </h2>
                                                        <div id="collapseThree" class="accordion-collapse collapse" data-bs-parent="#accordionExample">
                                                            <div class="accordion-body">
                                                                <div class="row gy-3">
                                                                    <div class="col-md-6">
                                                                        <label for="nombreCredito" class="form-label">Nombre del titular</label>
                                                                        <input type="text" class="form-control" id="nombreCredito" placeholder="" required>
                                                                        <small class="text-body-secondary">Nombre que figura en la tarjeta</small>
                                                                    </div>

                                                                    <div class="col-md-6">
                                                                        <label for="numeroCredito" class="form-label">Número de tarjeta</label>
                                                                        <input type="text" class="form-control" id="numeroCredito" placeholder="" required>
                                                                    </div>

                                                                    <div class="col-md-3">
                                                                        <label for="fechaVenCredito" class="form-label">Fecha de vencimiento</label>
                                                                        <input type="text" class="form-control" id="fechaVenCredito" placeholder="" required>
                                                                    </div>

                                                                    <div class="col-md-3">
                                                                        <label for="codSegCredito" class="form-label">CVV</label>
                                                                        <input type="text" class="form-control" id="codSegCredito" placeholder="" required>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <label for="dniCredito" class="form-label">Número de documento</label>
                                                                        <input type="text" class="form-control" id="dniCredito" placeholder="" required>
                                                                    </div>
                                                                </div>
                                                                <hr class="my-4">
                                                                <button class="w-100 btn btn-warning btn-lg " type="submit">Pagar</button>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <!-- Fin metodos de pago -->

                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <!-- FIN CONTROL ITEMS PRE COMPRA -->
                </div>
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
    </main>
</asp:Content>
