using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public GameObject webExitPanel; // Painel de sa�da para WebGL

    public void ExitGame()
    {
#if UNITY_WEBGL
        // Mostra um painel avisando que n�o � poss�vel sair no navegador
        if (webExitPanel != null)
        {
            webExitPanel.SetActive(true);
        }
#else
        Application.Quit();
#endif
    }
}
