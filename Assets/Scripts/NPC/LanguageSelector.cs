using UnityEngine;

public class LanguageSelector : MonoBehaviour
{
    public GameObject languagePanel;       // Painel de escolha de idioma
    public GameObject dialoguePanel;       // Painel do di�logo
    public DialogueManager dialogueManager; // Refer�ncia via Inspector

    public void SelectLanguage(string languageCode)
    {
        languagePanel.SetActive(false);     // Esconde o painel de idioma
        dialoguePanel.SetActive(true);      // Ativa o painel de di�logo

        dialogueManager.InitializeDialogue(languageCode); // Inicia o di�logo com o idioma escolhido
    }
}
