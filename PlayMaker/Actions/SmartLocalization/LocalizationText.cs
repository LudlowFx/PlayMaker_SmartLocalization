/* @LudlowFx : Addon Version 1.0.1 (06 March 2015) */

using UnityEngine;
using SmartLocalization;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("SmartLocalization")]
    [Tooltip("Get Text Reference value from SmartLocalization Database")]
    public class LocalizationText : FsmStateAction
    {

        [RequiredField]
        [Tooltip("Key name you want to retrieve Text (String) from SmartLocalization Database.")]
        public FsmString localizationKeyName;

        [RequiredField]
        [UIHint(UIHint.Variable)]
        [Tooltip("Variable to which to assign the key.")]
        public FsmString variable;


        public override void Reset()
        {
            localizationKeyName = null;
            variable = null;
        }

        public override void OnEnter()
        {
            LanguageManager langManager = LanguageManager.Instance;
            string tfK = langManager.GetTextValue(localizationKeyName.Value);

            variable.Value = (tfK != null ? tfK : "[" + localizationKeyName.Value + "_Not Found]");

            Finish();
        }

    }
}