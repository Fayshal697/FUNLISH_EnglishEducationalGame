using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject goalPanel; 
    public GameObject player;    

    private Supercyan.FreeSample.SimpleSampleCharacterControl playerControl;
    private Rigidbody playerRb;

    private void Start()
    {
        playerControl = player.GetComponent<Supercyan.FreeSample.SimpleSampleCharacterControl>();
        playerRb = player.GetComponent<Rigidbody>();

        // Kunci player di awal
        goalPanel.SetActive(true);
        if (playerControl != null) playerControl.enabled = false;
        if (playerRb != null) playerRb.isKinematic = true;
    }

    public void StartGame()
    {
        // Lepas kunci player
        goalPanel.SetActive(false);
        if (playerControl != null) playerControl.enabled = true;
        if (playerRb != null) playerRb.isKinematic = false;
    }
}
