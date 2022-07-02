using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy enemyPrefab;

    public float spawnRate = 5.0f;

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

            Instantiate(enemyPrefab, spawnpoint, transform.rotation);
            FindObjectOfType<AudioManager>().Play("enemysound");
        }
    }
}
