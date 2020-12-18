using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    public int delay = 180;
    void Start()
    {
        rb.velocity = transform.right * speed;  // moverse hacia la direccion apuntada
    }
    void Update(){
    	if (delay == 0){
    		Destroy(gameObject);  // destruir el obj despues de cierto tiempo
    	}
    	delay -= 1;
    }

    void OnTriggerEnter2D(Collider2D hitInfo){
    	Debug.Log(hitInfo.name);
    	Enemy enemy = hitInfo.GetComponent<Enemy>();  // si colisiona con un enemigo
    	if (enemy != null){
    		enemy.Die(1);  // destruir enemigo
    	}
    	// Destroy(gameObject);
    }


}
