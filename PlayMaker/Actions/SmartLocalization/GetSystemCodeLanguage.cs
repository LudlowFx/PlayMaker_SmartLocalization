/* @LudlowFx : Addon Version 1.0.1 (06 March 2015) */

using UnityEngine;
using SmartLocalization;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("SmartLocalization")]
    [Tooltip("Get system Language CodeName. If it is not managed by SmartLocalization, the default language will be loaded.")]
    public class GetSystemCodeLanguage : FsmStateAction
    {

        private LanguageManager langManager;

        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmString variable;

        [Tooltip("(Optional)")]
        public FsmEvent sendEvent;


        public override void Reset()
        {
            variable = null;
            sendEvent = null;
        }

        public override void OnEnter()
        {
            langManager = LanguageManager.Instance;
            string langCode = langManager.GetSupportedSystemLanguageCode();

            variable.Value = langCode != null ? langCode : langManager.defaultLanguage;
        }

        public override void OnUpdate()
        {
            if (sendEvent != null) { Fsm.Event(sendEvent); }

            Finish();
        }

    }
}