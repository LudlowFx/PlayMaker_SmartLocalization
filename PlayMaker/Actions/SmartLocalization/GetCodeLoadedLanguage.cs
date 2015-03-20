/* @LudlowFx : Addon Version 1.0.1 (06 March 2015) */

using UnityEngine;
using SmartLocalization;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("SmartLocalization")]
    [Tooltip("Get Loaded Language CodeName")]
    public class GetCodeLoadedLanguage : FsmStateAction
    {

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
            LanguageManager langManager = LanguageManager.Instance;

            variable.Value = langManager.LoadedLanguage;
        }

        public override void OnUpdate()
        {
            if (sendEvent != null) { Fsm.Event(sendEvent); }

            Finish();
        }

    }
}