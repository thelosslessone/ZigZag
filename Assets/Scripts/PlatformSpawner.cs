using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;
    public GameObject diamond;
    private Vector3 lastPosition;
    private Vector3 pos;
    private float size;
 
    
    // Use this for initialization
    private void Start()
    {
        lastPosition = platform.transform.position;
        size = platform.transform.localScale.x;

        for (int i = 0; i < 20; i++)
        {
            SpawnPlatforms();
        }

    }

    // Update is called once per frame
    private void Update()
    {
        if (GameManager.instance.gameOver)
        {
            CancelInvoke("SpawnPlatforms");
        }
    }

    public void StartSpawningPlatforms()
    {
        InvokeRepeating("SpawnPlatforms", 0.1f, 0.4f);

    }

    private void SpawnPlatforms()
    {
        var rand = Random.Range(0, 6);
        if (rand < 3)
        {
            SpawnX();
        }
        else if (rand >= 3)
        {
            SpawnZ();
        }
    }

    private void SpawnDiamond()
    {
        var rand = Random.Range(0, 3);
        if (rand < 1)
        {
            Instantiate(diamond, new Vector3(pos.x, pos.y + 1f, pos.z), diamond.transform.rotation);
        }
    }

    private void SpawnX()
    {
        pos = lastPosition;
        pos.x += size;
        lastPosition = pos;
        Instantiate(platform, pos, Quaternion.identity);    // instancira platformu na poziciji pos i bez rotacije
        SpawnDiamond();
    }

    private void SpawnZ()
    {
        pos = lastPosition;
        pos.z += size;
        lastPosition = pos;
        Instantiate(platform, pos, Quaternion.identity);    // instancira platformu na poziciji pos i bez rotacije
        SpawnDiamond();
    }
}