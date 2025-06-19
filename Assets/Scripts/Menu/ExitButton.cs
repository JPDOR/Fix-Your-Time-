using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public GameObject webExitPanel; // Painel de saída para WebGL

    public void ExitGame()
    {
#if UNITY_WEBGL
        // Mostra um painel avisando que não é possível sair no navegador
        if (webExitPanel != null)
        {
            webExitPanel.SetActive(true);
        }
#else
        Application.Quit();
#endif
    }
}
