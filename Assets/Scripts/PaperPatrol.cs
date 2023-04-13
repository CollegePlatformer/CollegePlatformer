using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperPatrol : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1f;

    public Rigidbody paperRb;
    public BoxCollider groundCheck;

    private bool isFlipped = false;

    // Start is called before the first frame update
    void Start()
    {
        paperRb.velocity = new Vector3(moveSpeed, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isFlipped)
        {
            groundCheck.center = new Vector3(-0.18f, groundCheck.center.y, groundCheck.center.z);
        } else if(isFlipped)
        {
            groundCheck.center = new Vector3(-0.225f, groundCheck.center.y, groundCheck.center.z);
        }

        /*
         if(IsFacingRight())
         {
            //Debug.Log("is facing right");
            paperRb.velocity = new Vector3(moveSpeed, 0f, 0f);
         } else
         {
            Debug.Log("is facing left");
            paperRb.velocity = new Vector3(-moveSpeed, 0f, 0f);
         } 
        */
    }

    /*
    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }
    */

    private void OnTriggerExit(Collider other) 
    {
        isFlipped = !isFlipped;
        Debug.Log("exited");
        //transform.localScale = new Vector3(-(Mathf.Sign(paperRb.velocity.x)), transform.localScale.y, transform.localScale.z);
        //transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        paperRb.velocity = new Vector3(-paperRb.velocity.x, 0f, 0f);
    }
}
