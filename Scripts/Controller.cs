using Godot;
using System;

public partial class Controller : RigidBody3D
{
	[Export] private float speed = 1.0f;
	[Export] private float fallingSpeed = 9.8f;
	private Vector3 direction;
	private Vector3 velocity;
	private KinematicCollision3D collision;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
		GD.Print("Working");
		velocity = Vector3.Zero;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public override void _PhysicsProcess(double delta)
	{
		direction = Vector3.Zero;
        if (Input.IsActionPressed("Forward"))
        {
			direction.Z++;
        }
        if (Input.IsActionPressed("Backwards"))
        {
            direction.Z--;
        }
        if (Input.IsActionPressed("Left"))
		{
			direction.X++;
		}

        if (Input.IsActionPressed("Right"))
        {
            direction.X--;
        }

        if (Input.IsActionPressed("Jump"))
        {
			GD.Print("Jumping");
        }

        velocity.X = direction.X;
		velocity.Z = direction.Z;
		velocity = velocity.Normalized() * speed;

        collision = MoveAndCollide(velocity);
    }
}
