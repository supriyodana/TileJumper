using NUnit.Framework;
using UnityEngine;

public class PlayPauseManager : MonoBehaviour
{
    private bool isPause = false;
    public GameObject PauseCanvas;
    public GameObject PlayCanvas;

    
    private BallController ballControllerScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballControllerScript = GameObject.Find("Ball").GetComponent<BallController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (ballControllerScript.isGameOver == true)
        {
            PauseCanvas.SetActive(false);
            PlayCanvas.SetActive(false);
            
        }

    }

    public void PauseFromPlay()
    {
        if (!isPause)
        {
            Time.timeScale = 0;
        }

        isPause = true;
        PauseCanvas.SetActive(false);
        PlayCanvas.SetActive(true);
    }

    public void PlayFromPause()
    {
        if (isPause)
        {
            Time.timeScale = 1;
        }
        isPause = false;
        PlayCanvas.SetActive(false);
        PauseCanvas.SetActive(true);

    }
}
