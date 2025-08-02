using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public void LoadScene3()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Bab3_Peternakan");
    }

    public void LoadScene2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Bab2_Klinik");
    }
}
