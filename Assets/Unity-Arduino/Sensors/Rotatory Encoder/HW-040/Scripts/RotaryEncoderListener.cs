using UnityEngine;
using TMPro;

public class RotaryEncoderListener : MonoBehaviour
{
    public TMP_Text value;

    public void SetValue(string value)
    {
        this.value.text = value;
    }
}
