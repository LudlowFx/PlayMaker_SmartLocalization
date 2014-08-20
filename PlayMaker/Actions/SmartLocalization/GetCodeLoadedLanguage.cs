using UnityEngine;
using SmartLocalization;

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

