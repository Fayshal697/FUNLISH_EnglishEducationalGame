using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class UncleCharacter : MonoBehaviour
{
    public NPCConversation uncleConvertation;
    private bool isPlayerNear = false;

    private void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            ConversationManager.Instance.StartConversation(uncleConvertation);
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
