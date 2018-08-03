using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Dorgam.Localization.RTLSupport;
using System;

namespace Dorgam.Localization.Core
{
	public class LocalizationManager : MonoBehaviour 
	{
		public static SystemLanguage CurrentLanguage {get; private set;}
		private static LocalizationDictionary _dictionary;
		private static Dictionary<string, Dictionary<SystemLanguage, Translation>> _termsDictionary;
        private static readonly List<SystemLanguage> RTLLanguages = new List<SystemLanguage>
        (
            new SystemLanguage[]
            {
                SystemLanguage.Arabic,
                SystemLanguage.Hebrew
            }
        );

        public delegate void LocalizationAction ();
		public static event LocalizationAction OnLocalization;

		static LocalizationManager()
		{
			LoadDictionary();
			SetStartingLanguge();
			SetTermsDictionary();
		}

		public static T GetTranslation<T>(string termValue)
		{
			if (_termsDictionary.ContainsKey(termValue)) 
			{
			    if (_termsDictionary[termValue].ContainsKey(CurrentLanguage))
			    {
			        Translation<T> targetTranslation = (Translation<T>) _termsDictionary[termValue][CurrentLanguage];
			        return targetTranslation.Value;
			    }
			    else
			    {
			        Debug.LogWarning(CurrentLanguage.ToString() + " Translation of term: " + termValue + " does not exist in the dictionary.");
			        return default(T);
			    }
            } 
			else 
			{
				Debug.LogWarning ("Term: " + termValue + " does not exist in the dictionary.");
				return default(T);
			}
		}

	    public static bool IsCurrentLanguageRTL()
	    {
	        return RTLLanguages.Contains(CurrentLanguage);
	    }

	    public static bool IsRTLLanguage(SystemLanguage language)
	    {
	        return RTLLanguages.Contains(language);
	    }

        private static Dictionary<SystemLanguage, Translation> FixRTLTranslation(Dictionary<SystemLanguage, Translation> translations)
        {
            Dictionary<SystemLanguage, Translation> fixedTranslations =  new Dictionary<SystemLanguage, Translation>();
            foreach (SystemLanguage language in translations.Keys)
            {
                if (IsRTLLanguage(language))
                {
                    string translationValue = ((Translation<string>) translations[language]).Value;
                    Translation<string> newTranslation = new Translation<string>();
                    newTranslation.Value = FixRTLString(translationValue);
                    fixedTranslations.Add(language, newTranslation);
                }
                else
                {
                    fixedTranslations.Add(language, translations[language]);
                }
            }
		    return fixedTranslations;
		}

		public static string Reverse(string s)
		{
			char[] charArray = s.ToCharArray();
			Array.Reverse(charArray);
			return new string(charArray);
		}

		public static void SetLanguage(SystemLanguage language)
		{
		    if (language == CurrentLanguage)
		        return;

			CurrentLanguage = language;
		    if (OnLocalization != null)
		    {
		        OnLocalization();
		    }

            Debug.Log("Language changed to: " + CurrentLanguage);
		}

		private static string FixRTLString(string s)
		{
			return Reverse(RTLFixer.Fix(s));
		}

		private static void SetStartingLanguge()
		{
			if(_dictionary.StartWithDeviceLanguage)
				CurrentLanguage = Application.systemLanguage;
			else
				CurrentLanguage = _dictionary.StartingLanguage;
		}

		private static void LoadDictionary()
		{
			GameObject dictionaryPrefab = Resources.Load ("Dictionary") as GameObject;
			_dictionary = dictionaryPrefab.GetComponent<LocalizationDictionary>();
		}

		private static void SetTermsDictionary()
		{
			_termsDictionary = new Dictionary<string, Dictionary<SystemLanguage, Translation>>();
			_dictionary.StringTerms.ToList().ForEach(term => _termsDictionary.Add(term.Value, FixRTLTranslation(CreateTranslationDictionary(term.Translations))));
			_dictionary.SpriteTerms.ToList().ForEach(term => _termsDictionary.Add(term.Value, CreateTranslationDictionary(term.Translations)));
			_dictionary.AudioTerms.ToList().ForEach(term => _termsDictionary.Add(term.Value, CreateTranslationDictionary(term.Translations)));
			_dictionary.Fonts.ToList().ForEach(term => _termsDictionary.Add(term.Value, CreateTranslationDictionary(term.Translations)));
#if TextMeshPro
            _dictionary.TMPFonts.ToList().ForEach(term => _termsDictionary.Add(term.Value, CreateTranslationDictionary(term.Translations)));
#endif
		}

	    private static Dictionary<SystemLanguage, Translation> CreateTranslationDictionary(Translation[] translations)
	    {
            Dictionary<SystemLanguage, Translation> translationsDictionary = new Dictionary<SystemLanguage, Translation>();
	        foreach (Translation translation in translations)
	        {
	            translationsDictionary.Add(translation.Language, translation);
	        }
	        return translationsDictionary;
	    }
	}
}