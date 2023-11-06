using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringPoint : MonoBehaviour
{
    [Header("RigidbodyProjectiles")]
    public GameObject bullet;
    public float projectileSpeed = 1000f;


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            FireRigidbody();
    }

    void FireRigidbody()
    {
        //Create a ref to hold instanciated object
        GameObject projectileInstance;
        //Instantiate our projectile at this objects position
        projectileInstance = Instantiate(bullet, transform.position, transform.rotation);
        //Add force to the projectile rigidbody
        projectileInstance.GetComponent<Rigidbody>().AddForce(transform.forward * projectileSpeed);
        Destroy(projectileInstance, 2);
    }
}
