using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float Hitpoints;
    public float MaxHitpoints = 5;
    public HPBarBehaviour HPBar;

    void Start()
    {
        Hitpoints = MaxHitpoints;
        // HPBar.SetHealth(Hitpoints, MaxHitpoints);
    }

    public void TakeHit(float damage)
    {
        Hitpoints -= damage;

        // HPBar.SetHealth(Hitpoints, MaxHitpoints);

        if (Hitpoints > 0) {
            FindObjectOfType<AudioManager>().Play("enemySight");
        }
        
        if (Hitpoints <= 0) {
            FindObjectOfType<AudioManager>().Play("shipdestroyed");
            Destroy(gameObject);
        }
    }
}
