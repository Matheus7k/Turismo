using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Pacotes
    {
        public int Id { get; set; }
        public Hotel Hotel { get; set; }
        public Passagem Passagem { get; set; }
        public DateTime DataCadastro { get; set; }
        public decimal Valor { get; set; }
        public Cliente Cliente { get; set; }
    }
}
