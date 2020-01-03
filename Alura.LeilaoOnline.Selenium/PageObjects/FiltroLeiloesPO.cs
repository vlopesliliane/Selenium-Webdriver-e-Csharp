using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class FiltroLeiloesPO
    {
        private IWebDriver driver;
        private By bySelectCategorias;
        private By byInputTermo;
        private By byInputAndamento;
        private By byBotaoPesquisar;

        public FiltroLeiloesPO(IWebDriver driver)
        {
            this.driver = driver;
            bySelectCategorias = By.ClassName("select-wrapper");
            byInputTermo = By.Name("termo");
            byInputAndamento = By.ClassName("swich");
            byBotaoPesquisar = By.CssSelector("form>button.btn");
        }

        public void PesquisarLeiloes(
            List<string> categorias,
            string termo,
            bool emAndamento)
        {
            var select = new SelectMaterialize(driver, bySelectCategorias);

            select.DeselectAll();


            Thread.Sleep(2000);

            categorias.ForEach(categ =>
            {
                select.SelectByText(categ);

            });
            driver.FindElement(byInputTermo).SendKeys(termo);
            if (emAndamento)
            {
                driver.FindElement(byInputAndamento).Click();
            }
            driver.FindElement(byBotaoPesquisar).Click();

        }
    }
}
