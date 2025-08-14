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
    public string question;              
    public string[] answers;             
    public int correctAnswerIndex;       

    [Header("Audio")]
    public AudioClip correctAudio;
    public AudioClip wrongAudio;
    public AudioClip narrationAudio; // 🎤 audio narasi soal

    private AudioSource audioSource;
    private bool playerInRange = false;
    private bool hasInteracted = false;
    private bool isCompleted = false; // ✅ penanda objektif ini sudah selesai

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogWarning($"[InteractiveObject] Tidak ada AudioSource di {gameObject.name}");
        }

        if (interactionPanel != null)
            interactionPanel.SetActive(false);
        else
            Debug.LogError("[InteractiveObject] Interaction Panel belum di-assign!");

        if (answers == null || answers.Length < answerButtons.Length)
        {
            Debug.LogError("[InteractiveObject] Jumlah jawaban di Inspector kurang!");
        }
    }

    private void Update()
    {
        if (playerInRange && !hasInteracted && Input.GetKeyDown(KeyCode.E))
        {
            ShowInteraction();
        }
    }

    void ShowInteraction()
    {
        if (interactionPanel == null || objectImage == null || questionText == null || answerButtons == null)
        {
            Debug.LogError("[InteractiveObject] Ada referensi UI yang belum di-assign!");
            return;
        }

        interactionPanel.SetActive(true);
        objectImage.sprite = objectSprite;
        questionText.text = question;

        // 🎤 Mainkan narasi soal kalau ada
        if (narrationAudio != null && audioSource != null)
            audioSource.PlayOneShot(narrationAudio);

        // Pasang teks & event di tombol
        for (int i = 0; i < answerButtons.Length; i++)
        {
            if (answerButtons[i] == null)
            {
                Debug.LogError($"[InteractiveObject] Button index {i} belum di-assign!");
                continue;
            }

            if (answers != null && i < answers.Length)
            {
                var textComponent = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
                if (textComponent != null)
                    textComponent.text = answers[i];
                else
                    Debug.LogError($"[InteractiveObject] Button index {i} tidak punya TextMeshProUGUI!");

                int index = i;
                answerButtons[i].onClick.RemoveAllListeners();
                answerButtons[i].onClick.AddListener(() => CheckAnswer(index));
            }
        }
    }

    void CheckAnswer(int index)
    {
    // Cek dan mainkan audio sesuai jawaban
    if (index == correctAnswerIndex)
    {
        Debug.Log("Jawaban benar");
        if (correctAudio != null && audioSource != null) audioSource.PlayOneShot(correctAudio);
    }
    else
    {
        Debug.Log("Jawaban salah");
        if (wrongAudio != null && audioSource != null) audioSource.PlayOneShot(wrongAudio);
    }

    // ✅ Hitung objektif selesai, meskipun salah
    if (!isCompleted)
    {
        isCompleted = true;
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ObjectCompleted();
        }
    }

    hasInteracted = true;
    interactionPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) playerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) playerInRange = false;
    }
}
