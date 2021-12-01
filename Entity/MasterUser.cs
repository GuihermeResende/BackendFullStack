using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceTenis.Entity
{
    public class MasterUser
    {
        public int id { get; set; }
        public String nome { get; set; }
        public String cpf { get; set; }
        public String email { get; set; }
        public String senha { get; set; }
    }
}
