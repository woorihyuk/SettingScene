using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Script.Settings
{
    public class KeySettingButton : MonoBehaviour, IPointerClickHandler
    {
        public TMP_Text slotName;
        public TMP_Text bindKeyName;
        public string setSlotName;
        public string actionName;
        public int bindingIndex;
    
        private Input _input;
    
        public InputAction inputAction;
        // Start is called before the first frame update
        void Start()
        {
            _input = new();
            slotName.text = setSlotName;
        }
        public void SetBindKeyName(string bindKeyName)
        {
            this.bindKeyName.text = bindKeyName.Substring((bindKeyName.IndexOf('/')+1));
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            SettingsManager.KeyRebind(this, _input.Player.Get()[actionName], bindingIndex);
        }
    }
}
