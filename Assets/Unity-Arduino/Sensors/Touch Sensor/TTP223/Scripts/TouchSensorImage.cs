using UnityEngine;
using UnityEngine.UI;

public class TouchSensorImage : MonoBehaviour
{
    public Image sensorImage;
    public float fill;
    public float fillStep = 0.1f;
    public bool lastTouchState = false;

    private void Awake()
    {
        fill = 0;
        UpdateFill();
    }

    void UpdateFill()
    {
        sensorImage.fillAmount = fill;
    }

    public void SensorFeedback(bool isTouchOn)
    {
        if (lastTouchState != isTouchOn)
        {
            lastTouchState = isTouchOn;
            if (lastTouchState)
            {
                fill += fillStep;
                fill = Mathf.Clamp(fill, 0f, 1f);
                UpdateFill();
            }
        }
    }
}
