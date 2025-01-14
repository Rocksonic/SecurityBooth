using Godot;
using System;

public partial class CharacterController : CharacterBody3D
{
	[Export] public Node3D head;
	public const float Speed = 5.0f;
	public const float JumpVelocity = 4.5f;

	public override void _PhysicsProcess(double delta)
	{
		Vector3 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("Jump") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 inputDir = Input.GetVector("Left", "Right", "Forward", "Backwards");

		if (inputDir != Vector2.Zero)
		{
            // Get the camera's basis vectors, but we only care about the horizontal rotation
            // We zero out the Y components to keep movement purely horizontal
            Vector3 forward = head.GlobalTransform.Basis.Z;
            forward.Y = 0;
            forward = forward.Normalized();

            Vector3 right = head.GlobalTransform.Basis.X;
            right.Y = 0;
            right = right.Normalized();

            // Combine the input with the camera direction
            Vector3 direction = (right * inputDir.X + forward * inputDir.Y).Normalized();

            velocity.X = direction.X * Speed;
            velocity.Z = direction.Z * Speed;

            // Move the character in this direction
            
        }
        
        else
        {
            // Handle stopping
            velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
            velocity.Z = Mathf.MoveToward(Velocity.Z, 0, Speed);
        }

        Velocity = velocity;
        
        MoveAndSlide();
	}
}
