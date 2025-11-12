using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    public float leftBound = -33.0f;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < leftBound )
        {
            Destroy(gameObject);
            // Debug.Log("out");
            
        }
    }
}
