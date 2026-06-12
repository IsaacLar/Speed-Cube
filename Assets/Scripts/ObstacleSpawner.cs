using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject Obstacle;

    public float timeBetweenObs = 1.6f;

    private Vector3 DefaultSpawnPos = new Vector3(0, 1, 85);
    private float spawnTimer;
    private float maxOffset = -5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnTimer = timeBetweenObs;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer < 0)
        {
            Vector3 SpawnPos = DefaultSpawnPos + new Vector3(Random.Range(-maxOffset, maxOffset), 0, 0);
            GameObject newObstacle = Instantiate(Obstacle, SpawnPos, transform.rotation);
            spawnTimer = timeBetweenObs;
        }
    }
}
