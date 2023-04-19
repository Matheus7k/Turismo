using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Pacote
    {
        public int Id { get; set; }
        public Hotel Hotel { get; set; }
        public Passagem Passagem { get; set; }
        public DateTime DataCadastro { get; set; }
        public decimal Valor { get; set; }
        public Cliente Cliente { get; set; }

        public override string ToString()
        {
            return $"Hotel: {Hotel.Nome}\nPassagem: {Passagem.Id}\nData Cadastro: {DataCadastro}\nValor: {Valor}\nCliente: {Cliente.Nome}\n";
        }
    }
}
