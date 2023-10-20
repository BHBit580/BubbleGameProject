using TMPro;
using UnityEngine;

public class DisplayTime : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    private void Start()
    {
        timeText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        float currentTime = Time.timeSinceLevelLoad;
        int wholeSeconds = Mathf.FloorToInt(currentTime);
        int decimalSeconds = Mathf.FloorToInt((currentTime - wholeSeconds) * 100);

        timeText.text = $"<size=60>{wholeSeconds}</size><size=30>.{decimalSeconds}</size>";
    }
}

