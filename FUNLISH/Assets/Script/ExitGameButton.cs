using UnityEngine;
using UnityEngine.UI; // untuk akses Button

public class ExitGameButton : MonoBehaviour
{
    [Header("Assign di Inspector")]
    public Button exitButton;

    private void Start()
    {
        if (exitButton != null)
        {
            // Pasang event listener
            exitButton.onClick.AddListener(ExitGame);
        }
        else
        {
            Debug.LogError("[ExitGameButton] Exit Button belum di-assign di Inspector!");
        }
    }

    public void ExitGame()
    {
        Debug.Log("Keluar dari game...");

        // Kalau di editor Unity, hentikan play mode
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Kalau sudah build, keluar dari game
        Application.Quit();
#endif
    }
}
