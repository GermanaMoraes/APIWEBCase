
using DesafioCase.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;

namespace DesafioCase.Interfaces
{
    public interface IPacienteRepository
    {
        Paciente Insert(Paciente paciente);
        ICollection<Paciente> GetAll();
        Paciente GetbyId(int id);
        void Update(Paciente paciente);
        void Delete(Paciente paciente);

        void UpdateParcial (JsonPatchDocument patchPaciente,Paciente paciente );
    }
}
