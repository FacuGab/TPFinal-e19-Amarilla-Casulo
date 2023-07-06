<%@ Page Title="HardFish" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Catalogo.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                 <div class="col">
                     <h1 class="mt-5">Los mejores hardware</h1>
                     <div class="slider responsive">
                         <asp:Repeater runat="server" ID="rptCategorias">
                             <ItemTemplate>
                                 <div>
                                     <%--<img class="img-fluid" src="http://placehold.it/200x200?text=1">--%>
                                     <div class="card bg-warning">
                                         <div class="card-body text-center">
                                             <h4 class="card-header fw-bold"><%#Eval("Descripcion") %></h4>
                                         </div>
                                         <div class="p-3 ">
                                             <asp:ImageButton ImageUrl='<%# Eval("UrlImagen") %>' class="card-img-top" ID="btnImgCate" OnClick="btnImgCate_Click" CommandArgument='<%# Eval("Id") %>' runat="server" />
                                         </div>
                                     </div>
                                 </div>
                             </ItemTemplate>
                         </asp:Repeater>
                     </div>
                 </div>
             </div>
         </div>
         <%--fin categorias--%>
         
         <%--TODO: Listar marcas--%>
         <div class="container">
             <div class="row">
                 <div class="col">
                     <h1 class="mt-5">Nuestras marcas</h1>
                     <div class="slider responsive">
                         <asp:Repeater runat="server" ID="rptMarcas">
                             <ItemTemplate>
                                 <div>
                                     <div class="card bg-dark text-light pb-3 ps-3 pe-3">
                                         <div class="card-body text-center">
                                             <h4 class="card-header fw-bold"><%#Eval("Descripcion") %></h4>
                                         </div>
                                         <asp:ImageButton ImageUrl='<%# Eval("UrlImagen") %>' class="card-img-top w-100" Width="" ID="btnImgCate" OnClick="btnImgCate_Click" CommandArgument='<%# Eval("Id") %>' runat="server" />
                                     </div>
                                 </div>
                             </ItemTemplate>
                         </asp:Repeater>
                     </div>
                 </div>
             </div>
         </div>
         <%--fin marcas--%>

         <button type="button" class="btn btn-primary" id="liveToastBtn">Show live toast</button>

<div class="toast-container position-fixed bottom-0 end-0 p-3">
  <div id="liveToast" class="toast" role="alert" aria-live="assertive" aria-atomic="true">
    <div class="toast-header">
      <img src="..." class="rounded me-2" alt="...">
      <strong class="me-auto">Bootstrap</strong>
      <small>11 mins ago</small>
      <button type="button" class="btn-close" data-bs-dismiss="toast" aria-label="Close"></button>
    </div>
    <div class="toast-body">
      Hello, world! This is a toast message.
    </div>
  </div>
</div>
         <%--fin toast--%>

         

    </main>
</asp:Content>
