using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    public GameObject player;
    private float timer = 3.0f;
    private bool move = false;
    private float speed = 5.0f;
    public AudioSource soundPlayer;
    private bool hasPlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Countdown());
        player = GameObject.Find("Student");
    }

    // Update is called once per frame
    void Update()
    {
        if (move == true)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
    }

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(timer);
        if(!hasPlayed)
        {
            soundPlayer.Play();
            hasPlayed = true;
        }
        move = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Student")
        {
            Debug.Log("Hit");
            player.transform.position = player.transform.position + new Vector3(25, 10, 0);
        }
    }
}
