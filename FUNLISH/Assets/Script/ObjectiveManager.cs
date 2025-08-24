using UnityEngine;
using TMPro;

public class ObjectiveManager : MonoBehaviour
{
    public static ObjectiveManager Instance; // singleton biar gampang akses

    [Header("UI Objective References")]
    public TextMeshProUGUI[] objectiveTexts; // assign di inspector
    public TextMeshProUGUI completeText;

    private bool[] objectivesCompleted;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        objectivesCompleted = new bool[objectiveTexts.Length];
        completeText.text = "";
    }

    public void CompleteObjective(int index)
    {
        if (index < 0 || index >= objectivesCompleted.Length) return;

        // tandai selesai
        objectivesCompleted[index] = true;
        objectiveTexts[index].text = "[✔] " + objectiveTexts[index].text.Substring(4); 
        objectiveTexts[index].color = Color.green;

        // cek kalau semua sudah selesai
        if (AllObjectivesCompleted())
        {
            completeText.text = "✅ Semua objektif selesai!\nPergilah ke lokasi untuk memulai Quiz Akhir.";
            completeText.color = Color.yellow;
        }
    }

    public bool AllObjectivesCompleted()
    {
        foreach (bool done in objectivesCompleted)
        {
            if (!done) return false;
        }
        return true;
    }
}
