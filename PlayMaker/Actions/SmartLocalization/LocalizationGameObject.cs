/* @LudlowFx : Addon Version 1.0.1 (06 March 2015) */

using UnityEngine;
using SmartLocalization;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("SmartLocalization")]
    [Tooltip("Get GameObject Reference from SmartLocalization Database")]
    public class LocalizationGameObject : FsmStateAction
    {

        [RequiredField]
        [Tooltip("Key name you want to retrieve GameObject from SmartLocalization Database.")]
        public FsmString localizationKeyName;

        [RequiredField]
        [UIHint(UIHint.Variable)]
        [Tooltip("Variable to which to assign the key.")]
        public FsmGameObject variable;


        public override void Reset()
        {
            localizationKeyName = null;
            variable = null;
        }

        public override void OnEnter()
        {
            LanguageManager langManager = LanguageManager.Instance;

            variable.Value = langManager.GetPrefab(localizationKeyName.Value);

            Finish();
        }

    }
}