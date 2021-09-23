using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    private bool IsCollisionApplied;

    private void Start()
    {
        EventManager.SendAnswerAboutCollision += ResultCollision;
    }

    private void OnCollisionEnter(Collision other)
    {
        if(IsCollisionApplied)
            return;
        
        if (other.collider.CompareTag("Player_Cloned"))
            return;

        if (other.collider.CompareTag("Player"))
        {
            var friend = GetComponent<Friendly>();
            if (friend != null)
            {
                EventManager.OnCollisionPLayer(friend);
            }

        }
    }

    private void ResultCollision(bool isCollisionApplied)
    {
        if (this.IsCollisionApplied)
        {
            Destroy(gameObject);
        }
    }
}
