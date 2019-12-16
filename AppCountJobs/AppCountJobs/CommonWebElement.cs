using OpenQA.Selenium;
using System.Linq;

namespace AppCountJobs
{
    public interface IClick
    {
        void Click();
    }

    public class CommonWebElement
    {
        protected string locator;
        protected CommonWebBrowser browser;

        public CommonWebElement(string locator, CommonWebBrowser browser)
        {
            this.browser = browser;
            this.locator = locator;
        }
    }

    public class DropDownList : CommonWebElement, IClick
    {
        public string name;
        public DropDownList(string locator, CommonWebBrowser browser, string name)
            : base(locator, browser)
        {
            this.name = name;
        }

        public string Find()
        {
            return browser.FindElement(locator).Text;
        }

        public void Click()
        {
            IWebElement[] elements = browser.FindElements(locator);
            if (elements != null)
                elements.First(x => x.Text == name).Click();
            return;
        }
    }

    public class DropDownItems : DropDownList
    {
        public DropDownItems(string locator, CommonWebBrowser browser, string name)
            : base(locator, browser, name)
        { }

        public string[] GetItemsList()
        {
            string[] items = null;
            IWebElement[] elements = browser.FindElements(locator);
            if(elements != null)
                items = elements.Where(x => !string.IsNullOrWhiteSpace(x.Text)).Select(x => x.Text).ToArray();
            return items;
        }
    }

    public class ButtonElement : CommonWebElement, IClick
    {
        public ButtonElement(string locator, CommonWebBrowser browser)
            : base(locator, browser)
        { }

        public void Click()
        {
            IWebElement button = browser.FindElement(locator);
            if (button != null)
                button.Click();
            return;
        }
    }

    public class JobsBlockElement : CommonWebElement
    {
        public JobsBlockElement(string locator, CommonWebBrowser browser)
            : base(locator, browser)
        { }

        public int GetCountJobs()
        {
            IWebElement[] elements = browser.FindElements(locator);
            if (elements != null)
                return elements.Length;
            return default(int);
        }
    }
}