/* @LudlowFx : Addon Version 1.0.1 (06 March 2015) */

using UnityEngine;
using SmartLocalization;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("SmartLocalization")]
    [Tooltip("Return number of languages create and available in SmartLocalization")]
    public class GetNumberOfSupportedLanguages : FsmStateAction
    {

        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmInt variable;

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
            variable.Value = langManager.NumberOfSupportedLanguages;
        }

        public override void OnUpdate()
        {
            if (sendEvent != null) { Fsm.Event(sendEvent); }

            Finish();
        }

    }
}