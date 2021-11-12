using UnityEngine;

namespace FenzyRide3D.Scripts.Input
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    _instance = obj.AddComponent<T>();
                    obj.name = typeof(T).ToString();
                }

                return _instance;
            }
            set
            {
                if (_instance == null)
                    _instance = value;
            }
        }
    }
}