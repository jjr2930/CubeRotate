using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class SpawnerAuthoring : MonoBehaviour
{
    public GameObject cubePrefab;
    public int maxCount;
    public int createCountPerFrame;
}

public class SpawnerBaker : Baker<SpawnerAuthoring>
{
    public override void Bake(SpawnerAuthoring authoring)
    {
        var entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity, new Spawner
        {
            createdCount = 0,
            maxCount = authoring.maxCount,
            creacteCountPerFrame = authoring.createCountPerFrame,
            prefabEntity = GetEntity(authoring.cubePrefab, TransformUsageFlags.Dynamic)
        });
    }
}
