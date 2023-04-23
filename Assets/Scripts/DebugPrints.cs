using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugPrints : MonoBehaviour
{
    public Text debugMessage;
    [SerializeField] GameObject player;
    private float yVel;
    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Student");
        playerRb = player.GetComponent<Rigidbody>();
        yVel = playerRb.velocity.y;
    }

    // Update is called once per frame
    void Update()
    {
        yVel = playerRb.velocity.y;
        debugMessage.text = "Y: " + yVel.ToString();
    }
}
