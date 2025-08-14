using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public GameObject dialogPanel;
    public AudioClip dialogAudio;
    public KeyCode interactKey = KeyCode.E;

    private AudioSource audioSource;
    private bool playerInRange = false;
    private bool hasInteracted = false;
    private InteractionPrompt prompt;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        dialogPanel.SetActive(false);
        prompt = FindFirstObjectByType<InteractionPrompt>();
    }

    private void Update()
    {
        if (playerInRange && !hasInteracted && Input.GetKeyDown(interactKey))
            StartConversation();
    }

    private void StartConversation()
    {
        dialogPanel.SetActive(true);

        if (dialogAudio != null && audioSource != null)
        {
            audioSource.clip = dialogAudio;
            audioSource.Play();
        }

        hasInteracted = true;
        prompt?.HidePrompt();

        if (dialogAudio != null)
            Invoke(nameof(HideDialog), dialogAudio.length);
    }

    private void HideDialog()
    {
        dialogPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            prompt?.ShowPrompt("Press E to talk");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            prompt?.HidePrompt();
        }
    }
}
