using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowdown : MonoBehaviour
{
    public GameObject border;
    Border bordergameobject;
    // private bool slow = false;
    private bool part2 = false;
    private float slowduration = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        border = GameObject.Find("Pusher");
        bordergameobject = border.GetComponent<Border>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bordergameobject.slow == true)
        {
            StartCoroutine(slowstart());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Student")
        {
            bordergameobject.slow = true;
        }
    }

    IEnumerator slowstart()
    {
        if (part2 == true)
        {
            slowduration = 6.0f;
        }
        // slow = false;
        bordergameobject.speed = 3f;
        yield return new WaitForSeconds(slowduration);
        bordergameobject.speed = bordergameobject.speedlevel1;
        if (part2 == false)
        {
            part2 = true;
        }
        bordergameobject.slow = false;
    }
}
