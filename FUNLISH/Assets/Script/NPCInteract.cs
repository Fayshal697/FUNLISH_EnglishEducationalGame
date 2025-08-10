using UnityEngine;
using DialogueEditor; // namespace Dialogue Editor

public class NPCInteract : MonoBehaviour
{
    public NPCConversation npcConversation; // Drag dari inspector
    public KeyCode interactKey = KeyCode.E; // Tombol untuk interaksi
    public float interactDistance = 3f; // Jarak maksimum interaksi

    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (player == null) return;

        // Hitung jarak player ke NPC
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= interactDistance)
        {
            // Cek input tombol
            if (Input.GetKeyDown(interactKey))
            {
                if (npcConversation != null)
                {
                    ConversationManager.Instance.StartConversation(npcConversation);
                }
                else
                {
                    Debug.LogWarning("NPCConversation belum di-assign untuk " + gameObject.name);
                }
            }
        }
    }
}
