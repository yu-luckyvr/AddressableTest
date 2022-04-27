using UnityEditor;
using UnityEngine;

namespace LuckyOS.Editor
{

    [CustomEditor(typeof(LuckyPackageInstaller))]
    public class LuckyPackageInstallerEditor : UnityEditor.Editor
    {
        private LuckyPackageInstaller comp;

        private void OnEnable()
        {
            comp = (LuckyPackageInstaller) target;
        }

        public override void OnInspectorGUI()
        {
            comp.originalPath = EditorGUILayout.TextField("AssetBundle Path", comp.originalPath);
            string currentPath = AssetDatabase.GetAssetPath(comp);
            EditorGUILayout.TextField("Current Path", currentPath);

            if (GUILayout.Button("Install Package"))
            {
                comp.InstallLuckyPackage(currentPath);
            }
        }
    }
}
