using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : MonoBehaviour
{
	public GameObject completeLevelUi;
    void Awake()
    {

    }

    void FixedUpdate()
    {

    }

    // called when this GameObject collides with GameObject2.
    void OnTriggerEnter2D(Collider2D col)
    {
        // Debug.Log("GameObject1 collided with " + col.name);
        if (col.name == "g1"){
        	completeLevelUi.SetActive(true); 
        }
    }
}
