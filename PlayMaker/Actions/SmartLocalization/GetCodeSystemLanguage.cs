using UnityEngine;
using SmartLocalization;

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

