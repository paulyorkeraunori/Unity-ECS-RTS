using System;
using Unity.Entities;
using Unity.Mathematics;

public struct PlayerInput : IComponentData
{
    public bool LeftClick;
    public bool RightClick;
    public bool Left;
    public bool Right;
    public bool Up;
    public bool Down;
}
