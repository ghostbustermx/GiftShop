using System;
using System.Collections.Generic;

namespace GiftShop.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Producto = new HashSet<Producto>();
        }

        public int CategoriaId { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public string Nombre { get; set; }

        public ICollection<Producto> Producto { get; set; }
    }
}
