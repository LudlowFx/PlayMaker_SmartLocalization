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

