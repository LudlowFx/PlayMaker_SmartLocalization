/* @LudlowFx : Addon Version 1.1.6 (18 March 2015) */

using UnityEngine;
using SmartLocalization;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("SmartLocalization")]
    [Tooltip("Change Current Language Used In Game")]
    public class ChangeLanguage : FsmStateAction
    {

        private FsmString languageCodename;
        public string[] availableCulturesCdnArray;
        public int selectLanguageIndex;

        [Tooltip("Local variable to use to assign the 'Codename' of loaded Language . (Optional)")]
        [UIHint(UIHint.Variable)]
        public FsmString assignTo;

        [Tooltip("(Optional)")]
        public FsmEvent sendEvent;


        public override void Reset()
        {
            languageCodename = null;
            assignTo = null;
            sendEvent = null;
        }

        public override void OnEnter()
        {
            LanguageManager langManager = LanguageManager.Instance;

            if (selectLanguageIndex > availableCulturesCdnArray.Length)
            {
                Debug.LogError("[FSM Error] ! An Action returns an index that does not exist. You must select a language.");
                Debug.Break();
            }
            else { languageCodename = availableCulturesCdnArray[selectLanguageIndex]; }

            if (languageCodename.Value != langManager.LoadedLanguage)
            {
                if (langManager.IsLanguageSupported(languageCodename.Value))
                {
                    langManager.ChangeLanguage(languageCodename.Value);
                }
            }
            assignTo.Value = langManager.LoadedLanguage;
        }

        public override void OnUpdate()
        {
            if (sendEvent != null) { Fsm.Event(sendEvent); }

            Finish();
        }

    }
}