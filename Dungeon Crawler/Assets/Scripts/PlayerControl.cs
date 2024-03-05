using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// Video Andrew used for this code
// https://www.youtube.com/watch?v=DBGvx-cCUMw&ab_channel=EPICALUX-GameDev @ 9:00 minutes

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed;

    private bool isMoving;

    private Vector2 input;

<<<<<<< Updated upstream
    private void Update()
    {
        if (!isMoving)
=======
    public LayerMask solidObjectsLayer;

    [SerializeField]
    private GameObject ability; //The ability of the player. player 1 uses flames. player 2 uses wind. Should contain a particle system
    [SerializeField]
    private KeyCode abilityInput; //Key to be pressed to activate the players ability

    private int startRotationX; //The starting rotation of the ability's x-axis

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
            //Rotates the ability to the left
            startRotationX = 180;

        }//end if

        if (Input.GetKeyDown("d"))
        {
            //Rotates the ability to the right
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

    }//end Update

    private void FixedUpdate()
    {
        var targetPos = transform.position;
        if (isWalkable(targetPos))
>>>>>>> Stashed changes
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input != Vector2.zero)
            {
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                StartCoroutine(Move(targetPos));
            }
        }
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            targetPos = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

        isMoving = false;
    }
}
