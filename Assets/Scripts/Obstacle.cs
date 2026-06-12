using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float ObsSpeed = 15f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0,0,1) * ObsSpeed * Time.deltaTime;
        //Delete the obstacle game object when it is out of view of the camera
        if (transform.position.z < -13)
        {
            Destroy(gameObject);
        }
    }
}
