using UnityEngine;

public class BgMusic : MonoBehaviour
{
    private AudioSource audioSource;
    private BallController ballControllerScript;
    private PlayPauseManager playPauseManagerScript;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballControllerScript = GameObject.Find("Ball").GetComponent<BallController>();
        playPauseManagerScript = GameObject.Find("PlayPauseManager").GetComponent<PlayPauseManager>();

        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (ballControllerScript.isGameOver)
        {
            if (audioSource.isPlaying)
                audioSource.Stop();
            return;
        }

        if (playPauseManagerScript.isPause)
        {
            if (audioSource.isPlaying)
                audioSource.Pause();
        }
        else
        {
            if (!audioSource.isPlaying)
                audioSource.UnPause();
        }

        // if (playPauseManagerScript.isPause == false && !audioSource.isPlaying)
        // {
        //     audioSource.UnPause();
        // }
        // else if (playPauseManagerScript.isPause == true && audioSource.isPlaying)
        // {
        //     audioSource.Pause();
        // }

    }
}
