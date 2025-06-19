using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    // Nome da cena para carregar
    public string sceneToLoad = "IntroScene"; // Altere conforme o nome da pr�xima cena

    public void PlayGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
