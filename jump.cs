using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jump : MonoBehaviour
{
	public GameObject player;
	public Text m_Text;
	int up_cooldown = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	if (up_cooldown > 0){
        	up_cooldown -= 1;
        }
        // m_Text.text = "" + up_cooldown;
    	if (Input.touchCount > 0){
        	Vector2 touchPos = Input.touches[0].position;
        	// m_Text.text = "" + touchPos.x + " , " + touchPos.y;
        	if (up_cooldown == 0 && touchPos.x < 300 && touchPos.y < 400){  // si se presiona el boton de saltar
        		Ball pl = player.GetComponent<Ball>();
        		pl.rb.velocity = pl.rb.velocity + Vector2.up * 6.0f; 
           		up_cooldown = 70;  // esperar cierto tiempo antes de poder volver a saltar
        	}
        }
        
    }
}
