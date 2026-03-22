using Godot;
using System;

public partial class HealthComponent : Node
{
    [Export]
    public float Health {get; set;}
    [Export]
    public float DrainRate {get; set;}
    public override void _Process(double delta)
    {
        if(Health > 0)
        {
            Health -= DrainRate ;
        } else
        {
            GD.Print("0 Health");
        }
    }

}
