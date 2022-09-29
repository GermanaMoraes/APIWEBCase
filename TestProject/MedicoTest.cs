using DesafioCase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject
{
    public class MedicoTest
    {
        [Fact]
        public void RetornarMedicoNotNull()
        {
            //preparação
            Medico medico;

            //Execução
            medico = new Medico();

            //Retorno Esperado
            Assert.NotNull(medico);



        }
    }
}
