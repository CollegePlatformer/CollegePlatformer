using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class skin_change : MonoBehaviour
{
    public Material newMaterialRef;
    // Material redMaterial = new Material(Shader.Find("Standard"));
    // redMaterial.color = Color.red;
    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
        Material material = meshRenderer.material;
        // newMat = Material.Load("Pink", typeof(Material)) as Material;
        // meshRenderer.material = newMat;
        StartCoroutine(ChangeSkinColor(material, meshRenderer));
        Debug.Log("AAAAA");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ChangeSkinColor(Material input, MeshRenderer meshR)
    {
        yield return new WaitForSeconds(2.0f);
        // gameObject.meshRenderer.material = newMat;
        meshR.material = newMaterialRef;
        // input.color = Color.magenta;
        // input = newmat;
    }
}
