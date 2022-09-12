using DesafioCase.Models;
using System.Collections.Generic;

namespace DesafioCase.Interfaces
{
    public interface IEspecialidadeRepository 
    {
        Especialidade Insert(Especialidade especialidade);
        ICollection<Especialidade> GetAll();
        Especialidade GetById(int id);
        void Update(Especialidade especialidade);
        void Delete(Especialidade especialidade);
    }
}
