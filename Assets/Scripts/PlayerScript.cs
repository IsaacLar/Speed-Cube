using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{

    public Rigidbody rb;
    public float forwardForce = 2000f;
    //Player controls using new Input system
    public InputAction playerControls;

    private float moveDirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
        //Add forward force to player
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        moveDirection = playerControls.ReadValue<float>();

        if (moveDirection > 0)
        {
            rb.AddForce(500 * Time.deltaTime, 0, 0);
        }

        if (moveDirection < 0)
        {
            rb.AddForce(-500*Time.deltaTime, 0, 0);
        }
    }

}
