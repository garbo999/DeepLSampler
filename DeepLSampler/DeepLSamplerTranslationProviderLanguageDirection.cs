using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sdl.LanguagePlatform.Core;
using Sdl.Core.Globalization;
using Sdl.LanguagePlatform.TranslationMemory;
using Sdl.LanguagePlatform.TranslationMemoryApi;

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

        // string borrar = DeepLSamplerProviderConfDialog.deepL.translateText("i think i hit the jackpot today"); // new test

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

            int score = 100;
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
            _provider = provider;
            _languageDirection = languages;
            _options = _provider.Options;
            _visitor = new DeepLSamplerTranslationProviderElementVisitor(_options);
            //_listOfTranslations = new Dictionary<string, string>();

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
            //throw new NotImplementedException();

            _visitor.Reset();
            foreach (var element in segment.Elements)
            {
                element.AcceptSegmentElementVisitor(_visitor);
            }

            SearchResults results = new SearchResults();
            results.SourceSegment = segment.Duplicate();

            // Look up the currently selected segment in the collection (normal segment lookup).
            if (settings.Mode == SearchMode.NormalSearch)
            {
                Segment translation = new Segment(_languageDirection.TargetCulture);
                //translation.Add(_listOfTranslations[_visitor.PlainText]);
                translation.Add(DeepLSamplerProviderConfDialog.deepL.translateText(_visitor.PlainText));
                results.Add(CreateSearchResult(segment, translation, _visitor.PlainText, segment.HasTags));
            }
            
            // concordance searches WOULD go here (but not supported)
            return results;
        }

        public SearchResults[] SearchSegments(SearchSettings settings, Segment[] segments)
        {
            throw new NotImplementedException();
        }

        public SearchResults[] SearchSegmentsMasked(SearchSettings settings, Segment[] segments, bool[] mask)
        {
            throw new NotImplementedException();
        }

        public SearchResults SearchText(SearchSettings settings, string segment)
        {
            throw new NotImplementedException();
        }

        public SearchResults SearchTranslationUnit(SearchSettings settings, TranslationUnit translationUnit)
        {
            throw new NotImplementedException();
        }

        public SearchResults[] SearchTranslationUnits(SearchSettings settings, TranslationUnit[] translationUnits)
        {
            throw new NotImplementedException();
        }

        public SearchResults[] SearchTranslationUnitsMasked(SearchSettings settings, TranslationUnit[] translationUnits, bool[] mask)
        {
            throw new NotImplementedException();
        }

        public System.Globalization.CultureInfo SourceLanguage
        {
            get { throw new NotImplementedException(); }
        }

        public System.Globalization.CultureInfo TargetLanguage
        {
            get { throw new NotImplementedException(); }
        }

        public ITranslationProvider TranslationProvider
        {
            get { throw new NotImplementedException(); }
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
