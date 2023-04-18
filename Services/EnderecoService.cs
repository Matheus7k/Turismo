using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public class EnderecoService
    {
        readonly string _strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\Desktop\c#\DB\turismo.mdf;";
        readonly SqlConnection Conn;

        public EnderecoService()
        {
            Conn = new(_strConn);
            Conn.Open();
        }

        public bool Update(Endereco endereco)
        {
            bool status;

            try
            {
                string strUpdateEndereco = "update Endereco set Logradouro = @Logradouro, Numero = @Numero, Bairro = @Bairro, CEP = @CEP, Complemento = @Complemento, Cidade = @Cidade, DataCadastro = @DataCadastro where Id = @Id";

                SqlCommand commandUpdate = new(strUpdateEndereco, Conn);

                commandUpdate.Parameters.Add(new SqlParameter("@Id", endereco.Id));
                commandUpdate.Parameters.Add(new SqlParameter("@Logradouro", endereco.Logradouro));
                commandUpdate.Parameters.Add(new SqlParameter("@Numero", endereco.Numero));
                commandUpdate.Parameters.Add(new SqlParameter("@Bairro", endereco.Bairro));
                commandUpdate.Parameters.Add(new SqlParameter("@CEP", endereco.CEP));
                commandUpdate.Parameters.Add(new SqlParameter("@Complemento", endereco.Complemento));
                commandUpdate.Parameters.Add(new SqlParameter("@Cidade", endereco.Cidade.Id));
                commandUpdate.Parameters.Add(new SqlParameter("@DataCadastro", endereco.DataCadastro));
                

                commandUpdate.ExecuteNonQuery();

                status = true;
            }
            catch (Exception ex)
            {
                status = false;
            }

            return status;
        }

        public bool Insert(Endereco endereco)
        {
            bool status;

            try
            {
                string strInsertEndereco = "insert into Endereco (Logradouro, Numero, Bairro, CEP, Complemento, Cidade, DataCadastro) values (@Logradouro, @Numero, @Bairro, @CEP, @Complemento, @Cidade, @DataCadastro)";

                SqlCommand commandInsertEndereco = new(strInsertEndereco, Conn);

                commandInsertEndereco.Parameters.Add(new SqlParameter("@Logradouro", endereco.Logradouro));
                commandInsertEndereco.Parameters.Add(new SqlParameter("@Numero", endereco.Numero));
                commandInsertEndereco.Parameters.Add(new SqlParameter("@Bairro", endereco.Bairro));
                commandInsertEndereco.Parameters.Add(new SqlParameter("@CEP", endereco.CEP));
                commandInsertEndereco.Parameters.Add(new SqlParameter("@Complemento", endereco.Complemento));
                commandInsertEndereco.Parameters.Add(new SqlParameter("@Cidade", InsertCidade(endereco)));
                commandInsertEndereco.Parameters.Add(new SqlParameter("@DataCadastro", endereco.DataCadastro));

                commandInsertEndereco.ExecuteNonQuery();

                status = true;
            }
            catch (Exception ex)
            {
                throw ex;
                status = false;
            }

            return status;
        }

        public int InsertCidade(Endereco endereco)
        {
            string strInsertCidade = "insert into Cidade (Descricao, DataCadastro) values (@Descricao, @DataCadastro); select cast(scope_identity() as int)";

            SqlCommand commandInsertCidade = new(strInsertCidade, Conn);

            commandInsertCidade.Parameters.Add(new SqlParameter("@Descricao", endereco.Cidade.Descricao));
            commandInsertCidade.Parameters.Add(new SqlParameter("@DataCadastro", endereco.Cidade.DataCadastro));

            return (int) commandInsertCidade.ExecuteScalar();
        }

        public bool Delete(Endereco endereco)
        {
            bool status;

            try
            {
                string strDeleteEndereco = "delete Endereco where Id = @Id";

                SqlCommand commandDelete = new(strDeleteEndereco, Conn);

                commandDelete.Parameters.Add(new SqlParameter("@Id", endereco.Id));

                commandDelete.ExecuteNonQuery();

                status = true;
            }
            catch (Exception ex)
            {
                throw ex;
                status = false;
            }

            return status;
        }

        public Endereco GetEndereco(string logradouro, int numero)
        {
            try
            {
                string strSelectCidade = "select Id, Logradouro, Numero, Bairro, CEP, Complemento, Cidade, DataCadastro from Endereco where Logradouro = @Logradouro AND Numero = @Numero";

                SqlCommand commandSelect = new(strSelectCidade, Conn);

                commandSelect.Parameters.Add(new SqlParameter("@Logradouro", logradouro));
                commandSelect.Parameters.Add(new SqlParameter("@Numero", numero));

                SqlDataReader dr = commandSelect.ExecuteReader();

                Endereco endereco = new();

                while (dr.Read())
                {
                    endereco.Id = (int)dr["Id"];
                    endereco.Logradouro = (string)dr["Logradouro"];
                    endereco.Numero = (int)dr["Numero"];
                    endereco.Bairro = (string)dr["Bairro"];
                    endereco.CEP = (string)dr["CEP"];
                    endereco.Complemento = (string)dr["Complemento"];
                    endereco.Cidade = new Cidade() { Id = (int)dr["Cidade"] };
                    endereco.DataCadastro = (DateTime)dr["DataCadastro"];
                }

                return endereco;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Endereco> GetEnderecos()
        {
            List<Endereco> enderecos = new();

            StringBuilder sb = new();
            sb.Append("select e.Id, e.Logradouro, e.Numero, e.Bairro, e.CEP, e.Complemento, c.Descricao Cidade, e.DataCadastro from Endereco e, Cidade c where e.Cidade = c.Id");

            SqlCommand commandSelect = new(sb.ToString(), Conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while(dr.Read())
            {
                Endereco endereco = new();

                endereco.Id = (int)dr["Id"];
                endereco.Logradouro = (string)dr["Logradouro"];
                endereco.Numero = (int)dr["Numero"];
                endereco.Bairro = (string)dr["Bairro"];
                endereco.CEP = (string)dr["CEP"];
                endereco.Complemento = (string)dr["Complemento"];
                endereco.Cidade = new Cidade() { Descricao = (string)dr["Cidade"] };
                endereco.DataCadastro = (DateTime)dr["DataCadastro"];

                enderecos.Add(endereco);
            }

            return enderecos;
        }
    }
}
