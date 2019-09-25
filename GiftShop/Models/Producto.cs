using System;
using System.Collections.Generic;

namespace GiftShop.Models
{
    public partial class Producto
    {
        public int ProductoId { get; set; }
        public int CategoriaId { get; set; }
        public decimal Costo { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public string Nombre { get; set; }

        public Categoria Categoria { get; set; }
    }
}
