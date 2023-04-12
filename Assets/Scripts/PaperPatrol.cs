using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperPatrol : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1f;

    Rigidbody paperRb;
    BoxCollider groundCheck;

    // Start is called before the first frame update
    void Start()
    {
        paperRb = GetComponent<Rigidbody>();
        groundCheck = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
