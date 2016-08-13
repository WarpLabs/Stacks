using UnityEngine;
using System.Collections;

public class PillarControl : MonoBehaviour {

	public Color NormalColor;

	public GameObject Body;

	private Renderer Rend;

	void Start () {

		Rend = Body.GetComponent<Renderer> ();
		ChangeColor (NormalColor);

	}

	public void Reset () {

		ChangeColor (NormalColor);

	}

	public void ChangeHeight (float Speed, float Count, bool Gradual) {

		if (Gradual)
			StartCoroutine (GradualHeightChange (Speed, Count));
		else {
			float GrowAmount = Time.deltaTime * Speed;

			Body.transform.localScale = new Vector3 (Body.transform.localScale.x, Body.transform.localScale.y + GrowAmount, Body.transform.localScale.z);
			Body.transform.position = new Vector3 (Body.transform.position.x, Body.transform.position.y + GrowAmount / 2, Body.transform.position.z);
		}

	}
		
	IEnumerator GradualHeightChange (float Speed, float Count) {

		for (int i = 0; i<Count; i++) {

			float GrowAmount = Time.deltaTime * Speed;

			Body.transform.localScale = new Vector3 (Body.transform.localScale.x, Body.transform.localScale.y + GrowAmount, Body.transform.localScale.z);
			Body.transform.position = new Vector3 (Body.transform.position.x, Body.transform.position.y + GrowAmount / 2, Body.transform.position.z);

			yield return null;

		}

	}
		
	public void ChangeColor (Color targetColor) {

		Rend.material.SetColor ("_Color", targetColor);

	}

}
