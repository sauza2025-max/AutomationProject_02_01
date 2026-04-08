using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace AutomationProject_02.TestCase
{
    public abstract class BaseTest
    {
        // Selenium Driver
        protected IWebDriver Driver;
        protected string url = "https://automationexercise.com/login";

        // Metodo para inicializar el navegador Chrome y abrir la url
        [SetUp]
        public void BeforeTest()
        {
            var driverPath = new DriverManager().SetUpDriver(new ChromeConfig()); // returns full exe path
            var driverDir = Path.GetDirectoryName(driverPath);                    // get directory
            if (string.IsNullOrEmpty(driverDir) || !File.Exists(driverPath))
                throw new FileNotFoundException($"Chromedriver not found at: {driverPath}");

            var service = ChromeDriverService.CreateDefaultService(driverDir);
            var options = new ChromeOptions();
            Driver = new ChromeDriver(service, options);

            Driver.Navigate().GoToUrl(url);
            Driver.Manage().Window.Maximize();
        }
        
        // Metodo para cerrar el navegador
        [TearDown] 
        public void AfterTest()
        {
            if(Driver != null) 
            {
               Driver.Quit();
            }
        }
    }
}
