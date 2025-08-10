using UnityEngine;
using DialogueEditor;

public class NPCCharacter : MonoBehaviour
{
    public NPCConversation fatherConversation;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ConversationManager.Instance.StartConversation(fatherConversation);
        }
    }
}