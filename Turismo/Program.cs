using Controllers;
using Models;

internal class Program
{
    private static void Main(string[] args)
    {

        Cidade cidade = new()
        {
            Descricao = "Araraquara",
            DataCadastro = DateTime.Now,
        };

        //new CidadeController().Insert(cidade);

        //new CidadeController().UpdateCidade("Adonai", "Shalom");

        new CidadeController().GetCidades().ForEach(Console.WriteLine);

        //new CidadeController().Delete("Guaribas");
        
    }
}