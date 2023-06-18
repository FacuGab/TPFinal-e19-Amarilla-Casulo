<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ListaCarrito.aspx.cs" Inherits="Catalogo.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main aria-labelledby="title">

        <div class="container">
            <div class="py-5 text-center">
                <img class="d-block mx-auto mb-4" src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQUuaXz7MXhpP9p6e9Je_QK3yDFW5H7f5k8GQlkeUsdmyYQ4Xpf_BJiKPp6wB6hSPhsG58&usqp=CAU" alt="" width="172" height="157">
                <h2>Carrito de compras</h2>
                <p class="lead">Verifique la cantidad y los productos seleccionados para continuar con la compra</p>
            </div>

            <asp:GridView runat="server" ID="dgvCarrito" CssClass="table table-hover"></asp:GridView>
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
