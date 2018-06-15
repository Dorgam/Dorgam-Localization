using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dorgam.Localization
{
	public class SetLanguageOnButtonClick : MonoBehaviour 
	{
		[SerializeField] private SystemLanguage TargetLanguage;
		private Button button;
		private void Start() 
		{
			GetComponent<Button>().onClick.AddListener(delegate 
			{
				LocalizationManager.SetLanguage(TargetLanguage);
			});
		}
	}
}