using UnityEngine;
using System.Collections;

public class Spinning : MonoBehaviour {

	public float SpinSpeed;
	public Vector3 SpinDirection;
	public bool UseRandomDirection;
	public Rigidbody PhysicsBody;

	void Start () {

		if (UseRandomDirection) {

			float x = Random.Range (0, 1f);
			float y = Random.Range (0, 1f);
			float z = Random.Range (0, 1f);

			SpinDirection = new Vector3 (x, y, z);

		}

		for (int i = 0; i < SpinSpeed; i++) {

			PhysicsBody.AddTorque(SpinDirection);

		}

		PhysicsBody.velocity = Vector3.ClampMagnitude (PhysicsBody.velocity, SpinSpeed);



	}


}
