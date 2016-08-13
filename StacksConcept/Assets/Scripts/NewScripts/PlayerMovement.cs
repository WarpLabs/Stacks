using UnityEngine;
using System.Collections;

public class PlayerMovement: MonoBehaviour {

	public float speed = 10.0f;

	public bool manualGravity = true;
	public float gravity = 10.0f;
	public float maxVelocityChange = 10.0f;

	public bool canJump = true;
	public float jumpHeight = 2.0f;

	private bool grounded = false;
	private Rigidbody rb;
	public float xMin;
	public float xMax;


	void Awake()
	{
		rb = GetComponent<Rigidbody>();
		rb.freezeRotation = true;
		if (manualGravity)
			rb.useGravity = false;
		else
			rb.useGravity = true;
	}

	void FixedUpdate()
	{
		// Calculate how fast we should be moving
		Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
		targetVelocity = transform.TransformDirection(targetVelocity);
		targetVelocity *= speed;

		// Apply a force that attempts to reach our target velocity
		Vector3 velocity = rb.velocity;
		Vector3 velocityChange = (targetVelocity - velocity);
		velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
		velocityChange.z = 0;
		velocityChange.y = 0;
		rb.AddForce(velocityChange, ForceMode.VelocityChange);


		if (grounded)
		{

			// Jump
			if (canJump && Input.GetKeyDown(KeyCode.UpArrow))
			{
				rb.velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
			}
		}

		// We apply gravity manually for more tuning control
		if (manualGravity)
			rb.AddForce(new Vector3(0, -gravity * rb.mass, 0));

		grounded = false;


		rb.transform.position = new Vector3
			(
				Mathf.Clamp(rb.transform.position.x, xMin, xMax),
				rb.transform.position.y,
				rb.transform.position.z
			);

	}

	void OnCollisionEnter()
	{
		grounded = true;
	}

	void OnCollisionStay()
	{
		grounded = true;
	}

	float CalculateJumpVerticalSpeed()
	{
		// From the jump height and gravity we deduce the upwards speed 
		// for the character to reach at the apex.
		return Mathf.Sqrt(2 * jumpHeight * gravity);
	}

}
