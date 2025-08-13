using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int totalObjects; // akan dihitung otomatis
    private int completedObjects = 0;

    public GameObject finalQuizMarker;
    public string quizSceneName = "FinalQuiz";

    private bool quizStarted = false; // proteksi double scene load

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Hitung jumlah objek interaktif di scene
        totalObjects = FindObjectsByType<InteractiveObject>(FindObjectsSortMode.None).Length;

        if (finalQuizMarker != null)
            finalQuizMarker.SetActive(false);
    }

    public void ObjectCompleted()
    {
        completedObjects++;

        if (completedObjects >= totalObjects)
        {
            Debug.Log("Semua objek sudah selesai!");
            if (finalQuizMarker != null)
                finalQuizMarker.SetActive(true);
        }
    }

    public void StartFinalQuiz()
    {
        if (quizStarted) return; // cegah double load
        quizStarted = true;

        SceneManager.LoadScene(quizSceneName);
    }
}
