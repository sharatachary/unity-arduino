using UnityEngine;
using UnityEngine.Events;

//  Terminal command to fetch arduino port on mac.
//  ls /dev/tty.*
//  /dev/tty.usbserial-210 - A sample port on mac.

using UnityEngine;
using UnityEngine.Events;

public class Responder_HW505 : MonoBehaviour
{
    public SerialController serialController;

    public UnityEvent<string> OnMessage;
    public UnityEvent<string> OnRawMessage;

    public UnityEvent OnToggle;             // No-arg toggle
    public UnityEvent<bool> OnToggleBool;   // Boolean toggle

    private bool isOn = false;
    private int val = -1;

    public void Update()
    {
        string message = serialController.ReadSerialMessage();

        if (message == null)
            return;

        Debug.Log($"Sensor Data: {message}");

        OnRawMessage?.Invoke(message);
        OnMessage?.Invoke(message);

        if (int.TryParse(message, out val))
        {
            OnMessage?.Invoke(message);

            isOn = val == 1;
            OnToggle?.Invoke();
            OnToggleBool?.Invoke(isOn);
        }
    }
}
