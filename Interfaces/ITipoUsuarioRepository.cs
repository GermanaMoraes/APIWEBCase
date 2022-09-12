using DesafioCase.Models;
using System.Collections.Generic;

namespace DesafioCase.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        TipoUsuario Insert(TipoUsuario tipoUsuario);
        ICollection<TipoUsuario> GetAll();
        TipoUsuario GetbyId(int id);
        void Update(TipoUsuario tipoUsuario);
        void Excluir(TipoUsuario tipoUsuario);    

    }
}
