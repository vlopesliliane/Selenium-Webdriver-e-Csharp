using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Alura.LeilaoOnline.Selenium.Helpers;
using Alura.LeilaoOnline.Selenium.PageObjects;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    public class AoNavegarParaHomeMobile : IDisposable
    {
        private ChromeDriver driver;

        public AoNavegarParaHomeMobile()
        {
            var deviceSettings = new ChromeMobileEmulationDeviceSettings();
            deviceSettings.Width = 400;
            deviceSettings.Height = 800;
            deviceSettings.UserAgent = "Customizada";

            var options = new ChromeOptions();
            options.EnableMobileEmulation(deviceSettings);


            driver = new ChromeDriver(TestHelper.PastaDoExecutavel, options);
        }

        [Fact]
        public void DadaLargura400DeveMostrarMenuMobile()
        {
            //arrange
            var homePO = new HomeNaoLogadaPO(driver);

            //act 
            homePO.Visitar();

            //assert
            Assert.True(homePO.Menu.MenuMobileVisivel);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
