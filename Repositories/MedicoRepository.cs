using DesafioCase.Interfaces;
using DesafioCase.Models;
using DesafioCase.Data;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;

namespace DesafioCase.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        ClinicaContext ctx;

        public MedicoRepository(ClinicaContext _ctx)
        {
            ctx = _ctx;
        }

        public void Delete(Medico medico)
        {
            ctx.Medicos.Remove(medico);
            ctx.SaveChanges();
        }

        public ICollection<Medico> GetAll()
        {
            return ctx.Medicos.ToList();
           
        }

        public Medico GetbyId(int id)
        {
            return ctx.Medicos.Find(id);
            
        }

        public Medico Insert(Medico medico)
        {
            ctx.Medicos.Add(medico);
            ctx.SaveChanges();
            return medico;
        }

        public void Update(Medico medico)
        {
            ctx.Entry(medico).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public void UpdateParcial(JsonPatchDocument patchMedico, Medico medico)
        {
            patchMedico.ApplyTo(medico);
            ctx.Entry(medico).State = EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}
