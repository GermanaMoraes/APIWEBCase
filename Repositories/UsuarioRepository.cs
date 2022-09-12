using DesafioCase.Interfaces;
using DesafioCase.Models;
using DesafioCase.Data;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;

namespace DesafioCase.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        ClinicaContext ctx;
        public UsuarioRepository(ClinicaContext ctx)
        {
            this.ctx = ctx;
        }

        public void Delete(Usuario usuario)
        {
            ctx.Usuarios.Remove(usuario);
        }

        public ICollection<Usuario> GetAll()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario GetbyId(int id)
        {
            return ctx.Usuarios.Find(id);
        }

        public Usuario Insert(Usuario usuario)
        {
            ctx.Usuarios.Add(usuario);
            ctx.SaveChanges();
            return usuario;
        }

        public void Update(Usuario usuario)
        {
            ctx.Entry(usuario).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public void UpdateParcial(JsonPatchDocument patchUsuario, Usuario usuario)
        {
            patchUsuario.ApplyTo(usuario);
            ctx.Entry(usuario).State = EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}
