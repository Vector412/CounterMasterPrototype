using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dead : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(1);
        if (other.gameObject.CompareTag("Enemy"))
            Destroy(other.gameObject);

    }
    

}
