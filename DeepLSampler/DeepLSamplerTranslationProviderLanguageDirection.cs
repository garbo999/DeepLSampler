using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sdl.LanguagePlatform.Core;
using Sdl.Core.Globalization;
using Sdl.LanguagePlatform.TranslationMemory;
using Sdl.LanguagePlatform.TranslationMemoryApi;
using System.Windows.Forms;

namespace DeepLSampler
{
    class DeepLSamplerTranslationProviderLanguageDirection : ITranslationProviderLanguageDirection
    {
        #region ITranslationProviderLanguageDirection Members

        private DeepLSamplerTranslationProvider _provider;
        private LanguagePair _languageDirection;
        private DeepLSamplerTranslationOptions _options;
        private DeepLSamplerTranslationProviderElementVisitor _visitor;
        //private Dictionary<string, string> _listOfTranslations;

        //private static bool search_segment_locked = false;


        // helper function
        /// Creates the translation unit as it is later shown in the Translation Results
        /// window of SDL Trados Studio. This member also determines the match score
        /// (in our implementation always 100%, as only exact matches are supported)
        /// as well as the confirmation lelvel, i.e. Translated.
        private SearchResult CreateSearchResult(Segment searchSegment, Segment translation, string sourceSegment, bool formattingPenalty)
        {
            TranslationUnit tu = new TranslationUnit();
            Segment orgSegment = new Segment();
            orgSegment.Add(sourceSegment);
            tu.SourceSegment = orgSegment;
            tu.TargetSegment = translation;

            tu.ResourceId = new PersistentObjectToken(tu.GetHashCode(), Guid.Empty);

            //int score = 100;
            int score = 85; // my standard score for DeepL
            tu.Origin = TranslationUnitOrigin.TM;

            SearchResult searchResult = new SearchResult(tu);
            searchResult.ScoringResult = new ScoringResult();
            searchResult.ScoringResult.BaseScore = score;

            if (formattingPenalty)
            {
                #region "Draft"
                tu.ConfirmationLevel = ConfirmationLevel.Draft;
                #endregion

                #region "FormattingPenalty"
                Penalty penalty = new Penalty(PenaltyType.TagMismatch, 1);
                searchResult.ScoringResult.ApplyPenalty(penalty);
                #endregion
            }
            else
            {
                tu.ConfirmationLevel = ConfirmationLevel.Translated;
            }
            //#endregion

            return searchResult;

        }

        public DeepLSamplerTranslationProviderLanguageDirection(DeepLSamplerTranslationProvider provider, LanguagePair languages)
        {
            // this gets instantiated hundreds of times
            // DeepLSamplerTranslationProvider.log.WriteLine("DeepLSamplerTranslationProviderLanguageDirection instantiated", true);

            _provider = provider;
            _languageDirection = languages;
            _options = _provider.Options;
            _visitor = new DeepLSamplerTranslationProviderElementVisitor(_options);
            //_listOfTranslations = new Dictionary<string, string>();

            // examples
            //_languageDirection.SourceCultureName = "en-US";
            //_languageDirection.TargetCultureName = "de-DE";
            string _source_lang = _languageDirection.SourceCultureName.Substring(0, 2).ToUpper();
            string _target_lang = _languageDirection.TargetCultureName.Substring(0, 2).ToUpper();

            // TRY / CATCH !!!!
            // without the if statement, this was repeated many times!
            if (DeepLSamplerTranslationProvider.deepL.SrcLang != _source_lang || DeepLSamplerTranslationProvider.deepL.TgtLang != _target_lang)
            {
                DeepLSamplerTranslationProvider.deepL.setLanguages(_source_lang, _target_lang);
            }

        }

        public ImportResult[] AddOrUpdateTranslationUnits(TranslationUnit[] translationUnits, int[] previousTranslationHashes, ImportSettings settings)
        {
            throw new NotImplementedException();
        }

        public ImportResult[] AddOrUpdateTranslationUnitsMasked(TranslationUnit[] translationUnits, int[] previousTranslationHashes, ImportSettings settings, bool[] mask)
        {
            throw new NotImplementedException();
        }

        public ImportResult AddTranslationUnit(TranslationUnit translationUnit, ImportSettings settings)
        {
            throw new NotImplementedException();
        }

        public ImportResult[] AddTranslationUnits(TranslationUnit[] translationUnits, ImportSettings settings)
        {
            throw new NotImplementedException();
        }

        public ImportResult[] AddTranslationUnitsMasked(TranslationUnit[] translationUnits, ImportSettings settings, bool[] mask)
        {
            throw new NotImplementedException();
        }

        public bool CanReverseLanguageDirection
        {
            //get { throw new NotImplementedException(); }
            get { return false; }
        }

