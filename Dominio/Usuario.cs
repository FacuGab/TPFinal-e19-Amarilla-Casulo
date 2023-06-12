﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }
        public string Mail { get; set; }
        public string Clave { get; set; }
        public string Direccion { get; set; }
        public char Nivel { get; set; }
        public string UrlImgUsuario { get; set; }

        //CONSTRUCTORES
        public Usuario() { }
        public Usuario(int id, string nombre, string apellido, int dni, string mail, string clave, string direccion, char nivel, string urlImgUsuario)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Dni = dni;
            Mail = mail;
            Clave = clave;
            Direccion = direccion;
            Nivel = nivel;
            UrlImgUsuario = urlImgUsuario;
        }
    }
}