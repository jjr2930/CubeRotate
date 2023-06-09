using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefab = null;

    [SerializeField]
    int spawnCountPerFrame = 100;

    [SerializeField]
    int maxSpawnCount = 100000;

    [SerializeField]
    int createdCount = 0;

    public int CreatedCount { get => createdCount; set => createdCount = value; }

    private void Update()
    {
        for (int i = 0; i < maxSpawnCount && createdCount < maxSpawnCount; i++)
        {
            Vector3 position = new Vector3(
                Random.Range(-20, 20),
                Random.Range(-20, 20),
                Random.Range(-20, 20));

            Instantiate(prefab, position, Quaternion.identity);
            createdCount++;
            CountClass.createdCount = createdCount;
        }
    }
}
