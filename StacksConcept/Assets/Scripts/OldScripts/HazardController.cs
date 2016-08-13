using UnityEngine;
using System.Collections;

public class HazardController : MonoBehaviour {

    private Transform tr;
    public float fallSpeed = 5;
    public GameObject LandedHazardPrefab;
    private GameObject landedHazardClone;


    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // pool things! versions of hazards

    void FixedUpdate()
    {

        tr.position += Vector3.down * fallSpeed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pillar"))
        {
            Destroy(gameObject);
            landedHazardClone = (GameObject)Instantiate(LandedHazardPrefab, tr.position, tr.rotation);
            landedHazardClone.transform.parent = other.gameObject.transform;          
        }

        if (other.gameObject.CompareTag("HazardPillar"))
        {
            Destroy(gameObject);
            landedHazardClone = (GameObject)Instantiate(LandedHazardPrefab, tr.position, tr.rotation);
            landedHazardClone.transform.parent = other.gameObject.transform.parent;
        }


    }

}
