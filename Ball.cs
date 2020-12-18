using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour
{
	int up_cooldown = 0;
	float oldPosition = 0.0f;
	float dirX;
	public int facing = 1;  // direccion de apuntado
	public Rigidbody2D rb;  // colisiones
    public GameObject gameOverUi;  // pantalla que se muestra cuando se pierden las 3 vidas
	public int lives = 3;  // num vidas
	public GameObject lifeprefab; // animacion de perder vida
	public Transform lifepoint;  // punto de origen de animacion
	private GameObject instantiatedObj;
    void Start()
    {
    	int lives = 3;
    	oldPosition = transform.position.x;
    }

    void Update()
    {
    	Debug.Log(lives);
        // GetComponent<Rigidbody2D>().drag = 0.0f;
        if (up_cooldown > 0){
        	up_cooldown -= 1;
        } 
        dirX = Input.acceleration.x * 0.1f;  // moverse usando acelerometro
        transform.position = new Vector3(transform.position.x + dirX, transform.position.y, transform.position.z);
        
        if (Input.GetKey(KeyCode.RightArrow))  // moverse usando teclas (para testing)
        {
        	// transform.localRotation = Quaternion.Euler(0, 0, 0);
            transform.position = new Vector3(transform.position.x + 0.05f, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
        	// transform.localRotation = Quaternion.Euler(0, 180, 0);
            transform.position = new Vector3(transform.position.x - 0.05f, transform.position.y, transform.position.z);
        }
        /*if (Input.touchCount > 0){
        	Touch touch =  Input.GetTouch(0);
            // transform.position = new Vector3(transform.position.x - 0.05f, transform.position.y, transform.position.z);
        	// if (touch.position.y < 0){
        		if (up_cooldown == 0){
        			GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity + Vector2.up * 2.5f; 
           			up_cooldown = 70;
        		}
        		//if (touch.position.x < 0 ){
        		//	GetComponent<Rigidbody2D>().drag += 0.7f; 
        		//}
        	 // }
        }
        */
        if (Input.GetKey(KeyCode.UpArrow) && up_cooldown == 0)  // saltar usando teclas (para testing)
        {
           	GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity + Vector2.up * 6.0f; 
           	up_cooldown = 115;
        }


        if (transform.position.x > oldPosition) // he's looking right
         {
             transform.localRotation = Quaternion.Euler(0, 0, 0);
             facing = 1;
         }
 
         if (transform.position.x < oldPosition) // he's looking left
         {
             transform.localRotation = Quaternion.Euler(0, 180, 0);
             facing = -1;
         }
         oldPosition = transform.position.x;
    	if (lives <= 0){
    		// si se acaban las vidas mostrar pantalla de perder
    		gameOverUi.SetActive(true); 
    	}
    }
    public void Damage(){
    	// al recibir daño se muestra la animacion de perder vida
    	instantiatedObj = (GameObject) Instantiate(lifeprefab, lifepoint.position, lifepoint.rotation);
    	Destroy(instantiatedObj, 1.3f);
    	// se reduce el numero de vidas en 1
    	lives-= 1;
    }
}
