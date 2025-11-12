using UnityEngine;

public class Collectible : MonoBehaviour
{
    // public int scoreValue = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Destroy(gameObject);
            // scoreValue += 1;
        }
    }
}
