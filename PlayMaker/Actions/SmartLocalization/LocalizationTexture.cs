/* @LudlowFx : Addon Version 1.0.1 (06 March 2015) */

using UnityEngine;
using SmartLocalization;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("SmartLocalization")]
    [Tooltip("Get Texture Reference from SmartLocalization Database")]
    public class LocalizationTexture : FsmStateAction
    {

        private LanguageManager langManager;

        [RequiredField]
        [Tooltip("Key name you want to retrieve Texture from SmartLocalization Database.")]
        public FsmString localizationKeyName;

        [RequiredField]
        [UIHint(UIHint.Variable)]
        [Tooltip("Variable to which to assign the key.")]
        public FsmTexture variable;

        public override void Reset()
        {
            variable = null;
            localizationKeyName = null;
        }

        public override void OnEnter()
        {
            langManager = LanguageManager.Instance;

            variable.Value = langManager.GetTexture(localizationKeyName.Value);

            Finish();
        }

    }
}