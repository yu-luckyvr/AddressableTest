using UnityEngine;

namespace LuckyOS.Editor
{
    [CreateAssetMenu(menuName = "LuckyOS/PackageInstaller", fileName = "PackageInstaller")]
    public class LuckyPackageInstaller : ScriptableObject
    {
        public string originalPath;

        public void InstallLuckyPackage(string destinationPath)
        {
            Debug.Log($"Try install from category from {originalPath} to {destinationPath}");
        }
    }
}
