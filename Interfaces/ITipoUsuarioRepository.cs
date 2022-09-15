using DesafioCase.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;

namespace DesafioCase.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        TipoUsuario Insert(TipoUsuario tipoUsuario);
        ICollection<TipoUsuario> GetAll();
        TipoUsuario GetbyId(int id);
        void Update(TipoUsuario tipoUsuario);
        void Delete(TipoUsuario tipoUsuario);

        void UpdateParcial (JsonPatchDocument patchTipo, TipoUsuario tipoUsuario);

    }
}
