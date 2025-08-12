using UnityEngine;
using UnityEngine.SceneManagement; // perlu kalau mau load scene

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int totalObjects = 3;  // jumlah total objek interaktif
    private int completedObjects = 0;

    public GameObject finalQuizMarker; // marker/titik tujuan final quiz
    public string quizSceneName = "FinalQuiz"; // nama scene quiz

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

    // Method untuk memulai quiz
    public void StartFinalQuiz()
    {
        SceneManager.LoadScene(quizSceneName);
    }
}
