using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;   // Panel UI pause
    public GameObject miniMapUI;    // UI minimap
    public GameObject objectivePanel; // UI objective

    private bool isPaused = false;

    void Start()
    {
        pausePanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        pausePanel.SetActive(true);
        miniMapUI.SetActive(false);  // sembunyikan minimap saat pause
        objectivePanel.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }

    void ResumeGame()
    {
        pausePanel.SetActive(false);
        miniMapUI.SetActive(true);   // tampilkan kembali minimap
        objectivePanel.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
    }
}
