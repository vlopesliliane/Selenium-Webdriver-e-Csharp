using System;
using System.Threading;
using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using Xunit;
using System.Linq;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoFiltrarLeiloes
    {
        private IWebDriver driver;


        public AoFiltrarLeiloes(TestFixture fixture)
        {
            driver = fixture.Driver;

        }

        [Fact]
        public void DadoLoginInteressadaDeveMostrarPainelResultado()
        {
            //arrange
            new LoginPO(driver)
                .EfetuarLoginComCredenciais("fulano@example.org", "123");

            var dashboardinteressadaPO = new DashBoardInteressadaPO(driver);

            //act
            dashboardinteressadaPO.Filtro.PesquisarLeiloes(new List<string> {"Arte", "Coleções"}, "", true);

            //assert
            Assert.Contains("Resultado da Pesquisa", driver.PageSource);
            
        }

    }
}
