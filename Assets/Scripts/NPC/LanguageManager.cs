using UnityEngine;

public static class LanguageManager
{
    public static string SelectedLanguage { get; private set; } = "";

    public static void SetLanguage(string lang)
    {
        SelectedLanguage = lang;
    }
}
