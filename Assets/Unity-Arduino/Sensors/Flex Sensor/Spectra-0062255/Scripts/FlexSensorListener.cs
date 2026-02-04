using UnityEngine;
using TMPro;

public class FlexSensorListener : MonoBehaviour
{
    public TMP_Text value;

    public void SetValue(string value)
    {
        this.value.text = value;
    }
}
