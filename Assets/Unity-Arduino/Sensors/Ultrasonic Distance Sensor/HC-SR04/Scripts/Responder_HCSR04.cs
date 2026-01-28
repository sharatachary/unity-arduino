using UnityEngine;
using UnityEngine.Events;

public class Responder_HCSR04 : MonoBehaviour
{
    //  Terminal command to fetch arduino port on mac
    //  ls /dev/tty.*


    public SerialController serialController;

    public UnityEvent<float> OnMessage;


    public void Update()
    {
        string message = serialController.ReadSerialMessage();

        Debug.Log($"Sensor Data: {message}");

        if (message == null)
            return;

        float distance;

        if (!float.TryParse(message, out distance))
        {
            distance = 0;
        }

        float distanceMax = 50;
        distance = Mathf.Clamp(distance, 0, distanceMax);
        float percent = distance / distanceMax;

        OnMessage?.Invoke(percent);
    }

}
