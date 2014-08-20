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
    [Tooltip("Get system Language CodeName")]
	public class GetCodeSystemLanguage : FsmStateAction
	{
		private LanguageManager languageManager;

		[RequiredField]
		[UIHint(UIHint.Variable)]
		public FsmString assignLanguage;


		public override void Reset()
		{
            assignLanguage = null;
		}

		public override void OnEnter()
		{	
			languageManager = LanguageManager.Instance;
			
			DoGetSystemLanguage();
		}
		
		void DoGetSystemLanguage()
		{
			string langCode = languageManager.defaultLanguage;

            langCode = languageManager.GetSupportedSystemLanguageCode();

            assignLanguage.Value = langCode;
		}
	}
}

