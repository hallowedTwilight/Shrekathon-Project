using Godot;
using System;

public partial class HealthComponent : Node
{
    public float Health {get; set;}
    public float DrainRate {get; set;}
    public override void _Process(double delta)
    {
        if(Health > 0)
        {
            Health -= DrainRate * (float) delta;
        }
    }

}
