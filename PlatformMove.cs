using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    // Start is called before the first frame update
    int counter = 0;
    int direction = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	if (counter < 180){
    		// mover la plataforma hacia la derecha
        	transform.position = new Vector3(transform.position.x + direction*0.015f, transform.position.y, transform.position.z);
        	counter += 1;
    	}
    	else{
    		// mover la plataforma hacia la izquierda
    		direction *= -1;
    		counter = 0;
    	}
    }
}
