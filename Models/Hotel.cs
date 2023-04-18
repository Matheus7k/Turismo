using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
        public DateTime DataCriacao { get; set; }
        public decimal Valor { get; set; }

        public override string ToString()
        {
            return $"Nome: {Nome}\n{Endereco}\nValor: {Valor}";
        }
    }
}
