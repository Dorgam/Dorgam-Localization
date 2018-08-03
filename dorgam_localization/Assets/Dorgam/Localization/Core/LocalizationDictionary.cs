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
		public bool StartWithDeviceLanguage { get{return _startWithDeviceLanguage;} }
		[SerializeField] private bool _startWithDeviceLanguage = false;
		public SystemLanguage StartingLanguage { get {return _startingLanguage;}}
		[SerializeField] private SystemLanguage _startingLanguage;
	}
}