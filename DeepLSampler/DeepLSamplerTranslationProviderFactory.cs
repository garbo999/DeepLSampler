using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sdl.LanguagePlatform.Core;
using Sdl.LanguagePlatform.TranslationMemory;
using Sdl.LanguagePlatform.TranslationMemoryApi;
using DeepLSampler;
//using System.Resources;

namespace DeepLSampler
{
    [TranslationProviderFactory(Id = "DeepLSamplerTranslationProviderFactory",
                                Name = "DeepLSamplerTranslationProviderFactory",
                                Description = "Fetches translations from DeepL")]
    class DeepLSamplerTranslationProviderFactory : ITranslationProviderFactory
    {
        #region ITranslationProviderFactory Members

        public ITranslationProvider CreateTranslationProvider(Uri translationProviderUri, string translationProviderState, ITranslationProviderCredentialStore credentialStore)
        {
            //throw new NotImplementedException();
            if (!SupportsTranslationProviderUri(translationProviderUri))
            {
                throw new Exception("Cannot handle URI.");
            }

            DeepLSamplerTranslationProvider tp = new DeepLSamplerTranslationProvider(new DeepLSamplerTranslationOptions(translationProviderUri));

            return tp;
        }

        public TranslationProviderInfo GetTranslationProviderInfo(Uri translationProviderUri, string translationProviderState)
        {
            //throw new NotImplementedException();
            TranslationProviderInfo info = new TranslationProviderInfo();

            #region "TranslationMethod"
            info.TranslationMethod = DeepLSamplerTranslationOptions.ProviderTranslationMethod;
            #endregion

            #region "Name"
            info.Name = PluginResources.Plugin_NiceName;
            #endregion

            return info;

        }

        public bool SupportsTranslationProviderUri(Uri translationProviderUri)
        {
            //throw new NotImplementedException();
            if (translationProviderUri == null)
            {
                throw new ArgumentNullException("Translation provider URI not supported.");
            }
            return String.Equals(translationProviderUri.Scheme, DeepLSamplerTranslationProvider.DeepLSamplerTranslationProviderScheme, StringComparison.OrdinalIgnoreCase);

        }

        #endregion
    }
}
