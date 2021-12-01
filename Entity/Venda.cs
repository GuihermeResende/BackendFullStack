using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceTenis.Entity
{
    public class Venda
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public Produto produto{ get; set; }
        public DateTime MomentoDaCompra { get; set; }
        public int quantidade { get; set; }
        public Double valorTotal { get; set; }
    }
}
