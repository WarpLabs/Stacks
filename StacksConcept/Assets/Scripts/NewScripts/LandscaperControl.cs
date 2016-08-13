using UnityEngine;
using System.Collections;

public class LandscaperControl : MonoBehaviour {

	public float MaxVelocity;
	public LayerMask TargetLayer;

	public string Effect;
	public string[] EffectParameters;

	private Rigidbody rb;


	void Start () {

		rb = GetComponent<Rigidbody> ();
	
	}

	void Update () {

		if (rb.velocity.magnitude > MaxVelocity) {
			rb.velocity = Vector3.ClampMagnitude (rb.velocity, MaxVelocity);
		}
	
	}

	void OnTriggerEnter (Collider other) {


		if ((1<<other.gameObject.layer) == TargetLayer) {

			TriggerEffect (other);

		}

	}

	void TriggerEffect (Collider other) {

		SendMessage (Effect, other);



		Destroy (gameObject);

	}

	void Grow (Collider other) {

		int GrowAmount = int.Parse(EffectParameters[0]);
		float GrowSpeed = float.Parse (EffectParameters [1]);

		PillarControl Pillar = other.gameObject.GetComponentInParent<PillarControl> ();
		if (Pillar != null) {
			Pillar.ChangeHeight (GrowSpeed, GrowAmount, true);
		}

	}
}
