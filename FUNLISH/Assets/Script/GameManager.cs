using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int totalObjects = 3;  
    private int completedObjects = 0;

    public GameObject finalQuizMarker; // marker tujuan final quiz
    public string quizSceneName = "FinalQuiz_Level3"; // nama scene quiz

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
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
            Debug.Log("Semua objektif selesai! Marker muncul.");
            if (finalQuizMarker != null)
                finalQuizMarker.SetActive(true);
        }
    }

    public void GoToQuiz()
    {
        SceneManager.LoadScene(quizSceneName);
    }
}
