using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class ObjectiveManager : MonoBehaviour
{
    public List<Objective> objectives;   // daftar objektif
    public TextMeshProUGUI objectivesText;          // UI untuk menampilkan objektif

    void UpdateUI()
    {
        objectivesText.text = "";
        bool allCompleted = true;

        foreach (Objective obj in objectives)
        {
            if (obj.isCompleted)
                objectivesText.text += "✔ " + obj.description + "\n";
            else
            {
                objectivesText.text += "✘ " + obj.description + "\n";
                allCompleted = false;
            }
        }

        if (allCompleted)
        {
            objectivesText.text += "\n➡ Semua objektif selesai!\nPergi ke lokasi Quiz Akhir.";
        }
    }

    public void CompleteObjective(int index)
    {
        if (index >= 0 && index < objectives.Count)
        {
            objectives[index].isCompleted = true;
            UpdateUI();
        }
    }

    void Start()
    {
        UpdateUI();
    }
}
