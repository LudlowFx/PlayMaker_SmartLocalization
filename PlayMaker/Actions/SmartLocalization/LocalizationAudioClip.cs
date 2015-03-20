/* @LudlowFx : Addon Version 1.0.1 (06 March 2015) */

using UnityEngine;
using SmartLocalization;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("SmartLocalization")]
    [Tooltip("Get AudioClip (Object) Reference from SmartLocalization Database")]
    public class LocalizationAudioClip : FsmStateAction
    {

        [RequiredField]
        [Tooltip("Key name you want to retrieve AudioClip from SmartLocalization Database.")]
        public FsmString localizationKeyName;

        [RequiredField]
        [UIHint(UIHint.Variable)]
        [Tooltip("Variable to which to assign the key.")]
        public FsmObject variable;


        public override void Reset()
        {
            localizationKeyName = null;
            variable = null;
        }

        public override void OnEnter()
        {
            LanguageManager langManager = LanguageManager.Instance;

            variable.Value = langManager.GetAudioClip(localizationKeyName.Value);

            Finish();
        }

    }
}