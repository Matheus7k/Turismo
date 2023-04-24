using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public class PassagemService
    {
        readonly string _strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\Desktop\c#\DB\Turismo\Turismo\Banco\turismo.mdf;";
        readonly SqlConnection Conn;

        public PassagemService()
        {
            Conn = new(_strConn);
            Conn.Open();
        }

        public bool Insert(Passagem passagem)
        {
            bool status;

            try
            {
                string strInsertPassagem = "insert into Passagem (Origem, Destino, Cliente, Data, Valor) values (@Origem, @Destino, @Cliente, @Data, @Valor)";

                SqlCommand commandInsertPassagem = new(strInsertPassagem, Conn);

                commandInsertPassagem.Parameters.Add(new SqlParameter("@Origem", InsertEnderecoOrigem(passagem)));
                commandInsertPassagem.Parameters.Add(new SqlParameter("@Destino", InsertEnderecoDestino(passagem)));
                commandInsertPassagem.Parameters.Add(new SqlParameter("@Cliente", passagem.Cliente.Id));
                commandInsertPassagem.Parameters.Add(new SqlParameter("@Data", passagem.Data));
                commandInsertPassagem.Parameters.Add(new SqlParameter("@Valor", passagem.Valor));

                commandInsertPassagem.ExecuteNonQuery();

                status = true;
            }
            catch (Exception ex)
            {
                throw ex;
                status = false;
            }

            return status;
        }

        public int InsertEnderecoOrigem(Passagem passagem)
        {
            string strInsertEndereco = "insert into Endereco (Logradouro, Numero, Bairro, CEP, Complemento, Cidade, DataCadastro) values (@Logradouro, @Numero, @Bairro, @CEP, @Complemento, @Cidade, @DataCadastro); select cast(scope_identity() as int)";

            SqlCommand commandInsertEndereco = new(strInsertEndereco, Conn);

            commandInsertEndereco.Parameters.Add(new SqlParameter("@Logradouro", passagem.Origem.Logradouro));
            commandInsertEndereco.Parameters.Add(new SqlParameter("@Numero", passagem.Origem.Numero));
            commandInsertEndereco.Parameters.Add(new SqlParameter("@Bairro", passagem.Origem.Bairro));
            commandInsertEndereco.Parameters.Add(new SqlParameter("@CEP", passagem.Origem.CEP));
            commandInsertEndereco.Parameters.Add(new SqlParameter("@Complemento", passagem.Origem.Complemento));
            commandInsertEndereco.Parameters.Add(new SqlParameter("@Cidade", passagem.Origem.Cidade.Id));
            commandInsertEndereco.Parameters.Add(new SqlParameter("@DataCadastro", passagem.Origem.DataCadastro));

            return (int)commandInsertEndereco.ExecuteScalar();
        }

        public int InsertEnderecoDestino(Passagem passagem)
        {
            string strInsertEndereco = "insert into Endereco (Logradouro, Numero, Bairro, CEP, Complemento, Cidade, DataCadastro) values (@Logradouro, @Numero, @Bairro, @CEP, @Complemento, @Cidade, @DataCadastro); select cast(scope_identity() as int)";

            SqlCommand commandInsertEndereco = new(strInsertEndereco, Conn);

            commandInsertEndereco.Parameters.Add(new SqlParameter("@Logradouro", passagem.Destino.Logradouro));
            commandInsertEndereco.Parameters.Add(new SqlParameter("@Numero", passagem.Destino.Numero));
            commandInsertEndereco.Parameters.Add(new SqlParameter("@Bairro", passagem.Destino.Bairro));
            commandInsertEndereco.Parameters.Add(new SqlParameter("@CEP", passagem.Destino.CEP));
            commandInsertEndereco.Parameters.Add(new SqlParameter("@Complemento", passagem.Destino.Complemento));
            commandInsertEndereco.Parameters.Add(new SqlParameter("@Cidade", passagem.Destino.Cidade.Id));
            commandInsertEndereco.Parameters.Add(new SqlParameter("@DataCadastro", passagem.Destino.DataCadastro));

            return (int)commandInsertEndereco.ExecuteScalar();
        }

        public List<Passagem> GetPassagens()
        {
            List<Passagem> passagens = new();

            string strSelectPassagens = "select p.Id, p.Origem, p.Destino, p.Cliente, p.[Data], p.Valor, cli.Nome from Passagem p, Endereco e, Cidade c, Cliente cli where p.Destino = e.Id and e.Cidade = c.Id and p.Cliente = cli.Id";

            SqlCommand commandSelectPassagem = new(strSelectPassagens, Conn);

            SqlDataReader dr = commandSelectPassagem.ExecuteReader();

            while(dr.Read())
            {
                Passagem passagem = new();

                passagem.Origem = new EnderecoService().GetEnderecoId((int)dr["Origem"]);
                passagem.Destino = new EnderecoService().GetEnderecoId((int)dr["Destino"]);
                passagem.Cliente = new ClienteService().GetClienteId((int)dr["Cliente"]);
                passagem.Data = (DateTime)dr["Data"];
                passagem.Valor = (decimal)dr["Valor"];

                passagens.Add(passagem);
            }

            return passagens;
        }

        public Passagem GetPassagemId(int id)
        {
            StringBuilder sb = new();

            sb.Append("select p.Id, p.Origem, p.Destino, p.Cliente, p.[Data], p.Valor from Passagem p where p.Id = @Id");

            SqlCommand commandSelect = new(sb.ToString(), Conn);

            commandSelect.Parameters.Add(new SqlParameter("@Id", id));

            SqlDataReader dr = commandSelect.ExecuteReader();

            Passagem passagem = new();

            while (dr.Read())
            {
                passagem.Id = (int)dr["Id"];
                passagem.Origem = new EnderecoService().GetEnderecoId((int)dr["Origem"]);
                passagem.Destino = new EnderecoService().GetEnderecoId((int)dr["Destino"]);
                passagem.Cliente = new ClienteService().GetClienteId((int)dr["Cliente"]);
                passagem.Data = (DateTime)dr["Data"];
                passagem.Valor = (decimal)dr["Valor"];
            }

            return passagem;
        }

        public void Update(Passagem passagem)
        {
            string strUpdate = "update Passagem set Valor = @Valor where Id = @Id";

            SqlCommand commandUpdate = new(strUpdate, Conn);

            commandUpdate.Parameters.Add(new SqlParameter("@Id", passagem.Id));
            commandUpdate.Parameters.Add(new SqlParameter("@Valor", passagem.Valor));

            commandUpdate.ExecuteNonQuery();
        }
    }
}
