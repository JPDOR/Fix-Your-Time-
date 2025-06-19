using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    [SerializeField] private string menuSceneName = "Menu"; // Altere para o nome real da sua cena de menu

    public void LoadMenu()
    {
        SceneManager.LoadScene(menuSceneName);
    }
}
