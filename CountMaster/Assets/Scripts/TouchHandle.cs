using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchHandle : MonoBehaviour

{  
    [SerializeField] PlayerManager playerManager;
    [SerializeField] float controlSpeed;
    [SerializeField] bool isTouching;
    
    [Header("Доп смещение левой и правой границы")]
    [SerializeField] private float offset;
    
    float _touchPosX;
    Vector3 _direction;
    private float border;
    private ChunkPlacer _chunkPlacer;

    private void Start()
    {
        border = WidthPlane.width / 2 + offset;
    }

    void Update()
    {
        GetInput();
    }

    private void FixedUpdate() {
        
        if(playerManager.playerState==PlayerManager.PlayerState.Move)
        {
            transform.position += Vector3.forward * Moving.speed * Time.fixedDeltaTime;
        }
        if(isTouching )
        {
            _touchPosX += Input.GetAxis("Mouse X") * controlSpeed *Time.fixedDeltaTime;
        }

        
      if(_touchPosX > -border && _touchPosX < border)
        {
            transform.position = new Vector3(_touchPosX, transform.position.y, transform.position.z);
        }

        
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

