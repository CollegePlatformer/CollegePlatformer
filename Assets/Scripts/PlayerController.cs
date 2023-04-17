using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float walkSpeed = 10.0f;
    [SerializeField] float jump = 5.0f;
    [SerializeField] float gravityModifier = 1.0f;
    [SerializeField] GameObject shot, shootPoint;
    [SerializeField] float fallGravityModifierFactor;

    public AudioSource pencilSound;
    public AudioSource jumpSound;
    private float turnSpeed = 5f;
    private float horizontalInput;
    private int jumpCount = 2;
    public bool atFinish = false;
    public bool isDead = false;
    private bool isOnGround = true;
    private Rigidbody playerRb;
    private Animator studentAnim;
    private bool hasPencilPlayed = false;
    private bool hasJumpPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        studentAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(jumpCount);
        //playerMovement();
        //Debug.Log("horizontalInput: " + horizontalInput);

        horizontalInput = Input.GetAxisRaw("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        direction.Normalize();

        transform.Translate(direction * walkSpeed * Time.deltaTime, Space.World);

        if (direction != Vector3.zero)
        {
            //transform.forward = direction;
            Vector3 toRotation = Vector3.RotateTowards(transform.forward, direction, Time.deltaTime * turnSpeed, 0.0f);
            transform.rotation = Quaternion.LookRotation(direction);
        }

        if (horizontalInput != 0)
        {
            studentAnim.SetBool("Run_Anim", true);
        }
        else
        {
            studentAnim.SetBool("Run_Anim", false);
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.P)) && isOnGround)
        {
            //Debug.Log("jump input pressed");
            //Debug.Log(jumpCount);
            //studentAnim.SetBool("Jump_Anim", true);
            //studentAnim.SetBool("Run-Jump", true);
            playerRb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            isOnGround = false;
            jumpCount--;
            if (!hasJumpPlayed)
            {
                jumpSound.Play();
                hasJumpPlayed = true;
            }
            hasJumpPlayed = false;
        }
        /*else if (Input.GetKeyDown(KeyCode.Space) && !isOnGround && jumpCount > 0)
        {
            Debug.Log("double jump pressed");
            //Debug.Log(jumpCount);

            playerRb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            jumpCount--;
        }*/
        else if (!isOnGround && (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.P)))
        {
                Debug.Log("no horizontalInput + jump released");
                playerRb.AddForce(Vector3.down * fallGravityModifierFactor, ForceMode.VelocityChange);
            
            //StartCoroutine(DelayedFall());
            // ay yo where the speedcap at
        }

        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log("shoot input pressed");
            Instantiate(shot, shootPoint.transform.position, transform.rotation);
            if (!hasPencilPlayed)
            {
                pencilSound.Play();
                hasPencilPlayed = true;
            }
            hasPencilPlayed = false;
        }

        
        if(playerRb.velocity.y > 0)
        {
            studentAnim.SetBool("Jump_Anim", true);
            studentAnim.SetBool("Run_Anim", false);
        } else
        {
            studentAnim.SetBool("Jump_Anim", false);
        }
        
    }

    /*
    void playerMovement()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        direction.Normalize();

        transform.Translate(direction * walkSpeed * Time.deltaTime, Space.World);

        if (direction != Vector3.zero)
        {
            //transform.forward = direction;
            Vector3 toRotation = Vector3.RotateTowards(transform.forward, direction, Time.deltaTime * turnSpeed, 0.0f);
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isOnGround = true;
            studentAnim.SetBool("Jump_Anim", false);
            //studentAnim.SetBool("Run-Jump", false);
            jumpCount = 2;
            //Debug.Log(collision.gameObject.tag);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Sticky"))
        {
            walkSpeed /= 2;
            jump /= 2;
            studentAnim.SetBool("Run_Slow_Anim", true);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.CompareTag("Sticky"))
        {
            walkSpeed *= 2;
            jump *= 2;
            studentAnim.SetBool("Run_Slow_Anim", false);
        }
    }
    
    /*IEnumerator DelayedFall()
    {
        yield return new WaitForSeconds(0.5f);
        playerRb.AddForce(Vector3.down * fallGravityModifierFactor, ForceMode.Impulse);
        Debug.Log("addforce");
        
    }*/
}
