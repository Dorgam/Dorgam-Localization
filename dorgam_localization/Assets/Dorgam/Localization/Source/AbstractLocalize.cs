using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dorgam.Localization 
{
	public abstract class AbstractLocalize : MonoBehaviour 
	{
		[SerializeField] protected string term;
		protected abstract void Localize();
		private void OnEnable()
		{
			LocalizationManager.OnLocalization += Localize;
		}

		private void Start()
		{
			Localize();
		}

		private void OnDisable()
		{
			LocalizationManager.OnLocalization -= Localize;
		}

		public void SetTerm(string term)
		{
			this.term = term;
			Localize();
		}
	}
}
