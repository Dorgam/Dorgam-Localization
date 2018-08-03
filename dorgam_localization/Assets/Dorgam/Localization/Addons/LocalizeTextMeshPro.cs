#if TextMeshPro
using System;
using Dorgam.Localization.Core;
using UnityEngine;
using TMPro;
using Debug = UnityEngine.Debug;

namespace Dorgam.Localization.Addons
{
    public class LocalizeTextMeshPro : AbstractLocalize
    {
        [SerializeField] private string _font;
        [SerializeField] private bool _allowAlignmentChange = true;

        private TextMeshPro _tmPro;

        private void Awake()
        {
            _tmPro = GetComponent<TextMeshPro>();
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
                _tmPro.SetText(translation);
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
            TMP_FontAsset defaultFont = LocalizationManager.GetTranslation<TMP_FontAsset>("default_tmp");
            if (defaultFont != null)
            {
                _tmPro.font = defaultFont;
            }
            else
            {
                Debug.LogWarning("Default TextMeshPro Font is not assigned. Please create term: 'default_tmp'");
            }
        }

        private void LocalizeFont()
        {
            _tmPro.font = LocalizationManager.GetTranslation<TMP_FontAsset>(_font);
        }

        private void SetRTL()
        {
            _tmPro.isRightToLeftText = true;
            SetAlignmentRTL();
        }

        private void SetAlignmentRTL()
        {
            switch (_tmPro.alignment)
            {
                case TextAlignmentOptions.Left:
                    _tmPro.alignment = TextAlignmentOptions.Right;
                    break;
                case TextAlignmentOptions.TopLeft:
                    _tmPro.alignment = TextAlignmentOptions.TopRight;
                    break;
                case TextAlignmentOptions.BottomLeft:
                    _tmPro.alignment = TextAlignmentOptions.BottomRight;
                    break;
                case TextAlignmentOptions.BaselineLeft:
                    _tmPro.alignment = TextAlignmentOptions.BaselineRight;
                    break;
                case TextAlignmentOptions.MidlineLeft:
                    _tmPro.alignment = TextAlignmentOptions.MidlineRight;
                    break;
                case TextAlignmentOptions.CaplineLeft:
                    _tmPro.alignment = TextAlignmentOptions.CaplineRight;
                    break;
            }
        }

        private void SetLTR()
        {
            _tmPro.isRightToLeftText = false;
            SetAlignmentLTR();
        }

        private void SetAlignmentLTR()
        {
            switch (_tmPro.alignment)
            {
                case TextAlignmentOptions.Right:
                    _tmPro.alignment = TextAlignmentOptions.Left;
                    break;
                case TextAlignmentOptions.TopRight:
                    _tmPro.alignment = TextAlignmentOptions.TopLeft;
                    break;
                case TextAlignmentOptions.BottomRight:
                    _tmPro.alignment = TextAlignmentOptions.BottomLeft;
                    break;
                case TextAlignmentOptions.BaselineRight:
                    _tmPro.alignment = TextAlignmentOptions.BaselineLeft;
                    break;
                case TextAlignmentOptions.MidlineRight:
                    _tmPro.alignment = TextAlignmentOptions.MidlineLeft;
                    break;
                case TextAlignmentOptions.CaplineRight:
                    _tmPro.alignment = TextAlignmentOptions.CaplineLeft;
                    break;
            }
        }
    }
}
#endif