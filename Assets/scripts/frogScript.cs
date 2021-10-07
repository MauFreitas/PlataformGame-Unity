using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frogScript : MonoBehaviour
{
    
    private Rigidbody2D rig;
    private Animator ani;


    public float speed;
    public Transform rightL;
    public Transform leftL;

    public Transform headP;

    private bool colliding;

    public BoxCollider2D box2d;
    public CircleCollider2D circle2D;

    public LayerMask layer; 
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rig.velocity = new Vector2(speed, rig.velocity.y);

        colliding = Physics2D.Linecast(rightL.position, leftL.position, layer);

        if (colliding)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
            speed = -speed;
        }

    }
     private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            float height = col.contacts[0].point.y - headP.position.y;
            if(height > 0)
            {
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 12,ForceMode2D.Impulse);
                speed = 0;
                ani.SetTrigger("die");
                box2d.enabled = false;
                circle2D.enabled = false;
               
                Destroy(gameObject, 1.04f);
            }
            else
            {
                GameCC.instance.ShowGameOver();
                Destroy(col.gameObject);
            }
          
            
        }
    }
}
