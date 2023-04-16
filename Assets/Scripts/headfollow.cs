using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headfollow : MonoBehaviour
{
    public GameObject player;
    GameObject[] children = new GameObject[3];
    Vector3 newPosition;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Student");
        for (int i = 0; i < 3; i++)
        {
            children[i] = transform.GetChild(i).gameObject;
        }
        StartCoroutine(headpop());
    }

    // Update is called once per frame
    void Update()
    {
        newPosition = gameObject.transform.position;
        if (player != null)
        {
            newPosition.y = player.transform.position.y + 3;
        }
        gameObject.transform.position = newPosition;
    }

    IEnumerator headpop()
    {
        yield return new WaitForSeconds(3.0f);
        for (int i = 0; i < 3; i++)
        {
            children[i].SetActive(true);
        }
    }
}
