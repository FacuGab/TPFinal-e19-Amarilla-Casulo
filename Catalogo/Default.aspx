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

        <div class="container">
                     <%--categoria--%>
            <div class="col-6 mt-5">
                <h3 class="mb-3">Los mejores hardware</h3>
            </div>
             <div class="row mt-5">
                 <div class="col-3 p-0">
                     <img src="recursos/img/icons8-auricular-64.png" class="card-img-top" />
                 </div>
                 <div class="col-3 p-0">
                     <img src="recursos/img/icons8-ram-60.png" class="card-img-top"/>
                 </div>
                 <div class="col-3 p-0">
                     <img src="recursos/img/icons8-hdd-50.png" class="card-img-top"/>
                 </div>
                 <div class="col-3 p-0">
                     <img src="recursos/img/icons8-monitor-64.png" class="card-img-top"/>
                 </div>
                 <div class="col-3 p-0">
                    <img src="recursos/img/icons8-placa-base-62.png" class="card-img-top"/>
                 </div>
                 <div class="col-3 p-0">
                     <img src="recursos/img/icons8-procesador-64.png" class="card-img-top"/>
                 </div>
             </div>

         <%--fin categoria--%>
        </div>
        <%--CARD SLIDER--%>
        <section class="pt-5 pb-5">
            <div class="container mt-5">
                <div class="row">
                    <div class="col-6">
                        <h3 class="mb-3">Las mejores marcas para vos</h3>
                    </div>
                    <div class="col-4"></div>
                    <div class="col-2 text-right">
                        <a class="btn btn-primary mb-3 mr-1" href="#carouselExampleIndicators2" role="button" data-slide="prev">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-arrow-left" viewBox="0 0 16 16">
                                <path fill-rule="evenodd" d="M15 8a.5.5 0 0 0-.5-.5H2.707l3.147-3.146a.5.5 0 1 0-.708-.708l-4 4a.5.5 0 0 0 0 .708l4 4a.5.5 0 0 0 .708-.708L2.707 8.5H14.5A.5.5 0 0 0 15 8z" />
                            </svg>
                        </a>
                        <a class="btn btn-primary mb-3 " href="#carouselExampleIndicators2" role="button" data-slide="next">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-arrow-right" viewBox="0 0 16 16">
                                <path fill-rule="evenodd" d="M1 8a.5.5 0 0 1 .5-.5h11.793l-3.147-3.146a.5.5 0 0 1 .708-.708l4 4a.5.5 0 0 1 0 .708l-4 4a.5.5 0 0 1-.708-.708L13.293 8.5H1.5A.5.5 0 0 1 1 8z" />
                            </svg>
                        </a>
                    </div>
                    <div class="col-12">
                        <div id="carouselExampleIndicators2" class="carousel slide" data-ride="carousel">
                            <div class="carousel-inner">
                                <div class="carousel-item active">
                                    <div class="row">
                                        <div class="col-md-4 mb-3">
                                            <div class="card">
                                                <img class="img-fluid" alt="100%x280" src="https://front.dev.malditohard.com.ar/img/migration/PLACA-DE-VIDEO-RTX-3080-TI-ZOTAC-TRINITY-12GB.webp">
                                                <div class="card-body">
                                                    <h4 class="card-title">Special title treatment</h4>
                                                    <p class="card-text">With supporting text below as a natural lead-in to additional content.</p>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4 mb-3">
                                            <div class="card">
                                                <img class="img-fluid" alt="100%x280" src="https://www.necxus.com.ar/products_image/22875/1000x1000_2.jpg">
                                                <div class="card-body">
                                                    <h4 class="card-title">Special title treatment</h4>
                                                    <p class="card-text">With supporting text below as a natural lead-in to additional content.</p>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4 mb-3">
                                            <div class="card">
                                                <img class="img-fluid h-100 w-100" alt="100%x280" src="https://pcboutique.com.ar/content/images/thumbs/0002924_placa-de-video-zotac-rtx2060-ultra-gaming-6gb-ddr6-hdmidvivga_550.jpeg">
                                                <div class="card-body">
                                                    <h4 class="card-title">Special title treatment</h4>
                                                    <p class="card-text">With supporting text below as a natural lead-in to additional content.</p>

                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                                <div class="carousel-item">
                                    <div class="row">

                                        <div class="col-md-4 mb-3">
                                            <div class="card">
                                                <img class="img-fluid" alt="100%x280" src="https://www.mundodeportivo.com/alfabeta/hero/2022/06/mejores-procesadores-gaming.jpg?width=1200">
                                                <div class="card-body">
                                                    <h4 class="card-title">Special title treatment</h4>
                                                    <p class="card-text">With supporting text below as a natural lead-in to additional content.</p>

                                                </div>

                                            </div>
                                        </div>
                                        <div class="col-md-4 mb-3">
                                            <div class="card">
                                                <img class="img-fluid" alt="100%x280" src="https://i0.wp.com/codigoespagueti.com/wp-content/uploads/2021/02/intel-cpu.jpg">
                                                <div class="card-body">
                                                    <h4 class="card-title">Special title treatment</h4>
                                                    <p class="card-text">With supporting text below as a natural lead-in to additional content.</p>

                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4 mb-3">
                                            <div class="card">
                                                <img class="img-fluid" alt="100%x280" src="https://cdn.computerhoy.com/sites/navi.axelspringer.es/public/media/image/2021/06/procesador-intel-core-2383049.jpg?tf=3840x">
                                                <div class="card-body">
                                                    <h4 class="card-title">Special title treatment</h4>
                                                    <p class="card-text">With supporting text below as a natural lead-in to additional content.</p>

                                                </div>
                                            </div>
                                        </div>


                                    </div>
                                </div>
                                <%--<div class="carousel-item">
                                    <div class="row">

                                        <div class="col-md-4 mb-3">
                                            <div class="card">
                                                <img class="img-fluid" alt="100%x280" src="https://i.imgur.com/3Mv7VlW.jpg">
                                                <div class="card-body">
                                                    <h4 class="card-title">Special title treatment</h4>
                                                    <p class="card-text">With supporting text below as a natural lead-in to additional content.</p>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4 mb-3">
                                            <div class="card">
                                                <img class="img-fluid" alt="100%x280" src="https://img.pccomponentes.com/pcblog/7111/teclados-tkl-1.jpg">
                                                <div class="card-body">
                                                    <h4 class="card-title">Special title treatment</h4>
                                                    <p class="card-text">With supporting text below as a natural lead-in to additional content.</p>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-4 mb-3">
                                            <div class="card">
                                                <img class="img-fluid" alt="100%x280" src="https://www.qloud.ar/SITES/IMG/joy-div-computers-09-2021/236_12-10-2022-06-10-23-draconic-3.jpg">
                                                <div class="card-body">
                                                    <h4 class="card-title">Special title treatment</h4>
                                                    <p class="card-text">With supporting text below as a natural lead-in to additional content.</p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <%--FIN CARD SLIDER--%>



         <%--test1--%>
