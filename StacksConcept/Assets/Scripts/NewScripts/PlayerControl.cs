using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float GrowSpeed = 1f;
	public float ShrinkSpeed = 1f;

	public static float DebugRayAdjust = 1f;

	void OnCollisionEnter (Collision other) {



	}

	void OnCollisionStay (Collision other) {

		PillarControl Pillar = other.gameObject.GetComponentInParent<PillarControl> ();
		if (Pillar != null) {
			CheckPillar (other, Pillar);
		}

	}

	void OnCollisionExit (Collision other) {



	}

	void CheckPillar (Collision other, PillarControl Pillar) {

		string collisionSide = PlayerControl.FindCollisionSide (other, transform.position);

		float changeSpeed = 0f;

		if (collisionSide == "Top") {

			changeSpeed = GrowSpeed;

		} else if (collisionSide == "Right" || collisionSide == "Left") {
			
			changeSpeed = -ShrinkSpeed;

		}

		Pillar.ChangeHeight (changeSpeed, -1, false);

	}

	public static string FindCollisionSide (Collision other, Vector3 mainPosition) {

		Vector3 otherPosition = Vector3.zero;

		float adjustedY = other.gameObject.transform.position.y;
		adjustedY += other.gameObject.transform.localScale.y / 2;
		adjustedY -= DebugRayAdjust;

		otherPosition = new Vector3 (other.gameObject.transform.position.x, adjustedY, other.gameObject.transform.position.z);

		string side = "";

		Vector3 direction = (otherPosition - mainPosition).normalized;
		Ray detectRay = new Ray (mainPosition, direction);
		RaycastHit hitRay;

		Physics.Raycast (detectRay, out hitRay);

		Vector3 rayNormal = hitRay.normal;
		rayNormal = hitRay.transform.TransformDirection (rayNormal);

		if (rayNormal == hitRay.transform.up) {
			side = "Top";
		} else if (rayNormal == -hitRay.transform.up) {
			side = "Bottom";
		} else if (rayNormal == hitRay.transform.right) {
			side = "Right";
		} else if (rayNormal == -hitRay.transform.right) {
			side = "Left";
		}

		return side;

	}

}
