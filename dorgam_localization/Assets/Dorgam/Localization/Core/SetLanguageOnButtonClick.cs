using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dorgam.Localization.Core
{
	public class SetLanguageOnButtonClick : MonoBehaviour 
	{
		[SerializeField] private SystemLanguage _targetLanguage;
		private Button _button;
		private void Start() 
		{
			GetComponent<Button>().onClick.AddListener(delegate 
			{
				LocalizationManager.SetLanguage(_targetLanguage);
			});
		}
	}
}