using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArabicSupport;
using TMPro;

namespace Dorgam.Localization
{
	public class LocalizeTextMeshProUGUI : AbstractLocalize 
	{
		[SerializeField] private string font = "";
		private TextMeshProUGUI tmProUGUI;

		private void Awake()
		{
			tmProUGUI = GetComponent<TextMeshProUGUI>();
		}

		protected override void Localize()
		{
			tmProUGUI.SetText(LocalizationManager.GetTranslation<string>(term));
			if(font != "")
				ChangeFont();
			else
				SetDefaultFont();
			if(LocalizationManager.CurrentLanguage == SystemLanguage.Arabic)
				SetRTL();
			else
				SetLTR();
		}

		private void SetDefaultFont()
		{
			TMP_FontAsset defaultFont = LocalizationManager.GetTranslation<TMP_FontAsset>("default_tmp");
			if(defaultFont != null)
				tmProUGUI.font = defaultFont;
		}

		private void ChangeFont()
		{
			tmProUGUI.font = LocalizationManager.GetTranslation<TMP_FontAsset>(font);
		}

		private void SetRTL()
		{
			tmProUGUI.isRightToLeftText = true;
			if(IsLTR())
				tmProUGUI.alignment = TextAlignmentOptions.Right;
		}

		private void SetLTR()
		{
			tmProUGUI.isRightToLeftText = false;
			if(IsRTL())
				tmProUGUI.alignment = TextAlignmentOptions.Left;
		}

		private bool IsLTR()
		{
			return tmProUGUI.alignment == TextAlignmentOptions.Left ||
				tmProUGUI.alignment == TextAlignmentOptions.TopLeft ||
				tmProUGUI.alignment == TextAlignmentOptions.MidlineLeft ||
				tmProUGUI.alignment == TextAlignmentOptions.BottomLeft;
		}

		private bool IsRTL()
		{
			return tmProUGUI.alignment == TextAlignmentOptions.Right ||
				tmProUGUI.alignment == TextAlignmentOptions.TopRight ||
				tmProUGUI.alignment == TextAlignmentOptions.MidlineRight ||
				tmProUGUI.alignment == TextAlignmentOptions.BottomRight;
		}
	}
}
