using System.Collections.Generic;

namespace AppCountJobs
{
    public static class NameConstants
    {
        public static string DropDownCountrys = "DropDownCountrys";
        public static string DropDownLanguages = "DropDownLanguages";
        public static string Countrys = "Countrys";
        public static string Languages = "Languages";
        public static string AvailableLanguages = "AvailableLanguages";
        public static string ShowAllJobsButton = "ShowAllJobsButton";
        public static string JobsBlock = "JobsBlock";
        public static string UnitedStates = "United States";
        public static string AllLanguages = "All languages";
        public static string Romania = "Romania";
        public static string English = "English";
    }

    public static class LocatorMap
    {
        public static Dictionary<string, string> Locator = GetLocator();
        static Dictionary<string, string> GetLocator()
        {
            return new Dictionary<string, string>
            {
                { NameConstants.DropDownCountrys, "//span[@class='selecter-selected'][1]" },
                { NameConstants.DropDownLanguages, "//div[@id='language']/span[@class='selecter-selected']" },
                { NameConstants.Countrys, "//div[@class='scroller-content']/span[@class='selecter-item']" },
                { NameConstants.Languages, "//div[@id='language']//label[@class='controls-checkbox']" },
                { NameConstants.AvailableLanguages, "//label[@class='controls-checkbox']/input[@name ='language[]' and not(@disabled='disabled')]/ancestor::label" },
                { NameConstants.ShowAllJobsButton, "//a[text()='Show all jobs' and not(contains(@class, 'hide'))]" },
                { NameConstants.JobsBlock, "//div[@class='vacancies-blocks-container']/div" }
            };
        }
    }
}
