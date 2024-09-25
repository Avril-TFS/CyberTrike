using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isGrounded = false;
    //private Transform groundCheck;
    private LayerMask Ground;

    public float moveSpeed =10.0f;
    
    public Vector2 jumpForce;
    public Transform attackPoint;
    private Rigidbody2D rgbd;
    //private boxCollider2D box2d;        // this is for the raycast

    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
      //  box2D = transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        //float verticalMovement = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalMovement, 0);
        rgbd.velocity = movement * moveSpeed;

       if(Input.GetKeyDown("space"))
       {
        rgbd.AddForce(jumpForce, ForceMode2D.Impulse);
       }

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
