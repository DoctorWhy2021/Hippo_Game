using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    void Start()
    {
            
        Invoke("ObjectDestroy", 0.2f);
    }

    void ObjectDestroy()
    {
        Destroy(gameObject);
    }
}
