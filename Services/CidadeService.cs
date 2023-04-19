using System.Data.SqlClient;
using System.Text;
using Models;

namespace Services
{
    public class CidadeService
    {
        readonly string _strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\Desktop\c#\DB\Turismo\Turismo\Banco\turismo.mdf;";
        readonly SqlConnection Conn;

        public CidadeService()
        {
            Conn = new(_strConn);
            Conn.Open();
        }

        public Cidade GetCidade(string descricao)
        {
            string strSelectCidade = "select Id, Descricao, DataCadastro from Cidade where Descricao = @Descricao";

            SqlCommand commandSelect = new(strSelectCidade, Conn);

            commandSelect.Parameters.Add(new SqlParameter("@Descricao", descricao));

            SqlDataReader dr = commandSelect.ExecuteReader();

            Cidade cidade = new();

            while (dr.Read())
            {
                cidade.Id = (int)dr["Id"];
                cidade.Descricao = (string)dr["Descricao"];
                cidade.DataCadastro = (DateTime)dr["DataCadastro"];
            }

            return cidade;
        }

        public Cidade GetCIdadeId(int id)
        {
            string strSelectCidade = "select Id, Descricao, DataCadastro from Cidade where Id = @Id";

            SqlCommand commandSelect = new(strSelectCidade, Conn);

            commandSelect.Parameters.Add(new SqlParameter("@Id", id));

            SqlDataReader dr = commandSelect.ExecuteReader();

            Cidade cidade = new();

            while (dr.Read())
            {
                cidade.Id = (int)dr["Id"];
                cidade.Descricao = (string)dr["Descricao"];
                cidade.DataCadastro = (DateTime)dr["DataCadastro"];
            }

            return cidade;
        }

        public bool Update(Cidade cidade, string descricao)
        {
            bool status;

            try
            {
                string strUpdateCidade = "update Cidade set Descricao = @Descricao where Id = @Id";

                SqlCommand commandUpdate = new(strUpdateCidade, Conn);

                commandUpdate.Parameters.Add(new SqlParameter("@Id", cidade.Id));
                commandUpdate.Parameters.Add(new SqlParameter("@Descricao", descricao));

                commandUpdate.ExecuteNonQuery();

                status = true;
            }catch (Exception ex)
            {
                status = false;
            }

            return status;
        }

        public bool Insert(Cidade cidade)
        {
            bool status;

            try
            {
                string strInsertCidade = "insert into Cidade (Descricao, DataCadastro) values (@Descricao, @DataCadastro)";

                SqlCommand commandInsert = new(strInsertCidade, Conn);

                commandInsert.Parameters.Add(new SqlParameter("@Descricao", cidade.Descricao));
                commandInsert.Parameters.Add(new SqlParameter("@DataCadastro", cidade.DataCadastro));

                commandInsert.ExecuteNonQuery();

                status = true;
            }
            catch (Exception ex)
            {
                throw ex;
                status = false;
            }

            return status;
        }

        public List<Cidade> GetCidades()
        {
            List<Cidade> cidades = new();

            StringBuilder sb = new();
            sb.Append("select * from Cidade");

            SqlCommand commandSelect = new(sb.ToString(), Conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Cidade cidade = new();

                cidade.Id = (int)dr["Id"];
                cidade.Descricao = (string)dr["Descricao"];
                cidade.DataCadastro = (DateTime)dr["DataCadastro"];

                cidades.Add(cidade);
            }

            return cidades;
        }

        public bool Delete(Cidade cidade)
        {
            bool status;

            try
            {
                string strDeleteCidade = "delete Cidade where Id = @Id";

                SqlCommand commandDelete = new(strDeleteCidade, Conn);

                commandDelete.Parameters.Add(new SqlParameter("@Id", cidade.Id));

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
    }
}