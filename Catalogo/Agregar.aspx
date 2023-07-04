<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Agregar.aspx.cs" Inherits="Catalogo.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="vh-100 h-custom" style="background: rgb(0,0,0); background: radial-gradient(circle, rgba(0,0,0,1) 0%, rgba(148,187,233,1) 100%);" id="SectionCrearArt" >
        <div class="container py-5 h-100">
            <div class="row d-flex justify-content-center align-items-center h-100">
                <%--Carga nuevo artículo--%>
                <div class="card rounded-4 col-10 bg-warning" style="margin-top: 100px; margin-bottom: 100px;">
                    <div class=" card-header text-center">
                        <h1>🆕 Nuevo Artículo 🆕</h1>
                    </div>
                    <div class="row">
                        <div class="col-6 mt-3">
                            <label for="IdArticulo" class="form-label">Número de ID <span class="text-danger">*</span></label>
                            <asp:TextBox CssClass="form-control" ID="tbIdArt" placeholder="ID Articulo" runat="server" />
                        </div>
                        <div class="col-6 mt-3">
                            <label for="Nombre" class="form-label">Nombre <span class="text-danger">*</span></label>
                            <asp:TextBox CssClass="form-control" ID="tbNombreArt" runat="server" />
                        </div>
                        <div class="col-4 mt-3">
                            <label for="Marca" class="form-label">Marca<span class="text-danger">*</span></label>
                             <asp:DropDownList runat="server" ID="ddlMarca" CssClass="btn btn-light dropdown-toggle" Width="280px"></asp:DropDownList>
                        </div>
                        <div class="col-4 mt-3">
                            <label for="Categoria" class="form-label">Categoría <span class="text-danger">*</span></label>
                            <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="btn btn-light dropdown-toggle" Width="280px"></asp:DropDownList>
                        </div>
                        <div class="col-4 mt-3">
                            <label for="Stock" class="form-label">Stock <span class="text-danger">*</span></label>
                            <asp:TextBox CssClass="form-control" ID="tbStockArt" runat="server" />
                        </div>
                        <div class="col-4 mt-3">
                            <label for="Precio" class="form-label">Precio <span class="text-danger">*</span></label>
                            <asp:TextBox CssClass="form-control" ID="tbPrecioArt" runat="server" />
                        </div>
                        <div class="col-4 mt-3">
                            <label for="img" class="form-label">URL imágen <span class="text-danger">*</span></label>
                            <asp:TextBox CssClass="form-control" ID="tbImgArt" runat="server" AutoPostBack="true" OnTextChanged="tbImgArt_TextChanged" />
                        </div>
                        <div class="col-4 mt-3">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:Image ID="imgNuevoArt" runat="server" ImageUrl="~/recursos/img/agregar-img.png" Width="200px" CssClass="mt-3 ms-5" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="col-8 mt-3">
                            <label for="Descripcion" class="form-label">Descripcion <span class="text-danger">*</span></label>
                            <asp:TextBox CssClass="form-control pb-4" ID="tbDescripArt" runat="server" />
                        </div>
                        <div class="col-12 mt-3 text-center">
                            <asp:Button Text="Guardar artículo" ID="btnAgregar" CssClass="btn btn-dark text-light mb-3 ps-5 pe-5 fs-4" runat="server" OnClick="btnAgregar_Click"/>
                        </div>
                    </div>
                </div>
                <%--Fin Carga nuevo artículo--%>
            </div>
        </div>
    </section>
</asp:Content>
