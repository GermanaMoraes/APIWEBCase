using DesafioCase.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;

namespace DesafioCase.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario Insert(Usuario usuario);
        ICollection<Usuario> GetAll();
        Usuario GetbyId(int id);
        void Update(Usuario usuario);
        void Delete(Usuario usuario);
        void UpdateParcial (JsonPatchDocument patchUsuario, Usuario usuario);

    }
}
