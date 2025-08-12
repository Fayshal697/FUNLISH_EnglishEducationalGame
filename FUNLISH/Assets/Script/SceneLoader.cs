using UnityEngine;
using UnityEngine.SceneManagement; // ini SceneManager bawaan Unity

public class SceneLoader : MonoBehaviour
{
    public void LoadScene3()
    {
        SceneManager.LoadScene("Bab3_Peternakan");
    }

    public void LoadScene2()
    {
        SceneManager.LoadScene("Bab2_Klinik");
    }
}
