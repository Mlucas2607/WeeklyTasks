using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    

    void FixedUpdate()
    {
        RaycastHit hit;

        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if(Physics.Raycast(transform.position, fwd, out hit, 10))
        {
            print(hit.collider.name);

            if(hit.collider.CompareTag("Target"))
            {
                hit.collider.GetComponent<Renderer>().material.color = Color.green;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Target"))
        {
            collision.collider.GetComponent<Renderer>().material.color = Color.red;

            Destroy(collision.collider.gameObject, 1f);

            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        
    }
}
