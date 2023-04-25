using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilProjectile : MonoBehaviour
{
    [SerializeField] float speed = 30.0f;
    private GameObject border;
    // Start is called before the first frame update
    Border pencilcheck;
    void Start()
    {
        border = GameObject.Find("Pusher");
        pencilcheck = border.GetComponent<Border>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        // Debug.Log("Pencil has hit " + other);
        if (other.gameObject.name == "Pusher")
        {
            // Debug.Log("Argh");
            
            pencilcheck.pencilhit = true;
            // Debug.Log("pencilcheck pencilhit is now " + pencilcheck.pencilhit);
            Destroy(gameObject);
        }
    }
}
