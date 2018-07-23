using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace DeepLSampler
{
    public class DeepLSpider
    {
        // Currently supported languages are English, German, French, Spanish, Italian, Dutch, and Polish
        // EN, DE, FR, ES, IT, NL, PL

        public const string _default_source_lang = "DE";
        public const string _default_target_lang = "EN";
        public const string _default_source_sentence = "Linguee heißt jetzt DeepL und geht mit einem neuen maschinellen Übersetzer auf den Markt.";

        public const bool _DEBUG = false;

        // need to delete underscores
        public static bool _Delays_enabled = true;
        public static int _Delay_1 = 1000; // only used in creation of initial spider window
        public static int _Delay_2 = 500; // used in setLanguages() and translateText() 
        public static int _Delay_3 = 100; // used in ...LanguageDirection
        public static int _Max_wait_count = 50;
        public static int _Min_target_chars = 3;

        public static string _DeepLURL = "https://www.deepl.com/translator";

        public static string SrcLang; // { get; set; } for all of this when converted to static
        public static string TgtLang;
        public static string Browser;
        public static bool Headless;
        public static IWebDriver Driver;
        public static IWebElement SourceMenuDropdown;
        public static IWebElement TargetMenuDropdown;

        public DeepLSpider(bool headless) 
        {
            // headless option
            FirefoxOptions options = new FirefoxOptions();
            if (headless)
            {
                options.AddArguments("--headless");
            }

            Driver = new FirefoxDriver(options); // "this" not needed?

            SrcLang = _default_source_lang;
            TgtLang = _default_target_lang;

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            Driver.Navigate().GoToUrl(DeepLSpider._DeepLURL);

            if (_Delays_enabled) System.Threading.Thread.Sleep(DeepLSpider._Delay_1);

            // grab and save SOURCE and TARGET language selection dropdowns
            IList<IWebElement> lang_dropdown_selectors = Driver.FindElements(By.ClassName("lmt__language_select__opener"));
            SourceMenuDropdown = lang_dropdown_selectors[0];
            TargetMenuDropdown = lang_dropdown_selectors[1];

        }

        public void setLanguages(string source_lang, string target_lang)
        {
            // allowed values (strings) =  EN, DE, FR, ES, IT, NL, PL

            SrcLang = source_lang;
            TgtLang = target_lang;

            // Open SOURCE language selection dropdown menu and click desired language
            SourceMenuDropdown.Click();
            IWebElement lang_selector_source = Driver.FindElement(By.CssSelector($"div.lmt__language_select--source li[dl-value='{source_lang}']"));
            if (_Delays_enabled) System.Threading.Thread.Sleep(_Delay_2);
            lang_selector_source.Click();

            // Open TARGET language selection dropdown menu and click desired language
            TargetMenuDropdown.Click();
            IWebElement lang_selector_target = Driver.FindElement(By.CssSelector($"div.lmt__language_select--target li[dl-value='{target_lang}']"));
            if (_Delays_enabled) System.Threading.Thread.Sleep(_Delay_2);
            lang_selector_target.Click();
        }

        public string translateText(string source_text)
        {
            DeepLSamplerTranslationProvider.log.WriteLine("DeepLSpider.translateText executed for source: " + source_text, true);

            IList<IWebElement> sources = Driver.FindElements(By.ClassName("lmt__source_textarea"));
            IWebElement source_box = sources[0];
            IList<IWebElement> targets = Driver.FindElements(By.ClassName("lmt__target_textarea"));
            IWebElement target_box = targets[0];

            source_box.Clear();
            source_box.SendKeys(source_text);

            // LOOP until data arrives
            // - could be a problem with very short data!?
            // - also need to check translation result for filler patterns that sometimes appear before translation is complete
            //      e.g. filler pattern = "A[...][...]" or just "[...]"
            Match m;
            string translation_result, partial_result_pattern = @"\[\.\.\.\]";
            int request_count = 0;

            do
            {
                System.Threading.Thread.Sleep(_Delay_2);

                translation_result = target_box.GetAttribute("value");
                m = Regex.Match(translation_result, partial_result_pattern);

                request_count++;

            } while (request_count < _Max_wait_count && (m.Success || translation_result.Length <= _Min_target_chars));
            // do / while to wait for 'satisfactory' translation
            // maybe problem with conditions?

            DeepLSamplerTranslationProvider.log.WriteLine("DeepLSpider.translateText got translation: " + translation_result, true);

            return target_box.GetAttribute("value"); // should be translation_result???
        }

    }
}
