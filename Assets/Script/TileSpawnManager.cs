
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TileSpawnManager : MonoBehaviour
{
    public GameObject tilePrefab;

    public GameObject[] tilePrefabs; //new
    public GameObject collectiblesPrefab;

    // private float startDelay = 0f;
    // private float repeatDelay = 2.0f;

    public float nextSpawnDelay = 0f; //new

    //range of random y
    private float minY = -1f;
    private float maxY = 2f;


    private float collectibleOffsetY = 1.0f; //coin above dist

    private BallController ballControllerScript; // to get gameover bool
    private bool canSpawn = true;

    //test
    private float nextSpawnDelay1;

    private float lastRandomY = 0f;



    void Start()
    {
        ballControllerScript = GameObject.Find("Ball").GetComponent<BallController>();

        // InvokeRepeating("SpawnTileAndCollectibles", startDelay, repeatDelay);

        StartCoroutine(SpawnLoop());
    }


    void Update()
    {


    }

    void SpawnTileAndCollectibles()
    {
        // float randomY = GetRandomY();
        // float collectibleOffsetX = Random.Range(-3f, 3f);


        // Vector3 tileSpawnPos = new Vector3(35, randomY, 0);
        // Vector3 collectiblePos = new Vector3(tileSpawnPos.x + collectibleOffsetX, tileSpawnPos.y + collectibleOffsetY, tileSpawnPos.z);

        // if (ballControllerScript.isGameOver == false)
        // {
        //     Instantiate(tilePrefab, tileSpawnPos, tilePrefab.transform.rotation);
        //     Instantiate(collectiblesPrefab, collectiblePos, collectiblesPrefab.transform.rotation);

        // }

        GameObject selectedTilePrefab = tilePrefabs[Random.Range(0, tilePrefabs.Length)];
        TileInfo info = selectedTilePrefab.GetComponent<TileInfo>();
        float tileLength = info.length;

        MoveLeft moveLeft = selectedTilePrefab.GetComponent<MoveLeft>();
        float moveSpeed = moveLeft.speed;

        Debug.Log(tileLength.ToString());

        // nextSpawnDelay = Mathf.Clamp(tileLength / 8f, 1.5f, 3.5f); //here to change
        nextSpawnDelay = Mathf.Clamp(tileLength / moveSpeed, 1.5f,3f);
        // nextSpawnDelay = tileLength / moveSpeed;

        // float randomY = GetRandomY();
        // float randomY = Random.Range(1f, 3f) * (Random.value < 0.5f ? -1f : 1f);
        float randomY;
        do
        {
            randomY = Random.Range(-2f, 2f);
        }
        while (Mathf.Abs(randomY - lastRandomY) < 1f);

        lastRandomY = randomY;


        Vector3 tileSpawnPos = new Vector3(35, randomY, 0);

        float collectibleOffsetX = Random.Range(-3f, 3f);
        Vector3 collectiblePos = new Vector3(tileSpawnPos.x + collectibleOffsetX, tileSpawnPos.y + collectibleOffsetY, tileSpawnPos.z);

        Instantiate(selectedTilePrefab, tileSpawnPos, selectedTilePrefab.transform.rotation);
        Instantiate(collectiblesPrefab, collectiblePos, collectiblesPrefab.transform.rotation);
    }

    //new
    System.Collections.IEnumerator SpawnLoop()
    {
        while (!ballControllerScript.isGameOver)
        {
            if (canSpawn)
            {
                SpawnTileAndCollectibles();
                canSpawn = false;
                yield return new WaitForSeconds(nextSpawnDelay);
                canSpawn = true;
            }

            yield return null;
        }
    }

    float GetRandomY()
    {
        return Random.Range(minY, maxY);
    }
}
