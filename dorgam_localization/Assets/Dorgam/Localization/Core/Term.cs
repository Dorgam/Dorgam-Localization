using System.Collections;
using System.Collections.Generic;
#if TextMeshPro
using TMPro;
#endif
using UnityEngine;

namespace Dorgam.Localization.Core
{
	[System.Serializable]
	public abstract class Term
	{
		public string Value {get {return _value;}}
		[SerializeField] private string _value;
	}

	[System.Serializable]
	public abstract class Term<T> : Term
	{
		public abstract Translation<T>[] Translations {get;}
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

#if TextMeshPro
    [System.Serializable]
	public class TMPFontTerm : Term<TMP_FontAsset>
	{
		[SerializeField] private TMPFontTranslation[] translations;
		public override Translation<TMP_FontAsset>[] Translations { get {return translations;}}
	}
#endif

    [System.Serializable]
	public class FontTerm : Term<Font>
	{
		[SerializeField] private FontTranslation[] translations;
		public override Translation<Font>[] Translations { get {return translations;}}
	}
}