namespace Dreamteck.Editor
{
    using UnityEngine;
    using UnityEditor;

    public static class ScriptingDefineUtility 
    {
        public static void Add(string define, BuildTargetGroup target, bool log = false)
        {
#if UNITY_6000_0_OR_NEWER
            string definesString = PlayerSettings.GetScriptingDefineSymbols(NamedBuildTarget.FromBuildTargetGroup(target));
#else
            string definesString = PlayerSettings.GetScriptingDefineSymbolsForGroup(target);
#endif
            if (definesString.Contains(define)) return;
            string[] allDefines = definesString.Split(';');
            ArrayUtility.Add(ref allDefines, define);
            definesString = string.Join(";", allDefines);
#if UNITY_6000_0_OR_NEWER
            PlayerSettings.SetScriptingDefineSymbols(NamedBuildTarget.FromBuildTargetGroup(target), definesString);
#else
            PlayerSettings.SetScriptingDefineSymbolsForGroup(target, definesString);
#endif
            Debug.Log("Added \"" + define + "\" from " + EditorUserBuildSettings.selectedBuildTargetGroup + " Scripting define in Player Settings");
        }

        public static void Remove(string define, BuildTargetGroup target, bool log = false)
        {
#if UNITY_6000_0_OR_NEWER
            string definesString = PlayerSettings.GetScriptingDefineSymbols(NamedBuildTarget.FromBuildTargetGroup(target));
#else
            string definesString = PlayerSettings.GetScriptingDefineSymbolsForGroup(target);
#endif
            if (!definesString.Contains(define)) return;
            string[] allDefines = definesString.Split(';');
            ArrayUtility.Remove(ref allDefines, define);
            definesString = string.Join(";", allDefines);
#if UNITY_6000_0_OR_NEWER
            PlayerSettings.SetScriptingDefineSymbols(NamedBuildTarget.FromBuildTargetGroup(target), definesString);
#else
            PlayerSettings.SetScriptingDefineSymbolsForGroup(target, definesString);
#endif
            Debug.Log("Removed \""+ define + "\" from " + EditorUserBuildSettings.selectedBuildTargetGroup + " Scripting define in Player Settings");
        }
    }
}
