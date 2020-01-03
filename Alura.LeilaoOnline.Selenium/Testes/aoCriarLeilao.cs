using System;
using System.Threading;
using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using Xunit;
using System.Linq;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class aoCriarLeilao
    {
        private IWebDriver driver;
        
        
        public aoCriarLeilao(TestFixture fixture)
        {
            driver = fixture.Driver;
                
        }

        [Fact]
        public void DadoLoginAdminEInfoValidasDeveCadastrarLeilao()
        {
            //Arrange
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.PreencheFormulario("admin@example.org", "123");
            loginPO.SubmeteFormulario();

            var novoLeilaoPO = new NovoLeilaoPO(driver);
            
            novoLeilaoPO.Visitar();

            Thread.Sleep(3000);

            novoLeilaoPO.PreencherFormulario(
                "Leilão Museu do Diamante",
                "Nullam aliquet condimentum elit vitae volutpat. Vivamus ut nisi venenatis, facilisis odio eget, lobortis tortor. Cras mattis sit amet dolor id bibendum. Nulla turpis justo, porttitor eget leo vel, dictum tempor diam. Sed dui arcu, feugiat nec placerat ac, suscipit a mi. Etiam eget risus et tellus placerat tincidunt at ut lorem.",
                "Item de Colecionador",
                4000,
                "c:\\imagens\\colecao1.jpg",
                DateTime.Now.AddDays(20),
                DateTime.Now.AddDays(40)
                );

            Thread.Sleep(5000);

            //act
            novoLeilaoPO.SubmeterFormulario();

            //assert
            Assert.Contains("Leilões cadastrados no sistema", driver.PageSource);
        }
    }
}
