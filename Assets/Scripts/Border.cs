using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    public GameObject player;
    private float timer = 3.0f;
    private bool move = false;
    public float speed = 6.0f;
    public AudioSource soundPlayer;
    private bool hasPlayed = false;
    public bool pencilhit = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Student");
        StartCoroutine(Countdown());
    }

    // Update is called once per frame
    void Update()
    {
        if (move == true)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        if (player != null)
        {
            if (player.transform.position.x < gameObject.transform.position.x - 5)
            {
                gameObject.transform.position = player.transform.position - new Vector3(37, 0, 0);
            }
        }
        if (pencilhit)
        {
            pencilhit = false;
            StartCoroutine(Pencilstun());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Student")
        {
            // Debug.Log("Hit");
            StartCoroutine(Hit());
        }

        // if (other.gameObject.name.Contains("Blocker") || other.gameObject.tag == "Enemy")
        // {
        //     // Debug.Log("Destroy");
        //     Destroy(other.gameObject);
        // }
        Debug.Log("border has hit " + other);
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(timer);
        if (!hasPlayed)
        {
            soundPlayer.Play();
            hasPlayed = true;
        }
        move = true;
    }

    IEnumerator Hit()
    {
        move = false;
        gameObject.transform.position = gameObject.transform.position - new Vector3(25, 0, 0);
        yield return new WaitForSeconds(timer - 1);
        move = true;
    }

    IEnumerator Pencilstun()
    {
        speed = 1.0f;
        yield return new WaitForSeconds(1.0f);
        speed = 6.0f;
    }
}
