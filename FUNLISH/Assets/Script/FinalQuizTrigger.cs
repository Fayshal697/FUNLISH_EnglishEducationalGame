using UnityEngine;

public class FinalQuizTrigger : MonoBehaviour
{
    private bool triggered = false; // supaya tidak double trigger

    private void OnTriggerEnter(Collider other)
    {
        if (!triggered && other.CompareTag("Player"))
        {
            triggered = true;
            GameManager.Instance.StartFinalQuiz();
        }
    }
}
