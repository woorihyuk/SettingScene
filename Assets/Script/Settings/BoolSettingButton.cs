using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Script.Settings
{
    public class BoolSettingButton : MonoBehaviour
    {
        public TMP_Text slotName;
        public TMP_Text valueName;

        public string setSlotName;
        private string _yes;
        private string _no;

        void Start()
        {
            _yes = "켜기";
            _no = "끄기";
            slotName.text = setSlotName;
            valueName.text = SettingsManager.Instance.settingSaveData.BoolSettingData[setSlotName] 
                ? _yes : _no;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            
        }
    }
}