        public SearchResults SearchSegment(SearchSettings settings, Segment segment)
        {
            string dl_trans;

            // wait loop to avoid concurrent calls overlapping
            //while (DeepLSpider.search_segment_locked)
            //{
            //    System.Threading.Thread.Sleep(DeepLSpider._Delay_3);
            //}

            _visitor.Reset();
            foreach (var element in segment.Elements)
            {
                element.AcceptSegmentElementVisitor(_visitor);
            }

            DeepLSamplerTranslationProvider.log.WriteLine("SearchSegment executed for source: " + _visitor.PlainText, true);

            SearchResults results = new SearchResults();
            results.SourceSegment = segment.Duplicate();

            // Look up the currently selected segment in the collection (normal segment lookup).
            if (settings.Mode == SearchMode.NormalSearch)
            {
                Segment translation = new Segment(_languageDirection.TargetCulture);
                dl_trans = DeepLSamplerTranslationProvider.deepL.translateText(_visitor.PlainText);
                translation.Add(dl_trans);
                results.Add(CreateSearchResult(segment, translation, _visitor.PlainText, segment.HasTags));
                DeepLSamplerTranslationProvider.log.WriteLine("--> SearchSegment gets translation: ***" + dl_trans + "*** for source: " + _visitor.PlainText, true);

            }

            //DeepLSpider.search_segment_locked = false;

            // concordance searches WOULD go here (but not supported)
            return results;
        }

        public SearchResults[] SearchSegments(SearchSettings settings, Segment[] segments)
        {
            //throw new NotImplementedException();

            SearchResults[] results = new SearchResults[segments.Length];
            for (int p = 0; p < segments.Length; ++p)
            {
                results[p] = SearchSegment(settings, segments[p]);
            }
            return results;

        }

        public SearchResults[] SearchSegmentsMasked(SearchSettings settings, Segment[] segments, bool[] mask)
        {
            //throw new NotImplementedException();
            if (segments == null)
            {
                throw new ArgumentNullException("segments in SearchSegmentsMasked");
            }
            if (mask == null || mask.Length != segments.Length)
            {
                throw new ArgumentException("mask in SearchSegmentsMasked");
            }

            SearchResults[] results = new SearchResults[segments.Length];
            for (int p = 0; p < segments.Length; ++p)
            {
                if (mask[p])
                {
                    results[p] = SearchSegment(settings, segments[p]);
                }
                else
                {
                    results[p] = null;
                }
            }

            return results;

        }

        public SearchResults SearchText(SearchSettings settings, string segment)
        {
            //throw new NotImplementedException();
            Segment s = new Sdl.LanguagePlatform.Core.Segment(_languageDirection.SourceCulture);
            s.Add(segment);
            return SearchSegment(settings, s);

        }

        public SearchResults SearchTranslationUnit(SearchSettings settings, TranslationUnit translationUnit)
        {
            //throw new NotImplementedException();
            return SearchSegment(settings, translationUnit.SourceSegment);
        }

        public SearchResults[] SearchTranslationUnits(SearchSettings settings, TranslationUnit[] translationUnits)
        {
            //throw new NotImplementedException();
            SearchResults[] results = new SearchResults[translationUnits.Length];
            for (int p = 0; p < translationUnits.Length; ++p)
            {
                results[p] = SearchSegment(settings, translationUnits[p].SourceSegment);
            }
            return results;

        }

        public SearchResults[] SearchTranslationUnitsMasked(SearchSettings settings, TranslationUnit[] translationUnits, bool[] mask)
        {
            //throw new NotImplementedException();
            List<SearchResults> results = new List<SearchResults>();

            int i = 0;
            foreach (var tu in translationUnits)
            {
                if (mask == null || mask[i])
                {
                    var result = SearchTranslationUnit(settings, tu);
                    results.Add(result);
                }
                else
                {
                    results.Add(null);
                }
                i++;
            }

            return results.ToArray();

        }

        public System.Globalization.CultureInfo SourceLanguage
        {
            //get { throw new NotImplementedException(); }
            get { return _languageDirection.SourceCulture; }
        }

        public System.Globalization.CultureInfo TargetLanguage
        {
            //get { throw new NotImplementedException(); }
            get { return _languageDirection.TargetCulture; }
        }

        public ITranslationProvider TranslationProvider
        {
            //get { throw new NotImplementedException(); }
            get { return _provider; }
        }

        public ImportResult UpdateTranslationUnit(TranslationUnit translationUnit)
        {
            throw new NotImplementedException();
        }

        public ImportResult[] UpdateTranslationUnits(TranslationUnit[] translationUnits)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
