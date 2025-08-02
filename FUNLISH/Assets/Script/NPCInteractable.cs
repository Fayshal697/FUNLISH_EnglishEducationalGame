using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    public string npcName = "NPC";
    public GameObject talkPromptUI;
    private bool playerInRange = false;

    public void Interact()
    {
        Debug.Log("Interacting with " + npcName);
        // TODO: Di sini kamu panggil sistem dialog asset yang kamu punya
    }

    void Start()
    {
        if (talkPromptUI != null)
            talkPromptUI.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (talkPromptUI != null)
                talkPromptUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if (talkPromptUI != null)
                talkPromptUI.SetActive(false);
        }
    }

    public bool IsPlayerInRange()
    {
        return playerInRange;
    }
}
