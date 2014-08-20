using UnityEngine;
using SmartLocalization;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("SmartLocalization (Beta)")]
    [Tooltip("Get number of languages create and available in SmartLocalization (int)")]
    public class GetNumberOfSupportedLanguages : FsmStateAction
    {
        private LanguageManager languageManager;

        [RequiredField]
        [UIHint(UIHint.Variable)]
        [Tooltip("Get number of languages create and available in SmartLocalization")]
        public FsmInt variableNumber;

        public override void Reset()
        {
            variableNumber = null;
        }

        public override void OnEnter()
        {
            languageManager = LanguageManager.Instance;

            variableNumber.Value = languageManager.NumberOfSupportedLanguages;
        }

    }
}

