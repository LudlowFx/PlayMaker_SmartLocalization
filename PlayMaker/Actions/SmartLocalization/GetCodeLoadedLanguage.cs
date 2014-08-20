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
	[Tooltip("Get Loaded Language CodeName")]
    public class GetCodeLoadedLanguage : FsmStateAction
	{
		private LanguageManager languageManager;

        //public enum SmartLangTypes { CodeName, EnglishName };

		[RequiredField]
		[UIHint(UIHint.Variable)]
        public FsmString loadedLanguage;

        //[RequiredField]
        //[Tooltip("Used 'CodeName' for 'changeLanguage' action.")]
        //public SmartLangTypes nameType;

		public override void Reset()
		{
            loadedLanguage = null;
		}

		public override void OnEnter()
		{	
			languageManager = LanguageManager.Instance;

            GetLoadedLangName();
		}

        void GetLoadedLangName()
        {
            loadedLanguage.Value = languageManager.LoadedLanguage;
        }

	}
}

