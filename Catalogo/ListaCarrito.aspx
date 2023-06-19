<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ListaCarrito.aspx.cs" Inherits="Catalogo.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />

    <main aria-labelledby="title">
        <div class="container">
            <div class="py-5 text-center">
                <img class="d-block mx-auto mb-4" src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQUuaXz7MXhpP9p6e9Je_QK3yDFW5H7f5k8GQlkeUsdmyYQ4Xpf_BJiKPp6wB6hSPhsG58&usqp=CAU" alt="" width="172" height="157">
                <h2>Carrito de compras</h2>
                <p class="lead">Verifique la cantidad y los productos seleccionados para continuar con la compra</p>
            </div>

            <div class="row">
                <div class="row">
                    <div class="col">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:GridView runat="server" ID="dgvCarrito" CssClass="table table-hover" AutoGenerateColumns="false">
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
                                                <asp:Label runat="server" Text='<%# Eval("Precio") %>' CssClass="mt-3"></asp:Label>
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
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <asp:Button Text="Quitar Todo" ID="btnEliminarListaCompleta" runat="server" />
                    </div>
                </div>
            </div>

            <h4 class="mb-3">Metodo de pago</h4>
            <div class="my-3">
                <div class="form-check">
                    <input id="credit" name="paymentMethod" type="radio" class="form-check-input" checked required>
                    <label class="form-check-label" for="credit">Tarjeta de crédito</label>
                </div>
                <div class="form-check">
                    <input id="debit" name="paymentMethod" type="radio" class="form-check-input" required>
                    <label class="form-check-label" for="debit">Tarjeta de débito</label>
                </div>
                <div class="form-check">
                    <input id="paypal" name="paymentMethod" type="radio" class="form-check-input" required>
                    <label class="form-check-label" for="paypal">MercadoPago</label>
                </div>
            </div>
            <button class="col-6 btn btn-primary btn-lg mb-5" type="submit">Ir al pago</button>
        </div>
    </main>

</asp:Content>
