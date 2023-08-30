<%@ Page Title="HardFish" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Catalogo.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <main style="background-image:url(https://img3.wallspic.com/previews/9/2/0/5/6/165029/165029-imac_color_matching_wallpaper_in_dark_purple_for_ipad_or_desktop-x750.jpg);background-repeat: no-repeat;
         background-attachment: fixed;
         background-size: cover;">
         <%-- CAROUSEL BANNER--%>
         <div id="carousel-1" class="carousel slide mt-5" data-bs-ride="false">
             <div class="carousel-inner">
                 <div class="carousel-item active">
                     <img class="w-100 d-block" src="https://logitechsouthcone.com/logitechg/images/Landing-Gaming-BANNERS_WEBCAM.jpg" alt="Slide Image" /></div>
                 <div class="carousel-item">
                     <img class="w-100 d-block" src="https://logitechsouthcone.com/logitechg/images/Landing-Gaming-BANNERS_Mousepad.jpg" alt="Slide Image" /></div>
                 <div class="carousel-item">
                     <img class="w-100 d-block" src="https://logitechsouthcone.com/logitechg/images/Landing-Gaming-BANNERS_MOuse.jpg" alt="Slide Image" /></div>
             </div>
             <div><a class="carousel-control-prev" href="#carousel-1" role="button" data-bs-slide="prev"><span class="carousel-control-prev-icon" aria-hidden="true"></span><span class="visually-hidden">Previous</span></a><a class="carousel-control-next" href="#carousel-1" role="button" data-bs-slide="next"><span class="carousel-control-next-icon" aria-hidden="true"></span><span class="visually-hidden">Next</span></a></div>
             <div class="carousel-indicators">
                 <button class="active" type="button" data-bs-target="#carousel-1" data-bs-slide-to="0"></button>
                 <button type="button" data-bs-target="#carousel-1" data-bs-slide-to="1"></button>
                 <button type="button" data-bs-target="#carousel-1" data-bs-slide-to="2"></button>
             </div>
         </div>
         <%-- FIN CAROUSEL --%>

         <%--TODO: Listar categorias--%>
         <div class="container mt-5">
             <div class="row">
                 <div class="col">
                     <h1 class="mt-5 fw-bold text-light">Los mejores hardware</h1>
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
         <div class="container mt-5">
             <div class="row">
                 <div class="col">
                     <h1 class="mt-5 fw-bold text-light">Nuestras marcas</h1>
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

         <%--sección nuestro equipo--%>
             <div id="nuestroEquipo" class="container py-4 py-xl-5 mt-5" >
                 <div class="row mb-4 mb-lg-5">
                     <div class="col-md-12 col-xl-6 text-center mx-auto">
                         <h2 class="text-bg-light rounded-4 p-2"><strong>Nuestro equipo</strong></h2>
                     </div>
                 </div>
                 <div  class="row gy-4 row-cols-2 row-cols-md-4">
                     <div class="col"></div>
                     <div class="col">
                         <div class="card-body text-center d-flex flex-column align-items-center p-0">
                             <img class="rounded-circle mb-3 fit-cover" width="130" height="130" src="https://avatars.githubusercontent.com/u/85770730?v=4" />
                             <h5 class="fw-bold text-warning card-title mb-0"><strong>Emanuel F. Casulo</strong></h5>
                             <p class="text-light card-text mb-2">Legajo: 24482</p>
                             <ul class="list-inline fs-6 text-muted w-100 mb-0">
                                 <li class="list-inline-item text-center">
                                     <div class="d-flex flex-column align-items-center">
                                         <a href="https://github.com/EmanuelFCasulo"><i class="bi bi-github text-light fs-4"></i></a>
                                     </div>
                                 </li>
                             </ul>
                         </div>
                     </div>
                     <div class="col">
                         <div class="card-body text-center d-flex flex-column align-items-center p-0">
                             <img class="rounded-circle mb-3 fit-cover" width="130" height="130" src="https://avatars.githubusercontent.com/u/76824041?v=4" />
                             <h5 class="fw-bold text-warning card-title mb-0"><strong>Facundo Amarilla</strong></h5>
                             <p class="text-light card-text mb-2">Legajo:</p>
                             <ul class="list-inline fs-6 text-muted w-100 mb-0">
                                 <li class="list-inline-item text-center">
                                     <div class="d-flex flex-column align-items-center">
                                         <a href="https://github.com/FacuGab"><i class="bi bi-github text-light fs-4"></i></a>
                                     </div>
                                 </li>
                             </ul>
                         </div>
                     </div>
                 </div>
             </div>
         <%--fin sección nuestro equipo--%>
    </main>
</asp:Content>
