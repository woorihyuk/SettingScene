using System.Collections.Generic;
using UnityEngine;

namespace Script.Settings
{
    public class SettingsManager : MonoBehaviour
    {
        public static SettingsManager instance;

        public static SettingsManager Instance
        {
            get
            {
                if (instance != null) return instance;
                var obj = FindObjectOfType<SettingsManager>();
                if (obj != null)
                {
                    instance = obj;
                }
                else
                {
                    var newObj = new GameObject().AddComponent<SettingsManager>();
                    instance = newObj;
                }
                return instance;
            }
        }
    
        private void Awake()
        {
            var objs = FindObjectsOfType<SettingsManager>();
            if (objs.Length != 1)
            {
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        public AudioSettingsData audioSettingsData = new();

        public void Do()
        {
            
        }
    }
}