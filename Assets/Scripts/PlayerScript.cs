using TMPro;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    public Rigidbody rb;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button replayButton;

    //Default sideways force
    public float sidewaysForce = 50f;
    //Player controls using new Input system
    public InputAction playerControls;

    //Stores output from Unity's input system
    private float moveDirection;

    //General variables
    public bool alive = true;
    public int score;
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
            //Obtain mvmt direction of player
            //1 = Right, -1 = Left
            moveDirection = playerControls.ReadValue<float>();

            //Apply respective force to player object
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
        //End game once collided with obstacle
        if (collision.collider.tag == "Obstacle")
        {
            //Show game over text and replay button
            gameOverText.gameObject.SetActive(true);
            replayButton.gameObject.SetActive(true);
            //Prevent player mvmt and score increase
            alive = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Increment score when colliding with trigger and alive
        if (other.tag == "Score" && alive)
        {
            score++;
            //Display score on screen
            scoreText.text = "Score : " + score.ToString();
        }
    }

    //Reload the scene when replay button clicked
    public void onReplayClicked()
    {
        SceneManager.LoadScene("Level01");
    }
}
