﻿using DesafioCase.Interfaces;
using DesafioCase.Models;
using DesafioCase.Data;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
            throw new System.NotImplementedException();
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
    }
}
