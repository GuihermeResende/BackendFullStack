using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EcommerceTenis.Entity
{
    public class Endereco
    {

        public int id { get; set; }
        public String rua { get; set; }
        public int numero { get; set; }
        public String complemento { get; set; }
        public String bairro { get; set; }
        public String cidade { get; set; }
        public int cep { get; set; }

    }
}
