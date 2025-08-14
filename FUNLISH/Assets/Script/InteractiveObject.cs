using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InteractiveObject : MonoBehaviour
{
    [Header("UI References")]
    public GameObject interactionPanel;
    public Image objectImage;
    public TMP_Text questionText;
    public Button[] answerButtons;

    [Header("Content")]
    public Sprite objectSprite;
    [TextArea] public string question;
    public string[] answers;
    public int correctAnswerIndex;

    [Header("Audio")]
    public AudioClip correctAudio;
    public AudioClip wrongAudio;
    public AudioClip narrationAudio;

    private AudioSource audioSource;
    private bool playerInRange = false;
    private bool hasInteracted = false;
    private bool isCompleted = false;
    private InteractionPrompt prompt;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            Debug.LogWarning($"[InteractiveObject] Tidak ada AudioSource di {gameObject.name}");

        if (interactionPanel != null)
            interactionPanel.SetActive(false);
        else
            Debug.LogError("[InteractiveObject] Interaction Panel belum di-assign!");

        if (answers == null || answers.Length == 0)
            Debug.LogWarning("[InteractiveObject] Belum ada jawaban di Inspector!");

        prompt = FindFirstObjectByType<InteractionPrompt>();
    }

    private void Update()
    {
        if (playerInRange && !hasInteracted && Input.GetKeyDown(KeyCode.E))
            ShowInteraction();
    }

    private void ShowInteraction()
    {
        interactionPanel.SetActive(true);
        objectImage.sprite = objectSprite;
        questionText.text = question;

        if (narrationAudio != null && audioSource != null)
            audioSource.PlayOneShot(narrationAudio);

        for (int i = 0; i < answerButtons.Length; i++)
        {
            if (answerButtons[i] == null) continue;
            TMP_Text textComponent = answerButtons[i].GetComponentInChildren<TMP_Text>();
            textComponent.text = (i < answers.Length) ? answers[i] : "";

            int index = i;
            answerButtons[i].onClick.RemoveAllListeners();
            answerButtons[i].onClick.AddListener(() => CheckAnswer(index));
        }
    }

    private void CheckAnswer(int index)
    {
        if (index == correctAnswerIndex)
        {
            Debug.Log("Jawaban benar");
            if (correctAudio != null) audioSource.PlayOneShot(correctAudio);
        }
        else
        {
            Debug.Log("Jawaban salah");
            if (wrongAudio != null) audioSource.PlayOneShot(wrongAudio);
        }

        if (!isCompleted)
        {
            isCompleted = true;
            GameManager.Instance?.ObjectCompleted();
        }

        hasInteracted = true;
        interactionPanel.SetActive(false);
        prompt?.HidePrompt(); // Prompt hilang setelah selesai
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isCompleted)
        {
            playerInRange = true;
            prompt?.ShowPrompt("Press E to answer");
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
