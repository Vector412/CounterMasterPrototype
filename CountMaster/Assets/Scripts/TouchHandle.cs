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
    
    float _touchPosX;
    Vector3 _direction;

    private ChunkPlacer _chunkPlacer;

    private void Start()
    {
       // _chunkPlacer = GetComponent<ChunkPlacer>();
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

        
     //   if(_touchPosX < _chunkPlacer.WidthObject())
      //  if (_touchPosX > 0 && _touchPosX < 4 || _touchPosX < 0 && _touchPosX > -4)
      if(_touchPosX > -WidthPlane.width/2 && _touchPosX < WidthPlane.width/2)
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

