using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quests/Quest Data")]
public class QuestData : ScriptableObject
{
    public string questID;
    public bool isAccepted;
    public bool isCompleted;
}
