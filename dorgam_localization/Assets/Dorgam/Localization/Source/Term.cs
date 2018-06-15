using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Dorgam.Localization
{
	[System.Serializable]
	public abstract class Term
	{
		public string Value {get {return value;}}
		[SerializeField] private string value;
	}

	[System.Serializable]
	public abstract class Term<T> : Term
	{
		public abstract Translation<T>[] Translations {get;}
		public void SetTranslation(T translation, SystemLanguage language)
		{
			Translations[LocalizationManager.GetCurrentLanguageIndex()].Value = translation;
		}
	}

	[System.Serializable]
	public class StringTerm : Term<string>
	{
		[SerializeField] private StringTranslation[] translations;
		public override Translation<string>[] Translations { get {return translations;}}
	}

	[System.Serializable]
	public class SpriteTerm : Term<Sprite>
	{
		[SerializeField] private SpriteTranslation[] translations;
		public override Translation<Sprite>[] Translations { get {return translations;}}
	}

	[System.Serializable]
	public class AudioTerm : Term<AudioClip>
	{
		[SerializeField] private AudioTranslation[] translations;
		public override Translation<AudioClip>[] Translations { get {return translations;}}
	}

	[System.Serializable]
	public class TMPFontTerm : Term<TMP_FontAsset>
	{
		[SerializeField] private TMPFontTranslation[] translations;
		public override Translation<TMP_FontAsset>[] Translations { get {return translations;}}
	}

	[System.Serializable]
	public class FontTerm : Term<Font>
	{
		[SerializeField] private FontTranslation[] translations;
		public override Translation<Font>[] Translations { get {return translations;}}
	}
}