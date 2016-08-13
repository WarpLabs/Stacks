using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class CollisionControl : MonoBehaviour {

    public Color onTopCollisionColor;
    public Color onSideCollisionColor;
    public float riseSpeed;
    public float fallSpeed;
    public List<Collision> collisions = new List<Collision>();


    private int topContact = 0;
    private Transform tr;


    //void Update()
    //{
    //    Debug.Log(topContact);
    //    Debug.Log("number of collisions =" + collisions.Count);
    //}

    void Start()
    {
        tr = GetComponent<Transform>();
    }

    void OnCollisionEnter(Collision other)
    {
        collisions.Add(other);

        if (other.gameObject.CompareTag("Top") || other.gameObject.CompareTag("HazardTop"))
        {
            topContact += 1;
        }

        if (other.gameObject.CompareTag("Hazard"))
        {
            Destroy(tr.gameObject);
            Destroy(other.gameObject.transform.parent.gameObject);
            SceneManager.LoadScene(0);
        }

    }



    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Top") && topContact == 1)
        {
            Move(Vector3.up, riseSpeed, other);
            ColorChanger(other, onTopCollisionColor);
        }

        if (other.gameObject.CompareTag("Side") && collisions.Count == 1)
        {
            Move(Vector3.down, fallSpeed, other);
            ColorChanger(other, onSideCollisionColor);
        }

        if (other.gameObject.CompareTag("HazardTop") && topContact == 1)
        {
            Move(Vector3.up, riseSpeed, other);
            ColorChanger(other, onTopCollisionColor);
        }

        if (other.gameObject.CompareTag("HazardSide"))
        {
            Move(Vector3.down, fallSpeed, other);
            ColorChanger(other, onSideCollisionColor);
        }
    }



    void OnCollisionExit(Collision other)
    {
        collisions.Remove(collisions[0]);

        if (other.gameObject.CompareTag("Top") || other.gameObject.CompareTag("HazardTop"))
        {
            ColorChanger(other, Color.white);
            topContact -= 1;
        }

        if (other.gameObject.CompareTag("Side") || other.gameObject.CompareTag("HazardSide"))
        {
            ColorChanger(other, Color.white);
        }
    }


    void ColorChanger(Collision other, Color targetColor)
    {
        if (other.gameObject.CompareTag("Top") || other.gameObject.CompareTag("Side"))
        {
            foreach (Renderer r in other.gameObject.transform.parent.GetComponentsInChildren<Renderer>())
            {
                r.material.SetColor("_Color", targetColor);
            }
        }

        if (other.gameObject.CompareTag("HazardTop") || other.gameObject.CompareTag("HazardSide"))
        {
            foreach (Renderer r in other.gameObject.transform.parent.parent.GetComponentsInChildren<Renderer>())
            {
                r.material.SetColor("_Color", targetColor);
            }
        }
    }


    void Move(Vector3 direction, float speed, Collision collision)
    {
        if (collision.gameObject.CompareTag("Top") || collision.gameObject.CompareTag("Side"))
        {
            collision.gameObject.transform.parent.position += direction * speed * Time.deltaTime;
            tr.position += direction * speed * Time.deltaTime;
        }

        if (collision.gameObject.CompareTag("HazardTop") || collision.gameObject.CompareTag("HazardSide"))
        {
            collision.gameObject.transform.parent.parent.position += direction * speed * Time.deltaTime;
            tr.position += direction * speed * Time.deltaTime;
        }
    }


}
