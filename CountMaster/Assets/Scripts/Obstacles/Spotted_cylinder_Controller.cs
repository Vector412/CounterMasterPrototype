using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spotted_cylinder_Controller : MonoBehaviour
{
    public float _speed;
    private float speed;

    private void Start()
    {
        if (transform.position.x > 0) speed = _speed;
        else speed = -_speed;
    }

    void Update()
    {
       transform.Rotate(0, 0, Time.deltaTime * speed * 100);
    }
}
