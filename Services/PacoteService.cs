using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public class PacoteService
    {
        readonly string _strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\Desktop\c#\DB\Turismo\Turismo\Banco\turismo.mdf;";
        readonly SqlConnection Conn;

        public PacoteService()
        {
            Conn = new(_strConn);
            Conn.Open();
        }

        public bool Insert(Pacote pacote)
        {
            bool status;

            try
            {
                string strInsertPacote = "insert into Pacote (Hotel, Passagem, DataCadastro, Valor, Cliente) values (@Hotel, @Passagem, @DataCadastro, @Valor, @Cliente)";

                SqlCommand commandInsertPacote = new(strInsertPacote, Conn);

                commandInsertPacote.Parameters.Add(new SqlParameter("@Hotel", pacote.Hotel.Id));
                commandInsertPacote.Parameters.Add(new SqlParameter("@Passagem", pacote.Passagem.Id));
                commandInsertPacote.Parameters.Add(new SqlParameter("@DataCadastro", pacote.DataCadastro));
                commandInsertPacote.Parameters.Add(new SqlParameter("@Valor", pacote.Valor));
                commandInsertPacote.Parameters.Add(new SqlParameter("@Cliente", pacote.Cliente.Id));

                commandInsertPacote.ExecuteNonQuery();

                status = true;
            }
            catch (Exception ex)
            {
                throw ex;
                status = false;
            }

            return status;
        }

        public List<Pacote> GetPacotes()
        {
            List<Pacote> pacotes = new();

            StringBuilder sb = new();

            sb.Append("select p.Id, p.Hotel, p.Passagem, p.DataCadastro, p.Valor, p.Cliente");
            sb.Append(" from Pacote p");

            SqlCommand commandSelect = new(sb.ToString(), Conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Pacote pacote = new();

                pacote.Id = (int)dr["Id"];
                pacote.Hotel = new HotelService().GetHotelId((int)dr["Hotel"]);
                pacote.Passagem = new PassagemService().GetPassagemId((int)dr["Passagem"]);
                pacote.DataCadastro = (DateTime)dr["DataCadastro"];
                pacote.Valor = (decimal)dr["Valor"];
                pacote.Cliente = new ClienteService().GetClienteId((int)dr["Cliente"]);

                pacotes.Add(pacote);
            }

            return pacotes;
        }

        public void Delete(Pacote pacote)
        {
            string strDelete = $"delete from Pacote where Id = @Id";

            SqlCommand commandUpdate = new(strDelete, Conn);

            commandUpdate.Parameters.Add(new SqlParameter("@Id", pacote.Id));

            commandUpdate.ExecuteNonQuery();
        }

        public void Update(Pacote pacote)
        {
            string strUpdate = "update Pacote set Valor = @Valor where Id = @Id";

            SqlCommand commandUpdate = new(strUpdate, Conn);

            commandUpdate.Parameters.Add(new SqlParameter("@Id", pacote.Id));
            commandUpdate.Parameters.Add(new SqlParameter("@Valor", pacote.Valor));

            commandUpdate.ExecuteNonQuery();
        }
    }
}
