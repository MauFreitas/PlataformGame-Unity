using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruit : MonoBehaviour
{
    private SpriteRenderer sr;
    private CircleCollider2D circle;
    public GameObject particles;

    public int Score;
    
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter2D(Collider2D colliderr)
    {
        if (colliderr.gameObject.tag == "Player")
        {
            GameCC.instance.tScore += Score;
            sr.enabled = false;
            circle.enabled = false;
            particles.SetActive(true);
            GameCC.instance.tScore += Score;
            GameCC.instance.UpadeScoreText();
            Destroy(gameObject,0.25f);

        }
    }
}
