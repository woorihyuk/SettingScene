using System.Collections;
using System.Collections.Generic;
using Script.Settings;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Serialization;

public class Button : MonoBehaviour, IPointerClickHandler
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
    public void KeyBind(string name)
    {
        bindKeyName.text = name.Substring((name.IndexOf('/')+1));
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SettingsManager.Instance.Do(this, _input.Player.Get()[actionName], bindingIndex);
    }
}
