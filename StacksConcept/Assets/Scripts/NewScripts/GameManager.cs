using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	[System.Serializable]
	public class SpawnControl {

		public float SpawnSpeed;
		public int SpawnCount;
		public float SpawnHeight;
		public float[] SpawnSpots;
		public GameObject[] Prefabs;

	}
	public SpawnControl Spawner;

	public GameObject Player;

	void Start () {

		StartCoroutine (SpawnCoroutine ());
	
	}

	IEnumerator SpawnCoroutine () {

		while (true) {

			float spawnX = Spawner.SpawnSpots[Random.Range (0, Spawner.SpawnSpots.Length)];

			float spawnHeight = Spawner.SpawnHeight + Player.transform.position.y;

			Vector3 spawnPos = new Vector3 (spawnX,spawnHeight,0);
			Quaternion spawnRot = new Quaternion (0, 0, 0, 0);

			GameObject spawn = Instantiate (Spawner.Prefabs[Random.Range(0,Spawner.Prefabs.Length)], spawnPos, spawnRot) as GameObject;

			yield return new WaitForSeconds (Spawner.SpawnSpeed);

		}

	}

}
