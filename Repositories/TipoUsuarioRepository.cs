using DesafioCase.Interfaces;
using DesafioCase.Models;
using DesafioCase.Data;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;

namespace DesafioCase.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        ClinicaContext ctx;

        public TipoUsuarioRepository(ClinicaContext _ctx)
        {
            ctx = _ctx;
        }

        public void Delete(TipoUsuario tipoUsuario)
        {
         ctx.TipoUsuarios.Remove(tipoUsuario);
        }

        public ICollection<TipoUsuario> GetAll()
        {
            return ctx.TipoUsuarios.ToList();
        }

        public TipoUsuario GetbyId(int id)
        {
           return ctx.TipoUsuarios.Find(id);
        }

        public TipoUsuario Insert(TipoUsuario tipoUsuario)
        {
            ctx.TipoUsuarios.Add(tipoUsuario);
             ctx.SaveChanges();
            return tipoUsuario;
        }

        public void Update(TipoUsuario tipoUsuario)
        {
            ctx.Entry(tipoUsuario).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public void UpdateParcial(JsonPatchDocument patchTipo, TipoUsuario tipoUsuario)
        {
            patchTipo.ApplyTo(tipoUsuario);
            ctx.Entry(tipoUsuario).State = EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}
