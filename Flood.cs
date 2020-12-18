using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flood : MonoBehaviour
{
    int counter = 0;
    public Transform player;  // detectar posicion del jugador
    public GameObject gameOverUi;
    public float speed = 0.001f;
    void Start()
    {
        speed = 0.001f;
    }

    // Update is called once per frame
    void Update()
    {
    	if (counter < 10000){
    		// mover inundacion hacia arria}ba
			transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
			counter += 1;
    	}
    	// Debug.Log(player.position.y + " - " + transform.position.y);
    	if (player.position.y < (transform.position.y + 6.5)){
			gameOverUi.SetActive(true);  // si choca con el jugador entonces se activa la pantalla de perder
    	}
    }
}
