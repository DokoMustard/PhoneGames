using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{

    static Color[] Colors = new Color[] { Color.red, Color.blue, Color.green, Color.black, Color.cyan };



    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Cube" || other.gameObject.tag == "Sphere" || other.gameObject.tag == "Cylinder" || other.gameObject.tag == "Capsule")
        {
            Debug.Log(other.gameObject.name + " collides with " + name);
            gameObject.tag = "Floor";
            other.gameObject.GetComponent<MeshRenderer>().material.color = Colors[Random.Range(0, Colors.Length - 1)];
        }
    }

}
