using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Cliente
    {
        public readonly static string INSERT = "insert into Cliente (Nome, Telefone, Endereco, DataCadastro) values (@Nome, @Telefone,@Endereco, @DataCadastro)";
        public readonly static string GETALL = "select cli.Id, cli.Nome, cli.Telefone, e.Logradouro, e.Numero , e.Bairro, e.CEP, e.Complemento, c.Descricao Cidade, cli.DataCadastro from Cliente cli, Endereco e, Cidade c where cli.Endereco = e.Id and e.Cidade = c.Id";
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public Endereco Endereco { get; set; }
        public DateTime DataCadastro { get; set; }

        public override string ToString()
        {
            return $"\nNome: {Nome}\nTelefone: {Telefone}\n{Endereco}\nData de cadastro: {DataCadastro}";
        }
    }
}
