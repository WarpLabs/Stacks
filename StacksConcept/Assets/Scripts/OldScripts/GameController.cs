using UnityEngine;
using System.Collections;
using UnityEngine.UI;


[System.Serializable]
public class SpawnBoundary
{
    public int xMin, xMax;
    public float offset;
}

public class GameController : MonoBehaviour {

    private int pillarNumber;
    private float pillarOffset;
    private Vector3 spawnPoint;
    private GameObject FallingHazard;

    public SpawnBoundary spawnBoundary;
    public Transform Player;
    public float waitTime = 10;
    public GameObject FallingHazardPrefab;
    private int Score;
    public Text ScoreText;
    

    void Update()
    {
        if (Player != null && Player.transform.position.y > Score)
        {
            Score = Mathf.RoundToInt(Player.transform.position.y);   
        }
        ScoreText.text = Score.ToString();
    }

    IEnumerator Start()
    {
        while (true)
        {
            pillarNumber = 2 * Random.Range(spawnBoundary.xMin, spawnBoundary.xMax);
            pillarOffset = Random.Range(-spawnBoundary.offset, spawnBoundary.offset);

            spawnPoint = new Vector3(pillarNumber + pillarOffset, Player.position.y + 16, 0);

            FallingHazard = (GameObject)Instantiate(FallingHazardPrefab, spawnPoint, Quaternion.Euler(0,0,0));
			FallingHazard.SetActive (true);

            yield return new WaitForSeconds(waitTime);
        }
        
    }

    float RandomSpawnPosition()
    {


        return 1;
    }

        

}
