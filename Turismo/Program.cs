using Controllers;
using Models;
using Services;

internal class Program
{
    private static void Main(string[] args)
    {
        #region CRUD CIDADE
        /*
        Cidade cidade = new()
        {
            Descricao = "Araraquara",
            DataCadastro = DateTime.Now,
        };
        */
        //new CidadeController().Insert(cidade);

        //new CidadeController().UpdateCidade("Adonai", "Shalom");

        //new CidadeController().GetCidades().ForEach(Console.WriteLine);

        //new CidadeController().Delete("Guaribas");
        #endregion

        #region CRUD ENDEREÇO
        /*
        Endereco endereco = new()
        {
            Logradouro = "Rua Jornalista Alexandre",
            Numero = 183,
            Bairro = "Nova Guariba",
            CEP = "14840-000",
            Complemento = "Casa",
            Cidade = new Cidade() { Descricao = "Araraquara", DataCadastro = DateTime.Now },
            DataCadastro = DateTime.Now
        };
        */

        //new EnderecoController().Insert(endereco);
        //new EnderecoController().GetEnderecos().ForEach(Console.WriteLine);

        //Endereco enderecoToEdit = new EnderecoController().GetEndereco("Rua Jornalista Alexandre", 183);
        //enderecoToEdit.Logradouro = "Rua Testando 123";
        //new EnderecoController().Update(enderecoToEdit);

        //new EnderecoController().Delete("Rua Testando 123", 183);

        #endregion

        #region CRUD HOTEL
        //Cidade cidade = new CidadeService().GetCidade("Guariba");

        /*
        Hotel hotel = new()
        {
            Nome = "Teste hotel",
            Endereco = new Endereco()
            {
                Logradouro = "Rua Jornalista Alexandre",
                Numero = 183,
                Bairro = "Nova Guariba",
                CEP = "14840-000",
                Complemento = "Casa",
                Cidade = cidade,
                DataCadastro = DateTime.Now
            },
            DataCriacao = DateTime.Now,
            Valor = 150
        };
        */

        //new HotelController().Insert(hotel);
        //new HotelController().GetHoteis().ForEach(Console.WriteLine);

        #endregion

        #region CRUD CLIENTE
        //Cidade cidade = new CidadeService().GetCidade("Araraquara");

        /*
        Cliente cliente = new()
        {
            Nome = "Matheus",
            Telefone = "16 996363004",
            Endereco = new Endereco()
            {
                Logradouro = "Rua Jornalista Alexandre",
                Numero = 183,
                Bairro = "Nova Guariba",
                CEP = "14840-000",
                Complemento = "Casa",
                Cidade = cidade,
                DataCadastro = DateTime.Now
            },
            DataCadastro = DateTime.Now,
        };
        */

        //new ClienteController().Insert(cliente);
        //new ClienteController().GetCliente().ForEach(Console.WriteLine);

        //new ClienteController().InsertDapper(cliente);
        //new ClienteController().GetClientesDapper().ForEach(Console.WriteLine);


        #endregion

        #region CRUD PASSAGEM
        /*
        Cidade cidadeOrigem = new CidadeService().GetCidade("Guariba");

        Endereco origem = new()
        {
            Logradouro = "Rua Jornalista Alexandre",
            Numero = 183,
            Bairro = "Nova Guariba",
            CEP = "14840-000",
            Complemento = "Casa",
            Cidade = cidadeOrigem,
            DataCadastro = DateTime.Now
        };

        Cidade cidadeDestino = new CidadeService().GetCidade("Araraquara");

        
        Endereco destino = new()
        {
            Logradouro = "Rua Teste",
            Numero = 742,
            Bairro = "Nova Holanda",
            CEP = "14848-745",
            Complemento = "Casa",
            Cidade = cidadeDestino,
            DataCadastro = DateTime.Now
        };

        Cliente cliente = new ClienteController().GetClienteNome("Matheus");

        Passagem passagem = new()
        {
            
            Origem = new Endereco()
            {
                Logradouro = "Rua Jornalista Alexandre",
                Numero = 183,
                Bairro = "Nova Guariba",
                CEP = "14840-000",
                Complemento = "Casa",
                Cidade = cidadeOrigem,
                DataCadastro = DateTime.Now
            },
            Destino = new Endereco()
            {
                Logradouro = "Rua Teste",
                Numero = 742,
                Bairro = "Nova Holanda",
                CEP = "14848-745",
                Complemento = "Casa",
                Cidade = cidadeDestino,
                DataCadastro = DateTime.Now
            },
            Cliente = cliente,
            Data = DateTime.Now,
            Valor = 258
        };
        */

        //new PassagemController().Insert(passagem);

        //new PassagemController().GetPassagens().ForEach(Console.WriteLine);
        #endregion

        #region CRUD PACOTE
        /*
        Hotel hotel = new HotelService().GetHotelId(7);
        Passagem passagemPacote = new PassagemController().GetPassagemId(5);
        Cliente clientePacote = new ClienteController().GetClienteNome("Matheus");

        Pacote pacote = new()
        {
            Hotel = hotel,
            Passagem = passagemPacote,
            DataCadastro = DateTime.Now,
            Valor = 6500,
            Cliente = clientePacote
        };
        */

        //new PacoteService().Insert(pacote);
        //new PacoteService().GetPacotes().ForEach(Console.WriteLine);

        #endregion
    }
}