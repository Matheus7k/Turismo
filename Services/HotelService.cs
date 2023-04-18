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

            sb.Append("select h.Id, h.Nome, e.Logradouro, e.Numero , e.Bairro, e.CEP, e.Complemento, c.Descricao Cidade, h.Valor");
            sb.Append(" from Hotel h, Endereco e, Cidade c where h.Endereco = e.Id and e.Cidade = c.Id");

            SqlCommand commandSelect = new(sb.ToString(), Conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Hotel hotel = new();

                hotel.Id = (int)dr["Id"];
                hotel.Nome = (string)dr["Nome"];
                hotel.Endereco = new Endereco()
                {
                    Logradouro = (string)dr["Logradouro"],
                    Numero = (int)dr["Numero"],
                    Bairro = (string)dr["Bairro"],
                    CEP = (string)dr["CEP"],
                    Complemento = (string)dr["Complemento"],
                    Cidade = new Cidade() { Descricao = (string)dr["Cidade"] },
                };
                hotel.Valor = (decimal)dr["Valor"];

                hoteis.Add(hotel);
            }

            return hoteis;
        }
    }
}
