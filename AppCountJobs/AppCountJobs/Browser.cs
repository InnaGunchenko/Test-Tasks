using System;
using System.Threading;
namespace AppCountJobs
{
    public class Browser : CommonWebBrowser
    {
        public DropDownList DropDownCountrys { get; set; }
        public DropDownList DropDownLanguages { get; set; }
        public DropDownItems Languages { get; set; }
        public DropDownItems AvailableLanguages { get; set; }
        public DropDownItems Countrys { get; set; }
        public IClick ShowAllJobs { get; set; }
        public JobsBlockElement JobsBlock { get; set; }

        public Browser(string url, string defaultCountry, string defaultLanguage)
            : base(url)
        {
            this.DropDownCountrys = new DropDownList(LocatorMap.Locator[NameConstants.DropDownCountrys], this, NameConstants.UnitedStates);
            this.DropDownLanguages = new DropDownList(LocatorMap.Locator[NameConstants.DropDownLanguages], this, NameConstants.AllLanguages);
            this.Countrys = new DropDownItems(LocatorMap.Locator[NameConstants.Countrys], this, defaultCountry);
            this.Languages = new DropDownItems(LocatorMap.Locator[NameConstants.Languages], this, defaultLanguage);
            this.AvailableLanguages = new DropDownItems(LocatorMap.Locator[NameConstants.AvailableLanguages], this, defaultLanguage);
            this.ShowAllJobs = new ButtonElement(LocatorMap.Locator[NameConstants.ShowAllJobsButton], this);
            this.JobsBlock = new JobsBlockElement(LocatorMap.Locator[NameConstants.JobsBlock], this);
        }

        public string[] FirstLoad(DropDownList list, DropDownItems item)
        {
            list.Click();
            string[] items = item.GetItemsList();
            item.Click();
            list.name = item.name;
            return items;
        }

        public int CalcJobs(string language, string country)
        {
            DropDownCountrys.name = DropDownCountrys.Find();
            DropDownLanguages.name = DropDownLanguages.Find();
            if (!CheckElementEqual(country, language))
            {
                FillElementsPage(country, language);
            }

            return CalcJobs();
        }

        public bool CheckElementEqual(string country, string language)
        {        
            if (DropDownCountrys.name.Equals(country)
                && DropDownLanguages.name.Equals(language))
                return true;
            return false;
        }

        public void FillElementsPage(string country, string language)
        {
            UpdateBrowser();
            LoadName(country, language);
            FillCountrys();
            Wait();
            FillLanguages();
            Wait();
        }

        public void Wait()
        {
            Thread.Sleep(3000);
        }

        public void UpdateBrowser()
        {
            Update();
            DropDownLanguages.name = NameConstants.AllLanguages;
        }

        public void LoadName(string country, string language)
        {
            Countrys.name = country;
            Languages.name = language;
        }

        public void FillCountrys()
        {
            if (DropDownCountrys.name.Equals(Countrys.name))
                return;
            DropDownCountrys.Click();
            Countrys.Click();
        }

        public void FillLanguages()
        {
            DropDownLanguages.Click();
            if (!CheckAvailableItem())
                return;
            Languages.Click();
        }

        public bool CheckAvailableItem()
        {
            if (Array.IndexOf(AvailableLanguages.GetItemsList(), Languages.name) < 0)
            {
                return false;
            }

            return true;
        }

        private int CalcJobs()
        {
            ShowAllJobs.Click();
            Wait();
            return JobsBlock.GetCountJobs();
        }
    }
}