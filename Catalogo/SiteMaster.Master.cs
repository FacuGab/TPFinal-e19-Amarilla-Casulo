﻿using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Catalogo
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        private Usuario userControl = null;
        public int itemsCarrito { get; set; }
        public bool Flag { get; set; }
        public Usuario usuario { get { return userControl; } }
        public string preUrl { get { return Request.UrlReferrer.ToString(); } }

        //LOAD
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
                {
                    Path = "~/scripts/jquery-3.6.0.min.js",
                    DebugPath = "~/scripts/jquery-3.6.0.js",
                    CdnPath = "https://code.jquery.com/jquery-3.6.0.min.js",
                    CdnDebugPath = "https://code.jquery.com/jquery-3.6.0.js"
                });

                if (Session["countCarrito"] != null)
                {
                    lblTotalArticulos.Text = Session["countCarrito"].ToString();
                    Flag = true;
                }
                else
                {
                    Flag = false;
                }

                if (Session["usuarioActual"] != null)
                {
                    btnLoggin.Visible = false;
                    btnDisloggin.Visible = true;
                }
                else
                {
                    btnLoggin.Visible = true;
                    btnDisloggin.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        //Filtro Rapido
        protected void btnFiltroRapido_Click(object sender, EventArgs e)
        {
            try
            {  
                string str = tbFiltroRapido.Text;
                if (!string.IsNullOrWhiteSpace(str))
                    Response.Redirect("Productos.aspx?text=" + str, false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        // Boton Cerrar (en modal)
        protected void btnCerrarModal_Click(object sender, EventArgs e)
        {
            lblUsuarioNoExiste.Visible = false;
        }

        // Boton Ingresar (en modal de ingreso)
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                string pass = txtClaveLogin.Text;
                string mail = txtMailLogin.Text;
                string paginaActual = Page.Request.Url.ToString();

                if( !string.IsNullOrWhiteSpace(pass) && !string.IsNullOrWhiteSpace(mail))
                {
                    NegocioUsuario negocioUsuario = new NegocioUsuario();
                    userControl = negocioUsuario.BuscarUsuario(mail, pass);
                    if (userControl != null)
                    {
                        Session.Add("usuarioActual", userControl);
                        Response.Redirect(paginaActual, false);
                        btnLoggin.Visible = false;
                        btnDisloggin.Visible = true;
                    }
                    else
                    {
                        lblUsuarioNoExiste.Visible = true;
                        lblRespuestaLoggin.Text = "Usuario No Encontrado";
                    }
                }
                else
                {
                    lblUsuarioNoExiste.Visible = true;
                    lblRespuestaLoggin.Text = "Campos Incorrectos";
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        // Boton Cerrar Sesion (en nav)
        protected void btnDisloggin_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Remove("usuarioActual");
                Session.Remove("listaCarrito");
                Session.Remove("countCarrito");
                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registro.aspx", false);
        }
    }
}