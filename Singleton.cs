namespace Dreamteck
{
    using System.Linq;
    using UnityEngine;

    public class Singleton<T> : PrivateSingleton<T> where T : Component
    {
        public static T instance
        {
            get
            {
                if (_instance == null)
                {
#if UNITY_6000_0_OR_NEWER
                    _instance = Object.FindObjectsByType<T>(FindObjectsSortMode.None).FirstOrDefault();
#else
                    _instance = Object.FindObjectsOfType<T>().FirstOrDefault();
#endif
                }

                return _instance;
            }
        }
    }
}
