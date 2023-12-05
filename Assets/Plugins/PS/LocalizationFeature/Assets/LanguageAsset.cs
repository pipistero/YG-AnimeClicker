using System;
using System.Collections.Generic;
using PS.LocalizationFeature.Types;
using UnityEngine;

namespace PS.LocalizationFeature.Assets
{
    [Serializable]
    public class LanguageAsset
    {
        private readonly char LinesSplitChar = '\n';
        private readonly char PairsSplitChar = ':';
        
        [SerializeField] private TextAsset _asset;
        [SerializeField] private LanguageType _languageType;

        public LanguageType LanguageType => _languageType;

        private Dictionary<string, string> _keyValueMap;

        public void Prepare()
        {
            _keyValueMap = new Dictionary<string, string>();
            
            TryParseAsset();
        }

        public string Get(string key)
        {
            if (_keyValueMap.ContainsKey(key) == false)
            {
                Debug.Log($"There is no key ({key}) in localization asset ({LanguageType})");
                return "ERROR";
            }

            return _keyValueMap[key];
        }

        #region Internal methods

        private void TryParseAsset()
        {
            string[] lines = _asset.text.Split(LinesSplitChar);

            foreach (string line in lines)
            {
                string[] pair = line.Split(PairsSplitChar);

                if (pair.Length != 2)
                    throw new Exception($"Problem with line in localization asset ({LanguageType});" +
                                        $"\n" +
                                        $"Line below" +
                                        $"\n" +
                                        $"{line}");

                if (_keyValueMap.ContainsKey(pair[0]))
                    throw new Exception($"Key ({pair[0]}) already exist in localization asset ({LanguageType})");
                
                _keyValueMap.Add(pair[0], pair[1]);
            }
        }

        #endregion
    }
}