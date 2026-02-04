using UnityEngine;
using UnityEngine.Events;

//  Terminal command to fetch arduino port on mac.
//  ls /dev/tty.*
//  /dev/tty.usbserial-210 - A sample port on mac.

using UnityEngine;
using UnityEngine.Events;

public class Responder_Spectra0062255 : MonoBehaviour
{
    public SerialController serialController;

    public int maxFlex;
    public float sleepDuration = 1000f; // milliseconds

    public UnityEvent<string> OnMessage;
    public UnityEvent<string> OnRawMessage;

    public UnityEvent OnToggle;             // No-arg toggle
    public UnityEvent<bool> OnToggleBool;   // Boolean toggle

    private int flex = 0;
    private float nextReadTime = 0f;
    private bool isOn = false;

    public void Update()
    {
        // Skip reading until sleep duration has passed
        if (Time.time * 1000f < nextReadTime)
            return;

        string message = serialController.ReadSerialMessage();

        if (message == null)
            return;

        Debug.Log($"Sensor Data: {message}");

        OnRawMessage?.Invoke(message);

        if (int.TryParse(message, out flex))
        {
            OnMessage?.Invoke(message);

            if (flex >= maxFlex)
            {
                // Toggle state
                isOn = !isOn;

                // Fire events
                OnToggle?.Invoke();
                OnToggleBool?.Invoke(isOn);

                // Start cooldown
                nextReadTime = (Time.time * 1000f) + sleepDuration;
            }
        }
    }
}
