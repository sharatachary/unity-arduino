using UnityEngine;

public class TouchSensorListener : MonoBehaviour
{
    public GameObject yesGO, noGO;

    public void SensorFeedback(bool isTouchOn)
    {
        yesGO.SetActive(isTouchOn);
        noGO.SetActive(!isTouchOn);
    }
}
