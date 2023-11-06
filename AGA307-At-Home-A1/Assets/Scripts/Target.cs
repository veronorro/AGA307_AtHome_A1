using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;

public class Target : GameBehaviour
{
    public static event Action<GameObject> OnTargetHit = null;
    public static event Action<GameObject> OnTargetDie = null;

    int baseHealth = 100;
    int maxHealth;
    public int targetHealth;
    public int myScore;

    public TargetType myType;

  
    void Start()
    {


        switch (myType)
        {
            case TargetType.T1:
                targetHealth = maxHealth = baseHealth;
                myScore = 100;
                break;

            case TargetType.T2:
                targetHealth = maxHealth = baseHealth * 2;
                myScore = 170;
                break;


            case TargetType.T3:
                targetHealth = maxHealth = baseHealth * 3;
                myScore = 270;
                break;
        }
        
    }
    public void Hit(int _damage)
    {

        _GM.AddScore(myScore);
        targetHealth -= _damage;
       

        if (targetHealth <= 0)
        {
            Die();

        }
        else
        {
            OnTargetHit?.Invoke(this.gameObject);
            _GM.AddScore(myScore);
        }

    }
    void Die()
    {
        StopAllCoroutines();
        OnTargetDie?.Invoke(this.gameObject);
        _GM.AddScore(myScore * 2);
        _TM.KillTarget(this.gameObject);
        Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Projectile"))
            Hit(collision.gameObject.GetComponent<Projectile>().damage);
    }
}
