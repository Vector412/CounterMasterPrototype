using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WidthPlane : MonoBehaviour
{
    private Renderer _rend;
    public static float width;
    
   private void Start()
    {
        _rend = GetComponent<Renderer>();
        width = _rend.bounds.extents.magnitude;
    }
    
    
    
}
