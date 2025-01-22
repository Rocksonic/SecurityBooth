using Godot;
using System;
public partial class ThrowDice : Node
{
    [Export] private Node3D _dice;
    [Export] private Node3D body;
    [Export] public float throwForce;
    private RigidBody3D rigidBody;
    public Node3D Dice { get; set; }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {

    }

    public override void _PhysicsProcess(double delta)
    {
        if (Input.IsActionJustPressed("Shoot") && Dice != null)
        {
            GD.Print(Dice.Name);
            ThrowTheDice(Dice.GetNode<RigidBody3D>("../DicePhysics"));
        }
    }


    public void ThrowTheDice(RigidBody3D rb)
    {
        rb.ApplyForce((Dice.GlobalPosition - body.GlobalPosition) * throwForce);
    }
}

