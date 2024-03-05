using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 2f;

    [SerializeField]
    private GameObject ability; //The ability of the player. player 1 uses flames. player 2 uses wind. Should contain a particle system
    [SerializeField]
    private KeyCode abilityInput; //Key to be pressed to activate the players ability
    private int startRotationX; //The starting rotation of the ability's x-axis

    private Rigidbody2D rb;

    private Vector2 movementDirection;

    public LayerMask solidObjectsLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (Input.GetKeyDown("w"))
        {
            //Rotates the ability up
            startRotationX = -90;
        }//end if

        if (Input.GetKeyDown("s"))
        {
            //Rotates the ability down
            startRotationX = 90;
        }//end if

        if (Input.GetKeyDown("a"))
        {
            //Rotates the ability to the right
            startRotationX = 180;
        }//end if

        if (Input.GetKeyDown("d"))
        {
            //Rotates the ability to the left
            startRotationX = 0;
        }//end if

        if (Input.GetKeyDown(abilityInput))
        {
            ability.transform.rotation = Quaternion.Euler(startRotationX, 90, 90);
            ability.GetComponent<ParticleSystem>().Play();
        }//end if
        if (Input.GetKeyUp(abilityInput))
        {
            ability.GetComponent<ParticleSystem>().Stop();
        }//end if

    }

    private void FixedUpdate()
    {
        var targetPos = transform.position;
        if (isWalkable(targetPos))
        {
            rb.velocity = movementDirection * movementSpeed;
        }
            
    }

    private bool isWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer) != null)
        {
            return false;
        }

        return true;
    }
}
