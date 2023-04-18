using Models;
using Services;

namespace Controllers
{
    public class CidadeController
    {
        public bool UpdateCidade(string nome, string descricao)
        {
            Cidade cidade = new CidadeService().GetCidade(nome);

            if(cidade.Descricao == null)
            {
                Console.WriteLine("Cidade não cadastrada!");
            }

            return new CidadeService().Update(cidade, descricao);
        }
        public bool Insert(Cidade cidade)
        {
            return new CidadeService().Insert(cidade);
        }

        public List<Cidade> GetCidades()
        {
            return new CidadeService().GetCidades();
        }

        public bool Delete(string descricao)
        {
            Cidade cidade = new CidadeService().GetCidade(descricao);

            if (cidade.Descricao == null)
            {
                Console.WriteLine("Cidade não cadastrada!");
            }

            return new CidadeService().Delete(cidade);
        }
    }
}