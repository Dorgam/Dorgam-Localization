
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dorgam.Localization.Core
{
	public class LocalizeImage : AbstractLocalize
	{
		private Image _image;

		private void Awake()
		{
			_image = GetComponent<Image>();
		}

		protected override void Localize()
		{
			_image.sprite = LocalizationManager.GetTranslation<Sprite>(Term);
		}
	}
}
