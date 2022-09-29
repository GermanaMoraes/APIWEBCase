using DesafioCase.Models;
using System;
using Xunit;

namespace DesafioCaseTeste
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Consultum consultum;

            consultum = new Consultum();

            Assert.NotNull(consultum);

        }
    }
}
