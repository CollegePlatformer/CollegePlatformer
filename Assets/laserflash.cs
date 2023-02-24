using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.Universal;
using UnityEngine;

public class laserflash : MonoBehaviour
{
    // private new Renderer renderer;
    private Material material;
    public float alpha = 0f;
    // Start is called before the first frame update
    void Start()
    {
        // renderer = GetComponent<Renderer>();
        // Material material = renderer.material;
        // Color color = material.color;
        // color.a = 0f;
        // material.color = color;
        // gameObject.renderer.color.a = 0.5;
        Renderer renderer = GetComponent<Renderer>();
        material = renderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        // if (renderer != null)
        // {
        //     // Get the material of the Renderer component
        //     Material material = renderer.material;

        //     // Set the alpha value of the material color to make it transparent
        //     Color color = material.color;
        //     color.a = 0.5f; // Set the alpha value to 0.5 (50% transparent)
        //     material.color = color;
        // }
        Color color = material.color;
        color.a = alpha;
        material.color = color;
    }


}
