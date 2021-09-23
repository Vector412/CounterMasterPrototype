using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyManager : MonoBehaviour
{
    public List<Friendly> friendlyObjects;

    private void Start()
    {
        EventManager.SpawnFriendlyPlayers += FriendlyList;
        EventManager.CollisionPLayer += TryReleaseCollision;
    }

    private void FriendlyList(Friendly friend)
    {
        friendlyObjects.Add(friend);
    }

    private bool TryReleaseCollision(Friendly friend)
    {
        var fr = friendlyObjects.Find(x => friend);

        if (fr.IsMarkedForRemove)
        {
          
            return false;
            
        }
        else
        {
            fr.IsMarkedForRemove = true;
            Destroy(fr.gameObject);
          
            return true;
        }

        
     
        
        
    }
}

