using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchHandle : MonoBehaviour

{  
    [SerializeField] PlayerManager playerManager;
    [SerializeField] float controlSpeed;

    //Touch Settings
    [SerializeField] bool isTouching;
    float touchPosX;
    Vector3 direction;



    void Update()
    {
        GetInput();
    }

    private void FixedUpdate() {
        
        if(playerManager.playerState==PlayerManager.PlayerState.Move)
        {
            transform.position += Vector3.forward * Moving.speed * Time.fixedDeltaTime;
        }
        if(isTouching)
        {
            touchPosX += Input.GetAxis("Mouse X") * controlSpeed *Time.fixedDeltaTime;
        }

        transform.position = new Vector3(touchPosX, transform.position.y, transform.position.z);
    }

    void GetInput()
    {
        if(Input.GetMouseButton(0))
        {
            isTouching=true;
        }
        else
        {
            isTouching=false;
        }
    }
}

