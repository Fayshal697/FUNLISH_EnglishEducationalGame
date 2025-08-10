using UnityEngine;
using System.Collections.Generic;
using DialogueEditor; // Pastikan ini sesuai namespace Dialogue Editor kamu

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;

    // Pakai QuestData sebagai struktur data
    private Dictionary<string, DialogueQuestData> quests = new Dictionary<string, DialogueQuestData>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeQuests();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeQuests()
    {
        quests.Add("questFather", new DialogueQuestData("questFather"));
        quests.Add("questFarmer", new DialogueQuestData("questFarmer"));
        quests.Add("questUncle", new DialogueQuestData("questUncle"));
    }

    // === VERSI PARAMETER STRING ===
    public void StartQuest(string questID)
    {
        if (quests.ContainsKey(questID))
        {
            quests[questID].isAccepted = true;
            Debug.Log($"Quest {questID} started!");
            ConversationManager.Instance.SetBool($"{questID}_Accepted", true);
        }
    }

    public void CompleteQuest(string questID)
    {
        if (quests.ContainsKey(questID))
        {
            quests[questID].isCompleted = true;
            Debug.Log($"Quest {questID} completed!");
            ConversationManager.Instance.SetBool($"{questID}_Completed", true);
        }
    }

    // === VERSI PARAMETER QUESTDATA ===
    public void StartQuest(QuestData questData)
    {
        if (questData == null) return;
        StartQuest(questData.questID); // panggil versi string
    }

    public void CompleteQuest(QuestData questData)
    {
        if (questData == null) return;
        CompleteQuest(questData.questID); // panggil versi string
    }

    public bool IsQuestCompleted(string questID)
    {
        return quests.ContainsKey(questID) && quests[questID].isCompleted;
    }

    public bool IsQuestAccepted(string questID)
    {
        return quests.ContainsKey(questID) && quests[questID].isAccepted;
    }
}

[System.Serializable]
public class DialogueQuestData
{
    public string questID;
    public bool isAccepted;
    public bool isCompleted;

    public DialogueQuestData(string id)
    {
        questID = id;
        isAccepted = false;
        isCompleted = false;
    }
}
