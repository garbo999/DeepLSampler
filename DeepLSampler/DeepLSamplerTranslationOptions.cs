using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdl.LanguagePlatform.TranslationMemoryApi;
using System.Windows.Forms;


namespace DeepLSampler
{
    public class DeepLSamplerTranslationOptions
    {
        public static readonly TranslationMethod ProviderTranslationMethod = TranslationMethod.Other;

        TranslationProviderUriBuilder _uriBuilder;

        public DeepLSamplerTranslationOptions()
        {
            _uriBuilder = new TranslationProviderUriBuilder(DeepLSamplerTranslationProvider.DeepLSamplerTranslationProviderScheme);
        }

        public DeepLSamplerTranslationOptions(Uri uri)
        {
            _uriBuilder = new TranslationProviderUriBuilder(uri);
        }

        public Uri Uri
        {
            get
            {
                return _uriBuilder.Uri;
            }
        }

        public string DeepLSamplerFileName
        {
            get { return GetStringParameter("listfile"); }
            set { SetStringParameter("listfile", value); }
        }

        public string Delimiter
        {
            get { return GetStringParameter("delimiter"); }
            set { SetStringParameter("delimiter", value); }
        }

        private void SetStringParameter(string p, string value)
        {
            _uriBuilder[p] = value;
        }

        private string GetStringParameter(string p)
        {
            string paramString = _uriBuilder[p];
            return paramString;
        }

    }
}
