using UnityEngine;

public class DialogueOptionBinder : MonoBehaviour {
    [Tooltip("Isi dengan ID objective yang ingin ditandai selesai saat option ini dipilih")]
    public string objectiveId;

    public void OnOptionChosen(){
        if(string.IsNullOrEmpty(objectiveId)){
            Debug.LogWarning("objectiveId kosong pada DialogueOptionBinder");
            return;
        }
        QuestManager.Instance?.CompleteObjective(objectiveId);
    }
}
