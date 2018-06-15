using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArabicSupport;
using UnityEngine.UI;

namespace Dorgam.Localization
{
	public class LocalizeTextUGUI : AbstractLocalize 
	{
		[SerializeField] private string font = "";
		private Text textUGUI;

		private void Awake()
		{
			textUGUI = GetComponent<Text>();
		}

		protected override void Localize()
		{
			textUGUI.text = LocalizationManager.GetTranslation<string>(term);
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
			Font defaultFont = LocalizationManager.GetTranslation<Font>("default_ugui");
			if(defaultFont != null)
				textUGUI.font = defaultFont;
		}


		private void ChangeFont()
		{
			textUGUI.font = LocalizationManager.GetTranslation<Font>(font);
		}

		private void SetRTL()
		{
			textUGUI.text = LocalizationManager.Reverse(textUGUI.text);
			if(IsLTR())
				textUGUI.alignment = TextAnchor.MiddleRight;
		}

		private void SetLTR()
		{
			if(IsRTL())
				textUGUI.alignment = TextAnchor.MiddleLeft;
		}

		private bool IsLTR()
		{
			return textUGUI.alignment == TextAnchor.LowerLeft ||
				textUGUI.alignment == TextAnchor.MiddleLeft ||
				textUGUI.alignment == TextAnchor.UpperLeft;
		}

		private bool IsRTL()
		{
			return textUGUI.alignment == TextAnchor.UpperRight ||
				textUGUI.alignment == TextAnchor.MiddleRight ||
				textUGUI.alignment == TextAnchor.UpperRight;
		}
	}
}