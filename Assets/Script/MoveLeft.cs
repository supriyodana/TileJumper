using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 10f;

    // public float leftBound = -33f;

    private BallController ballControllerScript;
    
    
    void Start()
    {
        ballControllerScript = GameObject.Find("Ball").GetComponent<BallController>();
    }

    void Update()
    {
        if(ballControllerScript.isGameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        
    }
}
