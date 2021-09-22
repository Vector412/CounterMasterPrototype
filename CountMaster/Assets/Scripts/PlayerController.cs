using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ParticleSystem deathParticle;
    private Animator playerAnimationController;
    public GameObject target;
    
   
    private void Start()
    {
    }

    public void OnDestroy()
    {
        deathParticle.Play();
        //Destroy(gameObject);
    }


    private void Update()
    {
        
      
    }
}
