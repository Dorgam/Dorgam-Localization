using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ArabicSupport;
using System;

namespace Dorgam.Localization
{
	public class LocalizationManager : MonoBehaviour 
	{
		public static SystemLanguage CurrentLanguage {get; private set;}
		private static LocalizationDictionary dictionary;
		private static Dictionary<string, Translation[]> termsDictionary;
		public delegate void LocalizationAction ();
		public static event LocalizationAction OnLocalization;
		private static SystemLanguage[] supportedLanguages;

		static LocalizationManager()
		{
			LoadDictionary();
			SetStartingLanguge();
			LoadSupportedLanguages();
			SetTermsDictionary();
		}

		public static T GetTranslation<T>(string termValue)
		{
			if (termsDictionary.ContainsKey(termValue)) 
			{
				Translation<T> targetTranslation = (Translation<T>) termsDictionary[termValue][GetCurrentLanguageIndex()];
				if (targetTranslation != null) 
				{
					return targetTranslation.Value;
				} 
				else 
				{
					Debug.LogWarning (CurrentLanguage.ToString() + " Translation of term: " + termValue + " does not exist in the dictionary.");
					return default(T);
				}
			} 
			else 
			{
				Debug.LogWarning ("Term: " + termValue + " does not exist in the dictionary.");
				return default(T);
			}
		}

		private static Translation<string>[] FixArabicTranslation(Translation<string>[] translations)
		{
			Translation<string>[] newTranslations = new Translation<string>[translations.Length];
			for(int i = 0; i < translations.Length; i++)
			{
				Translation<string> translation = new Translation<string>();
				if(i == GetArabicLanguageIndex())
				{
					translation.Value = FixArabicString(translations[i].Value);
				}
				else
				{
					translation.Value = translations[i].Value;
				}
				newTranslations[i] = translation;
			} 
			return newTranslations;
		}

		public static int GetCurrentLanguageIndex()
		{
			return Array.IndexOf(supportedLanguages, CurrentLanguage);
		}

		public static int GetArabicLanguageIndex()
		{
			return Array.IndexOf(supportedLanguages, SystemLanguage.Arabic);
		}

		public static string Reverse(string s)
		{
			char[] charArray = s.ToCharArray();
			Array.Reverse(charArray);
			return new string(charArray);
		}

		public static void SetLanguage(SystemLanguage language)
		{
			CurrentLanguage = language;
			OnLocalization();
		}

		private static string FixArabicString(string s)
		{
			return Reverse(ArabicFixer.Fix(s));
		}

		private static void SetStartingLanguge()
		{
			if(dictionary.StartWithDeviceLanguage)
				CurrentLanguage = Application.systemLanguage;
			else
				CurrentLanguage = dictionary.StartingLanguage;
		}

		private static void LoadDictionary()
		{
			GameObject dictionaryPrefab = Resources.Load ("Dictionary") as GameObject;
			dictionary = dictionaryPrefab.GetComponent<LocalizationDictionary>();
		}

		private static void LoadSupportedLanguages()
		{
			supportedLanguages = dictionary.SupportedLanguages;
		}

		private static void SetTermsDictionary()
		{
			termsDictionary = new Dictionary<string, Translation[]>();
			dictionary.StringTerms.ToList().ForEach(term => termsDictionary.Add(term.Value, FixArabicTranslation(term.Translations)));
			dictionary.SpriteTerms.ToList().ForEach(term => termsDictionary.Add(term.Value, term.Translations));
			dictionary.AudioTerms.ToList().ForEach(term => termsDictionary.Add(term.Value, term.Translations));
			dictionary.Fonts.ToList().ForEach(term => termsDictionary.Add(term.Value, term.Translations));
			dictionary.TMPFonts.ToList().ForEach(term => termsDictionary.Add(term.Value, term.Translations));
		}
	}
}