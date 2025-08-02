using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float interactionRange = 5f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactionRange);
            foreach (Collider collider in colliderArray)
            {
                if (collider.TryGetComponent<NPCInteractable>(out NPCInteractable npc))
                {
                    if (npc.IsPlayerInRange()) // Pastikan player benar-benar dekat
                    {
                        npc.Interact(); // Panggil interaksi
                        break; // hanya interaksi dengan satu NPC terdekat
                    }
                }
            }
        }
    }
}
