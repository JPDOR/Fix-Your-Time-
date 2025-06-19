using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.InputSystem;

public class TimeSynchronizer : MonoBehaviour
{
    public DigitalClock playerClock;
    public DigitalClock serverClock;

    public GameObject syncCanvas;
    public TextMeshProUGUI t0Text, tsText, t1Text, rttText, formulaText, resultText;

    public InputAction syncAction;

    private void OnEnable()
    {
        syncAction.Enable();
        syncAction.performed += OnSyncPressed;
    }

    private void OnDisable()
    {
        syncAction.performed -= OnSyncPressed;
        syncAction.Disable();
    }

    private void OnSyncPressed(InputAction.CallbackContext context)
    {
        StartCoroutine(SynchronizeWithVisualization());
    }

    private IEnumerator SynchronizeWithVisualization()
    {
        syncCanvas.SetActive(true);

        float T0 = playerClock.GetCurrentTime();
        t0Text.text = $"T0 = {playerClock.GetFormattedTime()}";
        yield return new WaitForSeconds(1f);

        // Latência simulada com chance de congestionamento
        float latencyOut = GetLatencyWithCongestion();
        yield return new WaitForSeconds(latencyOut);

        float Ts = serverClock.GetCurrentTime();
        tsText.text = $"Ts = {serverClock.GetFormattedTime()}";
        yield return new WaitForSeconds(1f);

        float latencyIn = GetLatencyWithCongestion();
        yield return new WaitForSeconds(latencyIn);

        float T1 = playerClock.GetCurrentTime();
        t1Text.text = $"T1 = {playerClock.GetFormattedTime()}";
        yield return new WaitForSeconds(1f);

        float RTT = latencyOut + latencyIn;
        float Tajustado = Ts + (RTT / 2f);

        rttText.text = $"RTT = {RTT:F2} segundos";
        formulaText.text = $"Tajustado = {Ts:F2} + ({T1:F2} - {T0:F2}) / 2";
        yield return new WaitForSeconds(2f);

        resultText.text = $"Tajustado = {FormatSecondsAsTime(Tajustado)}";
        yield return new WaitForSeconds(2f);

        playerClock.SetTime(Tajustado);

        syncCanvas.SetActive(false);
    }

    private float GetLatencyWithCongestion()
    {
        float baseLatency = Random.Range(0.1f, 0.4f);
        bool hasCongestion = Random.value < 0.2f; // 20% de chance
        if (hasCongestion)
        {
            float congestionDelay = Random.Range(0.3f, 0.8f);
            return baseLatency + congestionDelay;
        }
        return baseLatency;
    }

    private string FormatSecondsAsTime(float timeInSeconds)
    {
        int hours = (int)(timeInSeconds / 3600) % 24;
        int minutes = (int)(timeInSeconds / 60) % 60;
        int seconds = (int)(timeInSeconds % 60);
        return string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }
}
