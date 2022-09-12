using DesafioCase.Interfaces;
using DesafioCase.Models;
using DesafioCase.Data;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DesafioCase.Repositories
{
    public class ConsultumRepository : IConsultumRepository
    {
       ClinicaContext  ctx;

        public ConsultumRepository (ClinicaContext _ctx)
        {
            ctx = _ctx;
        }

        public void Delete(Consultum consulta)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<Consultum> GetAll()
        {
            return ctx.Consulta.ToList();
            
        }

        public Consultum GetById(int id)
        {
            return ctx.Consulta.Find(id);
           
        }

        public Consultum Insert(Consultum consulta)
        {
            ctx.Consulta.Add(consulta);
            ctx.SaveChanges();
            return consulta;
           
        }

        public void Update(Consultum consulta)
        {
            ctx.Entry(consulta).State= EntityState.Modified;
            ctx.SaveChanges();
            
        }
    }
}
