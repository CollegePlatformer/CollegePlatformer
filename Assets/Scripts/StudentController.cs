using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentController : MonoBehaviour
{
    [SerializeField] float walkSpeed = 10.0f;
    [SerializeField] float jump = 5.0f;
    [SerializeField] float gravityModifier = 1.0f;
    [SerializeField]
    private float turnSpeed = 5f;
    private float horizontalInput;
    private int jumpCount = 2;
    private bool isOnGround = true;
    private Rigidbody playerRb;
    private Animator studentAnim;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        studentAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(jumpCount);
        playerMovement();
        
        if(horizontalInput != 0)
        {
            studentAnim.SetBool("Run_Anim", true);
        }
        else
        {
            studentAnim.SetBool("Run_Anim", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            Debug.Log("jump input pressed");
            //Debug.Log(jumpCount);
            studentAnim.SetBool("Jump_Anim", true);
            studentAnim.SetBool("Run-Jump", true);
            playerRb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            isOnGround = false;
            jumpCount--;
        }
        /*else if (Input.GetKeyDown(KeyCode.Space) && !isOnGround && jumpCount > 0)
        {
            Debug.Log("double jump pressed");
            //Debug.Log(jumpCount);

            playerRb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            jumpCount--;
        }*/
    }

    void playerMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        direction.Normalize();
        
        transform.Translate(direction * walkSpeed * Time.deltaTime, Space.World);

        if(direction != Vector3.zero)
        {
            //transform.forward = direction;
            Vector3 toRotation = Vector3.RotateTowards(transform.forward, direction, Time.deltaTime * turnSpeed, 0.0f);
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isOnGround = true;
            studentAnim.SetBool("Jump_Anim", false);
            studentAnim.SetBool("Run-Jump", false);
            jumpCount = 2;
            Debug.Log(collision.gameObject.tag);
        }
    }
}
