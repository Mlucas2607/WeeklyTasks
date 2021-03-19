using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform firingPoint;
    public float projectileSpeed = 1000;
    public GameObject projectilePrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            GameObject projectileInstance;

            projectileInstance = Instantiate(projectilePrefab, firingPoint.position, firingPoint.rotation);

            projectileInstance.GetComponent<Rigidbody>().AddForce(firingPoint.forward * projectileSpeed);

            Destroy(projectileInstance, 5);
        }
    }
}
