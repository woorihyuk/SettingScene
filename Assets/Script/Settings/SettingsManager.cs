using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.InputSystem;


namespace Script.Settings
{
    [System.Serializable]
    public class SettingSaveData
    {
        public string keySaveValue;
        public Dictionary<string, bool> BoolSettingData;
        public List<Resolution> Resolutions;
    }

    public class SettingsManager : MonoBehaviour
    {
        public static SettingsManager Instance;

        public AudioSettingsData AudioSettingsData = new();
        public GraphicSettingsData GraphicSettingsData = new();
        public SettingSaveData settingSaveData;
        
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

        public void SetSettingSaveData()
        {
            settingSaveData.Resolutions=new List<Resolution>(Screen.resolutions);
            settingSaveData.BoolSettingData = new Dictionary<string, bool>()
            {
                {"FoolScreen", true}
            };
        }

        public void SaveSettingData()
        {
            var jsonData = JsonUtility.ToJson(settingSaveData, true);
            File.WriteAllText(Path.Combine(Application.persistentDataPath, 
                "save.json"), jsonData);
        }

        public void LoadSettingData()
        {
            if (!File.Exists(Path.Combine(Application.persistentDataPath,"save.json")))
            {
                settingSaveData = new SettingSaveData();
                return;
            }

            var jsonData = 
                File.ReadAllText(Path.Combine(Application.persistentDataPath, "save.json"));
            settingSaveData = JsonUtility.FromJson<SettingSaveData>(jsonData);
        }

        public static void KeyRebind(KeySettingButton keySettingButton, InputAction inputAction, int i)
        {
            inputAction.PerformInteractiveRebinding().WithCancelingThrough("<Keyboard>/escape").WithTargetBinding(i)
                .WithExpectedControlType("Button").OnComplete(operation =>
                {
                    keySettingButton.SetBindKeyName(inputAction.bindings[i].effectivePath);
                    operation.Dispose();
                }).Start();
        }
    }
    
}