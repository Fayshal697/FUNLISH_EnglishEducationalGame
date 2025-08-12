using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfoBoardInteraction : MonoBehaviour
{
    [Header("UI References")]
    public GameObject learningPanel;       // Panel UI pembelajaran
    public Image contentImage;             // Gambar materi
    public TMP_Text contentText;           // Teks materi
    public AudioSource audioSource;        // Audio narasi
    public AudioClip narrationClip;        // File audio narasi

    [Header("Content")]
    public Sprite learningSprite;          // Gambar materi
    [TextArea] public string learningText; // Teks materi

    private bool isPlayerNear = false;

    void Update()
    {
        // Jika player dekat dan menekan tombol E
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            ShowLearningPanel();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            Debug.Log("Player dekat dengan palang info. Tekan E untuk belajar.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }

    void ShowLearningPanel()
    {
        learningPanel.SetActive(true);

        // Set konten panel
        contentImage.sprite = learningSprite;
        contentText.text = learningText;

        // Putar narasi
        if (narrationClip != null)
        {
            audioSource.clip = narrationClip;
            audioSource.Play();
        }

        // Hentikan gerakan player (opsional, kalau mau freeze)
        Time.timeScale = 0f;
    }

    public void CloseLearningPanel()
    {
        learningPanel.SetActive(false);

        // Resume game
        Time.timeScale = 1f;
    }
}
