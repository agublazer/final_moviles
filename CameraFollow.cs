using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform player;
	public Vector3 offset;
    void Start()
    {
        
    }
  	void Update () 
  	{
  		// seguir al jugador
    	transform.position = new Vector3 (player.position.x + offset.x, player.position.y + offset.y, transform.position.z); // Camera follows the player with specified offset position
  	}
}
 