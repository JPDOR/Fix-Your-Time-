using UnityEngine;

public class LanguageSelector : MonoBehaviour
{
    public GameObject languagePanel;       // Painel de escolha de idioma
    public GameObject dialoguePanel;       // Painel do diálogo
    public DialogueManager dialogueManager; // Referência via Inspector

    public void SelectLanguage(string languageCode)
    {
        languagePanel.SetActive(false);     // Esconde o painel de idioma
        dialoguePanel.SetActive(true);      // Ativa o painel de diálogo

        dialogueManager.InitializeDialogue(languageCode); // Inicia o diálogo com o idioma escolhido
    }
}
