using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InfoInteraction : MonoBehaviour
{
    [Header("UI References")]
    public GameObject learningPanel;
    public Image contentImage;
    public TMP_Text contentText;
    public TMP_Text nextMissionText;

    [Header("Content")]
    public Sprite learningSprite;
    [TextArea] public string learningText;
    [TextArea] public string nextGoalMissionText;
    public AudioClip narrationClip;

    private bool isPlayerNear = false;
    private AudioSource currentAudioSource;
    private InteractionPrompt prompt;

    private void Start()
    {
        prompt = FindFirstObjectByType<InteractionPrompt>();
    }

    private void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
            ShowLearningPanel();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            prompt?.ShowPrompt("Press E to read");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            prompt?.HidePrompt();
        }
    }

    private void ShowLearningPanel()
    {
        learningPanel.SetActive(true);
        contentImage.sprite = learningSprite;
        contentText.text = learningText;
        nextMissionText.text = nextGoalMissionText;

        if (narrationClip != null)
        {
            GameObject audioObj = new GameObject("NarrationAudio");
            currentAudioSource = audioObj.AddComponent<AudioSource>();
            currentAudioSource.clip = narrationClip;
            currentAudioSource.Play();
        }

        Time.timeScale = 0f;
    }

    public void CloseLearningPanel()
    {
        learningPanel.SetActive(false);
        if (currentAudioSource != null)
        {
            currentAudioSource.Stop();
            Destroy(currentAudioSource.gameObject);
        }
        Time.timeScale = 1f;
    }
}
