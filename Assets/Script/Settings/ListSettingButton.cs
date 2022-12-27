using TMPro;
using UnityEngine;

namespace Script.Settings
{
    public class ListSettingButton : MonoBehaviour
    {
        public string slotText;
        public TMP_Text slotName;
        public TMP_Text valueName;

        private void Awake()
        {
            slotName.text = slotText;
        }

        public void ValueChange(int i)
        {
            var tuple = SettingsManager.Instance.settingSaveData.ListSettingData[slotText];
            tuple.Item1 += i;
            if (tuple.Item1 < 0)
            {
                tuple.Item1 = 4;
            }

            if (tuple.Item1 > 4)
            {
                tuple.Item1 = 0;
            }

            var valueTuple = tuple.Item1;
            SettingsManager.Instance.settingSaveData.ListSettingData[slotText] = tuple;
            valueName.text = tuple.Item2[valueTuple];
        }
    }
}