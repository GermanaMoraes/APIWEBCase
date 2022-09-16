using DesafioCase.Interfaces;
using DesafioCase.Models;
using DesafioCase.Data;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;

namespace DesafioCase.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        ClinicaContext ctx;

        public EspecialidadeRepository(ClinicaContext _ctx)
        {
            ctx= _ctx;
        }
           

        public void Delete(Especialidade especialidade)
        {
            ctx.Especialidades.Remove(especialidade);
            ctx.SaveChanges();
        }

        public ICollection<Especialidade> GetAll()
        {
            return ctx.Especialidades.ToList();
           
        }

        public Especialidade GetById(int id)
        {
            return ctx.Especialidades.Find(id);
            
        }

        public Especialidade Insert(Especialidade especialidade)
        {
            ctx.Especialidades.Add(especialidade);
            ctx.SaveChanges();
            return especialidade;

        }

        public void Update(Especialidade especialidade)
        {
            
            ctx.Entry(especialidade).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public void UpdateParcial(JsonPatchDocument patchEsp, Especialidade especialidade)
        {
            patchEsp.ApplyTo(especialidade);
            ctx.Entry(especialidade).State = EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}
