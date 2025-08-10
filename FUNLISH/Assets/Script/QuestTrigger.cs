using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    public QuestData questToComplete; // drag Quest_Farmer ke sini di Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            QuestManager.Instance.CompleteQuest(questToComplete);
        }
    }
}