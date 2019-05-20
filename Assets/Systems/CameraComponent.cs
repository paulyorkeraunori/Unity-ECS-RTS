using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class CameraComponent : ComponentSystem
{
    private EntityQuery query;

    protected override void OnCreate()
    {
        query = GetEntityQuery(
            ComponentType.ReadOnly<PlayerInput>());
    }

    protected override void OnUpdate()
    {
        var mainCamera = Camera.main;
        if (mainCamera == null)
        {
            return;
        }

        Entities.With(query).ForEach(
            (Entity entity, ref PlayerInput data) =>
            {
                if (data.Left)
                {
                    mainCamera.transform.Translate(Vector3.left * 0.001f, Space.World);
                }

                if (data.Right)
                {
                    mainCamera.transform.Translate(Vector3.right * 0.001f, Space.World);
                }

                if (data.Up)
                {
                    mainCamera.transform.Translate(Vector3.forward * 0.001f, Space.World);
                }

                if (data.Down)
                {
                    mainCamera.transform.Translate(Vector3.back * 0.001f, Space.World);
                }

            }
        );
    }

}
