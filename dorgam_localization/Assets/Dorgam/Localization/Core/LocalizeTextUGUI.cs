using System;
using Dorgam.Localization.Core;
using UnityEngine;
using Dorgam.Localization.RTLSupport;
using UnityEngine.UI;

namespace Dorgam.Localization.Core
{
	public class LocalizeTextUGUI : AbstractLocalize 
	{
		[SerializeField] private string _font;
	    [SerializeField] private bool _allowAlignmentChange = true;

        private Text _textUgui;

		private void Awake()
		{
			_textUgui = GetComponent<Text>();
		}

		protected override void Localize()
		{
		    SetText();
		    SetFont();
		    SetTextDirection();
		}

	    private void SetText()
	    {
	        string translation = LocalizationManager.GetTranslation<string>(Term);
	        if (!String.IsNullOrEmpty(translation))
	        {
	            if (!LocalizationManager.IsCurrentLanguageRTL())
	            {
	                _textUgui.text = translation;
	            }
	            else
	            {
	                _textUgui.text = LocalizationManager.Reverse(translation);
                }
            }
	    }

	    private void SetTextDirection()
	    {
	        if (_allowAlignmentChange)
	        {
	            if (LocalizationManager.IsCurrentLanguageRTL())
	            {
	                SetRTL();
	            }
	            else
	            {
	                SetLTR();
	            }
	        }
	    }

	    private void SetFont()
	    {
	        if (!String.IsNullOrEmpty(_font))
	        {
	            LocalizeFont();
	        }
	        else
	        {
	            SetDefaultFont();
	        }
	    }

	    private void SetDefaultFont()
		{
			Font defaultFont = LocalizationManager.GetTranslation<Font>("default_ugui");
			if(defaultFont != null)
				_textUgui.font = defaultFont;
		}


		private void LocalizeFont()
		{
			_textUgui.font = LocalizationManager.GetTranslation<Font>(_font);
		}

		private void SetRTL()
		{   
		    switch (_textUgui.alignment)
		    {
		        case TextAnchor.UpperLeft:
		            _textUgui.alignment = TextAnchor.UpperRight;
		            break;
		        case TextAnchor.MiddleLeft:
		            _textUgui.alignment = TextAnchor.MiddleRight;
		            break;
		        case TextAnchor.LowerLeft:
		            _textUgui.alignment = TextAnchor.LowerRight;
		            break;
		    }
        }

		private void SetLTR()
		{
		    switch (_textUgui.alignment)
		    {
		        case TextAnchor.UpperRight:
		            _textUgui.alignment = TextAnchor.UpperLeft;
                    break;
		        case TextAnchor.MiddleRight:
		            _textUgui.alignment = TextAnchor.MiddleLeft;
                    break;
		        case TextAnchor.LowerRight:
		            _textUgui.alignment = TextAnchor.LowerLeft;
                    break;
		    }
		}
	}
}