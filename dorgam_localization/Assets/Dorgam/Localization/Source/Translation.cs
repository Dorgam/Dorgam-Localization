using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Translation {}

[System.Serializable]
public class Translation<T> : Translation
{
	public T Value {get {return value;} set{this.value = value;}}
	[SerializeField] private T value;
}

[System.Serializable]
public class StringTranslation : Translation<string>{}

[System.Serializable]
public class SpriteTranslation : Translation<Sprite>{}

[System.Serializable]
public class AudioTranslation : Translation<AudioClip>{}

[System.Serializable]
public class TMPFontTranslation : Translation<TMP_FontAsset>{}

[System.Serializable]
public class FontTranslation : Translation<Font>{}
