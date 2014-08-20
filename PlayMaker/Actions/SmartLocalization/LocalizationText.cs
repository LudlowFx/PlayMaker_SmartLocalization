using UnityEngine;
using SmartLocalization;

/*
 * BETA INFORMATIONS :
 * 
 * This bridge between PlayMaker and SmartLocalization is not an official package, but a personal version I try to adapt. So it is possible that many improvements are to be made.
 * 
 * This version is based on the Package of kdimas and extended to new shares by LudlowFx.
 * 
 */

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("SmartLocalization (Beta)")]
	[Tooltip("Get text value from Smart Localization plugin")]	
	public class LocalizationText : FsmStateAction
	{
		private LanguageManager languageManager;

        [RequiredField]
        [Tooltip("Key name you want to retrieve from SmartLocalization database.")]
        public FsmString localizationKeyName;

		[RequiredField]
		[UIHint(UIHint.Variable)]
        [Tooltip("Variable to which to assign the key.")]
        public FsmString assignKeyName;
		
		public override void Reset ()
		{
			assignKeyName = null;
			localizationKeyName = null;
		}

		public override void OnEnter ()
		{	
			languageManager = LanguageManager.Instance;

			GetStringValue();
		}
		
		void GetStringValue()
		{		
			assignKeyName.Value = languageManager.GetTextValue(localizationKeyName.Value);
		}
	}
}

