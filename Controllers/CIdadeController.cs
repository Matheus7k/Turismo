using Models;
using Services;

namespace Controllers
{
    public class CidadeController
    {
        private readonly CidadeService _cidadeService;

        public CidadeController()
        {
            _cidadeService = new();
        }

        public bool UpdateCidade(string nome, string descricao)
        {
            Cidade cidade = _cidadeService.GetCidade(nome);

            if(cidade.Descricao == null)
            {
                Console.WriteLine("Cidade não cadastrada!");
            }

            return _cidadeService.Update(cidade, descricao);
        }
        public bool Insert(Cidade cidade)
        {
            return _cidadeService.Insert(cidade);
        }

        public List<Cidade> GetCidades()
        {
            return _cidadeService.GetCidades();
        }

        public bool Delete(string descricao)
        {
            Cidade cidade = _cidadeService.GetCidade(descricao);

            if (cidade.Descricao == null)
            {
                Console.WriteLine("Cidade não cadastrada!");
            }

            return _cidadeService.Delete(cidade);
        }
    }
}