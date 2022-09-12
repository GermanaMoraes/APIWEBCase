using DesafioCase.Models;
using System.Collections;
using System.Collections.Generic;

namespace DesafioCase.Interfaces
{
    public interface IConsultumRepository
    {
        Consultum Insert(Consultum consulta);
        ICollection<Consultum> GetAll();
        Consultum GetById(int id);
        void Update(Consultum consulta);
        void Delete(Consultum consulta);
    }
}

