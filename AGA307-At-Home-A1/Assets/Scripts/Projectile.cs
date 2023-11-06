using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject projectile;
    public float projectileSpeed = 1000;
    public Transform firingPoint;

    public int damage = 20;

    private void Start()
    {
        Destroy(this.gameObject, 5);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Target"))
        {
            collision.collider.GetComponent<Renderer>().material.color = Color.blue;
            Destroy(collision.collider.gameObject, 1f);
            Destroy(this.gameObject);
        }
    }
}
