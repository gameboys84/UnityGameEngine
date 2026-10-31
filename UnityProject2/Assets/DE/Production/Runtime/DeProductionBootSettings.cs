using UnityEngine;

namespace DE.Production.Runtime
{
    [CreateAssetMenu(menuName = "DE/Production Boot Settings")]
    public sealed class DeProductionBootSettings : ScriptableObject
    {
        public string resourcePackage = "DefaultPackage";
        public string versionKey;
        public string clientVersion = "0.69.0";
        public string language = "cn";
        public string dedicatedDevicePreferenceKey = "DE.Production.DevelopmentDeviceId.v1";
        public string ResolveVersionKey()
        {
            if (!string.IsNullOrWhiteSpace(versionKey)) return versionKey;
#if UNITY_ANDROID
            return "ANDROID_6900";
#else
            return "IOS_6900";
#endif
        }
    }
}