<div class="container text-center my-3">
		<div class="row mx-auto my-auto justify-content-center">
			<div id="recipeCarousel" class="carousel slide" data-bs-ride="carousel">
				<div class="carousel-inner" role="listbox">
					<div class="carousel-item active">
						<div class="col-md-4">
							<div class="card">
								<div class="card-img">
									<img src="https://via.placeholder.com/700x500.png/CB997E/333333?text=1" class="img-fluid">
								</div>
								<div class="card-img-overlay">Slide 1</div>
							</div>
						</div>
					
					<%--<div class="carousel-item">--%>
						<div class="col-md-4">
							<div class="card">
								<div class="card-img">
									<img src="https://via.placeholder.com/700x500.png/DDBEA9/333333?text=2" class="img-fluid">
								</div>
								<div class="card-img-overlay">Slide 2</div>
							</div>
						</div>
					<%--</div>--%>
					<%--<div class="carousel-item">--%>
						<div class="col-md-4">
							<div class="card">
								<div class="card-img">
									<img src="https://via.placeholder.com/700x500.png/FFE8D6/333333?text=3" class="img-fluid">
								</div>
								<div class="card-img-overlay">Slide 3</div>
							</div>
						</div>
					<%--</div>--%>
					<%--<div class="carousel-item">--%>
						<div class="col-md-4">
							<div class="card">
								<div class="card-img">
									<img src="https://via.placeholder.com/700x500.png/B7B7A4/333333?text=4" class="img-fluid">
								</div>
								<div class="card-img-overlay">Slide 4</div>
							</div>
						</div>
                        <div class="col-md-4">
							<div class="card">
								<div class="card-img">
									<img src="https://via.placeholder.com/700x500.png/B7B7A4/333333?text=4" class="img-fluid">
								</div>
								<div class="card-img-overlay">Slide 4</div>
							</div>
						</div>
                        <div class="col-md-4">
							<div class="card">
								<div class="card-img">
									<img src="https://via.placeholder.com/700x500.png/B7B7A4/333333?text=4" class="img-fluid">
								</div>
								<div class="card-img-overlay">Slide 4</div>
							</div>
						</div>
					<%--</div>--%>
                        </div>
					
					
				</div>
				<a class="carousel-control-prev bg-transparent w-auto" href="#recipeCarousel" role="button" data-bs-slide="prev">
					<span class="carousel-control-prev-icon" aria-hidden="true"></span>
				</a>
				<a class="carousel-control-next bg-transparent w-auto" href="#recipeCarousel" role="button" data-bs-slide="next">
					<span class="carousel-control-next-icon" aria-hidden="true"></span>
				</a>
			</div>
		</div>		
	</div>
         <%--fin test1--%>

    </main>
</asp:Content>
