using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lojavirtual.Entidade
{
    public class Produto
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string descricao { get; set; }
        public string validade { get; set; }
        public int quantidade { get; set; }
        public double preco { get; set; }
    }
}