using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firepoint;  // punto de donde salen los proyectiles
    public GameObject bulletprefab;  // objeto proyectil
    public int bullet_cooldown = 0;
    // Update is called once per frame
    void Update()
    {
    	if (bullet_cooldown > 0){
        	bullet_cooldown -= 1;
        }
        if (Input.touchCount > 0 && bullet_cooldown == 0){  // esperar cierto tiempo antes de poder disparar nuevamente
        	Vector2 touchPos = Input.touches[0].position;
        	if (touchPos.x > 400 && touchPos.y < 700){  // si se presiona el boton
        		Shoot();
        	}
        	bullet_cooldown = 40;
        }
        if (Input.GetKey(KeyCode.DownArrow) && bullet_cooldown == 0){
        	Shoot();
        	bullet_cooldown = 40;
        }
    }
    void Shoot(){
    	Instantiate(bulletprefab, firepoint.position, firepoint.rotation);  // crear un obj proyectil  desde la posicion firepoint
    }
}
