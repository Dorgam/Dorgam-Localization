using System.Collections;
using System.Collections.Generic;
#if TextMeshPro
using TMPro;
#endif
using UnityEngine;

namespace Dorgam.Localization.Core
{
    public abstract class Translation
    {
        public SystemLanguage Language
        {
            get { return _language; }
            set { _language = value; }
        }

        [SerializeField] private SystemLanguage _language;
    }

    [System.Serializable]
    public class Translation<T> : Translation
    {
        public T Value
        {
            get { return _value; }
            set { this._value = value; }
        }

        [SerializeField] private T _value;
    }

    [System.Serializable]
    public class StringTranslation : Translation<string> { }

    [System.Serializable]
    public class SpriteTranslation : Translation<Sprite> { }

    [System.Serializable]
    public class AudioTranslation : Translation<AudioClip> { }

#if TextMeshPro
    [System.Serializable]
    public class TMPFontTranslation : Translation<TMP_FontAsset> { }
#endif

    [System.Serializable]
    public class FontTranslation : Translation<Font> { }

}
