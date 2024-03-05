using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Torch : MonoBehaviour
{
    private CircleCollider2D collider;
    private Animator animator;

    void Start()
    {
        collider = GetComponent<CircleCollider2D>();
        animator = GetComponent<Animator>();
    }//end start

    public void MakeTorchLit()
    {
        animator.SetBool("isLit", true);
    }//end MakeTorchLit

    public void MakeTorchUnlit()
    {
        animator.SetBool("isLit", false);
    }//end MakeTorchUnlit

}
