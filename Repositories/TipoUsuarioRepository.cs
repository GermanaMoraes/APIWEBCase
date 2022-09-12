using DesafioCase.Interfaces;
using DesafioCase.Models;
using DesafioCase.Data;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DesafioCase.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        ClinicaContext ctx;

        public TipoUsuarioRepository(ClinicaContext ctx)
        {
            this.ctx = ctx;
        }

        public void Excluir(TipoUsuario tipoUsuario)
        {
            throw new System.NotImplementedException();
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
    }
}
