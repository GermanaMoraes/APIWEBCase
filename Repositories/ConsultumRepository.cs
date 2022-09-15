using DesafioCase.Interfaces;
using DesafioCase.Models;
using DesafioCase.Data;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;

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
            
           // ctx.Consulta.Remove(consulta);
            ctx.Consulta.Remove(consulta);
            
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

        public void UpdateParcial(JsonPatchDocument patchConsulta, Consultum consulta)
        {
            patchConsulta.ApplyTo(consulta);
            ctx.Entry(consulta).State = EntityState.Modified;
            ctx.SaveChanges();
            
        }
    }
}
