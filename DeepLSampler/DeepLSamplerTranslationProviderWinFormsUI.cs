using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sdl.LanguagePlatform.Core;
using Sdl.LanguagePlatform.TranslationMemory;
using Sdl.LanguagePlatform.TranslationMemoryApi;
using DeepLSampler;

namespace DeepLSampler
{
    [TranslationProviderWinFormsUi(Id = "DeepLSamplerTranslationProviderWinFormsUI",
                                   Name = "DeepLSamplerTranslationProviderWinFormsUI",
                                   Description = "DeepLSamplerTranslationProviderWinFormsUI")]
    class DeepLSamplerTranslationProviderWinFormsUI : ITranslationProviderWinFormsUI
    {
        #region ITranslationProviderWinFormsUI Members

        public ITranslationProvider[] Browse(IWin32Window owner, LanguagePair[] languagePairs, ITranslationProviderCredentialStore credentialStore)
        {
            //throw new NotImplementedException();
            DeepLSamplerProviderConfDialog dialog = new DeepLSamplerProviderConfDialog(new DeepLSamplerTranslationOptions());
            if (dialog.ShowDialog(owner) == DialogResult.OK)
            {
                DeepLSamplerTranslationProvider testProvider = new DeepLSamplerTranslationProvider(dialog.Options);
                return new ITranslationProvider[] { testProvider };
            }
            return null;
        }

        public bool Edit(IWin32Window owner, ITranslationProvider translationProvider, LanguagePair[] languagePairs, ITranslationProviderCredentialStore credentialStore)
        {
            //throw new NotImplementedException();
            DeepLSamplerTranslationProvider editProvider = translationProvider as DeepLSamplerTranslationProvider;
            if (editProvider == null)
            {
                return false;
            }

            DeepLSamplerProviderConfDialog dialog = new DeepLSamplerProviderConfDialog(editProvider.Options);
            if (dialog.ShowDialog(owner) == DialogResult.OK)
            {
                editProvider.Options = dialog.Options;
                return true;
            }

            return false;
        }

        public bool GetCredentialsFromUser(IWin32Window owner, Uri translationProviderUri, string translationProviderState, ITranslationProviderCredentialStore credentialStore)
        {
            //throw new NotImplementedException();
            return true;
        }

        public TranslationProviderDisplayInfo GetDisplayInfo(Uri translationProviderUri, string translationProviderState)
        {
            //throw new NotImplementedException();
            TranslationProviderDisplayInfo info = new TranslationProviderDisplayInfo();
            info.Name = PluginResources.Plugin_NiceName;
            info.TranslationProviderIcon = PluginResources.band_aid_icon;
            info.TooltipText = PluginResources.Plugin_Tooltip;

            info.SearchResultImage = PluginResources.band_aid_symbol;

            return info;

        }

        public bool SupportsEditing
        {
            //get { throw new NotImplementedException(); }
            get { return true; }
        }

        public bool SupportsTranslationProviderUri(Uri translationProviderUri)
        {
            //throw new NotImplementedException();
            if (translationProviderUri == null)
            {
                throw new ArgumentNullException("URI not supported by the plug-in.");
            }
            return String.Equals(translationProviderUri.Scheme, DeepLSamplerTranslationProvider.DeepLSamplerTranslationProviderScheme, StringComparison.CurrentCultureIgnoreCase);
        }

        public string TypeDescription
        {
            //get { throw new NotImplementedException(); }
            get { return PluginResources.Plugin_Description; }
        }

        public string TypeName
        {
            //get { throw new NotImplementedException(); }
            get { return PluginResources.Plugin_NiceName; }
        }

        #endregion
    }
}
