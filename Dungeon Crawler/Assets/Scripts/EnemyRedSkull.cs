using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Video Reference https://www.youtube.com/watch?v=NbA95f1FlXQ&t=58s&ab_channel=AlexanderZotov

public class EnemyRedSkull : MonoBehaviour
{

    private float dirX;
    private float moveSpeed;
    private Rigidbody2D rb;
    private Vector3 localScale;

    
   
    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        dirX = -1f;
        moveSpeed = 3f;

        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Wall>())
        {
            dirX *= -1f;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
    }



    

}
