

using UnityEngine;

public class Repeatbackground : MonoBehaviour
{
    // private Vector3 startPos;
    // private float repeatWidth;


    // void Start()
    // {
    //     startPos = transform.position;
    //     // repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    //     repeatWidth = GetComponent<BoxCollider>().size.x;

    // }

    // void Update()
    // {
    //     if (transform.position.x < startPos.x - repeatWidth)
    //     {
    //         transform.position = startPos;
    //     }
    // }

    public float loopSpeed;
    public Renderer bgRenderer;

    private BallController ballControllerScript;

    void Start()
    {
        ballControllerScript = GameObject.Find("Ball").GetComponent<BallController>();
    }
    void Update()
    {
        if(ballControllerScript.isGameOver == false)
        {
            bgRenderer.material.mainTextureOffset += new Vector2(loopSpeed * Time.deltaTime, 0f);
        }
        // bgRenderer.material.mainTextureOffset += new Vector2(loopSpeed * Time.deltaTime, 0f);
    }
}
