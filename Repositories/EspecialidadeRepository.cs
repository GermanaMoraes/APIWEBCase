using DesafioCase.Interfaces;
using DesafioCase.Models;
using DesafioCase.Data;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
            throw new System.NotImplementedException();
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
    }
}
