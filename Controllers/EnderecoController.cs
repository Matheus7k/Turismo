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
        private readonly EnderecoService _enderecoService;

        public EnderecoController()
        {
            _enderecoService = new();
        }

        public bool Insert(Endereco endereco)
        {
            return _enderecoService.Insert(endereco);
        }

        public bool Delete(string logradouro, int numero)
        {
            Endereco enderecoToDelete = _enderecoService.GetEndereco(logradouro, numero);

            if(enderecoToDelete.Logradouro == null)
            {
                Console.WriteLine("Endereço não cadastrado!");
            }

            return _enderecoService.Delete(enderecoToDelete);
        }

        public bool Update(Endereco endereco)
        {
            return _enderecoService.Update(endereco);
        }

        public Endereco GetEndereco(string logradouro, int numero)
        {
            return _enderecoService.GetEndereco(logradouro, numero);
        }

        public List<Endereco> GetEnderecos()
        {
            return _enderecoService.GetEnderecos();
        }
    }
}
