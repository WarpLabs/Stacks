using UnityEngine;
using System.Collections;

public class Spinning : MonoBehaviour {

	public float SpinSpeed;
	public Vector3 SpinDirection;
	public bool UseRandomDirection;
	public Rigidbody PhysicsBody;

	void Start () {

		float lengthDifference = SpinSpeed /= SpinDirection.magnitude;

		int integerDiff = (int)(lengthDifference + 1f);

		for (int i = 0; i < integerDiff; i++) {

			PhysicsBody.AddForce (SpinDirection);

		}

	}


}
