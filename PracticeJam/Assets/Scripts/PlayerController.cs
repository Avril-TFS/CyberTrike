using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed =10.0f;
    private Rigidbody2D rgbd;  

    private bool isGrounded = false;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float jumpForce = 10f;

    public Transform attackPoint;
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
        rgbd.velocity = new Vector2(movement.x * moveSpeed, rgbd.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        if(isGrounded && Input.GetKeyDown("space"))
        {
            rgbd.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
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
