using DesafioCase.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;

namespace DesafioCase.Interfaces
{
    public interface IConsultumRepository
    {
        Consultum Insert(Consultum consulta);
        ICollection<Consultum> GetAll();
        Consultum GetById(int id);
        void Update(Consultum consulta);
        void Delete(Consultum consulta);

        //Alterar Parcialmente utilizando o Json
        void UpdateParcial(JsonPatchDocument patchConsulta, Consultum consulta);
       
    }
}

