using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sdl.LanguagePlatform.Core;
using Sdl.LanguagePlatform.TranslationMemory;
using Sdl.LanguagePlatform.TranslationMemoryApi;
using System.IO;

namespace DeepLSampler
{
    public class DeepLSamplerTranslationProvider : ITranslationProvider
    {
        /// This string needs to be a unique value.
        /// This is the string that precedes the plug-in URI.
        public static readonly string DeepLSamplerTranslationProviderScheme = "deeplsamplerprovider";

        // spider variables
        public static DeepLSpider deepL = null;
        public static string connectionError = "";

        // logger variable
        public static Logger log;
        public static string log_filename = "DLS_log_file.txt";

        public DeepLSamplerTranslationOptions Options
        {
            get;
            set;
        }

        public DeepLSamplerTranslationProvider(DeepLSamplerTranslationOptions options)
        {
            Options = options;

            OpenConnection();

            //DeepLSamplerProviderConfDialog.textBox3.Text = Path.GetTempPath();

            // log gets saved in "C:\Users\garchik2\AppData\Local\Temp" by default
            log = new Logger(Path.GetTempPath() + log_filename);
            log.WriteFileHeader();
            log.Close();

        }

        public static void OpenConnection()
        {
            if (deepL == null)
            {
                try
                {
                    deepL = new DeepLSpider();
                }
                catch (Exception e)
                {
                    // textBox3.Text = e.Message;
                    // log error!
                    connectionError = e.Message;
                    deepL = null;
                    return;
                }
            }
        }


        #region ITranslationProvider Members

        public ITranslationProviderLanguageDirection GetLanguageDirection(LanguagePair languageDirection)
        {
            //throw new NotImplementedException();
            return new DeepLSamplerTranslationProviderLanguageDirection(this, languageDirection);
        }

        public bool IsReadOnly
        {
            //get { throw new NotImplementedException(); }
            get { return true; }
        }

        public void LoadState(string translationProviderState)
        {
            //throw new NotImplementedException();
        }

        public string Name
        {
            //get { throw new NotImplementedException(); }
            get { return PluginResources.Plugin_NiceName; }
        }

        public void RefreshStatusInfo()
        {
            //throw new NotImplementedException();
        }

        public string SerializeState()
        {
            //throw new NotImplementedException();

            // Save settings
            return null;
        }

        public ProviderStatusInfo StatusInfo
        {
            //get { throw new NotImplementedException(); }
            get { return new ProviderStatusInfo(true, PluginResources.Plugin_NiceName); }
        }

        public bool SupportsConcordanceSearch
        {
            //get { throw new NotImplementedException(); }

            get { return false; } // no concordance search for MT provider!!!
        }

        public bool SupportsDocumentSearches
        {
            //get { throw new NotImplementedException(); }
            get { return false; }
        }

        public bool SupportsFilters
        {
            //get { throw new NotImplementedException(); }
            get { return false; }
        }

        public bool SupportsFuzzySearch
        {
            //get { throw new NotImplementedException(); }
            get { return false; }
        }

        public bool SupportsLanguageDirection(LanguagePair languageDirection)
        {
            //throw new NotImplementedException();

            // The provider supports the selected language direction.
            return true;  // have to implement this!!!
        }

        public bool SupportsMultipleResults
        {
            //get { throw new NotImplementedException(); }
            get { return false; }
        }

        public bool SupportsPenalties
        {
            //get { throw new NotImplementedException(); }
            get { return false; } // different from LIST
        }

        public bool SupportsPlaceables
        {
            //get { throw new NotImplementedException(); }
            get { return false; }
        }

        public bool SupportsScoring
        {
            //get { throw new NotImplementedException(); }
            get { return false; }
        }

        public bool SupportsSearchForTranslationUnits
        {
            //get { throw new NotImplementedException(); }
            get { return true; }
        }

        public bool SupportsSourceConcordanceSearch
        {
            //get { throw new NotImplementedException(); }
            get { return false; } 

        }

        public bool SupportsStructureContext
        {
            //get { throw new NotImplementedException(); }
            get { return false; } 

        }

        public bool SupportsTaggedInput
        {
            //get { throw new NotImplementedException(); }
            get { return false; } 
        }

        public bool SupportsTargetConcordanceSearch
        {
            //get { throw new NotImplementedException(); }
            get { return false; }
        }

        public bool SupportsTranslation
        {
            //get { throw new NotImplementedException(); }
            get { return true; }
        }

        public bool SupportsUpdate
        {
            //get { throw new NotImplementedException(); }
            get { return false; }
        }

        public bool SupportsWordCounts
        {
            //get { throw new NotImplementedException(); }
            get { return false; }
        }

        public TranslationMethod TranslationMethod
        {
            //get { throw new NotImplementedException(); }
            get { return DeepLSamplerTranslationOptions.ProviderTranslationMethod; }
        }

        public Uri Uri
        {
            //get { throw new NotImplementedException(); }
            get { return Options.Uri; }
        }

        #endregion
    }
}

