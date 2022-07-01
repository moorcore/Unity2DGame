using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public Asteroid asteroidPrefab;

    public float spawnRate = 2.5f;

    public float spawnDistance = 15.0f;

    public float trajectoryVariety = 18.0f;

    public int spawnAmount = 1;

    void Start()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void Spawn()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * spawnDistance;
            Vector3 spawnpoint = transform.position + spawnDirection;

            float variety = Random.Range(-trajectoryVariety, trajectoryVariety);
            Quaternion rotation = Quaternion.AngleAxis(variety, Vector3.forward);
            
            Asteroid asteroid = Instantiate(asteroidPrefab, spawnpoint, rotation);
            asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize);
            asteroid.SetTrajetory(rotation * -spawnDirection);
        }
    }
}
