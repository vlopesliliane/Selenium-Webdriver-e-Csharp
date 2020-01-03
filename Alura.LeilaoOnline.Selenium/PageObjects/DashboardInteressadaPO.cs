using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class DashBoardInteressadaPO
    {
        private IWebDriver driver;
        private By byLogoutLink;
        private By byMeuPerfilLink;
       
        public FiltroLeiloesPO Filtro { get;}
        public MenuLogadoPO Menu { get; }

        public DashBoardInteressadaPO(IWebDriver driver)
        {
            this.driver = driver;
            
            Filtro = new FiltroLeiloesPO(driver);
            Menu = new MenuLogadoPO(driver);
           
        }
    }
}