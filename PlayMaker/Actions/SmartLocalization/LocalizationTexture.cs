using UnityEngine;
using SmartLocalization;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("SmartLocalization (Beta)")]
    [Tooltip("Get texture from Smart Localization plugin")]
    public class LocalizationTexture : FsmStateAction
    {
        private LanguageManager languageManager;

        [RequiredField]
        [Tooltip("Key name you want to retrieve from SmartLocalization database.")]
        public FsmString localizationKeyName;

        [RequiredField]
        [UIHint(UIHint.Variable)]
        [Tooltip("Variable to which to assign the key.")]
        public FsmTexture assignKeyName;

        public override void Reset()
        {
            assignKeyName = null;
            localizationKeyName = null;
        }

        public override void OnEnter()
        {
            languageManager = LanguageManager.Instance;

            GetTextureValue();
        }

        void GetTextureValue()
        {
            assignKeyName.Value = languageManager.GetTexture(localizationKeyName.Value);
        }
    }
}

