using UnityEngine;
using UnityEngine.UI;

public class FrameSequencer : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Image targetImage;   // Child Image component

    [Header("Frames")]
    [SerializeField] private Sprite[] frames;

    private int currentIndex = 0;

    private void Awake()
    {
        // Optional safety check
        if (targetImage == null)
            targetImage = GetComponentInChildren<Image>();

        if (frames != null && frames.Length > 0)
            targetImage.sprite = frames[currentIndex];
    }

    public void ShowNextFrame()
    {
        if (frames == null || frames.Length == 0) return;

        currentIndex = (currentIndex + 1) % frames.Length;
        targetImage.sprite = frames[currentIndex];
    }

    public void ShowPrevFrame()
    {
        if (frames == null || frames.Length == 0) return;

        currentIndex--;
        if (currentIndex < 0)
            currentIndex = frames.Length - 1;

        targetImage.sprite = frames[currentIndex];
    }
}
