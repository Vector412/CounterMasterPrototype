
using UnityEngine;

public class Hole : MonoBehaviour
{
    private Transform thisTransform;
    int radius = 3;
    int power = 3;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    
    void FixedUpdate()
    {
        Vector3 explosionPos = thisTransform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            if (hit && hit.transform != thisTransform )
            {
                var rb = hit.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    Vector3 difference = hit.transform.position - thisTransform.position;
                    rb.AddForce(difference.normalized * power, ForceMode.Force);
                }
            }
        }
    }
}
