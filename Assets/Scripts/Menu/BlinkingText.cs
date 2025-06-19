using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class BlinkingText : MonoBehaviour
{
    public float speed = 2f;        // Velocidade da oscilação
    public float minAlpha = 0.2f;   // Opacidade mínima
    public float maxAlpha = 1f;     // Opacidade máxima

    private TextMeshProUGUI textMesh;
    private Color originalColor;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        originalColor = textMesh.color;
    }

    void Update()
    {
        float alpha = Mathf.Lerp(minAlpha, maxAlpha, Mathf.PingPong(Time.time * speed, 1));
        Color newColor = originalColor;
        newColor.a = alpha;
        textMesh.color = newColor;
    }
}
