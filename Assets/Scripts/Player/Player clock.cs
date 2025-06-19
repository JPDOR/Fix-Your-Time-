using UnityEngine;
using TMPro;

public class DigitalClock : MonoBehaviour
{
    public TextMeshProUGUI clockText;

    [Header("Manual Offset (ignored if Randomize is enabled)")]
    public int offsetHours = 0;
    public int offsetMinutes = 0;
    public int offsetSeconds = 0;

    [Header("Random Offset Settings")]
    public bool useRandomOffset = false;
    public int minRandomHour = 0;
    public int maxRandomHour = 23;
    public int minRandomMinute = 0;
    public int maxRandomMinute = 59;
    public int minRandomSecond = 0;
    public int maxRandomSecond = 59;

    public bool isRunning = true;

    private float internalTime = 0f;

    void Start()
    {
        float totalOffset;

        if (useRandomOffset)
        {
            int randHours = Random.Range(minRandomHour, maxRandomHour + 1);
            int randMinutes = Random.Range(minRandomMinute, maxRandomMinute + 1);
            int randSeconds = Random.Range(minRandomSecond, maxRandomSecond + 1);
            totalOffset = randHours * 3600 + randMinutes * 60 + randSeconds;
        }
        else
        {
            totalOffset = offsetHours * 3600 + offsetMinutes * 60 + offsetSeconds;
        }

        internalTime = Time.time + totalOffset;
    }

    void Update()
    {
        if (!isRunning) return;

        internalTime += Time.deltaTime;

        int hours = (int)(internalTime / 3600) % 24;
        int minutes = (int)(internalTime / 60) % 60;
        int seconds = (int)(internalTime % 60);

        clockText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }

    public void SetTime(float newTime)
    {
        internalTime = newTime;
    }

    public float GetCurrentTime()
    {
        return internalTime;
    }

    public string GetFormattedTime()
    {
        int hours = (int)(internalTime / 3600) % 24;
        int minutes = (int)(internalTime / 60) % 60;
        int seconds = (int)(internalTime % 60);

        return string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }

    public void PauseClock()
    {
        isRunning = false;
    }

    public void ResumeClock()
    {
        isRunning = true;
    }
}
