using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_PTC
{
    public class Agregar
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Producto { get; set; }
        public string Precio { get; set; }
        public string Cantidad { get; set; }

        public Agregar() { }

        public Agregar(int pId, string pMarca, string pNombre, string pPrecio, string pCantidad)
        {
            this.Id = pId;
            this.Marca = pMarca;
            this. Producto = pNombre;
            this.Precio = pPrecio;
            this.Cantidad = pCantidad;
            
        }
    }
}