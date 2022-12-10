using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class OptionCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MenuOn(GameObject targetMenu)
    {
        print("dfdf");
        targetMenu.SetActive(true);
        targetMenu.transform.DOScale(new Vector3(1, 1, 1), 0.2f).ChangeStartValue(new Vector3(0, 0, 0));
    }
}
