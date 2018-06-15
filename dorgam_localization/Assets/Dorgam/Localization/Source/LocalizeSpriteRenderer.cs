using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dorgam.Localization
{
public class LocalizeSpriteRenderer : AbstractLocalize
	{
		private SpriteRenderer spriteRenderer;
		private void Awake()
		{
			spriteRenderer = GetComponent<SpriteRenderer>();
		}

		protected override void Localize()
		{
			spriteRenderer.sprite = LocalizationManager.GetTranslation<Sprite>(term);
		}
	}
}