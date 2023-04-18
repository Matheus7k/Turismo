using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using Models;
using static System.Formats.Asn1.AsnWriter;

namespace Repositories
{
    public class ClienteRepository
    {
        private string Conn { get; set; }

        public ClienteRepository()
        {
            Conn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        }

        public bool Insert(Cliente cliente)
        {
            bool status;

            using (var db = new SqlConnection(Conn))
            {
                db.Open();
                db.Execute(Cliente.INSERT, cliente);
                status = true;
            }

            return status;
        }

        public List<Cliente> GetAll()
        {
            using (var db = new SqlConnection(Conn))
            {
                var clientes = db.Query<Cliente>(Cliente.GETALL);
                return (List<Cliente>)clientes;
            }
        }
    }
}