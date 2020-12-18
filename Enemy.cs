using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;  // jugador al que seguir
    public GameObject dieprefab;  // animacion de muerte
    public Rigidbody2D rb;  // detectar colisiones
    public int facing;  // direccion a la que esta mirando
    float oldPosition = 0.0f;
    public float speed = 0.015f;
    public SpriteRenderer spriteRenderer;
	public Sprite newSpriteCover;
	public Sprite newSpriteAttack;
	int awaken = 0;  // si esta activo
	int awakening = 0;
	float start_op = 0.0f;
    private GameObject instantiatedObj;
    void Start()
    {
        oldPosition = transform.position.x;
        spriteRenderer.color = new Color(1f,1f,1f,start_op);
    }

    // Update is called once per frame
    void Update()
    {
    	float distX = (player.transform.position.x - transform.position.x);
        float distY = (player.transform.position.y - transform.position.y);
    	Ball f = player.GetComponent<Ball>();
    	// Debug.Log(f.facing + " " + facing);
    	if (Mathf.Abs(distX) < 2 && Mathf.Abs(distY) < 2 && awaken == 0){  // si esta dormido y el jugador pasa cerca se despierta
    		awaken = 1;
    		// aparece por detras del jugador
        	transform.position = new Vector3(player.transform.position.x + 1.3f*f.facing*(-1), player.transform.position.y + distY*speed, transform.position.z);
    		facing = f.facing;
    		//transform.position.x = player.transform.position.x + 2;  
    	}
    	if (awaken == 1 && awakening < 100){
    		start_op += 0.03f;
    		// mostrar efecto de aparecer gradualmente
    		spriteRenderer.color = new Color(1f,1f,1f, start_op);
    		awakening += 1;
    	}
    	if (awaken == 1){
    		//Debug.Log(f.facing +  " - " + facing);
    		if (f.facing == facing){
    			// si el jugador le da la espalda cambia a la animacion de ataque y se mueve hacia el jugador
    			ChangeSpriteAttack();
        		transform.position = new Vector3(transform.position.x + distX*speed, transform.position.y + distY*speed, transform.position.z);
        	}
        	else{
        		// si el jugador lo esta mirando entonces cambia la animacion a cubrirse y no se mueve
        		ChangeSpriteCover();
        	}
        	if (transform.position.x > oldPosition) {
            	transform.localRotation = Quaternion.Euler(0, 0, 0);
             	// facing = 1;
         	} 
         	if (transform.position.x < oldPosition){
            	transform.localRotation = Quaternion.Euler(0, 180, 0);
            	// facing = 0;
         	}
         	oldPosition = transform.position.x;
         	if (player.transform.position.x > transform.position.x){
         		facing = 1;
         	}
         	else{
         		facing = -1;
         	}
     	}
    }

    public void Die(int animation){
    	int delay = 180;
    	Destroy(gameObject);
    	Handheld.Vibrate();  // vibrar al morir
    	if (animation == 1){
    		instantiatedObj = (GameObject) Instantiate(dieprefab, transform.position, transform.rotation);
    		Destroy(instantiatedObj, 1.5f);
    	}
    }
    void OnTriggerEnter2D(Collider2D hitInfo){
    	if (hitInfo.name == "g1"){
			Die(0);
    		Ball pl = player.GetComponent<Ball>();
    		pl.Damage();
    	} 

    }
    void ChangeSpriteCover()
    {
        spriteRenderer.sprite = newSpriteCover; 
    }
    void ChangeSpriteAttack()
    {
        spriteRenderer.sprite = newSpriteAttack; 
    }

}
