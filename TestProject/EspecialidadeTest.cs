using DesafioCase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CaseTests
{
    public class EspecialidadeTest
    {
        [Fact]
        public void RetornarEspecialidadNotNull()
        {
            //preparação
            Especialidade especialidade;

            //Execução
            especialidade = new Especialidade();

            //Retorno Esperado
            Assert.NotNull(especialidade);



        }
    }
}