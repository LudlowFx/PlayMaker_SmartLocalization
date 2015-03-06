/* @LudlowFx : Addon Version 1.0.1 (06 March 2015) */

using UnityEngine;
using SmartLocalization;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("SmartLocalization")]
    [Tooltip("Change Current Language Used In Game")]
    public class ChangeCurrentLanguage : FsmStateAction
    {

        private LanguageManager langManager;

        [RequiredField]
        [Tooltip("Specify CodeName language to load. The default language will be loaded if the specified language is not supported by SmartLocalization.")]
        public FsmString languageCodename;

        [RequiredField]
        [UIHint(UIHint.Variable)]
        public FsmString assignLocally;

        [Tooltip("(Optional)")]
        public FsmEvent sendEvent;


        public override void Reset()
        {
            languageCodename = null;
            assignLocally = null;
            sendEvent = null;
        }

        public override void OnEnter()
        {
            langManager = LanguageManager.Instance;

            if (languageCodename.Value != langManager.LoadedLanguage)
            {
                if (langManager.IsLanguageSupported(languageCodename.Value))
                {
                    langManager.ChangeLanguage(languageCodename.Value);
                }
            }
            assignLocally.Value = langManager.LoadedLanguage;
        }

        public override void OnUpdate()
        {
            if (sendEvent != null) { Fsm.Event(sendEvent); }

            Finish();
        }

    }
}