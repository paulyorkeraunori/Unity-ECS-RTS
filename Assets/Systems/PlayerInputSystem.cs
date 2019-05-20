using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

public class PlayerInputSystem : JobComponentSystem
{
    [BurstCompile]
    struct PlayerInputJob : IJobForEach<PlayerInput>
    {
        public bool leftClick;
        public bool rightClick;
        public bool left;
        public bool up;
        public bool down;
        public bool right;

        public void Execute(ref PlayerInput input)
        {
            input.LeftClick = leftClick;
            input.RightClick = rightClick;
            input.Left = left;
            input.Right = right;
            input.Up = up;
            input.Down = down;
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {

        var job = new PlayerInputJob
        {
            leftClick = Input.GetMouseButtonDown(0),
            rightClick = Input.GetMouseButtonDown(1),
            left = Input.GetKey(KeyCode.A),
            right = Input.GetKey(KeyCode.D),
            up = Input.GetKey(KeyCode.W),
            down = Input.GetKey(KeyCode.S),
        };
        return job.Schedule(this, inputDeps);
    }
}
