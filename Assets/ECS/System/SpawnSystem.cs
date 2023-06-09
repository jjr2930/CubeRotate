using System;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public partial struct SpawnSystem : ISystem
{
    Unity.Mathematics.Random random;

    public void OnCreate(ref SystemState state)
    {
        random = new Unity.Mathematics.Random();
        random.InitState();
        state.RequireForUpdate<Spawner>();
    }
	public void OnUpdate(ref SystemState state)
	{
        foreach (RefRW<Spawner> spawner in SystemAPI.Query<RefRW<Spawner>>())
        {
            ProcessSpawner(ref state, spawner);
        }
    }

    private void ProcessSpawner(ref SystemState state, RefRW<Spawner> spawner)
    {
        var maxCount = spawner.ValueRO.maxCount;

        if (spawner.ValueRW.createdCount >= maxCount)
            return;

        int createCountPerFrame = spawner.ValueRO.creacteCountPerFrame;
        for (int i = 0; i < createCountPerFrame && spawner.ValueRO.createdCount < spawner.ValueRW.maxCount; i++)
        {
            float3 randomPosition = new float3(
                random.NextFloat(-20, 20),
                random.NextFloat(-20, 20),
                random.NextFloat(-20, 20));

            Entity newEntity = state.EntityManager.Instantiate(spawner.ValueRO.prefabEntity);

            state.EntityManager.SetComponentData(newEntity, LocalTransform.FromPosition(randomPosition));
            spawner.ValueRW.createdCount++;
            CountClass.createdCount = spawner.ValueRW.createdCount;
        }
    }
}

