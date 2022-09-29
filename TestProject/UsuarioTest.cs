using DesafioCase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CaseTests
{
    public class UsuarioTest
    {
        [Fact]
        public void RetornarUsuarioNotNull()
        {
            //preparação
            Usuario usuario;

            //Execução
            usuario = new Usuario();

            //Retorno Esperado
            Assert.NotNull(usuario);



        }
    }
}