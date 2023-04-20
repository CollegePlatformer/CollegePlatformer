using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapsingBook : MonoBehaviour
{
    private Rigidbody bookRb;

    public float timeToFall = 1;

    // Start is called before the first frame update
    void Start()
    {
        bookRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(Collapse());
        }
    }

    IEnumerator Collapse()
    {

        Debug.Log("Starting collapse");
        yield return new WaitForSeconds(timeToFall);


        //bookTransform.position -= transform.up;
        bookRb.isKinematic = false;
        bookRb.useGravity = true;
        

        Debug.Log("Collapsed");
    }
}
