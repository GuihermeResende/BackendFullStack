using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceTenis.Entity
{
    public class Cliente
    {

        public int id { get; set; }
        public String nome { get; set;}
        public String cpf { get; set; }
        public DateTime dataNascimento { get; set; }
        public String email { get; set; }
        public String senha { get; set; }
        public String perfil { get; set; }
        public Endereco endereco { get; set; }

    }
}
