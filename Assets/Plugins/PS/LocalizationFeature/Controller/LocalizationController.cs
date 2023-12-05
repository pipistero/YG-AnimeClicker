using System.Collections.Generic;
using System.Linq;
using PS.LocalizationFeature.Types;
using PS.LocalizationFeature.Assets;

namespace PS.LocalizationFeature.Controller
{
    public class LocalizationController
    {
        private readonly Dictionary<LanguageType, LanguageAsset> _languageAssets;

        private LanguageType _currentLanguageType;
        
        public LocalizationController(IEnumerable<LanguageAsset> languageAssets, LanguageType languageType)
        {
            _languageAssets = languageAssets.ToDictionary(asset => asset.LanguageType);
            _currentLanguageType = languageType;

            PrepareAssets();
        }

        public string Get(string key)
        {
            return _languageAssets[_currentLanguageType].Get(key);
        }

        public void SetLanguage(LanguageType languageType)
        {
            _currentLanguageType = languageType;
        }

        #region Internal methods

        private void PrepareAssets()
        {
            foreach (var keyValuePair in _languageAssets)
            {
                keyValuePair.Value.Prepare();
            }
        }

        #endregion
    }
}