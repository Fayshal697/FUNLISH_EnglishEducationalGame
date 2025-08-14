using UnityEngine;

public abstract class BaseInteraction : MonoBehaviour
{
    [Header("Prompt Settings")]
    public string promptMessage = "Press E to interact";
    protected InteractionPrompt prompt;
    protected bool playerInRange = false;

    protected virtual void Start()
    {
        prompt = FindFirstObjectByType<InteractionPrompt>();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && ShouldShowPrompt())
        {
            playerInRange = true;
            prompt?.ShowPrompt(promptMessage);
        }
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            prompt?.HidePrompt();
        }
    }

    protected abstract bool ShouldShowPrompt(); // Aturan kapan prompt muncul
}
