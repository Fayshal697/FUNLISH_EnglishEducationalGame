using UnityEngine;

public class FinalQuizTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Menuju Final Quiz...");
            GameManager.Instance.GoToQuiz();
        }
    }
}
