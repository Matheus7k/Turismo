using Controllers;
using Models;

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

        new EnderecoController().Delete("Rua Testando 123", 183);

        #endregion

    }
}