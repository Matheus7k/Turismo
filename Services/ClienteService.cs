using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public class ClienteService
    {
        readonly string _strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\Desktop\c#\DB\Turismo\Turismo\Banco\turismo.mdf;";
        readonly SqlConnection Conn;

        public ClienteService()
        {
            Conn = new(_strConn);
            Conn.Open();
        }

        public bool Insert(Cliente cliente)
        {
            bool status;

            try
            {
                string strInsertCliente = "insert into Cliente (Nome, Telefone, Endereco, DataCadastro) values (@Nome, @Telefone,@Endereco, @DataCadastro)";

                SqlCommand commandInsertCliente = new(strInsertCliente, Conn);

                commandInsertCliente.Parameters.Add(new SqlParameter("@Nome", cliente.Nome));
                commandInsertCliente.Parameters.Add(new SqlParameter("@Telefone", cliente.Telefone));
                commandInsertCliente.Parameters.Add(new SqlParameter("@Endereco", InsertEndereco(cliente)));
                commandInsertCliente.Parameters.Add(new SqlParameter("@DataCadastro", cliente.DataCadastro));

                commandInsertCliente.ExecuteNonQuery();

                status = true;
            }
            catch (Exception ex)
            {
                throw ex;
                status = false;
            }

            return status;
        }

        public int InsertEndereco(Cliente cliente)
        {
            string strInsertEndereco = "insert into Endereco (Logradouro, Numero, Bairro, CEP, Complemento, Cidade, DataCadastro) values (@Logradouro, @Numero, @Bairro, @CEP, @Complemento, @Cidade, @DataCadastro); select cast(scope_identity() as int)";

            SqlCommand commandInsertEndereco = new(strInsertEndereco, Conn);

            commandInsertEndereco.Parameters.Add(new SqlParameter("@Logradouro", cliente.Endereco.Logradouro));
            commandInsertEndereco.Parameters.Add(new SqlParameter("@Numero", cliente.Endereco.Numero));
            commandInsertEndereco.Parameters.Add(new SqlParameter("@Bairro", cliente.Endereco.Bairro));
            commandInsertEndereco.Parameters.Add(new SqlParameter("@CEP", cliente.Endereco.CEP));
            commandInsertEndereco.Parameters.Add(new SqlParameter("@Complemento", cliente.Endereco.Complemento));
            commandInsertEndereco.Parameters.Add(new SqlParameter("@Cidade", cliente.Endereco.Cidade.Id));
            commandInsertEndereco.Parameters.Add(new SqlParameter("@DataCadastro", cliente.Endereco.DataCadastro));

            return (int)commandInsertEndereco.ExecuteScalar();
        }

        public List<Cliente> GetClientes()
        {
            List<Cliente> clientes = new();

            StringBuilder sb = new();

            sb.Append("select cli.Id, cli.Nome, cli.Telefone, e.Logradouro, e.Numero , e.Bairro, e.CEP, e.Complemento, c.Descricao Cidade, cli.DataCadastro");
            sb.Append(" from Cliente cli, Endereco e, Cidade c where cli.Endereco = e.Id and e.Cidade = c.Id");

            SqlCommand commandSelect = new(sb.ToString(), Conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Cliente cliente = new();

                cliente.Id = (int)dr["Id"];
                cliente.Nome = (string)dr["Nome"];
                cliente.Telefone = (string)dr["Telefone"];
                cliente.Endereco = new Endereco()
                {
                    Logradouro = (string)dr["Logradouro"],
                    Numero = (int)dr["Numero"],
                    Bairro = (string)dr["Bairro"],
                    CEP = (string)dr["CEP"],
                    Complemento = (string)dr["Complemento"],
                    Cidade = new Cidade() { Descricao = (string)dr["Cidade"] },
                };
                cliente.DataCadastro = (DateTime)dr["DataCadastro"];

                clientes.Add(cliente);
            }

            return clientes;
        }

        public Cliente GetCliente(string nome)
        {
            StringBuilder sb = new();

            sb.Append("select cli.Id, cli.Nome, cli.Telefone, e.Logradouro, e.Numero , e.Bairro, e.CEP, e.Complemento, c.Descricao Cidade, cli.DataCadastro");
            sb.Append(" from Cliente cli, Endereco e, Cidade c where cli.Endereco = e.Id and e.Cidade = c.Id");

            SqlCommand commandSelect = new(sb.ToString(), Conn);

            commandSelect.Parameters.Add(new SqlParameter("@Nome", nome));

            SqlDataReader dr = commandSelect.ExecuteReader();

            Cliente cliente = new();

            while (dr.Read())
            {
                cliente.Id = (int)dr["Id"];
                cliente.Nome = (string)dr["Nome"];
                cliente.Telefone = (string)dr["Telefone"];
                cliente.Endereco = new Endereco()
                {
                    Logradouro = (string)dr["Logradouro"],
                    Numero = (int)dr["Numero"],
                    Bairro = (string)dr["Bairro"],
                    CEP = (string)dr["CEP"],
                    Complemento = (string)dr["Complemento"],
                    Cidade = new Cidade() { Descricao = (string)dr["Cidade"] },
                };
                cliente.DataCadastro = (DateTime)dr["DataCadastro"];
            }

            return cliente;
        }
    }
}
