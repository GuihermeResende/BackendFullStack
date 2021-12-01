using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceTenis.Entity
{
    public class Carrinho
    {
        public int id { get; set; }
        public Double valorTotal { get; set; }
        public Double quantidade { get; set; }
        public List<Produto> produtos { get; set; }

    }
}
