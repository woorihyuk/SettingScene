using System.Collections;
using System.Collections.Generic;
using Script.Settings;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class Button : MonoBehaviour, IPointerClickHandler
{
    public string name;
    public int bindingIndex;
    
    private Input _input;
    
    public InputAction inputAction;
    // Start is called before the first frame update
    void Start()
    {
        _input = new();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SettingsManager.Instance.Do(_input.Player.Get()[name], bindingIndex);
    }
}
