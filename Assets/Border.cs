using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    private float timer = 3.0f;
    private bool move = false;
    public float speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Countdown());
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
        move = true;
    }
}
