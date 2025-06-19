using UnityEngine;

public class DelayedActivator : MonoBehaviour
{
    [Tooltip("Objeto que será ativado após o tempo de espera.")]
    public GameObject targetObject;

    [Tooltip("Tempo em segundos antes de ativar o objeto.")]
    public float delayInSeconds = 5f;

    void Start()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(false); // Começa desativado
            StartCoroutine(ActivateAfterDelay());
        }
    }

    private System.Collections.IEnumerator ActivateAfterDelay()
    {
        yield return new WaitForSeconds(delayInSeconds);
        targetObject.SetActive(true);
    }
}
