using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public class HotelService
    {
        readonly string _strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\Desktop\c#\DB\Turismo\Turismo\Banco\turismo.mdf;";
        readonly SqlConnection Conn;

        public HotelService()
        {
            Conn = new(_strConn);
            Conn.Open();
        }

        public bool Insert(Hotel hotel)
        {
            bool status;

            try
            {
                string strInsertHotel = "insert into Hotel (Nome, Endereco, DataCadastro, Valor) values (@Nome, @Endereco, @DataCadastro, @Valor)";

                SqlCommand commandInsertHotel = new(strInsertHotel, Conn);

                commandInsertHotel.Parameters.Add(new SqlParameter("@Nome", hotel.Nome));
                commandInsertHotel.Parameters.Add(new SqlParameter("@Endereco", InsertEndereco(hotel)));
                commandInsertHotel.Parameters.Add(new SqlParameter("@DataCadastro", hotel.DataCriacao));
                commandInsertHotel.Parameters.Add(new SqlParameter("@Valor", hotel.Valor));

                commandInsertHotel.ExecuteNonQuery();

                status = true;
            }
            catch (Exception ex)
            {
                throw ex;
                status = false;
            }

            return status;
        }

        public int InsertEndereco(Hotel hotel)
        {
            string strInsertEndereco = "insert into Endereco (Logradouro, Numero, Bairro, CEP, Complemento, Cidade, DataCadastro) values (@Logradouro, @Numero, @Bairro, @CEP, @Complemento, @Cidade, @DataCadastro); select cast(scope_identity() as int)";

            SqlCommand commandInsertEndereco = new(strInsertEndereco, Conn);

            commandInsertEndereco.Parameters.Add(new SqlParameter("@Logradouro", hotel.Endereco.Logradouro));
            commandInsertEndereco.Parameters.Add(new SqlParameter("@Numero", hotel.Endereco.Numero));
            commandInsertEndereco.Parameters.Add(new SqlParameter("@Bairro", hotel.Endereco.Bairro));
            commandInsertEndereco.Parameters.Add(new SqlParameter("@CEP", hotel.Endereco.CEP));
            commandInsertEndereco.Parameters.Add(new SqlParameter("@Complemento", hotel.Endereco.Complemento));
            commandInsertEndereco.Parameters.Add(new SqlParameter("@Cidade", hotel.Endereco.Cidade.Id));
            commandInsertEndereco.Parameters.Add(new SqlParameter("@DataCadastro", hotel.Endereco.DataCadastro));

            return (int)commandInsertEndereco.ExecuteScalar();
        }

        public List<Hotel> GetHoteis()
        {
            List<Hotel> hoteis = new();

            StringBuilder sb = new();

            sb.Append("select h.Id, h.Nome, h.Endereco, h.Valor");
            sb.Append(" from Hotel h, Endereco e, Cidade c where h.Endereco = e.Id and e.Cidade = c.Id");

            SqlCommand commandSelect = new(sb.ToString(), Conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Hotel hotel = new();

                hotel.Id = (int)dr["Id"];
                hotel.Nome = (string)dr["Nome"];
                hotel.Endereco = new EnderecoService().GetEnderecoId((int)dr["Endereco"]);
                hotel.Valor = (decimal)dr["Valor"];

                hoteis.Add(hotel);
            }

            return hoteis;
        }

        public Hotel GetHotelId(int id)
        {
            StringBuilder sb = new();

            sb.Append("select h.Id, h.Nome, h.Endereco, h.DataCadastro,h.Valor");
            sb.Append(" from Hotel h where h.Id = @Id");

            SqlCommand commandSelect = new(sb.ToString(), Conn);

            commandSelect.Parameters.Add(new SqlParameter("@Id", id));

            SqlDataReader dr = commandSelect.ExecuteReader();

            Hotel hotel = new();

            while(dr.Read())
            {
                hotel.Id= (int)dr["Id"];
                hotel.Nome = (string)dr["Nome"];
                hotel.Endereco = new EnderecoService().GetEnderecoId((int)dr["Endereco"]);
                hotel.DataCriacao = (DateTime)dr["DataCadastro"];
                hotel.Valor = (decimal)dr["Valor"];
            }

            return hotel;
        }

        public void Update(Hotel hotel)
        {
            string strUpdate = "update Hotel set Nome = @Nome, Valor = @Valor where Id = @Id";

            SqlCommand commandUpdate = new(strUpdate, Conn);

            commandUpdate.Parameters.Add(new SqlParameter("@Id", hotel.Id));
            commandUpdate.Parameters.Add(new SqlParameter("@Nome", hotel.Nome));
            commandUpdate.Parameters.Add(new SqlParameter("@Valor", hotel.Valor));

            commandUpdate.ExecuteNonQuery();
        }
    }
}
