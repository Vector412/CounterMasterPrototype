using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ParticleSystem deathParticle;
    private Animator playerAnimationController;

    private void Enable()
    {
        
    }


    public void OnDestroy()
    {
        deathParticle.Play();
        //Destroy(gameObject);
    }


}
