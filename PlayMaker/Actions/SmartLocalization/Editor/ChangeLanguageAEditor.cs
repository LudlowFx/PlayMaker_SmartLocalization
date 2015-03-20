/* @LudlowFx : Addon Version 1.1.6 (18 March 2015) */

using UnityEngine;
using UnityEditor;

using SmartLocalization;
using SmartLocalization.Editor;
using HutongGames.PlayMaker.Actions;

namespace HutongGames.PlayMakerEditor
{
    [CustomActionEditor(typeof(ChangeLanguage))]
    public class ChangeLanguageAEditor : CustomActionEditor
    {
        private SmartCultureInfo[] availableCultures;
        private string[] availableCulturesPopup, availableCulturesCodename;

        public override void OnEnable()
        {
            var _allCultures = SmartCultureInfoEx.Deserialize(LocalizationWorkspace.CultureInfoCollectionFilePath());
            var _availableCultures = LanguageHandlerEditor.CheckAndSaveAvailableLanguages(_allCultures);

            availableCultures = _availableCultures.cultureInfos.ToArray();
            availableCulturesPopup = new string[availableCultures.Length];
            availableCulturesCodename = new string[availableCultures.Length];

            for (var i = 0; i < availableCultures.Length; i++)
            {
                availableCulturesPopup[i] = availableCultures[i].englishName;
                availableCulturesCodename[i] = availableCultures[i].languageCode;
            }
        }

        public override bool OnGUI()
        {
            ChangeLanguage myTarget = (ChangeLanguage)target;

            myTarget.availableCulturesCdnArray = availableCulturesCodename;
            myTarget.selectLanguageIndex = EditorGUILayout.Popup("Select Language", myTarget.selectLanguageIndex, availableCulturesPopup);


            //## Error warnings 
            if (availableCultures.Length == 0)
                EditorGUILayout.HelpBox("No language is available. Use SmartLocalization tool to create a language.", MessageType.Error);

            else if (myTarget.selectLanguageIndex > availableCultures.Length)
                EditorGUILayout.HelpBox("Watch Out ! This Action returns an index that does not exist. You must select a language.", MessageType.Error);
            //## Error warnings


            GUILayout.BeginHorizontal();

            if (GUILayout.Button("Refresh List"))
                OnEnable();

            if (GUILayout.Button("Manage languages"))
                EditorWindow.GetWindow(typeof(SmartLocalization.Editor.SmartLocalizationWindow));

            GUILayout.EndHorizontal();
            EditorGUILayout.Space();


            EditField("assignTo");
            EditField("sendEvent");

            return GUI.changed;
        }
    }
}