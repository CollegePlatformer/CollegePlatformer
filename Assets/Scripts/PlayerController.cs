using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float walkSpeed = 10.0f;
    [SerializeField] float jump = 5.0f;
    [SerializeField] float gravityModifier = 1.0f;
    private float horizontalInput;
    private int jumpCount = 2;
    private bool isOnGround = true;
    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(jumpCount);
        playerMovement();
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            Debug.Log("jump input pressed");
            //Debug.Log(jumpCount);

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
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * walkSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isOnGround = true;
            jumpCount = 2;
            Debug.Log(collision.gameObject.tag);
        }
    }
}
