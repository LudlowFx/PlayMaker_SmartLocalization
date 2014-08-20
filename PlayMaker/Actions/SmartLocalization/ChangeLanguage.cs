using UnityEngine;
using SmartLocalization;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("SmartLocalization (Beta)")]
    [Tooltip("Change Current Language Used In Game")]
    public class ChangeLanguage : FsmStateAction
    {
        private LanguageManager languageManager;

        [RequiredField]
        [Tooltip("Specify CodeName language to load (fr, en, es...)")]
        public FsmString languageCodeName;

        public FsmEvent finishEvent;


        public override void Reset()
        {
            languageCodeName = null;
            finishEvent = null;
        }

        public override void OnEnter()
        {
            languageManager = LanguageManager.Instance;

            if (languageCodeName.ToString() != languageManager.LoadedLanguage && languageManager.IsLanguageSupported(languageCodeName.ToString()))
            {
                languageManager.ChangeLanguage(languageCodeName.ToString());
            }
        }

        public override void OnUpdate()
        {
            Fsm.Event(finishEvent);
        }
    }
}

