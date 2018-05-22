using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace DeepLSampler
{
    public class DeepLSpider
    {
        // Currently supported languages are English, German, French, Spanish, Italian, Dutch, and Polish
        // EN, DE, FR, ES, IT, NL, PL

        const string _DeepLURL = "https://www.deepl.com/translator";
        const bool _Delays_enabled = true;
        const int _Delay_1 = 1000;
        const int _Delay_2 = 500;
        const bool _DEBUG = false;
        const string _default_source_lang = "DE";
        const string _default_target_lang = "EN";

        public string SrcLang { get; set; }
        public string TgtLang { get; set; }
        public string Browser { get; set; }
        public bool Headless { get; set; }
        public IWebDriver Driver { get; set; }
        public IWebElement SourceMenuDropdown { get; set; }
        public IWebElement TargetMenuDropdown { get; set; }

        public DeepLSpider()
        {
            if (_DEBUG) Console.WriteLine("Creating DeepLSpider instance.");

            this.Driver = new FirefoxDriver();

            this.SrcLang = _default_source_lang;
            this.TgtLang = _default_target_lang;

            this.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            this.Driver.Navigate().GoToUrl(DeepLSpider._DeepLURL);

            if (_Delays_enabled) System.Threading.Thread.Sleep(DeepLSpider._Delay_1);

            // grab and save SOURCE and TARGET language selection dropdowns
            IList<IWebElement> lang_dropdown_selectors = this.Driver.FindElements(By.ClassName("lmt__language_select__opener"));
            //if (_Delays_enabled) System.Threading.Thread.Sleep(_Delay_2);
            this.SourceMenuDropdown = lang_dropdown_selectors[0];
            this.TargetMenuDropdown = lang_dropdown_selectors[1];

        }

        public void setLanguages(string source_lang, string target_lang)
        {
            this.SrcLang = source_lang;
            this.TgtLang = target_lang;

            // Open SOURCE language selection dropdown menu and click desired language

            //IList<IWebElement> lang_dropdown_selectors = this.Driver.FindElements(By.ClassName("lmt__language_select__opener"));
            //if (_Delays_enabled) System.Threading.Thread.Sleep(_Delay_1);
            //lang_dropdown_selectors[0].Click(); // note element [0] !

            this.SourceMenuDropdown.Click();
            IWebElement lang_selector_source = this.Driver.FindElement(By.CssSelector($"div.lmt__language_select--source li[dl-value='{source_lang}']"));
            if (_Delays_enabled) System.Threading.Thread.Sleep(_Delay_2);
            lang_selector_source.Click();

            // Open TARGET language selection dropdown menu and click desired language
            //lang_dropdown_selectors[1].Click(); // [1] !!!
            this.TargetMenuDropdown.Click();
            IWebElement lang_selector_target = this.Driver.FindElement(By.CssSelector($"div.lmt__language_select--target li[dl-value='{target_lang}']"));
            if (_Delays_enabled) System.Threading.Thread.Sleep(_Delay_2);
            lang_selector_target.Click();

        }

        public string translateText(string source_text)
        {
            IList<IWebElement> sources = this.Driver.FindElements(By.ClassName("lmt__source_textarea"));
            IWebElement source_box = sources[0];

            source_box.Clear();
            source_box.SendKeys(source_text);

            System.Threading.Thread.Sleep(_Delay_1);

            IList<IWebElement> targets = this.Driver.FindElements(By.ClassName("lmt__target_textarea"));
            IWebElement target_box = targets[0];

            // loop until data arrives
            // could be a problem with very short data!?
            while (target_box.GetAttribute("value").Length <= 3)
            {
                System.Threading.Thread.Sleep(_Delay_2);
            }

            return target_box.GetAttribute("value");
        }

    }
}
