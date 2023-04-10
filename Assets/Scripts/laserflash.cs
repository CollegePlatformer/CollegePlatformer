using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.Universal;
using UnityEngine;

public class laserflash : MonoBehaviour
{
    // private new Renderer renderer;
    [SerializeField] GameObject player;
    private Material material;


    
    Collider m_Collider;
    public float alpha = 0f;
    // Start is called before the first frame update
    public bool destroyit = false;
    public bool hit = false;
    health playerhealth;
    void Start()
    {
        player = GameObject.Find("Student");
        Renderer renderer = GetComponent<Renderer>();
        playerhealth = player.GetComponent<health>();
        m_Collider = GetComponent<Collider>();
        material = renderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        Color color = material.color;
        color.a = alpha;
        material.color = color;
        StartCoroutine(laserphase());
        if (alpha == 1f)
        {
            m_Collider.enabled = !m_Collider.enabled;
        }
    }

    IEnumerator laserphase()
    {
        yield return new WaitForSeconds(3f);
        alpha = 0.5f;
        yield return new WaitForSeconds(3f);
        alpha = 1f;
        yield return new WaitForSeconds(1f);
        destroyit = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (alpha == 1f && hit == false)
        {
            hit = true;
            StartCoroutine(playerhealth.Hit());
        }
    }
}
