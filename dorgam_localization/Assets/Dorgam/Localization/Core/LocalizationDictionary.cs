using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dorgam.Localization.Core
{
	public class LocalizationDictionary : MonoBehaviour 
	{
		public StringTerm[] StringTerms { get{return _stringTerms;} }
		[SerializeField] private StringTerm[] _stringTerms;
		public SpriteTerm[] SpriteTerms { get{return _spriteTerms;} }
		[SerializeField] private SpriteTerm[] _spriteTerms;
		public AudioTerm[] AudioTerms { get{return _audioTerms;} }
		[SerializeField] private AudioTerm[] _audioTerms;
#if TextMeshPro
        public TMPFontTerm[] TMPFonts { get{return _tmpFonts;} }
		[SerializeField] private TMPFontTerm[] _tmpFonts;
#endif
		public FontTerm[] Fonts { get{return _fonts;} }
		[SerializeField] private FontTerm[] _fonts;

	    [Tooltip("Setting this to true will make the game always start in the device default language and will ignore the value of Starting Language.")]
        [SerializeField] private bool _startWithDeviceLanguage = false;
	    public bool StartWithDeviceLanguage { get { return _startWithDeviceLanguage; } }

        [Tooltip("Forcing the game to start in a specific language.")]
		[SerializeField] private SystemLanguage _startingLanguage = SystemLanguage.English;
	    public SystemLanguage StartingLanguage { get { return _startingLanguage; } }

	    public SystemLanguage FallbackLanguage
	    {
	        get { return _fallbackLanguage; }
	        set { _fallbackLanguage = value; }
	    }
        [Tooltip("In case a translation is requested, and the term doesn't have it, fallback translation will be used.")]
	    [SerializeField] private SystemLanguage _fallbackLanguage = SystemLanguage.English;
	}
}