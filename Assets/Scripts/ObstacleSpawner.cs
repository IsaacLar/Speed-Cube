using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject Obstacle;
    public PlayerScript playerScript;

    //Default time between obstacles being spawned
    public float timeBetweenObs = 1.6f;

    //Default spawn position of obstacles
    private Vector3 DefaultSpawnPos = new Vector3(0, 1, 85);
    //Time until next obstacle spawns in 
    private float spawnTimer;
    //Maximum x co-ordinate offset allowed for obstacles
    private float maxOffset = -5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Retrieve reference to player script
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();

        //Initialise timer
        spawnTimer = timeBetweenObs;
    }

    // Update is called once per frame
    void Update()
    {
        //Decrement timer
        spawnTimer -= Time.deltaTime;
        //Spawn obstacle logic
        if (spawnTimer < 0 && playerScript.alive)
        {
            //Obtain spawn position of new obstacle
            Vector3 SpawnPos = DefaultSpawnPos + new Vector3(Random.Range(-maxOffset, maxOffset), 0, 0);
            //Instantiate object
            GameObject newObstacle = Instantiate(Obstacle, SpawnPos, transform.rotation);
            //Reset spawn timer
            spawnTimer = timeBetweenObs;
        }
    }
}
