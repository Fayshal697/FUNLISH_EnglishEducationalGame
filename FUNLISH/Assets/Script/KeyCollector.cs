using UnityEngine;

public class KeyCollector : MonoBehaviour
{
    public ObjectiveManager objectiveManager;
    public int objectiveIndex; // index objective di list

    private int collectedKeys = 0;
    public int requiredKeys = 3;

    void Update()
    {
        // misalnya kalau player tekan K, dianggap ambil kunci
        if (Input.GetKeyDown(KeyCode.E))
        {
            collectedKeys++;
            Debug.Log("Kunci terkumpul: " + collectedKeys);

            if (collectedKeys >= requiredKeys)
            {
                objectiveManager.CompleteObjective(objectiveIndex);
            }
        }
    }
}
