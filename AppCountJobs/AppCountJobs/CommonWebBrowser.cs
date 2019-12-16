using OpenQA.Selenium;
using System.Linq;
namespace AppCountJobs
{
    public class CommonWebBrowser 
    {
        IWebDriver driver;
        string url;
        
        public CommonWebBrowser(string url)
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            this.url = url;
        }

        public bool CheckBrowser(string title)
        {
            return driver.Title.Contains(title);
        }

        public void Maximize()
        {
            driver.Manage().Window.Maximize();
        }

        public void Update()
        {
            driver.Navigate().Refresh();
        }

        public void Load()
        {
            driver.Navigate().GoToUrl(url);
        }

        public IWebElement[] FindElements(string locator)
        {
            IWebElement[] elements;
            try
            {
                elements = driver.FindElements(By.XPath(locator)).ToArray();
            }
            catch
            {
                return null;
            }

            return elements;
        }

        public IWebElement FindElement(string locator)
        {
            IWebElement element;
            try
            {
                element = driver.FindElement(By.XPath(locator));
            }
            catch
            {
                return null;
            }

            return element;
        }
    }
}