using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceTenis.Entity
{
    public class Produto
    {

        public int id { get; set; }
        public String titulo { get; set; }
        public String descricao { get; set; }
        public String imagem { get; set; }
        public Double valor { get; set; }
        public MenuCategoria menuCategoria { get; set; }

    }
}
