using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float ObsSpeed;

    public PlayerScript playerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Obtain reference to player script
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();

        //Increment speed of obstacles depending on player score
        if (playerScript.score > 0)
        {
            //Speed multiplier takes the form of 1 + score/100
            //A score of 15 gives a multiplier of 1.15
            ObsSpeed = ObsSpeed * (1.0f+(playerScript.score/100.0f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Move the obstacle at a constant speed towards the player
        transform.position -= new Vector3(0,0,1) * ObsSpeed * Time.deltaTime;
        //Delete the obstacle game object when it is out of view of the camera
        if (transform.position.z < -13)
        {
            Destroy(gameObject);
        }
    }
}
