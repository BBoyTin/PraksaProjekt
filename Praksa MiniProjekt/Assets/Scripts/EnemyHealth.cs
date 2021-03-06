﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public GameObject deathExplosion;
    //public List<GameObject> powerUps;

    float currentHealth;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;

        if (currentHealth <= 0)
            Death();
    }

    void Death()
    {
        Instantiate(deathExplosion, transform.position, transform.rotation);
        //GameObject.Find("ScoreSistem").GetComponent<ScoreSistem>().UpdateScore(40);
        Destroy(this.gameObject);

        /*
        if (Random.Range(1, 100) < 35)
        {
            Instantiate(powerUps[Random.Range(0, powerUps.Count - 1)], transform.position, transform.rotation, null);
        }
        */
    }
}
