using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Script
{
    public class OptionCtrl : MonoBehaviour
    {
        public static OptionCtrl instance;
    
        public GameObject optionMenu;

        private bool _isOptionOpen;
    
        public static OptionCtrl Instance
        {
            get
            {
                if (instance == null)
                {
                    var obj = FindObjectOfType<OptionCtrl>();
                    if (obj != null)
                    {
                        instance = obj;
                    }
                    else
                    {
                        var newObj = new GameObject().AddComponent<OptionCtrl>();
                        instance = newObj;
                    }
                }
                return instance;
            }
        }
    
        private void Awake()
        {
            var objs = FindObjectsOfType<OptionCtrl>();
            if (objs.Length != 1)
            {
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject);
            instance = this;

        }
    
        // Start is called before the first frame update
        void Start()
        {
            //Instantiate(optionMenu).SetActive(false);
        
        }

        // Update is called once per frame
        void Update()
        {
            if (Keyboard.current.escapeKey.wasPressedThisFrame)
            {
                if (optionMenu.activeSelf)
                {
                    optionMenu.SetActive(false);
                }
                else
                {
                    optionMenu.SetActive(true);
                }
            }
        }

        public void MenuOn(GameObject targetMenu)
        {
            if (targetMenu.activeSelf)
            {
                targetMenu.transform.DOScale(new Vector3(0, 0, 0), 0.1f).OnComplete(() =>
                {
                    targetMenu.SetActive(false);
                });
            }
            else
            {
                targetMenu.SetActive(true);
                targetMenu.transform.DOScale(new Vector3(1, 1, 1), 0.1f).ChangeStartValue(new Vector3(0, 0, 0));
            }
        }
    }
}
