using Dominio;
using Helper;
using Negocio;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Catalogo
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        NegocioUsuario NuevoUsuario;

        //LOAD
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnRegistroUsu.Enabled = true;
            }
        }

        //TODO:BOTON CREAR USUARIO (Importante)
        protected void btnRegistroUsu_Click(object sender, EventArgs e)
        {
            try
            {
                //si es valido los imputs
                if(Page.IsValid)
                {
                    if (string.IsNullOrEmpty(txtNombre.Text) || 
                        string.IsNullOrEmpty(txtApellido.Text) ||
                        string.IsNullOrEmpty(txtDni.Text) || 
                        string.IsNullOrEmpty(txtMail.Text) || 
                        string.IsNullOrEmpty(txtPassword.Text) || 
                        string.IsNullOrEmpty(txtDomicilio.Text) ||
                        !txtDni.Text.All(char.IsDigit) && !txtDni.Text.All(char.IsNumber) ||
                        !txtNombre.Text.All(char.IsLetter) ||
                        !txtApellido.Text.All(char.IsLetter) ||
                        !txtMail.Text.Contains("@") ||
                        !txtMail.Text.Contains("."))
                        
                    {
                        HelperUsuario.MensajePopUp(this, "Hay campos erróneos o vacíos");
                        return;
                    }
                    //cargamos usuario
                    Usuario usuario = new Usuario();
                    usuario.Nombre = txtNombre.Text;
                    usuario.Apellido = txtApellido.Text;
                    usuario.Dni = int.Parse(txtDni.Text);
                    usuario.Mail = txtMail.Text;
                    usuario.Clave = txtPassword.Text;
                    usuario.Direccion = txtDomicilio.Text;
                    usuario.Nivel = "C";
                    usuario.UrlImgUsuario = "img/usuarios/default.png";
                    usuario.Activo = true;

                    //vemos si esta registrado
                    if (HelperUsuario.ExistUser(usuario))
                    {
                        HelperUsuario.MensajePopUp(this, "Usuario Existente");
                    }
                    else
                    {
                        //Registramos usuario
                        NuevoUsuario = new NegocioUsuario();
                        int res = NuevoUsuario.AgregarUsuario(usuario);
                        
                        //si fue exitoso el registro, se envia un mail de bienvenida
                        if (res > 0)
                        {
                            HelperUsuario.MensajePopUp(this, "Usuario Registrado Exitosamente, debes iniciar sesión.");
                            try
                            {
                                EmailService emailService = new EmailService(); // eviar mail de bienvenida
                                emailService.ArmarCorreo(usuario.Mail, "Bienvenido a HardFish", "Gracias por registrarte en HardFish Store, esperamos que disfrutes de nuestros productos. Saludos!");
                                emailService.EnviarCorreo();
                            }
                            catch (Exception)
                            {
                                HelperUsuario.MensajePopUp(this, "Error al enviar mail de registro");
                            }
                            Session["MensajeExito"] = "Usuario Registrado Exitosamente, debes iniciar sesión.";
                            Response.Redirect("Default.aspx", false);

                            // aca un response a Default.aspx o a ListaCarrito.aspx?text=ok&reg=ok. funciona correcteamente, pero es tan rapido que no muestra el cartel, intente poner un async await pero fallo por completo
                        }
                        else
                        {
                            HelperUsuario.MensajePopUp(this, "No se pudo crear el usuario");
                        }
                    }  
                }
                else
                {
                    HelperUsuario.MensajePopUp(this, "Hubo error en una validación");
                    return;
                } 
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }


        //METODOS DE VALIDACION DE LOS CAMPOS
        #region Validaciones
        protected void customValidatorNombre_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string nombre = txtNombre.Text;
            bool isValid = !string.IsNullOrWhiteSpace(nombre) && System.Text.RegularExpressions.Regex.IsMatch(nombre, "^[A-Za-z\\s]+$");
            args.IsValid = isValid;
            customValidatorNombre.ErrorMessage = "El nombre debe contener solo letras y espacios.";
            customValidatorNombre.Visible = false;
        }
        protected void customValidatorApellido_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string apellido = txtApellido.Text;
            bool isValid = !string.IsNullOrWhiteSpace(apellido) && System.Text.RegularExpressions.Regex.IsMatch(apellido, "^[A-Za-z\\s]+$");
            args.IsValid = isValid;
            customValidatorApellido.ErrorMessage = "El apellido es obligatorio solo se permiten letras.";
            customValidatorApellido.Visible = false;
        }

        protected void customValidatorDocumento_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string dni = txtDni.Text;
            bool isValid = !string.IsNullOrWhiteSpace(dni) && System.Text.RegularExpressions.Regex.IsMatch(dni, @"^\d+$"); /*Para que solo acepte 8 digitos  @"^\d{8}$"  */
            args.IsValid = isValid;
            customValidatorDocumento.ErrorMessage = "El DNI solo debe tener números";
            customValidatorDocumento.Visible = false;
        }


        protected void customValidatorMail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string mail = txtMail.Text;
            bool isValid = !string.IsNullOrWhiteSpace(mail) && System.Text.RegularExpressions.Regex.IsMatch(mail, @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$");
            args.IsValid = isValid;
            customValidatorMail.ErrorMessage = "Ingrese un mail correcto";
            customValidatorMail.Visible = false;
        }

        protected void customValidatorDomicilio_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string domicilio = txtDomicilio.Text;
            bool isValid = !string.IsNullOrWhiteSpace(domicilio) && System.Text.RegularExpressions.Regex.IsMatch(domicilio, "^[A-Za-z0-9\\s.,-]+$");
            args.IsValid = isValid;
            customValidatorDomicilio.ErrorMessage = "Ingrese un domicilio válido";
            customValidatorDomicilio.Visible = false;
        }

        //protected void customValidatorTipoUsuario_ServerValidate(object source, ServerValidateEventArgs args)
        //{
        //    string tipoUsuario = txtTipoUsuario.Text;
        //    bool isValid = !string.IsNullOrWhiteSpace(tipoUsuario) && (tipoUsuario == "C" || tipoUsuario == "A" || tipoUsuario == "E");
        //    args.IsValid = isValid;
        //    customValidatorTipoUsuario.ErrorMessage = "Tipos de usuarios admitidos: C - Cliente, A - Admin, E- Empleado";
        //    customValidatorTipoUsuario.Visible = false;
        //}

        protected void customValidatorPassword_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string password = txtPassword.Text;
            bool isValid = !string.IsNullOrWhiteSpace(password) && System.Text.RegularExpressions.Regex.IsMatch(password, "^(?=.*[A-Za-z])(?=.*\\d).+$");
            args.IsValid = isValid;
            customValidatorPassword.ErrorMessage = "La clave debe contener al menos un número y letra";
            customValidatorPassword.Visible = false;

        }
        #endregion Validaciones

    }

}