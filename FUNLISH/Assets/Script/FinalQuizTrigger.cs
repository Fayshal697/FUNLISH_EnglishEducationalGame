using UnityEngine;

public class FinalQuizTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.StartFinalQuiz();
        }
    }
}
