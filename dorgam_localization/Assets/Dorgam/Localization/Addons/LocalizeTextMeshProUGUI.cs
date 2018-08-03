#if TextMeshPro
using System;
using Dorgam.Localization.Core;
using UnityEngine;
using TMPro;
using Debug = UnityEngine.Debug;

namespace Dorgam.Localization.Addons
{
    public class LocalizeTextMeshProUGUI : AbstractLocalize 
	{
		[SerializeField] private string _font;
	    [SerializeField] private bool _allowAlignmentChange = true;

        private TextMeshProUGUI _tmProUgui;

		private void Awake()
		{
			_tmProUgui = GetComponent<TextMeshProUGUI>();
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
	            _tmProUgui.SetText(translation);
	        }
	    }

	    private void SetTextDirection()
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
			TMP_FontAsset defaultFont = LocalizationManager.GetTranslation<TMP_FontAsset>("default_tmp");
		    if (defaultFont != null)
		    {
		        _tmProUgui.font = defaultFont;
		    }
		    else
		    {
		        Debug.LogWarning("Default TextMeshPro Font is not assigned. Please create term: 'default_tmp'");
		    }
		}

		private void LocalizeFont()
		{
			_tmProUgui.font = LocalizationManager.GetTranslation<TMP_FontAsset>(_font);
		}

		private void SetRTL()
		{
		    _tmProUgui.isRightToLeftText = true;
		    if (_allowAlignmentChange)
		    {
		        SetAlignmentRTL();
		    }
		}

	    private void SetAlignmentRTL()
	    {
	        switch (_tmProUgui.alignment)
	        {
	            case TextAlignmentOptions.Left:
	                _tmProUgui.alignment = TextAlignmentOptions.Right;
	                break;
	            case TextAlignmentOptions.TopLeft:
	                _tmProUgui.alignment = TextAlignmentOptions.TopRight;
	                break;
	            case TextAlignmentOptions.BottomLeft:
	                _tmProUgui.alignment = TextAlignmentOptions.BottomRight;
	                break;
	            case TextAlignmentOptions.BaselineLeft:
	                _tmProUgui.alignment = TextAlignmentOptions.BaselineRight;
	                break;
	            case TextAlignmentOptions.MidlineLeft:
	                _tmProUgui.alignment = TextAlignmentOptions.MidlineRight;
	                break;
	            case TextAlignmentOptions.CaplineLeft:
	                _tmProUgui.alignment = TextAlignmentOptions.CaplineRight;
	                break;
	        }
	    }

	    private void SetLTR()
		{
			_tmProUgui.isRightToLeftText = false;
		    if (_allowAlignmentChange)
		    {
		        SetAlignmentLTR();
		    }
		}

	    private void SetAlignmentLTR()
	    {
	        switch (_tmProUgui.alignment)
	        {
	            case TextAlignmentOptions.Right:
	                _tmProUgui.alignment = TextAlignmentOptions.Left;
	                break;
	            case TextAlignmentOptions.TopRight:
	                _tmProUgui.alignment = TextAlignmentOptions.TopLeft;
	                break;
	            case TextAlignmentOptions.BottomRight:
	                _tmProUgui.alignment = TextAlignmentOptions.BottomLeft;
	                break;
	            case TextAlignmentOptions.BaselineRight:
	                _tmProUgui.alignment = TextAlignmentOptions.BaselineLeft;
	                break;
	            case TextAlignmentOptions.MidlineRight:
	                _tmProUgui.alignment = TextAlignmentOptions.MidlineLeft;
	                break;
	            case TextAlignmentOptions.CaplineRight:
	                _tmProUgui.alignment = TextAlignmentOptions.CaplineLeft;
	                break;
	        }
	    }
    }
}
#endif