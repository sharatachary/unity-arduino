using UnityEngine;
using UnityEngine.Events;

//  Terminal command to fetch arduino port on mac.
//  ls /dev/tty.*
//  /dev/tty.usbserial-210 - A sample port on mac.

public class Responder_HW040 : MonoBehaviour
{
    public SerialController serialController;

    public UnityEvent<string> OnMessage;
    public UnityEvent<string> OnRawMessage;
    public UnityEvent OnPrev;
    public UnityEvent OnNext;


    public void Update()
    {
        string message = serialController.ReadSerialMessage();

        Debug.Log($"Sensor Data: {message}");

        if (message == null)
            return;

        OnRawMessage?.Invoke(message);

        string[] values = message.Split("|");

        OnMessage?.Invoke(values[0]);

        int dir = 0;

        if (!int.TryParse(values[0], out dir))
        {
            dir = 0;
        }

        if (dir > 0)
        {
            OnNext?.Invoke();
        }
        else if (dir < 0)
        {
            OnPrev?.Invoke();
        }
    }

}
