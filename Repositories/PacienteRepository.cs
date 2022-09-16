using DesafioCase.Data;
using DesafioCase.Interfaces;
using DesafioCase.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DesafioCase.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        ClinicaContext ctx;
        public PacienteRepository(ClinicaContext ctx)
        {
            this.ctx = ctx;
        }

        public void Delete(Paciente paciente)
        {
            ctx.Pacientes.Remove(paciente);
            ctx.SaveChanges();
        }

        public ICollection<Paciente> GetAll()
        {
            return ctx.Pacientes.ToList();
            
        }

        public Paciente GetbyId(int id)
        {
            return ctx.Pacientes.Find(id);

        }

        public Paciente Insert(Paciente paciente)
        {
            ctx.Pacientes.Add(paciente);
            ctx.SaveChanges();
            return paciente;

        }

        public void Update(Paciente paciente)
        {
            ctx.Entry(paciente).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public void UpdateParcial(JsonPatchDocument patchPaciente, Paciente paciente)
        {
            patchPaciente.ApplyTo(paciente);
            ctx.Entry(paciente).State = EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}
