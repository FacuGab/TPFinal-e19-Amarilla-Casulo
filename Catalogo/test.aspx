<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="Catalogo.test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- PAGINA PARA TESTEAR COSAS -->
    <div class="container">
        <div class="row justify-content-center">

            <div class="col-9" style="padding-top:100px">

                <h3>PAGINA TEST</h3>
                <h4>Traemos distintos datos de la bd, articulos, marcas y categorias</h4>

                <h5>Marcas:</h5>
                <asp:GridView ID="dgvGridTest1" runat="server" CssClass="table">
                    <Columns>
                        <asp:BoundField HeaderText="Id" DataField="Id" />
                        <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                        <asp:ImageField HeaderText="Imagen" DataImageUrlField="UrlImagen" />
                    </Columns>
                </asp:GridView>
                <h5>Categorias:</h5>
                <asp:GridView ID="dgvGridTest2" runat="server" CssClass="table">
                    <Columns>
                        <asp:BoundField HeaderText="Id" DataField="Id" />
                        <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                        <asp:ImageField HeaderText="Imagen" DataImageUrlField="UrlImagen" />
                    </Columns>
                </asp:GridView>
                <!-- se rompe el .toString() -->
                <h5>Articulos:</h5>
                <asp:GridView ID="dgvGridTest3" runat="server" CssClass="table">
                </asp:GridView>

                <asp:GridView ID="dgvGridTest4" runat="server" AutoGenerateColumns="false" CssClass="table">
                    <Columns>
                        <asp:BoundField HeaderText="Id Articulo" DataField="Id"/>
                        <asp:BoundField HeaderText="Nombre" DataField="Nombre"/>
                        <asp:BoundField HeaderText="Descripcion" DataField="Descripcion"/>
                        <asp:BoundField HeaderText="Marca" DataField="Marca"/>
                        <asp:BoundField HeaderText="Categoria" DataField="Categoria"/>
                        <asp:BoundField HeaderText="Precio" DataField="Precio"/>
                        <asp:BoundField HeaderText="Estado" DataField="Estado"/>
                        <asp:BoundField HeaderText="Stock" DataField="Stock"/>
                        <asp:ImageField HeaderText="Imagen" DataImageUrlField="ImagenUrl" />
                    </Columns>
                </asp:GridView>

                <div class="row">
                    <h5>Cards en foreach de Articulos:</h5>
                        <%foreach(var art in Articulos){%>
                            <div class="col">
                                <div class="card" style="width: 18rem;">
                                    <!-- Ver si hacer un join y traer img con un top 1 para la img, o agregar una img default si se quiere usar -->
                                  <img src="<%:art.ImagenUrl %>" class="card-img-top" alt="imagen articulo">
                                  <div class="card-body">
                                    <h5 class="card-title"><%:art.Nombre %></h5>
                                    <p class="card-text"><%:art.Descripcion %></p>
                                    <p class="card-text">ID: <%:art.Id%></p>
                                    <p class="card-text">Codigo: <%:art.Cod%></p>
                                    <a href="#" class="btn btn-primary">Go somewhere</a>
                                  </div>
                                </div>
                            </div>
                        <% }%>
                    <h5>Cards en foreach de Articulos en Repeater:</h5>
                    <asp:Repeater ID="repeater" runat="server">
                        <ItemTemplate>
                            <div class="col">
                                <div class="card" style="width: 18rem;">
                                    <!-- Ver si hacer un join y traer img con un top 1 para la img, o agregar una img default si se quiere usar -->
                                  <img src="<%#Eval("ImagenUrl") %>" class="card-img-top" alt="imagen articulo">
                                  <div class="card-body">
                                    <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                    <p class="card-text"><%#Eval("Descripcion")%></p>
                                    <p class="card-text">ID: <%#Eval("Id")%></p>
                                    <p class="card-text">Codigo: <%#Eval("Cod")%></p>
                                    <a href="#" class="btn btn-primary">Go somewhere</a>
                                  </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>

                <div class="row">
                    <div class="col">
                        <h5>Lista Usuarios:</h5>
                        <asp:GridView ID="dgvGridTest5" runat="server" CssClass="table"></asp:GridView>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <h5>Buscar Usuario DNI = 111</h5>
                        <asp:GridView ID="dgvGridTest6" runat="server" CssClass="table"></asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
