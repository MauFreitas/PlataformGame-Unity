using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2D : MonoBehaviour
{
    public Rigidbody2D rb ;
    public int moveSpeed;
    private float direction;
    private Vector3 faceR;
    private Vector3 faceL;

    private Animator anim;

    public bool Onfloor;
    public Transform sensorFloor;
    public LayerMask whatIsFloor;
    

    private void Start()
    {
        faceR = transform.localScale;
        faceL = transform.localScale;
        faceL.x = faceL.x * -1;

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        move();
        jump();
    }
    void jump()
    {
        Onfloor = Physics2D.OverlapCircle(sensorFloor.position, 0.2f, whatIsFloor);

        if (Input.GetButtonDown("Jump") && Onfloor == true)
        {
            rb.velocity = Vector2.up * 12;
      
        }
    }
        void move()
        {
            direction = Input.GetAxis("Horizontal");

        if (Input.GetAxis("Horizontal") > 0f)
        {
            anim.SetBool("walk", true);
        }
        if (Input.GetAxis("Horizontal") < 0f)
        {
            anim.SetBool("walk", true);
        }
        if (Input.GetAxis("Horizontal") == 0f)
        {
            anim.SetBool("walk", false);
        }



        if (direction > 0)
        {
          transform.localScale = faceR;
        }
        if(direction < 0)
        {
            transform.localScale = faceL;
        }

        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
        }

    /* private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemies")
        {
            GameCC.instance.ShowGameOver();
            Destroy(gameObject);
        }
    }
    */
}
