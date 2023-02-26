using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.Universal;
using UnityEngine;

public class laserflash : MonoBehaviour
{
    // private new Renderer renderer;
    // [SerializeField] GameObject player;
    private Material material;
    public float alpha = 0f;
    // Start is called before the first frame update
    public bool destroyit = false;
    // health playerhealth;
    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        // playerhealth = player.GetComponent<health>();
        material = renderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        Color color = material.color;
        color.a = alpha;
        material.color = color;
        StartCoroutine(laserphase());
        Debug.Log("here");
    }

    IEnumerator laserphase()
    {
        yield return new WaitForSeconds(3f);
        alpha = 0.5f;
        yield return new WaitForSeconds(3f);
        alpha = 1f;
        yield return new WaitForSeconds(3f);
        Debug.Log("Destroyed");
        destroyit = true;
    }

    // void OnTriggerEnter(Collider other)
    // {
    //     if (alpha == 1f && other.gameObject.name == "Templayer")
    //     {
    //         playerhealth.lives--;
    //     }
    // }
}
