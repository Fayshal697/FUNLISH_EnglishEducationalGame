using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject goalPanel; // Panel misi awal
    public GameObject player;    // Player untuk diaktifkan setelah start

    private Supercyan.FreeSample.SimpleSampleCharacterControl playerControl;

    private void Start()
    {
        // Ambil script kontrol player
        playerControl = player.GetComponent<Supercyan.FreeSample.SimpleSampleCharacterControl>();

        // Pastikan panel aktif & player tidak bisa gerak
        goalPanel.SetActive(true);
        if (playerControl != null)
        {
            playerControl.enabled = false;
        }
    }

    public void StartGame()
    {
        // Sembunyikan panel & aktifkan player
        goalPanel.SetActive(false);
        if (playerControl != null)
        {
            playerControl.enabled = true;
        }
    }
}