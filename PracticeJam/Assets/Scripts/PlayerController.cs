using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed =10.0f;
    private Rigidbody rgbd;  
    public float jumpForce = 11.0f;
    public float downwardForce = 2.0f;
    public float maxFallSpeed = -15f;

    private bool isGrounded = false;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public Transform attackPoint;
    public GameObject bulletPrefab;

    //public float airControl = .5f;  // This is to try to make the player have less control when in the air
                                    // will remove if it doesnt work or feels bad
                                    // ... I didnt like it

    // Start is called before the first frame update
    void Start()
    {
        rgbd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // This is movement, back and forth with A nd D
        float horizontalMovement = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontalMovement, 0, 0);
        rgbd.velocity = new Vector3(movement.x * moveSpeed, rgbd.velocity.y, rgbd.velocity.z);

        // This is Jumping, Spacebar to jump
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer);
        if(isGrounded && Input.GetKeyDown("space"))
        {
            rgbd.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // This is me trying to add gravity, hopefully the player doesnt stick to walls now
        if(!isGrounded){
            rgbd.AddForce(Vector3.down * downwardForce, ForceMode.Acceleration);
            if(rgbd.velocity.y < maxFallSpeed)
            {
                rgbd.velocity = new Vector3(rgbd.velocity.x, maxFallSpeed, rgbd.velocity.z);
            }

            //This will be about air control
           // Vector3 airMovement = new Vector3(horizontalMovement * moveSpeed * airControl, rgbd.velocity.y, rgbd.velocity.z);
           // rgbd.velocity = airMovement;
        }

        // This is for shooting, Not sure if were keeping this click mouse to shoot
        if(Input.GetMouseButtonDown(0)){
            Attack();
        }
    }

    void Attack(){
        if(bulletPrefab != null && attackPoint!= null)
        {
            GameObject bullet = Instantiate(bulletPrefab, attackPoint.position, attackPoint.rotation);

        }
    }

    //private bool GroundCheck(){
       // float extraHeight = .1f;
        //RaycastHit2D
       
    //}
}
