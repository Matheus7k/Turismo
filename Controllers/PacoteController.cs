using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Services;

namespace Controllers
{
    public class PacoteController
    {
        private PacoteService pacoteService;

        public PacoteController()
        {
            pacoteService = new PacoteService();
        }

        public bool Insert(Pacote pacote)
        {
            return pacoteService.Insert(pacote);
        }

        public List<Pacote> GetPacotes()
        {
            return pacoteService.GetPacotes();
        }
    }
}
