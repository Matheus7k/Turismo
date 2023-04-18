using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Services;

namespace Controllers
{
    public class EnderecoController
    {
        public bool Insert(Endereco endereco)
        {
            return new EnderecoService().Insert(endereco);
        }

        public bool Delete(string logradouro, int numero)
        {
            Endereco enderecoToDelete = new EnderecoService().GetEndereco(logradouro, numero);

            if(enderecoToDelete.Logradouro == null)
            {
                Console.WriteLine("Endereço não cadastrado!");
            }

            return new EnderecoService().Delete(enderecoToDelete);
        }

        public bool Update(Endereco endereco)
        {
            return new EnderecoService().Update(endereco);
        }

        public Endereco GetEndereco(string logradouro, int numero)
        {
            return new EnderecoService().GetEndereco(logradouro, numero);
        }

        public List<Endereco> GetEnderecos()
        {
            return new EnderecoService().GetEnderecos();
        }
    }
}
