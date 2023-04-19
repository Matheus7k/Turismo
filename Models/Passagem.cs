using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Passagem
    {
        public int Id { get; set; }
        public Endereco Origem{ get; set; }
        public Endereco Destino { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }

        public override string ToString()
        {
            return $"Origem: {Origem}\nDestino: {Destino}\nCliente: {Cliente}\nData: {Data}\nValor: {Valor}";
        }
    }
}
