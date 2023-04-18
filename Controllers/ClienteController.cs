using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Repositories;
using Services;

namespace Controllers
{
    public class ClienteController
    {
        private ClienteService clienteService;

        public ClienteController()
        {
            clienteService = new ClienteService();    
        }

        public bool Insert(Cliente cliente)
        {
            return clienteService.Insert(cliente);
        }

        public List<Cliente> GetCliente()
        {
            return clienteService.GetClientes();
        }

        public Cliente GetClienteNome(string nome)
        {
            return clienteService.GetCliente(nome);
        }

        public bool InsertDapper(Cliente cliente)
        {
            return new ClienteRepository().Insert(cliente);
        }

        public List<Cliente> GetClientesDapper()
        {
            return new ClienteRepository().GetAll();
        }
    }
}
