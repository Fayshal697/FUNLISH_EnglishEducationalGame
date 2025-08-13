using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfoInteraction : MonoBehaviour
{
    [Header("UI References")]
    public GameObject learningPanel;       // Panel UI pembelajaran
    public Image contentImage;              // Gambar materi
    public TMP_Text contentText;            // Teks materi

    [Header("Content")]
    public Sprite learningSprite;           // Gambar materi
    [TextArea] public string learningText;  // Teks materi
    public AudioClip narrationClip;         // File audio narasi

    private bool isPlayerNear = false;
    private AudioSource currentAudioSource; // Audio yang sedang diputar

    void Update()
    {
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

        // Buat AudioSource baru untuk narasi
        if (narrationClip != null)
        {
            GameObject audioObj = new GameObject("NarrationAudio");
            currentAudioSource = audioObj.AddComponent<AudioSource>();
            currentAudioSource.clip = narrationClip;
            currentAudioSource.Play();
        }

        // Pause game (opsional)
        Time.timeScale = 0f;
    }

    public void CloseLearningPanel()
    {
        learningPanel.SetActive(false);

        // Hentikan audio jika ada
        if (currentAudioSource != null)
        {
            currentAudioSource.Stop();
            Destroy(currentAudioSource.gameObject);
        }

        // Resume game
        Time.timeScale = 1f;
    }
}
