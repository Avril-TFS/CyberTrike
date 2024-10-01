using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    private Rigidbody rgbd;
    public float jumpForce = 11.0f;
    public float downwardForce = 2.0f;
    public float maxFallSpeed = -15f;

    private bool isGrounded = false;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public Transform attackPoint;
    public GameObject bulletPrefab;
    public GameManager gameManager;

    public SpriteRenderer spriteRenderer;
    public Sprite spriteOne;
    public Sprite spriteTwo;
    public Sprite spriteThree;
    public Sprite spriteFour;
    public Sprite spriteFive;

    //public float airControl = .5f;  // This is to try to make the player have less control when in the air
    // will remove if it doesnt work or feels bad
    // ... I didnt like it

    // Start is called before the first frame update
    void Start()
    {
        rgbd = GetComponent<Rigidbody>();                           // This tells the script to find the Rigidbody that is attached to whatever the script is attached to, in this case the player
        gameManager = GameObject.FindObjectOfType<GameManager>();      // This basically tells the script to search the scene in unity for the GameManager
    }

    // Update is called once per frame
    void Update()
    {
        // This is movement, left and right with A nd D
        float horizontalMovement = Input.GetAxis("Horizontal");         // horizontal is defined in the unity editor, by default it is A and D
        Vector3 movement = new Vector3(horizontalMovement, 0, 0);       // This is saying to apply the movement along the X axis, while keeping the values for Y and Z axis at 0
        rgbd.velocity = new Vector3(movement.x * moveSpeed, rgbd.velocity.y, rgbd.velocity.z);  // here we apply the movement as moveSpeed which we can adjust the value for

        // This is Jumping, Spacebar to jump                                             // We are using a bool to check if the player is on the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer);       //  I attached an empty game object called ground check to the bottom of the player and assigned it to this script through the heirachy
        if (isGrounded && Input.GetKeyDown("space"))
        {
            rgbd.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);                   // This adds upward force to the player, which we can adjust by changing the value of jumpForce
        }

        // This is me trying to add gravity, hopefully the player doesnt stick to walls now
        if (!isGrounded)
        {
            rgbd.AddForce(Vector3.down * downwardForce, ForceMode.Acceleration);
            if (rgbd.velocity.y < maxFallSpeed)
            {
                rgbd.velocity = new Vector3(rgbd.velocity.x, maxFallSpeed, rgbd.velocity.z);
            }

            //This will be about air control
            // Vector3 airMovement = new Vector3(horizontalMovement * moveSpeed * airControl, rgbd.velocity.y, rgbd.velocity.z);
            // rgbd.velocity = airMovement;
        }

        // This is for shooting, Not sure if were keeping this click mouse to shoot
        /*  if(Input.GetMouseButtonDown(0))
          {
              Attack();
          }*/

        UpdateSprite(moveSpeed);

        if (Input.GetAxis("Horizontal") > .2f)  // When the character moves horizontally with a positive value, which would be left
        {
            spriteRenderer.flipX = false;       // the sprite renderer will set the flip along the X axis to false
        }
        if (Input.GetAxis("Horizontal") < -.2f) // when the character moves horizontally negatively, to the right
        {
            spriteRenderer.flipX = true;        // the sprite renderer will set the flip along the X axis to true, causing the bike to turn around
        }
    }

    /*void Attack()
    {
        if(bulletPrefab != null && attackPoint!= null)
        {
            GameObject bullet = Instantiate(bulletPrefab, attackPoint.position, attackPoint.rotation);

        }
    }*/

    // called from PowerUps.cs it adds the speed increase from the powerup to the player
    public void SpeedBoost(float amount)
    {
        moveSpeed += amount;        // take the current movement speed for the player and adds the amount defined in PowerUps.cs to it
    }
    public void GameOver()          // This method is called from Hazards.cs when the player hits the "Door" as a lose condition, we can add additional lose conditions as well
    {
        Time.timeScale = 0;         // This basically freezes the game so the player cannot continue moving around during a game over
        gameManager.GameOver();     // This calls the GameOver() method in the GameManager.cs
    }

    // This method is called in BreakableBoxes.cs so that that script knows how fast the player is moving
    public float PlayerSpeed()
    {
        return moveSpeed;     // basically just says hey the rigidbody is moving at this speed
    }
    void UpdateSprite(float speed)
    {
        if (speed < 15)
        {
            spriteRenderer.sprite = spriteOne;
        }
        else if (speed < 20)
        {
            spriteRenderer.sprite = spriteTwo;
        }
        else if (speed < 25)
        {
            spriteRenderer.sprite = spriteThree;
        }
        else if (speed < 30)
        {
            spriteRenderer.sprite = spriteFour;
        }
        else
        {
            spriteRenderer.sprite = spriteFive;
        }
    }
}
