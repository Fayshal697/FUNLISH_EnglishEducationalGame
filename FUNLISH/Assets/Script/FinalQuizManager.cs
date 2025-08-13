using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Question
{
    public string questionText;
    public Sprite questionImage; // gambar untuk soal
    public string[] options;
    public int correctAnswerIndex; 
}

public class FinalQuizManager : MonoBehaviour
{
    [Header("UI Pertanyaan")]
    public TMP_Text questionText;
    public Image questionImageUI; // komponen UI Image untuk gambar soal
    public Button[] optionButtons;

    [Header("UI Hasil Akhir")]
    public GameObject panelResult;
    public Image starImage;
    public TMP_Text motivationText;
    public Sprite[] starSprites; // index 0 = 1 bintang, dst
    [TextArea] public string[] messages; // index sesuai jumlah bintang
    public AudioClip[] narrationClips; // narasi sesuai jumlah bintang
    public AudioSource audioSource;

    [Header("Data Pertanyaan")]
    public Question[] questions;

    private int currentQuestionIndex = 0;
    private int score = 0;

    void Start()
    {
        ShowQuestion();
    }

    void ShowQuestion()
    {
        Question q = questions[currentQuestionIndex];

        // Set teks pertanyaan
        questionText.text = q.questionText;

        // Set gambar soal (jika ada)
        if (q.questionImage != null)
        {
            questionImageUI.sprite = q.questionImage;
            questionImageUI.gameObject.SetActive(true);
        }
        else
        {
            questionImageUI.gameObject.SetActive(false);
        }

        // Set opsi jawaban
        for (int i = 0; i < optionButtons.Length; i++)
        {
            int index = i;
            optionButtons[i].GetComponentInChildren<TMP_Text>().text = q.options[i];
            optionButtons[i].onClick.RemoveAllListeners();
            optionButtons[i].onClick.AddListener(() => CheckAnswer(index));
        }
    }

    void CheckAnswer(int chosenIndex)
    {
        if (questions[currentQuestionIndex].correctAnswerIndex == chosenIndex)
        {
            score++;
        }

        currentQuestionIndex++;
        if (currentQuestionIndex < questions.Length)
        {
            ShowQuestion();
        }
        else
        {
            ShowResult();
        }
    }

    void ShowResult()
    {
        panelResult.SetActive(true);

        // Hitung persentase skor
        float percentage = (float)score / questions.Length;
        int starCount = 1;

        if (percentage >= 0.25f) starCount = 1;
        if (percentage >= 0.5f)  starCount = 2;
        if (percentage >= 0.75f) starCount = 3;
        if (percentage >= 1f)    starCount = 4;

        // Pastikan index array aman
        int index = Mathf.Clamp(starCount - 1, 0, starSprites.Length - 1);

        // Set gambar bintang
        if (index < starSprites.Length)
            starImage.sprite = starSprites[index];

        // Set teks motivasi
        if (index < messages.Length)
            motivationText.text = messages[index];

        // Putar narasi
        if (index < narrationClips.Length && narrationClips[index] != null)
        {
            audioSource.clip = narrationClips[index];
            audioSource.Play();
        }
    }

    public void RestartQuiz()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
