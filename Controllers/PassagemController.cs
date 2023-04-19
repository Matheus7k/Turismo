using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Services;

namespace Controllers
{
    public class PassagemController
    {
        private PassagemService passagemService;

        public PassagemController()
        {
            passagemService = new PassagemService();
        }

        public bool Insert(Passagem passagem)
        {
            return passagemService.Insert(passagem);
        }        

        public Passagem GetPassagemId(int id)
        {
            return passagemService.GetPassagemId(id);
        }

        public List<Passagem> GetPassagens()
        {
            return passagemService.GetPassagens();
        }
    }
}
