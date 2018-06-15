
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dorgam.Localization
{
	public class LocalizeImage : AbstractLocalize
	{
		private Image image;
		private void Awake()
		{
			image = GetComponent<Image>();
		}

		protected override void Localize()
		{
			image.sprite = LocalizationManager.GetTranslation<Sprite>(term);
		}
	}
}
