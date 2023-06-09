using System;
using Unity.Entities;

public struct Spawner : IComponentData
{
    public Entity prefabEntity;
    public int maxCount;
    public int createdCount;
    public int creacteCountPerFrame;
}

