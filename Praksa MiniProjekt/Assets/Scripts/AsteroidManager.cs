﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    public int numberOfAsteroidsOnAnAxis = 5;

    public int gridSpacing = 50;

    public GameObject asteroid;

    void Start()
    {
        PlaceAsteroids();
    }

    void PlaceAsteroids()
    {
        for(int x = 0; x < numberOfAsteroidsOnAnAxis; x++)
        {
            for (int z = 0; z < numberOfAsteroidsOnAnAxis; z++)
            {
                InstantiateAsteroid(x, 0, z);
            }
        }
    }
    void InstantiateAsteroid(int x, int y, int z)
    {
        Instantiate(
            asteroid,
            new Vector3(transform.position.x + (x * gridSpacing) + AsteroidOffset(),
                transform.position.y + (y * gridSpacing) + AsteroidOffset(),
                transform.position.z + (z * gridSpacing) + AsteroidOffset()),
            Quaternion.identity,
            transform);
    }

    float AsteroidOffset()
    {
        return UnityEngine.Random.Range(-gridSpacing / 2f, gridSpacing / 2f);
    }
}
