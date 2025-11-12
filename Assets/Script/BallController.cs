using NUnit.Framework;
using TMPro;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody ballrb;

    public float jumpForce;
    // public float gravityModifier; //

    public bool isOnGround = false;
    public bool isGameOver = false;
    private float lowerBoundForGameOver = -4f; //y
    private float leftBoundForGameOver = -11f;  //x

    public GameObject GameOverUi;

    public int score = 0;
    public TextMeshProUGUI scoreTMP;

    //audio
    private AudioSource coinCollect;
    private AudioSource gameOverSound;
    private bool isGameOverSoundPlayed = false;

    private float rotationSpeed = 200f;

    void Start()
    {
        ballrb = GetComponent<Rigidbody>();

        AudioSource[] audioSources = GetComponents<AudioSource>();
        coinCollect = audioSources[0];
        gameOverSound = audioSources[1];
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);

        //fixing the x position change issue
        // if (ballrb.transform.position.x < 0 || ballrb.transform.position.x > 0)
        // {
        //     Debug.Log("changes in x position of ball !!!!!!!!");
        // }

        if (ballrb.transform.position.y < lowerBoundForGameOver || ballrb.transform.position.x < leftBoundForGameOver)
        {
            isGameOver = true;
            GameOverUi.SetActive(true);

            if (!isGameOverSoundPlayed)
            {
                gameOverSound.Play();
                isGameOverSoundPlayed = true;
            }

            // Debug.Log("game over!");
        }





        //fr mobile
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && isOnGround)
            {
                jump();
                isOnGround = false;
                // Debug.Log("jump");
            }
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tile") || collision.gameObject.CompareTag("Tile1") || collision.gameObject.CompareTag("Tile2") || collision.gameObject.CompareTag("Tile3"))
        {
            isOnGround = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            coinCollect.Play();
            // Debug.Log("score");
            score += 1;
            scoreTMP.text = "Score : " + score.ToString();

        }
    }

    void jump()
    {
        ballrb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
