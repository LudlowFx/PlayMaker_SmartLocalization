using UnityEngine;
using SmartLocalization;
using System.Collections.Generic;

/*
 * BETA INFORMATIONS :
 * 
 * This bridge between PlayMaker and SmartLocalization is not an official package, but a personal version I try to adapt. So it is possible that many improvements are to be made.
 * 
 * This version is based on the Package of kdimas and extended to new shares by LudlowFx.
 * 
 */

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

