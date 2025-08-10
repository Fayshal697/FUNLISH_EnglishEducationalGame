using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour {
    public GameObject levelInfoPanel; // panel sebelum start
    public GameObject objectivesPanel; // container panel saat main game
    public Transform objectivesListParent;
    public GameObject objectiveItemPrefab; // kecil: text + checkbox/toggle
    public GameObject finalResultPanel;
    public TMP_Text finalText;

    void Start(){
        if(QuestManager.Instance != null){
            QuestManager.Instance.OnQuestUpdated += RefreshObjectives;
            QuestManager.Instance.OnQuestCompleted += ShowFinalResult;
        }
    }

    public void ShowLevelInfo(string title, string description){
        levelInfoPanel.SetActive(true);
        objectivesPanel.SetActive(false);
        finalResultPanel.SetActive(false);
        // set text fields di levelInfoPanel (implement di inspector)
    }

    public void StartQuestFromUI(QuestData quest){
        levelInfoPanel.SetActive(false);
        objectivesPanel.SetActive(true);
        finalResultPanel.SetActive(false);
        QuestManager.Instance.StartQuest(quest);
        RefreshObjectives();
    }

    void RefreshObjectives(){
        // clear existing
        foreach(Transform t in objectivesListParent) Destroy(t.gameObject);

        if(QuestManager.Instance?.currentQuest == null) return;

        foreach(var o in QuestManager.Instance.currentQuest.objectives){
            var go = Instantiate(objectiveItemPrefab, objectivesListParent);
            var txt = go.GetComponentInChildren<TMP_Text>();
            txt.text = o.description;
            var tog = go.GetComponentInChildren<Toggle>();
            if(tog != null) {
                tog.isOn = o.isComplete;
            }
        }
    }

    void ShowFinalResult(){
        objectivesPanel.SetActive(false);
        finalResultPanel.SetActive(true);
        finalText.text = "Selamat! Kamu menyelesaikan semua objective.";
        // bisa tambahkan skor / statistik di sini
    }
}
