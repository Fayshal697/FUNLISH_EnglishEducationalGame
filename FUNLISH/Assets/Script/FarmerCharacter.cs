using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class FarmerCharacter : MonoBehaviour
{
    public NPCConversation farmerConvertation;
    private bool isPlayerNear = false;

    private void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            ConversationManager.Instance.StartConversation(farmerConvertation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }
}
