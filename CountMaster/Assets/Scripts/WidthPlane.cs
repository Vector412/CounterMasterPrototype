using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WidthPlane : MonoBehaviour
{
    public Renderer rend;

    public static float width;
    void Start()
    {
        rend = GetComponent<Renderer>();
        width = rend.bounds.extents.magnitude;
        Debug.Log(width);
    }
    
    
    
}
