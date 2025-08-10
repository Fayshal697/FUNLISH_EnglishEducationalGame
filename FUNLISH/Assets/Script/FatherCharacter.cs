using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class FatherCharacter : MonoBehaviour
{
    public NPCConversation fatherConvertation;
    private bool isPlayerNear = false;

    private void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            ConversationManager.Instance.StartConversation(fatherConvertation);
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