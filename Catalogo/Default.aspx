<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Catalogo.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="fonts/styles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <main>
        <%-- CAROUSEL BANNER--%>
        <section class="row" aria-labelledby="aspnetTitle">
            <div id="myCarousel" class="carousel slide mb-6 " data-bs-ride="carousel" data-bs-theme="light">
                <div class="carousel-indicators">
                    <button type="button" data-bs-target="#myCarousel" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                    <button type="button" data-bs-target="#myCarousel" data-bs-slide-to="1" aria-label="Slide 2"></button>
                    <button type="button" data-bs-target="#myCarousel" data-bs-slide-to="2" aria-label="Slide 3"></button>
                </div>
                <div class="carousel-inner">
                    <div class="carousel-item active">
                        <img src="https://logitechsouthcone.com/logitechg/images/Landing-Gaming-BANNERS_WEBCAM.jpg" class="d-block w-100" alt="...">
                        <div class="carousel-caption d-none d-md-block">
                            <h5>First slide label</h5>
                            <p>Some representative placeholder content for the first slide.</p>
                        </div>
                    </div>
                    <div class="carousel-item">
                        <img src="https://logitechsouthcone.com/logitechg/images/Landing-Gaming-BANNERS_Mousepad.jpg" class="d-block w-100" alt="...">
                        <div class="carousel-caption d-none d-md-block">
                            <h5>First slide label</h5>
                            <p>Some representative placeholder content for the first slide.</p>
                        </div>
                    </div>
                    <div class="carousel-item">
                        <img src="https://logitechsouthcone.com/logitechg/images/Landing-Gaming-BANNERS_MOuse.jpg" class="d-block w-100" alt="...">
                        <div class="carousel-caption d-none d-md-block">
                            <h5>First slide label</h5>
                            <p>Some representative placeholder content for the first slide.</p>
                        </div>
                    </div>
                </div>
                <button class="carousel-control-prev" type="button" data-bs-target="#myCarousel" data-bs-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Previous</span>
                </button>
                <button class="carousel-control-next" type="button" data-bs-target="#myCarousel" data-bs-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Next</span>
                </button>
            </div>
        </section>
            <%-- FIN CAROUSEL --%>

        <%--TODO: Listar categorias--%>
         <div class="container">
             <div class="row">
                 <h1 class="mt-5">Los mejores hardware</h1>
                 <asp:Repeater runat="server" ID="rptCategorias">
                     <ItemTemplate>
                         <div class="card m-3 mt-4" style="width: 18rem;">
                             <asp:ImageButton ImageUrl='<%# Eval("UrlImagen") %>' class="card-img-top" ID="btnImgCate" OnClick="btnImgCate_Click" CommandArgument='<%# Eval("Id") %>' runat="server" />
                             <div class="card-body">
                                 <p class="card-text text-center fs-4"><%#Eval("Descripcion") %></p>
                             </div>
                         </div>
                     </ItemTemplate>
                 </asp:Repeater>
             </div>
         </div>
         <%--fin categorias--%>
         
         <%--TODO: Listar marcas--%>
         <div class="container">
             <div class="row">
                 <h1 class="mt-5">Las mejores Marcas</h1>
                 <asp:Repeater runat="server" ID="rptMarcas">
                     <ItemTemplate>
                         <div class="card m-3 mt-4" style="width: 18rem;">
                             <asp:ImageButton ImageUrl='<%# Eval("UrlImagen") %>' class="card-img-top" ID="btnImgMarca" OnClick="btnImgMarca_Click" CommandArgument='<%# Eval("Id") %>' runat="server" />
                         </div>
                     </ItemTemplate>
                 </asp:Repeater>
             </div>
         </div>
         <%--fin marcas--%>

    </main>
</asp:Content>
