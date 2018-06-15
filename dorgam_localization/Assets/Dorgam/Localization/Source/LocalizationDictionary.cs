using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dorgam.Localization
{
	public class LocalizationDictionary : MonoBehaviour 
	{
		public SystemLanguage[] SupportedLanguages { get { return supportedLanguages;}}
		[SerializeField] private SystemLanguage[] supportedLanguages;
		public StringTerm[] StringTerms { get{return stringTerms;} }
		[SerializeField] private StringTerm[] stringTerms;
		public SpriteTerm[] SpriteTerms { get{return spriteTerms;} }
		[SerializeField] private SpriteTerm[] spriteTerms;
		public AudioTerm[] AudioTerms { get{return audioTerms;} }
		[SerializeField] private AudioTerm[] audioTerms;
		public TMPFontTerm[] TMPFonts { get{return tMPFonts;} }
		[SerializeField] private TMPFontTerm[] tMPFonts;
		public FontTerm[] Fonts { get{return fonts;} }
		[SerializeField] private FontTerm[] fonts;
		public bool StartWithDeviceLanguage { get{return startWithDeviceLanguage;} }
		[SerializeField] private bool startWithDeviceLanguage = false;
		public SystemLanguage StartingLanguage { get {return startingLanguage;}}
		[SerializeField] private SystemLanguage startingLanguage;
	}
}