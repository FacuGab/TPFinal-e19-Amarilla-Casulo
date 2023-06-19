<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ListaCarrito.aspx.cs" Inherits="Catalogo.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />

    <main aria-labelledby="title" class="min-vh-100">
        <%--carrito vacio--%>
        <div class="container-fluid mt-100 min-vh-100 d-flex justify-content-center align-items-center" id="divCarritoVacio" runat="server">
            <div class="row">
                <div class="col-md-12">
                    <div class="col-sm-12 text-center">
                        <img src="https://www.pngkey.com/png/full/411-4119504_el-carrito-de-la-compra-est-vaco-shopping.png" width="200px" height="200px" class="img-fluid mb-4 mr-3">
                        <h3 ><strong class="fs-1">Tu carrito esta vacío</strong></h3>
                        <h4 class="fs-3">Añade artículos nuevos para visualizarlos acá</h4>
                        <a href="#" class="btn btn-warning fs-5 m-3 mt-5" data-abc="true">Ver artículos</a>
                    </div>
                </div>
            </div>
        </div>
        <%--fin carrito vacio--%>
        <div class="container" runat="server" id="divCarritoConItems">
            <div class="row">
                <div class="col">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <%--<asp:GridView runat="server" ID="dgvCarrito" CssClass="table table-hover" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Eliminar">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnEliminar" CssClass="mt-3" runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="btnEliminarFila" OnClick="btnEliminar_Click" Height="29px" ImageUrl="~/recursos/img/Eliminar.png" Width="29px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Nombre">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Text='<%# Eval("Nombre") %>' CssClass="mt-3"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Precio">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Text='<%# string.Format("{0:C2}", Eval("Precio")) %>' CssClass="mt-3"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Cantidad">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Text='<%# Eval("Cantidad") %>' CssClass="mt-3"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Agregar">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnSumar" CssClass="mt-3" runat="server" CommandArgument='<%#Eval("Id")%>' OnClick="btnSumar_Click" CommandName="btnSumar" Height="29px" ImageUrl="~/recursos/img/agregar.png" Width="29px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Quitar">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnRestar" CssClass="mt-3" runat="server" CommandArgument='<%#Eval("Id")%>' OnClick="btnRestar_Click" CommandName="btnRestar" Height="29px" ImageUrl="~/recursos/img/minimizar.png" Width="29px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>--%>
                            <%-- test--%>
                            <div class="container py-5">
                                <div class="row d-flex justify-content-center my-4">
                                    <div class="col-md-8">
                                        <div class="card mb-4">
                                            <div class="card-header py-3">
                                                <h5 class="mb-0">Carrito de compras</h5>
                                            </div>
                                            <asp:Repeater runat="server" ID="dgvCarrito">
                                                <ItemTemplate>
                                                    <div class="card-body">
                                                        <div class="row">
                                                            <div class="col-lg-3 col-md-12 mb-4 mb-lg-0">
                                                                <img src="<%# Eval("ImagenUrl") %>"
                                                                    class="w-100" alt="Blue Jeans Jacket" />
                                                            </div>

                                                            <div class="col-lg-5 col-md-6 mb-4 mb-lg-0">
                                                                <p><strong><%# Eval("Nombre") %></strong></p>
                                                                <p>Cantidad: <%# Eval("Cantidad") %></p>
                                                                <asp:ImageButton ID="btnEliminar" CssClass="mt-3" runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="btnEliminarFila" OnClick="btnEliminar_Click" Height="29px" ImageUrl="~/recursos/img/Eliminar.png" Width="29px" />
                                                            </div>

                                                            <div class="col-lg-4 col-md-6 mb-4 mb-lg-0">
                                                                <div class="d-flex mb-4 justify-content-around" style="max-width: 300px">
                                                                    <asp:ImageButton ID="btnSumar" CssClass="mt-2" runat="server" CommandArgument='<%#Eval("Id")%>' OnClick="btnSumar_Click" CommandName="btnSumar" Height="19px" ImageUrl="~/recursos/img/agregar.png" Width="19px" />
                                                                    <asp:Label runat="server" Text='<%# Eval("Cantidad") %>' CssClass="ms-3 me-3 mt-1 fs-5"></asp:Label>
                                                                    <asp:ImageButton ID="btnRestar" CssClass="mt-2 " runat="server" CommandArgument='<%#Eval("Id")%>' OnClick="btnRestar_Click" CommandName="btnRestar" Height="19px" ImageUrl="~/recursos/img/minimizar.png" Width="19px" />
                                                                </div>
                                                                <p class="text-start text-md-center">
                                                                    <strong><%# string.Format("{0:C2}", Eval("Precio")) %></strong>
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
                                            <div class="card-header py-3">
                                                <h5 class="mb-0">Resumen</h5>
                                            </div>
                                            <div class="card-body">
                                                <ul class="list-group list-group-flush">
                                                    <li class="list-group-item d-flex justify-content-between align-items-center border-0 px-0 pb-0">Total artículos
                                                            <span>$54</span>
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
                                                        <span><strong>$54</strong></span>
                                                    </li>
                                                </ul>

                                                <button type="button" class="btn btn-primary btn-lg btn-block">
                                                    Ir al pago
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <%--fin test--%>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>


    </main>

</asp:Content>
