using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public GameObject dialogPanel;   // Panel UI untuk teks dialog
    public AudioClip dialogAudio;    // Audio narasi
    public KeyCode interactKey = KeyCode.E;

    private AudioSource audioSource;
    private bool playerInRange = false;
    private bool hasInteracted = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        dialogPanel.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange && !hasInteracted && Input.GetKeyDown(interactKey))
        {
            StartConversation();
        }
    }

    private void StartConversation()
    {
        // Tampilkan panel dialog
        dialogPanel.SetActive(true);

        // Putar audio narasi
        if (dialogAudio != null && audioSource != null)
        {
            audioSource.clip = dialogAudio;
            audioSource.Play();
        }

        // Tandai sudah interaksi sekali
        hasInteracted = true;

        // Opsional: sembunyikan panel setelah audio selesai
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
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
