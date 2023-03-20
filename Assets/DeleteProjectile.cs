using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteProjectile : MonoBehaviour
{
    // based on script by GDTitans video (insert link later)
    [SerializeField] private float persistTime;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, persistTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
