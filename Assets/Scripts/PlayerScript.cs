using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{

    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    //Player controls using new Input system
    public InputAction playerControls;

    private float moveDirection;
    private bool alive = true;
    private int score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
    }

    //Input System enable/disable
    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    // FixedUpdate called when dealing with Physics
    void FixedUpdate()
    {
        if (alive)
        {
            //Add forward force to player
            //rb.AddForce(0, 0, forwardForce * Time.deltaTime);

            moveDirection = playerControls.ReadValue<float>();

            if (moveDirection > 0)
            {
                rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }

            if (moveDirection < 0)
            {
                rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            Debug.Log("Game Over!");
            alive = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Score" && alive)
        {
            score++;
            Debug.Log("Score: "+ score.ToString());
        }
    }
}
