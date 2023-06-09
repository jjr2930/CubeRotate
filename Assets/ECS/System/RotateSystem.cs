using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public partial struct RotateSystem : ISystem
{
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<Rotation>();
    }

    public void OnUpdate(ref SystemState state)
    {
        foreach (var (localTransform, rotation)
            in SystemAPI.Query<RefRW<LocalTransform>, RefRW<Rotation>>())
        {
            var rotateSpeed = rotation.ValueRO.rotateSpeed * SystemAPI.Time.DeltaTime ;
            rotateSpeed = math.radians(rotateSpeed);
            quaternion delta = quaternion.RotateY(rotateSpeed);
            var nextRot = Unity.Mathematics.math.mul(localTransform.ValueRO.Rotation, delta);
            localTransform.ValueRW.Rotation = nextRot;
        }
    }
}
