using DesafioCase.Models;
using System.Collections.Generic;

namespace DesafioCase.Interfaces
{
    public interface IMedicoRepository
    {
        Medico Insert(Medico medico);
        ICollection<Medico> GetAll();
        Medico GetbyId(int id);
        void Update (Medico medico);
        void Delete(Medico medico);

    }
}
