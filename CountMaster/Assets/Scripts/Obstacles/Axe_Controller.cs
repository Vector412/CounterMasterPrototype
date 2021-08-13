using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe_Controller : MonoBehaviour, IObstacles
{
    public float _speed;
    private float yRot = 45f;

    private Transform localTransform;
    
    private string mainPlayer = "MainPlayer";
    public event Action OnKill;
    public event Action OnGameOver;
    private void Start()
    {
        localTransform = GetComponent<Transform>();
    }

    void Update()
    {
        Moving();
        //Quaternion.SlerpUnclamped(transform.rotation.ToEuler(0,0,-90), (0,0,90), _speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject && !other.CompareTag(mainPlayer))
        {
            DestroyObjects(other);
        }
        else if(other.CompareTag(mainPlayer))
        {
            OnGameOver?.Invoke();
        }
    }
    
    public  void DestroyObjects(Collider col)
    {
        Destroy(col.gameObject);
        OnKill?.Invoke();
    }

    public void Moving()
    {
        // Rotate the object around its local X axis at 1 degree per second

        transform.Rotate(0, (Mathf.PingPong(Time.time , 1.571f) - 3.92699f) /** _speed*/, 0);
        Debug.Log(Mathf.Rad2Deg*(Mathf.PingPong(Time.time, 1.571f) - 3.92699f));
        //transform.Rotate(Vector3.up , 10 * Time.deltaTime);
        
        //Vector3 axeEulerAngels = localTransform.rotation.eulerAngles;
        //Debug.Log(axeEulerAngels);
        //axeEulerAngels.y = (axeEulerAngels.y > 180) ? axeEulerAngels.y - 360 : axeEulerAngels.y;
        //axeEulerAngels.y = Mathf.Clamp(axeEulerAngels.y, 45, -45)* Time.deltaTime;
        //localTransform.rotation = Quaternion.Euler(axeEulerAngels);
        /*LimitRot();*/
       /*transform.localRotation = Quaternion.Euler(0, yRot, 0); // This clamps the xRotation (looking up and down) to a minimum of -90 degrees and a maximum of +90 degrees.*/
     
           
          
           /*if (transform.rotation.y < 45)
           {
               Debug.Log(11);
           }*/


            /*if (transform.rotation.y > -90)
            {
                transform.rotation = Quaternion.Euler(0, -90f, 0);
            }*/


    }

    private void LimitRot()
    {
     
    }
}
