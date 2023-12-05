using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PS.SpritesFeature.Controller
{
    public class SpritesStorage
    {
        private readonly Dictionary<string, Sprite> _spritesMap;

        public SpritesStorage(IEnumerable<Sprite> sprites)
        {
            _spritesMap = sprites.ToDictionary(sprite => sprite.name);
        }

        public Sprite GetSprite(string spriteName)
        {
            ValidateSpriteName(spriteName);
            
            return _spritesMap[spriteName];
        }

        #region Internal methods

        private void ValidateSpriteName(string spriteName)
        {
            if (_spritesMap.ContainsKey(spriteName) == false)
                throw new ArgumentException($"There is no such sprite ({spriteName}) in spritesStorage");
        }

        #endregion
    }
}