using UnityEngine;
using UnityEngine.Events;

//  Terminal command to fetch arduino port on mac.
//  ls /dev/tty.*
//  /dev/tty.usbserial-210 - A sample port on mac.

public class Responder_TTP223 : MonoBehaviour
{
    public SerialController serialController;

    public UnityEvent<bool> OnMessage;


    public void Update()
    {
        string message = serialController.ReadSerialMessage();

        Debug.Log($"Sensor Data: {message}");

        if (message == null)
            return;

        float value = 0;

        if (!float.TryParse(message, out value))
        {
            value = 0;
        }

        bool isTouchOn = value > 0;

        OnMessage?.Invoke(isTouchOn);
    }

}
