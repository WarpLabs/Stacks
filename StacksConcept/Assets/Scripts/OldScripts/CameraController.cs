using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public Transform Player;
    private Transform Camera;

    void Start()
    {
        Camera = GetComponent<Transform>();
    }


    void Update()

    {
        if (Player != null)
        {
            Camera.position = new Vector3(Camera.position.x, Player.position.y + 6, Camera.position.z); 
        }

         


    }
}

