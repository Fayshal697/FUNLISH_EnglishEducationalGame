using UnityEngine;
using TMPro;

public class InteractionPrompt : MonoBehaviour
{
    [SerializeField] private GameObject promptUI;
    [SerializeField] private TMP_Text promptText;

    public void ShowPrompt(string message = "Press E to interact")
    {
        if (promptUI != null)
        {
            promptUI.SetActive(true);
            if (promptText != null) promptText.text = message;
        }
    }

    public void HidePrompt()
    {
        if (promptUI != null) promptUI.SetActive(false);
    }
}
