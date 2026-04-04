// Assets/Editor/ResetPlayerPrefs.cs
using UnityEditor;
using UnityEngine;

public static class ResetPlayerPrefs
{
    // Menu: Tools > Reset PlayerPrefs > Reset UnlockedLevel
    [MenuItem("Tools/Reset PlayerPrefs/Reset UnlockedLevel")]
    public static void ResetUnlockedLevel()
    {
        bool ok = EditorUtility.DisplayDialog(
            "Reset UnlockedLevel",
            "Are you sure you want to delete the PlayerPrefs key 'UnlockedLevel'?",
            "Yes",
            "No"
        );

        if (!ok) return;

        if (PlayerPrefs.HasKey("UnlockedLevel"))
        {
            PlayerPrefs.DeleteKey("UnlockedLevel");
            PlayerPrefs.Save();
            EditorUtility.DisplayDialog("Reset UnlockedLevel", "'UnlockedLevel' has been removed.", "OK");
        }
        else
        {
            EditorUtility.DisplayDialog("Reset UnlockedLevel", "'UnlockedLevel' key was not found.", "OK");
        }
    }

    // Optional: Tools > Reset PlayerPrefs > Clear All PlayerPrefs
    [MenuItem("Tools/Reset PlayerPrefs/Clear All PlayerPrefs")]
    public static void ClearAllPlayerPrefs()
    {
        bool ok = EditorUtility.DisplayDialog(
            "Clear All PlayerPrefs",
            "Are you sure you want to delete ALL PlayerPrefs? This cannot be undone.",
            "Yes",
            "No"
        );

        if (!ok) return;

        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        EditorUtility.DisplayDialog("Clear All PlayerPrefs", "All PlayerPrefs have been cleared.", "OK");
    }
}
