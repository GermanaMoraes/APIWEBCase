using DesafioCase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CaseTests
{
    public class ConsultumTests
    {
        [Fact]
        public void RetornarConsultumNotNull()
        {
            //preparação
            Consultum consultum;

            //Execução
            consultum = new Consultum();

            //Retorno Esperado
            Assert.NotNull(consultum);



        }
    }
}