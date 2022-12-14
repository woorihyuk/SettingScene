using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


namespace Script.Settings
{
    public class SettingsManager : MonoBehaviour
    {
        public static SettingsManager Instance;
        
        public AudioSettingsData AudioSettingsData = new();
        public GraphicSettingsData GraphicSettingsData = new();

        public static SettingsManager Instance1
        {
            get
            {
                if (Instance != null) return Instance;
                var obj = FindObjectOfType<SettingsManager>();
                if (obj != null)
                {
                    Instance = obj;
                }
                else
                {
                    var newObj = new GameObject().AddComponent<SettingsManager>();
                    Instance = newObj;
                }
                return Instance;
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
            Instance = this;
        }

        

        public void Do(InputAction inputAction, int i)
        {
            inputAction.PerformInteractiveRebinding().
                WithCancelingThrough("<Keyboard>/escape").
                WithTargetBinding(i).
                WithExpectedControlType("Button");
        }
    }
    
}