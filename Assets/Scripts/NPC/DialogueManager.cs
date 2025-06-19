using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;

    [TextArea(3, 10)]
    public string[] portugueseLines;

    [TextArea(3, 10)]
    public string[] englishLines;

    public string nextSceneName = "Maingame";

    public InputAction advanceAction;

    private string[] currentLines;
    private int currentIndex = 0;

    private bool dialogueStarted = false;

    void OnEnable()
    {
        advanceAction.Enable();
        advanceAction.performed += OnAdvancePressed;
    }

    void OnDisable()
    {
        advanceAction.performed -= OnAdvancePressed;
        advanceAction.Disable();
    }

    public void InitializeDialogue(string languageCode)
    {
        LanguageManager.SetLanguage(languageCode);

        currentLines = (languageCode == "en") ? englishLines : portugueseLines;
        currentIndex = 0;
        dialogueStarted = true;
        ShowLine();
    }

    void OnAdvancePressed(InputAction.CallbackContext context)
    {
        if (dialogueStarted)
        {
            NextLine();
        }
    }

    void ShowLine()
    {
        if (currentIndex < currentLines.Length)
        {
            dialogueText.text = currentLines[currentIndex];
        }
    }

    void NextLine()
    {
        currentIndex++;

        if (currentIndex < currentLines.Length)
        {
            ShowLine();
        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
