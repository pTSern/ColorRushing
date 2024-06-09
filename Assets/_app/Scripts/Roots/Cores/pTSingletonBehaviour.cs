
using UnityEngine;
namespace pTS.Cores
{
    public class pTSingletonBehaviour<T> where T : pTSBehaviour
    {
        private static T _instance;
        public static T Instance
        {
            get
            {
                return _instance != null ? _instance : FindInstance();
            }
        }
        private static T FindInstance()
        {
            _instance = GameObject.FindObjectOfType<T>();
            if (_instance == null)
            {
                return null;
            }
            return _instance;
        }

    }
}
