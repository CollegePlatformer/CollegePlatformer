using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePlatform : MonoBehaviour
{
    [SerializeField]
    private float bounceMultiplier = 5000f;

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * bounceMultiplier, ForceMode.Impulse);
        }
    }
}
