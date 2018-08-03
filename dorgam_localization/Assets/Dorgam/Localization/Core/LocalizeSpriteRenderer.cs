using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dorgam.Localization.Core
{
    public class LocalizeSpriteRenderer : AbstractLocalize
	{
		private SpriteRenderer _spriteRenderer;

		private void Awake()
		{
			_spriteRenderer = GetComponent<SpriteRenderer>();
		}

		protected override void Localize()
		{
			_spriteRenderer.sprite = LocalizationManager.GetTranslation<Sprite>(Term);
		}
	}
}